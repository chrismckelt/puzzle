# Puzzle

> The art of simplicity is a puzzle of complexity. Douglas Horton

A simple out of the box Visual Studio Angular template with tests 

#Choices

* Visual Studio 2017 .Net Core Angular template
* XUnit
* LightBDD for a Behaviour Driven Development framework with Xunit - https://github.com/LightBDD/LightBDD

## Other samples from me in this area

* SpecFlow Acceptance Tests March 2011 http://mckelt.com/blog/?p=140

* TDD/BDD posts --> http://mckelt.com/blog/?cat=25

## LightBDD will output tests in the Given When Then format below

![image](https://user-images.githubusercontent.com/662868/49256107-eb85f100-f468-11e8-91bb-5e60fba310c3.png)






## The Problem

You work for a company that is a reseller for a vendor that sells cloud products. The vendor provides an API at http://alltheclouds.com.au . Your company would like to build an application that allows your customers to view the available products and their prices and to make orders.
#### User Story #1
As a customer I want to view a list of products with prices so that I can make informed decisions about what products to order
##### Acceptance Criteria
    Given a customer 
    When the customer uses the application 
    Then a list of products with descriptions and prices is displayed 
    And the prices have a mark-up of 20% above the base price provided by the vendor
#### User Story #2
As a customer I want to view prices in my local currency so that I don’t have to manually calculate how much products are going to cost
##### Acceptance Criteria
    Given a customer 
    When the customer is using the application 
    Then the customer is able to select a currency from the list of supported currencies (Australian Dollar, US Dollar, British Pound)

	Given a customer is viewing the product list 
	When the customer selects from the available currencies 
	Then the prices should be displayed in the selected currency
#### User Story #3 
This story is optional; however, you are encouraged to complete it if you have time.

As a customer I want to submit an order so that I can purchase products
##### Acceptance Criteria
    Given a customer 
    When the customer is viewing the product list 
    Then the customer can enter a quantity 
    And the customer can add the product to an order
    
    Given a customer has added one or more products to an order 
    And the customer has entered their name and email address 
    When the customer submits the order 
    Then the order is submitted to the vendor API