using System.Collections.Generic;
using LightBDD.XUnit2;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios.Basic;
using Puzzle.Domain;
using Puzzle.Domain.Products;


namespace Puzzle.Tests.Features
{
    [FeatureDescription(@"As a customer I want to view a list of products with prices so that I can make informed decisions about what products to order")] //feature description
    [Label("User Story #1")]
    public class ProductFeature : FeatureFixture
    {
        public IList<Product> Products { get; private set; }

        [Scenario]
        [Label("Scenario-1")]
        public void Display_list_of_products()
        {
            /*
             * Given a customer
             * When the customer uses the application
             * Then a list of products with descriptions and prices is displayed
             * And the prices have a mark-up of 20% above the base price provided by the vendor
             */

            Runner.RunScenario(
                Given_a_customer, //steps
                When_the_customer_uses_the_application,
                Then_a_list_of_products_with_descriptions_and_prices_is_displayed,
                And_the_prices_have_a_mark_up_of_20_percent_above_the_base_price_provided_by_the_vendor
            );
        }

        private void Given_a_customer() { /* ... */ }

        private void When_the_customer_uses_the_application() { /* ... */ }

        private void Then_a_list_of_products_with_descriptions_and_prices_is_displayed()
        {
        }

        private void And_the_prices_have_a_mark_up_of_20_percent_above_the_base_price_provided_by_the_vendor()
        {

        }
    }
}
