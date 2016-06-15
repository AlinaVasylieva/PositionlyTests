using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace PositionlyAutomation
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected string url = "https://positionly.com/";
        protected string userEmail = "a.v.vasylieva@gmail.com";
        protected string userPassword = "123456";

        [TestInitialize()]
        public void Initialize()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(url);
        }

        [TestCleanup()]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
