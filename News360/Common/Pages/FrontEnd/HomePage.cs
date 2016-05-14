using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using News360.Common.Extensions;
//using News360.Common.Pages;
using OpenQA.Selenium;


namespace News360.Common.Pages.FrontEnd
{
    public class HomePage : PageBase
    {
        public HomePage(IWebDriver driver) : base(driver) {}

        //protected override string GetPageUrl()
        //{
        //    return "Home/";
        //}

        public CreateAccountPage OpenCreateAccountPage()
        {
            var startReadingButton = _driver.FindElementWait(By.XPath("//a[contains(@class, 'eNav startreading ng-binding')]"));
            startReadingButton.Click();

            var createAccountPage = new CreateAccountPage(_driver);
            createAccountPage.Initialize();
            return createAccountPage;
        }

    }
}
