using API.DbContexts;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class ProductRepository : IRepositoryProduct
    {
        private readonly ProductContext db;

        public ProductRepository(ProductContext productContext)
        {
            db = productContext;
        }

        public void DeleteProduct(int id)
        {
            Product product = GetProductById(id);
            db.Entry(product).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return db.Products.SingleOrDefault(p => p.Id == id);
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
