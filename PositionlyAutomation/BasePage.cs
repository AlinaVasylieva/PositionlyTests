using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionlyAutomation
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected string MAIN_PAGE_TITLE = "Inbound Marketing Software - Positionly";

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        protected string GetPageTitle()
        {
            return _driver.Title;
        }

        protected string GetPageUrl()
        {
            return _driver.Url;
        }
    }
}
