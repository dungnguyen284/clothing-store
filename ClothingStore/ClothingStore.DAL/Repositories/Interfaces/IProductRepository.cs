using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
        public Product GetProductByName(string name);
        public List<Product> GetProductsByCategory(int categoryId);

    }
}
