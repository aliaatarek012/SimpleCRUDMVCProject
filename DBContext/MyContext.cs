using ITIFinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIFinalProject.DBContext
{
    public class MyContext : DbContext
    {


        /*---------------------------------------------*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Verstion3;Trusted_Connection=True;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var _Categories = new List<Category>
            {

            new Category{CategoryId = 1 , Name = "Programming" },
            new Category{CategoryId = 2 , Name = "Mathematics" },
            new Category{CategoryId = 3 , Name = "Literature" },
            new Category{CategoryId = 4 , Name = "philosophy" }

            };


            var Products = new List<Product>
            {

                new Product { ProductId = 1, Title = "", Price = 300, Description = "", Quantity = 10, ImagePath = "", CategoryId = 1 },
                new Product { ProductId = 2, Title = "", Price = 400, Description = "", Quantity = 5, ImagePath = "", CategoryId = 2 },
                new Product { ProductId = 3, Title = "", Price = 200, Description = "", Quantity = 5, ImagePath = "", CategoryId = 3 },
                new Product { ProductId = 4, Title = "Why We Sleep", Price = 400, Description = "", Quantity = 5, ImagePath = "", CategoryId = 4 }

            };


            var Users = new List<User>
            {

            };


            /*---------------------------------------------*/
            modelBuilder.Entity<Category>().HasData(_Categories);
            modelBuilder.Entity<Product>().HasData(Products);
            modelBuilder.Entity<Product>().HasData(Users);
            /*---------------------------------------------*/

        }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<User> User { get; set; }

    }
}

