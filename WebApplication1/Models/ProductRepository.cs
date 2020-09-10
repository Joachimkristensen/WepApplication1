using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = _db.Products;
            return _db.Products;
        }

        public void Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
