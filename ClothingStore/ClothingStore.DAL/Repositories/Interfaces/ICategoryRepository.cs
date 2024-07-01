using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task AddCategoryAsync(Category category);
        public Task UpdateCategoryAsync(Category category);
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<Category> GetCategoryByNameAsync(string name);
        public Task<List<Category>> GetAllCategoriesAsync();
        public Task DeleteCategoryAsync(Category category);

    }
}
