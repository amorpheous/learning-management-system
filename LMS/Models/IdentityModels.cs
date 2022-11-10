using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using LMS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string NickName { get; set; }
      //  public string Email { get; set; }
        public bool? IsActive { get; set; }
        public string AdditionalInfo { get; set; }
        public string SpecialInfo { get; set; }

        public virtual Course Course_ { get; set; }

        //fundera på det här
       // public virtual Roles Role_ { get; set; }




        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {


        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<LMS.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<LMS.Models.Module> Modules { get; set; }

        public System.Data.Entity.DbSet<LMS.Models.Activity> Activities { get; set; }

        public System.Data.Entity.DbSet<LMS.Models.ActivityType> ActivityTypes { get; set; }
    }
}