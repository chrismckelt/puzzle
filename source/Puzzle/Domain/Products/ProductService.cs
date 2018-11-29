using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Product> GetProducts(CurrencyRateType? currencyRate = null,int markUpPercentage = 20)
        {
            var vendorProducts = _allTheCloudsService.GetVendorProducts();
            
            // here we would map the vendor product onto our own domain
            // but re-using the same Product object

            var items = vendorProducts as Product[] ?? vendorProducts.ToArray();
            foreach (var item in items)
            {
                item.Price = item.Price.AddPercent(markUpPercentage);// here we are marking up the product price by 20%
              
                if (currencyRate.HasValue)
                {
                    // currency conversion
                    item.Price = CurrencyConverter.Convert(currencyRate.Value, item.Price);
                }
            }

            return items;
        }
    }
}
