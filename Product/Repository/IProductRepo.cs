using ProductService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public interface IProductRepo
    {
        public Product DisplayProducts(int ProdId);
        public List<Product> GetAll();
      
    }
}
