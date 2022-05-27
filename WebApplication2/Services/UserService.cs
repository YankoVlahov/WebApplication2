using masterLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication2.Models;
using WebApplication2.Models.Config;
using System.Linq;

namespace WebApplication2.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IOptions<JwtSetting> _options;
        private readonly masterthesisContext dbContext;
        
        public UserService(IHttpContextAccessor httpContext, IOptions<JwtSetting> options, masterthesisContext _dbContext)
        {
            _httpContext = httpContext;
            dbContext = _dbContext;
            _options = options;
            
        }
        public string CreateJwt(UserRequest user)
        {
            var secret = this._options.Value.Secret;
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddDays(1),
                Subject = new ClaimsIdentity(new Claim[]
                   {
                       new Claim("Name", user.Name)
                   }),
                SigningCredentials = new SigningCredentials(
                       new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                       )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
        public async Task<IdentitySqlUser?> GetUser(UserRequest userRequest)
        {
            if (userRequest.Name == null || userRequest.Password == null)
            {
                // return NotFound();
                
                return null;
            }
            else
            {
                string OutPass = Cipher.EncryptString(userRequest.Password);
                var identitySqlUser = await dbContext.IdentitySqlUsers.Where(x => x.Name == userRequest.Name).FirstOrDefaultAsync();
                
                return identitySqlUser;
                    
            }


        }

        public async Task<ActionResult<IdentitySqlUser>> Adduser(UserRequest userRequest)
        {
            if (userRequest.Name == null || userRequest.Password == null)
            {
                return null;

            }
            else
            {
                string NewName = userRequest.Name;
                var checkName =await this.dbContext.IdentitySqlUsers.Where(x => x.Name == NewName).ToListAsync();
                if (checkName != null)
                {
                    return null;
                }
                else
                {
                    string inPass = Cipher.EncryptString(userRequest.Password);
                    var inserdata = new IdentitySqlUser { Name = userRequest.Name, Password = inPass, RowIn = DateTime.Now, RowUp = DateTime.Now, ValidTo = DateTime.MinValue };
                    await dbContext.IdentitySqlUsers.AddAsync(inserdata);
                    await dbContext.SaveChangesAsync();
                    return inserdata;
                }
                

                

            }
        }

    }
}
