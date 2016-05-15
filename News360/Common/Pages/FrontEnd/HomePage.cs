using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using News360.Common.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace News360.Common.Pages.FrontEnd
{
    public class HomePage : PageBase
    {
        public HomePage(IWebDriver driver) : base(driver) {}


        public string TitleHomePage
        {
            get { return _driver.Title; }
        }

        public SignInMethodForm OpenSignInMethodForm()
        {
            var signinLink = _driver.FindElementWait(By.XPath("//a[contains(@class, 'eNav startreading ng-binding')]"));
            signinLink.Click();
            var signinmethodForm = new SignInMethodForm(_driver);
            signinmethodForm.Initialize();
            return signinmethodForm;
        }

        //#pragma warning disable 649
        //#region registration data

        //[FindsBy(How = How.XPath, Using = "//a[contains(@class, 'eNav startreading ng-binding')]")]
        //private IWebElement _signinLink;
        
        //#endregion

    }
}
