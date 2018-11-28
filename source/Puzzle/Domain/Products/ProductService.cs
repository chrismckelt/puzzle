using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Puzzle.Domain.Vendors;
using Puzzle.Infrastructure;

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
            var vendorProducts = _allTheCloudsService.GetVendorProducts();
            
            // here we would map the vendor product onto our own domain
            // but re-using the same Product object

            var items = vendorProducts as Product[] ?? vendorProducts.ToArray();
            foreach (var item in items)
            {
                item.Price = item.Price.AddPercent(20);// here we are marking up the product price by 20%
            }

            return items;
        }
    }
}
