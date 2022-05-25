using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.Config
{
    public class JwtSetting
    {
        public string Secret { get; set; }

        public string AllowedIPAddresses { get; set; }
    }
}
