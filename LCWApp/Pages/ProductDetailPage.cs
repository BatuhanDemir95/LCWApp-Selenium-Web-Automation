using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWApp.Pages
{
    public class ProductDetailPage : BasePage
    {
        public ProductDetailPage(IWebDriver driver)
        {
            base.driver = driver;
        }

        public void AssignProductProperties(Product selectProduct)
        {
            IWebElement productInsideElement = driver.FindElement(By.XPath("//*[@id='rightInfoBar']/div[1]/div/div[2]/div/div/div[2]/div[2]"));

            if (productInsideElement == null)
            {
                productInsideElement = driver.FindElement(By.XPath("//*[@id='rightInfoBar']/div[1]/div/div[2]/div/div/div/span[2]"));
                selectProduct.price = productInsideElement.Text;
            }
            else
            {
                selectProduct.price = productInsideElement.Text;
            }

            var nameElement = driver.FindElement(By.XPath("//*[@id='rightInfoBar']/div[1]/div/div[1]/div[1]/div[2]"));
            selectProduct.name = nameElement.Text;
        }

        public void ChooseProductSize()
        {
            Utils.WaitFunction(driver, By.Id("option-size"));

            IWebElement optionSizeElement;
            IWebElement optionSizeElements = driver.FindElement(By.Id("option-size"));
            IList<IWebElement> optionSizes = optionSizeElements.FindElements(By.TagName("a"));

            for (int i = 1; i <= optionSizes.Count; i++)
            {
                optionSizeElement = driver.FindElement(By.XPath("//*[@id='option-size']/a[" + i + "]"));
                if (optionSizeElement.GetAttribute("class") == "disabled")
                {
                    continue;
                }
                optionSizeElement.Click();
                break;
            }

            if (driver.FindElements(By.Id("option-height")).Count != 0)
            {
                IWebElement optionHeightElement;
                IWebElement optionHeightElements = driver.FindElement(By.Id("option-height"));
                IList<IWebElement> optionLenghts = optionHeightElements.FindElements(By.TagName("a"));

                for (int i = 1; i <= optionLenghts.Count; i++)
                {
                    optionHeightElement = driver.FindElement(By.XPath("//*[@id='option-height']/a[" + i + "]"));
                    if (optionHeightElement.GetAttribute("class") == "disabled")
                    {
                        continue;
                    }
                    optionHeightElement.Click();
                    break;
                }
            }
        }

        public void AddCart()
        {
            Utils.WaitFunction(driver, By.ClassName("add-to-cart"));

            IWebElement addCartElement = driver.FindElement(By.ClassName("add-to-cart"));
            addCartElement.Click();
        }

        public void OpenCart()
        {
            Utils.WaitFunction(driver, By.XPath("/html/body/div[5]/div[2]/div[1]/div[4]/div/div[4]/a/i"));
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[1]/div[4]/div/div[4]/a/i")).Click();
        }
    }
}
