using System.Collections;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Netwerk.Models
    {
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
        {
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

        public System.Data.Entity.DbSet<Netwerk.Models.Patient> Patients { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.IntakeCenter> IntakeCenters { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.Gender> Genders { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.Country> Countries { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.MocType> MocTypes { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.ListMbv> ListMbvs { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.ListTnm> ListTnms { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.ListFs> ListFss { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.ListPs> ListPss { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.ListHs> ListHses { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.Ecog> Ecogs { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.IntakeDoctor> IntakeDoctors { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.NetworkDoctor> NetworkDoctors { get; set; }
        public System.Data.Entity.DbSet<Netwerk.Models.InitialProblem> InitialProblems { get; set; }
        

        }
    }
