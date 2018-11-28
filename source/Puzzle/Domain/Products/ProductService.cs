using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Puzzle.Domain.Vendors;

namespace Puzzle.Domain.Products
{
    public class ProductService : IProductService
    {
        private readonly IAllTheCloudsService _allTheCloudsService;

        public ProductService(IAllTheCloudsService allTheCloudsService)
        {
            _allTheCloudsService = allTheCloudsService;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _allTheCloudsService.GetVendorProducts();
        }
    }
}
