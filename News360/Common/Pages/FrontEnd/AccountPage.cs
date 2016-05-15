using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using News360.Common.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace News360.Common.Pages.FrontEnd
{
    public class AccountPage : PageBase
    {
        public AccountPage(IWebDriver driver) : base(driver) { }

        public HomePage Logout()
        {
            var logoutButton = _driver.FindElementWait(By.XPath("//div[contains(@ng-click, 'logout()')]"));
            logoutButton.Click();
            var homePage = new HomePage(_driver);
            homePage.Initialize();
            return homePage;
        }
    }
}
