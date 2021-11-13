using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWApp.Pages
{
    public class BasePage
    {
        public IWebDriver driver;

        public void DisposeDriver()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
