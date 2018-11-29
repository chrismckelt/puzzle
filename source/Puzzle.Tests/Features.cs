using System;
using System.Linq;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios.Basic;
using LightBDD.XUnit2;
using NSubstitute;
using Puzzle.Domain.Orders;
using Puzzle.Domain.Products;
using Puzzle.Infrastructure;

namespace Puzzle.Tests
{
    [FeatureDescription(
        @"As a customer I want to view a list of products with prices so that I can make informed decisions about what products to order")] //feature description
    [Label("User Story #1")]
    public class Features : Context
    {
        [Scenario]
        [Label("Scenario-1")]
        public void Products_have_20_percent_markup_on_wholesale_vendor_products()
        {
            /*
             * Given a customer
             * When the customer uses the application
             * Then a list of products with descriptions and prices is displayed
             * And the prices have a mark-up of 20% above the base price provided by the vendor
             */

            // setup 
            var copies = Stubs.Select(x => x.DeepClone()); // convert to value types from reference types

            VendorServiceMock.GetVendorProducts().ReturnsForAnyArgs(copies);

            ProductService = new ProductService(VendorServiceMock);

            // execute scenarios for feature (LightBDD thing)
            Runner.RunScenario(
                Given_a_customer, //steps
                () => When_the_customer_uses_the_application(null),
                Then_a_list_of_products_with_descriptions_and_prices_is_displayed,
                And_the_prices_have_a_mark_up_of_20_percent_above_the_base_price_provided_by_the_vendor
            );
        }

        [Scenario]
        [Label("Scenario-2")]
        public void Customer_can_persist_their_own_currency()
        {
            /*
             * Given a customer
             * When the customer is using the application
             * Then the customer is able to select a currency from the list of supported currencies (Australian Dollar, US Dollar, British Pound)
             */

            // setup 
            var copies = Stubs.Select(x => x.DeepClone()); // convert to value types from reference types

            VendorServiceMock.GetVendorProducts().ReturnsForAnyArgs(copies);

            ProductService = new ProductService(VendorServiceMock);

            // execute scenarios for feature (LightBDD thing)
            Runner.RunScenario(
                Given_a_customer, //steps
                () => When_the_customer_uses_the_application(null),
                Then_the_customer_is_able_to_select_a_currency_from_the_list_of_supported_currencies
            );
        }

        [Scenario]
        [Label("Scenario-3")]
        public void Customer_can_view_products_in_their_local_currency()
        {
            /*
            Given a customer is viewing the product list 
            When the customer selects from the available currencies Then the prices should be displayed in the selected currency
             */

            // setup 
            var copies = Stubs.Select(x => x.DeepClone()); // convert to value types from reference types

            VendorServiceMock.GetVendorProducts().ReturnsForAnyArgs(copies);

            ProductService = new ProductService(VendorServiceMock);

            // execute scenarios for feature (LightBDD thing)
            Runner.RunScenario(
                Given_a_customer, //steps
                When_the_customer_selects_from_the_available_currencies,
                () => When_the_customer_uses_the_application(CurrencyRateType.Gbp),
                Then_the_prices_should_be_displayed_in_the_selected_currency
            );
        }

        [Scenario]
        [Label("Scenario-4")]
        public void Customer_can_submit_an_order_to_purchase_products()
        {
            /*
          Given a customer 
          When the customer is viewing the product list 
          Then the customer can enter a quantity And the customer can add the product to an order


            Given a customer has added one or more products to an order And the customer has entered their name and email address When the customer submits the order Then the order is submitted to the vendor API

             */

            // setup 
            var copies = Stubs.Select(x => x.DeepClone()); // convert to value types from reference types

            VendorServiceMock.GetVendorProducts().ReturnsForAnyArgs(copies);
            VendorServiceMock.CreateOrder(Arg.Any<Order>()).ReturnsForAnyArgs(Guid.NewGuid());

            ProductService = new ProductService(VendorServiceMock);

            // execute scenarios for feature (LightBDD thing)
            Runner.RunScenario(
                Given_a_customer,
                () => And_the_customer_has_entered_their_name_and_email_address("bob", "smitch",
                    "bob.smith@gmail.com"), //steps
                () => When_the_customer_uses_the_application(),
                When_the_customer_submits_an_order,
                Then_the_product_and_quantity_is_added_to_the_order,
                And_the_order_is_submitted_to_the_vendor_api
            );
        }
    }
}