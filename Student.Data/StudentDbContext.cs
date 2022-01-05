using Microsoft.AspNet.Identity.EntityFramework;
using Student.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Data
{
    public class StudentDbContext : IdentityDbContext<IdentityUser>
    {
        public StudentDbContext() : base("Data Source = DESKTOP-QH55T4E; Initial Catalog = StudentManagement; Integrated Security = False; User Id = nhan; Password=123456;MultipleActiveResultSets=True")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<StudentInformation> StudentInformation { set; get; }

        public DbSet<Error> Error { set; get; }

        public static StudentDbContext Create()
        {
            return new StudentDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");

        }
    }
}
