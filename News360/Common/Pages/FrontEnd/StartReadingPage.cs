using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using News360.Common.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace News360.Common.Pages.FrontEnd
{
    public class StartReadingPage : PageBase
    {
        public StartReadingPage(IWebDriver driver) : base(driver) { }


        public string ExploreLink
        {
            get { return _driver.FindElementValue(By.XPath("//div/a[contains(@href, 'explore/')]")); }
        }

        public AccountPage OpenAccountPage()
        {
            var settingsMenuButton = _driver.FindElementWait(By.XPath("//a[contains(@href, 'settings/')]"));
            settingsMenuButton.Click();
            var accountPage = new AccountPage(_driver);
            accountPage.Initialize();
            return accountPage;
        }

    }
}
