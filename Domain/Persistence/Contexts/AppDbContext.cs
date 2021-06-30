using System;
using Microsoft.EntityFrameworkCore;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Extensions;


namespace PosiPrice.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        //N-N
        //public DbSet<ProductUser> ProductsUsers { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //1 Category Entity
            builder.Entity<Category>().ToTable("Categories");
            //1 Constraints
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);


            //1 RelationShips
            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            //1 Initial Data

            builder.Entity<Category>().HasData
                (
                    new Category
                    {
                        Id = 1,
                        Name = "Procesadores"

                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Tarjetas Graficas"
                    }



               ) ;
            
            //2 Product Entity
            builder.Entity<Product>().ToTable("Products");
            //2 Constraints
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.Minimum_users).IsRequired();
            builder.Entity<Product>().Property(p => p.Price).IsRequired();
            builder.Entity<Product>().Property(p => p.Description).IsRequired();
            //2 RelationShips


            //2 Initial Data
            builder.Entity<Product>().HasData
                (
                    //  Id 
                    // Name
                    ////Price 
                    // Minimum_users
                    // Description

                    new Product
                    {
                        Id = 1,
                        Name = "Nvidia 3070 TI",
                        Price = 1230,
                        Minimum_users = 3,
                        Description = "The best RTX",
                        CategoryId = 2,
                        UserId = 2
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Ryzen 3800X",
                        Price = 400,
                        Minimum_users = 3,
                        Description = "The best Ryzen Zen 3",
                        CategoryId = 1,
                        UserId = 1
                    }
                ); ; 

         // 4 Product---Entity
/*
           //posible error
            builder.Entity<Product>().ToTable("ProductsUsers");

            // 4  Product---Constraints
            builder.Entity<ProductUser>().HasKey(p => new { p.ProductId, p.UserId });
            //4 --- RelationShip
             /// N N
            builder.Entity<ProductUser>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductUsers)
                .HasForeignKey(pt => pt.ProductId);
            //
            builder.Entity<ProductUser>()
                .HasOne(pt => pt.User)
                .WithMany(t => t.ProductUsers)
                .HasForeignKey(pt => pt.UserId);
            //4 Initial Data
         
  */          

            
          
            //6
            //6 User Entity
            builder.Entity<User>().ToTable("Users");
            //6 Constraints
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Address).IsRequired();
            builder.Entity<User>().Property(p => p.emailAddress).IsRequired();
            builder.Entity<User>().Property(p => p.PhoneNumber).IsRequired();


            //6 RelationShips


            //6 Initial Data
             builder.Entity<User>().HasData
                 (
                     new User
                     {
                         Id = 1,
                         Name = "Juan",
                         Address = "San Miguel",
                         emailAddress = "Juan@hotmail.com",
                         PhoneNumber=12345
                     },
                     new User
                     {
                         Id = 2,
                         Name = "Roberto",
                         Address = "San Isidrio",
                         emailAddress = "Roberto@hotmail.com",
                         PhoneNumber = 23457
                     }
                 );
            //
            builder.ApplySnakeCaseNamingConvention();
        }
    }    
}