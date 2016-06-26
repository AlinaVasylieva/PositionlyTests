﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace PositionlyAutomation
{
    public class SignUpPage : BasePage
    {
        public SignUpPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }

    }
}
