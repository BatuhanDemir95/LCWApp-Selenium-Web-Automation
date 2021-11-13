using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWApp.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver)
        {
            base.driver = driver;
        }

        public void LoginEvent(string username, string password)
        {
            Utils.WaitFunction(driver, By.XPath("//*[@id='header__container']/div[1]/header/div[2]/div/div[3]/div[2]/div[1]/a"));
            IWebElement loginBtnElement = driver.FindElement(By.XPath("//*[@id='header__container']/div[1]/header/div[2]/div/div[3]/div[2]/div[1]/a"));
            loginBtnElement.Click();

            Utils.WaitFunction(driver, By.Name("LoginEmail"));
            IWebElement usernameElement = driver.FindElement(By.Name("LoginEmail"));
            usernameElement.SendKeys(username);
            IWebElement passwordElement = driver.FindElement(By.Name("Password"));
            passwordElement.SendKeys(password);
            driver.FindElement(By.Id("loginLink")).Click();
        }
    }
}
