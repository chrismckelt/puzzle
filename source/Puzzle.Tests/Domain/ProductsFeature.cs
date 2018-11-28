using System;
using System.Collections.Generic;
using System.Linq;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios.Basic;
using LightBDD.XUnit2;
using NSubstitute;
using Puzzle.Domain;
using Puzzle.Domain.Products;
using Puzzle.Domain.Vendors;
using Shouldly;

namespace Puzzle.Tests.Domain
{
    [FeatureDescription(@"As a customer I want to view a list of products with prices so that I can make informed decisions about what products to order")] //feature description
    [Label("User Story #1")]
    public class ProductsFeature : FeatureFixture
    {
        public Customer Customer { get; set; }
        public IEnumerable<Product> Products { get; private set; }

        private IProductService _productService;
        private IAllTheCloudsService _vendorServiceMock = NSubstitute.Substitute.For<IAllTheCloudsService>();

        readonly IEnumerable<Product> _stubs = new List<Product>()
        {
            new Product() {Id = Guid.NewGuid(), Name = "P1", Price = 100.99m},
            new Product() {Id = Guid.NewGuid(), Name = "P2", Price = 1000}, // would love a test databuilder here
        };

        [Scenario]
        [Label("Scenario-1")]
        public void Display_list_of_products_with_20_percent_markup()
        {
            /*
             * Given a customer
             * When the customer uses the application
             * Then a list of products with descriptions and prices is displayed
             * And the prices have a mark-up of 20% above the base price provided by the vendor
             */

            // setup
            

            _vendorServiceMock.GetVendorProducts().ReturnsForAnyArgs(_stubs);

            _productService = new ProductService(_vendorServiceMock);
            
            Runner.RunScenario(
                Given_a_customer, //steps
                When_the_customer_uses_the_application,
                Then_a_list_of_products_with_descriptions_and_prices_is_displayed,
                And_the_prices_have_a_mark_up_of_20_percent_above_the_base_price_provided_by_the_vendor
            );
        }

        private void Given_a_customer()
        {
             // GWT  is customer needed for this scenario?
            Customer = new Customer();
        }

        private void When_the_customer_uses_the_application()
        {
            Products = _productService.GetProducts();
        }

        private void Then_a_list_of_products_with_descriptions_and_prices_is_displayed()
        {
            Products.Count().ShouldNotBe(0);

        }

        private void And_the_prices_have_a_mark_up_of_20_percent_above_the_base_price_provided_by_the_vendor()
        {

        }
    }
}
