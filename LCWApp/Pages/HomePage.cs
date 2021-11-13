using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWApp.Pages
{
    public class HomePage : BasePage
    {
        static readonly string PAGE_URL = "https://www.lcwaikiki.com/tr-TR/TR/";

        public HomePage(IWebDriver driver)
        {
            base.driver = driver;
        }

        public void OpenPage()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(PAGE_URL);
        }

        public void OpenSearchPage(string search)
        {
            Utils.WaitFunction(driver, By.XPath("//*[@id='search_input']"));
            IWebElement searchElement = driver.FindElement(By.XPath("//*[@id='search_input']"));
            searchElement.Click();

            searchElement.SendKeys(search);
            driver.FindElement(By.ClassName("searchButton")).Click();
        }
    }
}
