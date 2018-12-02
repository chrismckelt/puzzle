using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Puzzle.Domain.Products;

namespace Puzzle.Controllers
{
    [Route("api/[controller]")]
    public class ProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Product> List()
        {
            return _productService.GetProducts();
        }
    }
}
