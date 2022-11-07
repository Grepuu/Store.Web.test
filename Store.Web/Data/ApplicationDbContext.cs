using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Web.Models.Entities;

namespace Store.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<SectionEntity> Sections { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<SectionEntity>()
                .HasMany(n => n.Products)
                .WithOne(n => n.Section)
                .HasForeignKey(n => n.SectionId)
                .OnDelete(DeleteBehavior.Cascade); 


            builder.Entity<ProductEntity>()
                .HasMany(n => n.Ingredients)
                .WithOne(n => n.Product)
                .HasForeignKey(n => n.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }


    }
}