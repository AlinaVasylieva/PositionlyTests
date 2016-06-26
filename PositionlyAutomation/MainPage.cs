using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace PositionlyAutomation
{
    public class MainPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='new-promo']/header/div/div/a")]
        IWebElement signUpBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='header']/div/div[1]/ul/li[6]/a")]
        IWebElement logInLnk;

        public MainPage(IWebDriver driver) : base (driver)
        {
            if (!MAIN_PAGE_TITLE.Equals(GetPageTitle()))
                throw new Exception("This is not main page!");
            PageFactory.InitElements(_driver, this);
        }

        public SignUpPage SignUpClick()
        {
            signUpBtn.Click();
            return new SignUpPage(_driver);
        }

        public LoginPage LogInClick()
        {
            logInLnk.Click();
            return new LoginPage(_driver);
        }

    }
}
