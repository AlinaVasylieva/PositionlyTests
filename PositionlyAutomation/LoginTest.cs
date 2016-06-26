using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PositionlyAutomation
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        string _expectedTitle = "Dashboard - Positionly";
        string _expectedPageTitle = "Login - Positionly";
        string _expectedLoginErrorMessage = "Invalid email or password.";

        [TestMethod]
        public void SuccessfulLogin()
        {
            page.LogInClick().
                PopulateUserEmail(userEmail).
                PopulateUserPass(userPassword).
                SubmitLoginBtn();

            Assert.AreEqual(_expectedTitle, driver.Title);
        }

        [TestMethod]
        public void LogOut()
        {
            driver.FindElement(By.XPath("//*[@id='header']/div/div[1]/ul/li[5]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='user_email']")).SendKeys(userEmail);
            driver.FindElement(By.XPath("//*[@id='user_password']")).SendKeys(userPassword);
            driver.FindElement(By.XPath("//*[@id='new_user']/div[2]/input")).Submit();
            driver.FindElement(By.Id("user-dropdown-trigger")).Click();
            driver.FindElement(By.XPath("//*[@id='user-dropdown']/div[2]/ul/li[3]/a")).Click();

            Assert.AreEqual(_expectedPageTitle, driver.Title);
        }

        [TestMethod()]
        public void EmptyLoginSubmit()
        {
            driver.FindElement(By.XPath("//*[@id='header']/div/div[1]/ul/li[5]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='new_user']/div[2]/input")).Click();

            Assert.IsTrue(driver.FindElement(By.ClassName("noty_text")).Displayed);
            Assert.AreEqual(driver.FindElement(By.ClassName("noty_text")).Text, _expectedLoginErrorMessage);
            Assert.AreNotEqual(_expectedTitle, driver.Title);
        }

        [TestMethod()]
        public void LoginEmailOnly()
        {
            driver.FindElement(By.XPath("//*[@id='header']/div/div[1]/ul/li[5]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='user_email']")).SendKeys(userEmail);
            driver.FindElement(By.XPath("//*[@id='new_user']/div[2]/input")).Click();

            Assert.IsTrue(driver.FindElement(By.ClassName("noty_text")).Displayed);
            Assert.AreEqual(driver.FindElement(By.ClassName("noty_text")).Text, _expectedLoginErrorMessage);
            Assert.AreNotEqual(_expectedTitle, driver.Title);
        }

        [TestMethod()]
        public void LoginPasswordOnly()
        {
            driver.FindElement(By.XPath("//*[@id='header']/div/div[1]/ul/li[5]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='user_password']")).SendKeys(userPassword);
            driver.FindElement(By.XPath("//*[@id='new_user']/div[2]/input")).Click();

            Assert.IsTrue(driver.FindElement(By.ClassName("noty_text")).Displayed);
            Assert.AreEqual(driver.FindElement(By.ClassName("noty_text")).Text, _expectedLoginErrorMessage);
            Assert.AreNotEqual(_expectedTitle, driver.Title);
        }
    }
}
