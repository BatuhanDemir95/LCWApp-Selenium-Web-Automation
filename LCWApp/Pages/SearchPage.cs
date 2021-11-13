using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWApp.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver)
        {
            base.driver = driver;
        }

        public void ScrollPage()
        {
            Utils.WaitFunction(driver, By.XPath("//*[@id='divModels']/div[7]/div/div[4]/a"));
            Utils.ExecuteJS(driver, "window.scrollBy(0, document.body.scrollHeight);");
        }

        public void GetMoreProducts()
        {
            IWebElement getMoreProductsElement = driver.FindElement(By.XPath("//*[@id='divModels']/div[7]/div/div[4]/a"));
            getMoreProductsElement.Click();
        }

        public IWebElement SelectRandomProduct()
        {
            Utils.WaitFunction(driver, By.XPath("//*[@id='divModels']/div[7]/div/div[1]"));

            IWebElement productsElement = driver.FindElement(By.XPath("//*[@id='divModels']/div[7]/div/div[1]"));
            IList<IWebElement> allProductsElements = productsElement.FindElements(By.ClassName("product-item-wrapper"));

            int index = Utils.GetRandomNumber(0, allProductsElements.Count - 1);
            IWebElement selectedProductElement = allProductsElements[index];
            return selectedProductElement;
        }

        public void OpenSelectedProductPage(IWebElement selectedProductElement)
        {
            IWebElement openSelectedProductPageElement = selectedProductElement.FindElement(By.ClassName("a_model_item"));
            openSelectedProductPageElement.Click();
        }
    }
}
