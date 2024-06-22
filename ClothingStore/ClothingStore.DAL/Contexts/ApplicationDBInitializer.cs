using ClothingStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Contexts
{
    public static class ApplicationDBInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                            new Category { Id = 1, Name = "Áo" },
                            new Category { Id = 2, Name = "Quần" },
                            new Category { Id = 3, Name = "Giày" },
                            new Category { Id = 4, Name = "Phụ kiện" }
                );
            modelBuilder.Entity<Product>().HasData(
                            new Product { Id = 1, Name = "Áo thun nam", CategoryId = 1, Price = 100000, Quantity = 100, Description = "Áo thun nam", Image = ""},
                            new Product { Id = 2, Name = "Áo thun nữ", CategoryId = 1, Price = 90000, Quantity = 100, Description = "Áo thun nữ", Image = "" },
                            new Product { Id = 3, Name = "Quần jean nam", CategoryId = 2, Price = 200000, Quantity = 100, Description = "Quần jean nam", Image = "" },
                            new Product { Id = 4, Name = "Quần jean nữ", CategoryId = 2, Price = 180000, Quantity = 100 , Description = "Quần jean nữ", Image = "" },
                            new Product { Id = 5, Name = "Giày thể thao nam", CategoryId = 3, Price = 300000, Quantity = 100, Description = "Giày thể thao nam", Image = "" },
                            new Product { Id = 6, Name = "Giày thể thao nữ", CategoryId = 3, Price = 280000, Quantity = 100, Description = "Giày thể thao nữ", Image = "" }
                            
                );
            modelBuilder.Entity<Account>().HasData(
                            new Account { Id = 1, Username = "admin", Password = "admin", PhoneNumber = "0388188526", Email = "realvietdung@gmail.com" });
        }
    }
}
