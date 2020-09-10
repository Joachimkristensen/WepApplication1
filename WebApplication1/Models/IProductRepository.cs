using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        public void Save(Product product);
    }
}
