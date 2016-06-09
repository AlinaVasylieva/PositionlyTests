using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PositionlyAutomation
{
    [TestClass]
    public class LoginTest
    {
        IWebDriver driver;
        string url = "https://positionly.com/";
        string userEmail = "a.v.vasylieva@gmail.com";
        string userPassword = "123456";

        string expectedTitle = "Dashboard - Positionly";

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

        [TestMethod()]
        public void SuccessfulLogin()
        {
            driver.FindElement(By.XPath("//*[@id='navigation']/div/ul/li[3]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='user_email']")).SendKeys(userEmail);
            driver.FindElement(By.XPath("//*[@id='user_password']")).SendKeys(userPassword);
            driver.FindElement(By.XPath("//*[@id='new_user']/div[2]/input")).Submit();

            Assert.AreEqual(expectedTitle, driver.Title);
        }
    }
}
