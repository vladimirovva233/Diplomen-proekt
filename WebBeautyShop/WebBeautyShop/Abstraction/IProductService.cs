﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBeautyShop.Domain;

namespace WebBeautyShop.Abstraction
{
    public interface IProductService
    {
        bool Create(string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount);
        bool Update(int productId, string name, int brandId, int categiryId, string picture, int quantity, decimal price, decimal discount);
        List<Product> GetProducts();
        Product GetProductById(int productId);
        bool RemoveById(int productId);
        List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName);
    }
}
