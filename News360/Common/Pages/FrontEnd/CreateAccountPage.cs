using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News360.Common.Extensions;
using OpenQA.Selenium;

namespace News360.Common.Pages.FrontEnd
{
    public class CreateAccountPage : PageBase
    {
        public CreateAccountPage(IWebDriver driver) : base(driver) { }

        public SignInPage OpenSignInPage()
        {
            var signInLink = _driver.FindElementWait(By.XPath("//a[contains(@class, 'expand fancybox login-signin ng-binding')]"));
            signInLink.Click();

            var signInPage = new SignInPage(_driver);
            signInPage.Initialize();
            return signInPage;
        }
    }
}
