using ExamEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Image> Images { get; set; }
        #endregion

        #region fluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //category-product
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.CategoryId);

            //product-image
            modelBuilder.Entity<ProductImage>()
            .HasKey(t => new { t.ProductId, t.ImageId });
            modelBuilder.Entity<ProductImage>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pt => pt.ProductId);
            modelBuilder.Entity<ProductImage>()
                .HasOne(pt => pt.Image)
                .WithMany(t => t.ProductImages)
                .HasForeignKey(pt => pt.ImageId);
            base.OnModelCreating(modelBuilder);

        }
        #endregion
    }
}
