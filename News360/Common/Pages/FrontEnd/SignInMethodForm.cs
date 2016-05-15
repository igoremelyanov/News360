using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using News360.Common.Extensions;
using OpenQA.Selenium.Support.PageObjects;


namespace News360.Common.Pages.FrontEnd
{
    public class SignInMethodForm : PageBase
    {
        public SignInMethodForm(IWebDriver driver) : base(driver) { }

        public LogInPage OpenLogInPage()
        {
            _signinWithEmailLink.Click();
            var loginPage = new LogInPage(_driver);
            loginPage.Initialize();
            return loginPage;
        }

        #pragma warning disable 649
        #region registration data

        [FindsBy(How = How.XPath, Using = "//a[contains(@class, 'expand fancybox login-signin ng-binding')]")]
        private IWebElement _signinWithEmailLink;

        #endregion
    }

}
