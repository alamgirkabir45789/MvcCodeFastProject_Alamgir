using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MvcCodeFastProject_Alamgir.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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
            : base("DbCon", throwIfV1Schema: false)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HEmployee> HEmployees { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<InternDoctor> InternDoctors { get; set; }
        public DbSet<LabExam> LabExams { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Nurse> Nurses{ get; set; }
        public DbSet<OrderMaster> OrderMasters{ get; set; }
        public DbSet<OrderDetail> OrderDetails{ get; set; }
        public DbSet<MedicineCategory> MedicineCategories{ get; set; }
        public DbSet<MedicineItem> MedicineItems{ get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}