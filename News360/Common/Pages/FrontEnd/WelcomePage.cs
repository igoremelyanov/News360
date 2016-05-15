using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News360.Common.Extensions;
using OpenQA.Selenium;

namespace News360.Common.Pages.FrontEnd
{
    public class WelcomePage : PageBase
    {
        public WelcomePage(IWebDriver driver) : base(driver) { }

        public string Title
        {
            get { return _driver.FindElementValue(By.XPath("//h2[text()='Welcome to News360']")); }
        }

        public StartReadingPage OpenStartReadingPage()
        {
            var startReadingButton = _driver.FindElementWait(By.XPath("//div[contains(@class, 'startReading ng-binding show')]"));
            startReadingButton.Click();
            var startreadingPage = new StartReadingPage(_driver);
            startreadingPage.Initialize();
            return startreadingPage;
        }

    }
}
