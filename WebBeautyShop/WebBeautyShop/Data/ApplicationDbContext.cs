using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebBeautyShop.Domain;
using WebBeautyShop.Models.Product;
using WebBeautyShop.Models.Order;
using WebBeautyShop.Models.Client;

namespace WebBeautyShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
   
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<WebBeautyShop.Models.Product.ProductCreateVM> ProductCreateVM { get; set; }
        public DbSet<WebBeautyShop.Models.Product.ProductIndexVM> ProductIndexVM { get; set; }
        public DbSet<WebBeautyShop.Models.Product.ProductEditVM> ProductEditVM { get; set; }
        public DbSet<WebBeautyShop.Models.Product.ProductDetailsVM> ProductDetailsVM { get; set; }
        public DbSet<WebBeautyShop.Models.Product.ProductDeleteVM> ProductDeleteVM { get; set; }
        public DbSet<WebBeautyShop.Models.Order.OrderConfirmVM> OrderConfirmVM { get; set; }
        public DbSet<WebBeautyShop.Models.Order.OrderIndexVM> OrderIndexVM { get; set; }
        public DbSet<WebBeautyShop.Models.Client.ClientIndexVM> ClientIndexVM { get; set; }
        public DbSet<WebBeautyShop.Models.Client.ClientDeleteVM> ClientDeleteVM { get; set; }
    }
}
