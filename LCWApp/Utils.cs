using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWApp
{
    public class Utils
    {
        public static int GetRandomNumber(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }

        public static void WaitFunction(IWebDriver driver, By by)
        {
            int count = 0;
            while (driver.FindElements(by).Count == 0 && count < 50)
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(300));
                webDriverWait.Until(dr => dr.FindElements(by));
                count++;
            }
        }

        public static void ExecuteJS(IWebDriver driver, string jsCode)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript(jsCode);
        }
    }
}
