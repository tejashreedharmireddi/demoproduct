using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepo _repo;
        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("{ProdId}")]
        public IActionResult GetProduct(int ProdId)
        {
            
            var prod= _repo.DisplayProducts(ProdId);
            if (prod != null)
            {
                return Ok(prod);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            var prod = _repo.GetAll();
            if (prod != null)
            {
                return Ok(prod);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
