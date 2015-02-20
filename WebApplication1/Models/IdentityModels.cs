using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JJTrailerStore.Models
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

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.WeightClass> WeightClasses { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.TaxClass> TaxClasses { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.Shop> Shops { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.Tax> Taxes { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.Category> Categories { get; set; }


        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.ImageManager> ImageManagers { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.Manufacturer> Manufacturers { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.DimensionClass> DimensionClasses { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.OutOfStockStatus> OutOfStockStatus { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.PaymentMethod> PaymentMethods { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.Payment> Payments { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.Shipping> Shippings { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.ShippingMethod> ShippingMethods { get; set; }

        public System.Data.Entity.DbSet<JJTrailerStore.Areas.Admin.Models.CategoryImage> CategoryImages { get; set; }
    }
}