using System;
using System.Collections.Generic;
using System.Linq;
using LightBDD.XUnit2;
using Puzzle.Domain.Customers;
using Puzzle.Domain.Products;
using Puzzle.Domain.Vendors;
using Puzzle.Infrastructure;
using Shouldly;
using Xunit;

namespace Puzzle.Tests
{
    public abstract class Context : FeatureFixture
    {
        public Customer Customer { get; set; }
        public IEnumerable<Product> Products { get; protected set; }

        protected IProductService ProductService;
        protected readonly IAllTheCloudsService VendorServiceMock = NSubstitute.Substitute.For<IAllTheCloudsService>();

        protected static readonly IEnumerable<Product> Stubs = new List<Product>()
        {
            new Product() {Id = Guid.NewGuid(), Name = "P1", Price = 100m},
            new Product() {Id = Guid.NewGuid(), Name = "P2", Price = 1000m}, // would love a test databuilder here
            new Product() {Id = Guid.NewGuid(), Name = "P3", Price = 10000.80m}, // would love a test databuilder here
        };

        // sorry richard banks
        #region Given

        protected void Given_a_customer()
        {
            // GWT  is customer needed for this scenario?
            Customer = new Customer();
        }

        #endregion

        #region When

        protected void When_the_customer_uses_the_application(CurrencyRateType? currencyRate)
        {
            if (currencyRate.HasValue)
            {
                Products = ProductService.GetProducts(currencyRate.Value);
            }
            else
            {
                Products = ProductService.GetProducts();
            }
        }

        protected void When_the_customer_selects_from_the_available_currencies()
        {
            Customer.CurrencyRate = CurrencyRateType.Gbp; // customer chooses GDP
        }

        #endregion

        #region Then / And

        protected void Then_the_customer_is_able_to_select_a_currency_from_the_list_of_supported_currencies()
        {
            Customer.CurrencyRate.ShouldBe(CurrencyRateType.Aud); // ensure default value is aussie
            // probably more of a UI test
        }

        protected void Then_a_list_of_products_with_descriptions_and_prices_is_displayed()
        {
            Products.Count().ShouldNotBe(0);
        }
   
        protected void And_the_prices_have_a_mark_up_of_20_percent_above_the_base_price_provided_by_the_vendor()
        {
         
            foreach (var product in Products)
            {
                var seed = Stubs.Single(x => x.Id == product.Id);
                var markup = seed.Price.AddPercent(20);
                product.Price.ShouldBe(markup);
            }
        }

        protected void Then_the_prices_should_be_displayed_in_the_selected_currency()
        {
            string match = CurrencyRateType.Gbp.GetDescription();

            var rate = CurrencyConverter.CountryConversationRates.Single(x => x.Key == match).Value;
            foreach (var product in Products)
            {
                var seed = Stubs.Single(x => x.Id == product.Id);
                var markup = seed.Price.AddPercent(20) *rate;
                product.Price.ShouldBe(markup);
            }
        }

        #endregion

  
    }
}
