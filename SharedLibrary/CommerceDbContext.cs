using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SharedLibrary
{
    public class CommerceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CommerceDbContext(DbContextOptions<CommerceDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products);

            base.OnModelCreating(modelBuilder);

            //Some seed datas

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Giyim" },
                new Category { Id = 2, Name = "Elektronik" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Tişört", Price = 50, CategoryId = 1 },
                new Product { Id = 2, Name = "Şort", Price = 40, CategoryId = 1 },
                new Product { Id = 3, Name = "Kulaklık", Price = 150, CategoryId = 2 },
                new Product { Id = 4, Name = "Laptop", Price = 3000, CategoryId = 2 }
            );
        }
    }
}
