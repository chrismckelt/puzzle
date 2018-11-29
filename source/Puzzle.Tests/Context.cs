using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using LightBDD.XUnit2;
using NSubstitute;
using Puzzle.Domain.Customers;
using Puzzle.Domain.Orders;
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
        protected IOrderService OrderService;
        protected readonly IAllTheCloudsService VendorServiceMock = NSubstitute.Substitute.For<IAllTheCloudsService>();
        protected Guid OrderId;

        protected static readonly IEnumerable<Product> Stubs = new List<Product>()
        {
            new Product() {Id = Guid.NewGuid(), Name = "P1", Price = 100m},
            new Product() {Id = Guid.NewGuid(), Name = "P2", Price = 1000m}, // would love a test databuilder here
            new Product() {Id = Guid.NewGuid(), Name = "P3", Price = 10000.80m}, // would love a test databuilder here
        };

        protected Order Order;


        #region Given

        protected void Given_a_customer()
        {
            Customer = new Customer
            {
                Id = Guid.NewGuid(),
                CreatedUtcDateTime = DateTime.UtcNow
            };
        }

        protected void And_the_customer_has_entered_their_name_and_email_address(string firstname, string surname, string email)
        {
            if (Customer != null)
            {
                Customer.FirstName = firstname;
                Customer.Surname = surname;
                Customer.Email = email;
            }
        }

        #endregion

        #region When

        protected void When_the_customer_uses_the_application(CurrencyRateType? currencyRate = null)
        {
            Products = currencyRate.HasValue ? ProductService.GetProducts(currencyRate.Value) : ProductService.GetProducts();
        }

        protected void When_the_customer_selects_from_the_available_currencies()
        {
            Customer.CurrencyRate = CurrencyRateType.Gbp; // customer chooses GDP
        }


        protected void When_the_customer_submits_an_order()
        {
            OrderService = new OrderService(VendorServiceMock);
            Order = new Order
            {
                Customer = Customer,
                ProductQuantities = new Dictionary<Product, int>()
            };

            Order.AddProduct(Products.First());
            Order.AddProduct(Products.First());

            Order.ProductQuantities.Count.ShouldBe(1);
            Order.ProductQuantities.First().Value.ShouldBe(2);  // we added the same product twice (so quantity = 2)

            OrderId = OrderService.CreateOrder(Order);
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

        public void Then_the_product_and_quantity_is_added_to_the_order()
        {
           Order.ProductQuantities.Count.ShouldNotBe(0);
            Order.ProductQuantities.First().Value.ShouldBe(2); //1 product added twice
        }

        public void And_the_order_is_submitted_to_the_vendor_api()
        {
            VendorServiceMock.Received().CreateOrder(Order);
        }

        #endregion

  
    }
}
