using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class masterthesisContext : DbContext
    {
        public masterthesisContext()
        {
        }

        public masterthesisContext(DbContextOptions<masterthesisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IdentitySqlClass> IdentitySqlClasses { get; set; } = null!;
        public virtual DbSet<IdentitySqlDepartment> IdentitySqlDepartments { get; set; } = null!;
        public virtual DbSet<IdentitySqlPermission> IdentitySqlPermissions { get; set; } = null!;
        public virtual DbSet<IdentitySqlPersonal> IdentitySqlPersonals { get; set; } = null!;
        public virtual DbSet<IdentitySqlTicket> IdentitySqlTickets { get; set; } = null!;
        public virtual DbSet<IdentitySqlUser> IdentitySqlUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<IdentitySqlClass>(entity =>
            {
                entity.ToTable("identity_sql_class");

                entity.HasIndex(e => e.Id, "id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasPrecision(2)
                    .HasColumnName("code");

                entity.Property(e => e.Delind)
                    .HasPrecision(1)
                    .HasColumnName("delind");

                entity.Property(e => e.MaxForDay)
                    .HasPrecision(2)
                    .HasColumnName("maxForDay");

                entity.Property(e => e.MaxForMonth)
                    .HasPrecision(2)
                    .HasColumnName("maxForMonth");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.Note)
                    .HasMaxLength(250)
                    .HasColumnName("note");

                entity.Property(e => e.RowIn)
                    .HasColumnType("datetime")
                    .HasColumnName("row_in");

                entity.Property(e => e.RowUpdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("row_update")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<IdentitySqlDepartment>(entity =>
            {
                entity.ToTable("identity_sql_departments");

                entity.HasIndex(e => e.Code, "code");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasColumnType("int(11)")
                    .HasColumnName("code");

                entity.Property(e => e.Delind)
                    .HasPrecision(1)
                    .HasColumnName("delind");

                entity.Property(e => e.ManagerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("manager_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.RowIn)
                    .HasColumnType("datetime")
                    .HasColumnName("row_in");

                entity.Property(e => e.RowUpdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("row_update")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<IdentitySqlPermission>(entity =>
            {
                entity.ToTable("identity_sql_permissions");

                entity.HasIndex(e => e.Type, "type");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Excel).HasPrecision(1);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.ReadOnly).HasPrecision(1);

                entity.Property(e => e.RowIn)
                    .HasColumnType("datetime")
                    .HasColumnName("row_in");

                entity.Property(e => e.RowUpdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("row_update")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ToGiveStatus).HasPrecision(1);

                entity.Property(e => e.ToRegTicket).HasPrecision(1);

                entity.Property(e => e.ToRegUser).HasPrecision(1);

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<IdentitySqlPersonal>(entity =>
            {
                entity.ToTable("identity_sql_personal");

                entity.HasIndex(e => e.DepId, "dep_id")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "id1");

                entity.HasIndex(e => e.PositionType, "position_type");

                entity.HasIndex(e => e.Userid, "userid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DepId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Dep_id");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.Incompany).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PositionType)
                    .HasColumnType("int(11)")
                    .HasColumnName("Position_Type");

                entity.Property(e => e.RowIn)
                    .HasColumnType("datetime")
                    .HasColumnName("row_in");

                entity.Property(e => e.RowUpdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("row_update")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.SecondName).HasMaxLength(100);

                entity.Property(e => e.Userid)
                    .HasColumnType("int(11)")
                    .HasColumnName("userid");

                entity.Property(e => e.WorkTimeFrom).HasColumnType("time");

                entity.Property(e => e.WorkTimeTo).HasColumnType("time");

                entity.HasOne(d => d.Dep)
                    .WithOne(p => p.IdentitySqlPersonal)
                    .HasForeignKey<IdentitySqlPersonal>(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sql_personal_ibfk_4");

                entity.HasOne(d => d.PositionTypeNavigation)
                    .WithMany(p => p.IdentitySqlPersonals)
                    .HasForeignKey(d => d.PositionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sql_personal_ibfk_3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IdentitySqlPersonals)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sql_personal_ibfk_2");
            });

            modelBuilder.Entity<IdentitySqlTicket>(entity =>
            {
                entity.ToTable("identity_sql_tickets");

                entity.HasIndex(e => e.ClassId, "classid")
                    .IsUnique();

                entity.HasIndex(e => e.FromUser, "fromuser");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnType("int(11)");

                entity.Property(e => e.DocId).HasColumnType("int(11)");

                entity.Property(e => e.FromUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("fromUser");

                entity.Property(e => e.Note)
                    .HasMaxLength(250)
                    .HasColumnName("note");

                entity.Property(e => e.RowIn)
                    .HasColumnType("datetime")
                    .HasColumnName("row_in");

                entity.Property(e => e.RowUpdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("row_update")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.ToUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("toUser");

                entity.HasOne(d => d.Class)
                    .WithOne(p => p.IdentitySqlTicket)
                    .HasForeignKey<IdentitySqlTicket>(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sql_tickets_ibfk_2");

                entity.HasOne(d => d.FromUserNavigation)
                    .WithMany(p => p.IdentitySqlTickets)
                    .HasForeignKey(d => d.FromUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sql_tickets_ibfk_1");
            });

            modelBuilder.Entity<IdentitySqlUser>(entity =>
            {
                entity.ToTable("identity_sql_user");

                entity.HasIndex(e => e.Id, "id2");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Admin).HasColumnType("int(1)");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .HasColumnName("password")
                    .IsFixedLength();

                entity.Property(e => e.RowIn)
                    .HasColumnType("datetime")
                    .HasColumnName("row_in");

                entity.Property(e => e.RowUp)
                    .HasColumnType("timestamp")
                    .HasColumnName("row_up")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("validTo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
