using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LCWApp.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver)
        {
            base.driver = driver;
        }

        public string GetCartPrice()
        {
            Utils.WaitFunction(driver, By.XPath("//*[@id='ShoppingCartContent']/div[1]/div[1]/div[3]/div[1]/div[1]/div[2]/span[2]"));

            return driver.FindElement(By.XPath("//*[@id='ShoppingCartContent']/div[1]/div[1]/div[3]/div[1]/div[1]/div[2]/span[2]")).Text;
        }

        public void CheckProductAndCartPrice(Product selectProduct, string cartPrice)
        {
            if (selectProduct.price.Equals(cartPrice))
            {
                // Increase product count
                driver.FindElement(By.ClassName("oq-up")).Click();
                Thread.Sleep(2000);

                // Delete product
                driver.FindElement(By.XPath("//*[@title='Sil']")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.ClassName("sc-delete")).Click();
            }
            else
            {
                throw new Exception("Ürünün sayfa fiyatı ile sepetteki fiyatı farklı.");
            }
        }
    }
}
