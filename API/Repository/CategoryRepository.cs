using API.DbContexts;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class CategoryRepository : IRepositoryCategory
    {
        private readonly ProductContext db;

        public CategoryRepository(ProductContext productContext)
        {
            db = productContext;
        }

        public void DeleteCategory(int id)
        {
            Category category = GetCategoryById(id);
            db.Entry(category).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.SingleOrDefault(c => c.Id == id);
        }

        public void InsertCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
