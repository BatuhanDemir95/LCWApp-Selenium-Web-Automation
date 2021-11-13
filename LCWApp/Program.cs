using LCWApp.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LCWApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            HomePage homePage = new HomePage(driver);
            LoginPage loginPage = new LoginPage(driver);
            SearchPage searchPage = new SearchPage(driver);
            ProductDetailPage productDetailPage = new ProductDetailPage(driver);
            CartPage cartPage = new CartPage(driver);

            Product selectProduct = new Product();

            try
            {
                homePage.OpenPage();

                loginPage.LoginEvent("username", "password");
 
                homePage.OpenSearchPage("pantolan");

                searchPage.ScrollPage();

                searchPage.GetMoreProducts();

                IWebElement selectedProductElement = searchPage.SelectRandomProduct();

                searchPage.OpenSelectedProductPage(selectedProductElement);

                productDetailPage.AssignProductProperties(selectProduct);

                productDetailPage.ChooseProductSize();

                productDetailPage.AddCart();

                productDetailPage.OpenCart();

                string cartPrice = cartPage.GetCartPrice();

                cartPage.CheckProductAndCartPrice(selectProduct, cartPrice);
            }
            catch (Exception)
            {
                homePage.DisposeDriver();
                throw;
            }
            
            Console.Read();
        }
    }
}