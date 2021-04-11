using Newtonsoft.Json;
using ProductService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public class ProductRepo: IProductRepo
    {
        private readonly ProductDbContext _db;
        public static List<Product> prod = new List<Product>();
        Product finalproduct = null;
        public ProductRepo(ProductDbContext db)
        {
            _db = db;
        }
        public List<Product> GetAll()
        {
            prod = _db.Product.ToList();
            return prod;
        }
        public Product DisplayProducts(int ProdId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44364");
            client.DefaultRequestHeaders.Accept.Clear();



            var contentType = new MediaTypeWithQualityHeaderValue("application/json");



            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = client.GetAsync("/api/Vendor/SearchProduct/" + ProdId).Result;



            string apiResponse = response.Content.ReadAsStringAsync().Result;
            if (apiResponse != null)
            {
                finalproduct = _db.Product.FirstOrDefault(x => x.ProdId == ProdId);
            }
            return finalproduct;


        }
    }
}
