using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using News360.Common.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace News360.Common.Extensions
{
    static class WebDriverExtentions
    {
        //public static DashboardPage OpenWebsite(this IWebDriver driver)
        //{
        //    return driver.LoginToAdminWebsiteAs("SuperAdmin", "SuperAdmin");
        //}

        //public static DashboardPage OpenTitlePage(this IWebDriver driver)
        //{
        //    var loginPage = new TitleFlyCowGamePage(driver);
        //    loginPage.NavigateToTitleFlyCowGamePage();
        //    driver.Manage().Cookies.DeleteAllCookies();
        //    driver.Navigate().Refresh();
        //    return driver;
        //}

        public static IWebElement FindElementWait(this IWebDriver driver, By by, Func<IWebElement, bool> predicate = null)
        {
            var elements = FindAllElementsWait(driver, by, predicate);

            return elements.First();
        }

        public static IEnumerable<IWebElement> FindAllElementsWait(this IWebDriver driver, By by, Func<IWebElement, bool> predicate = null)
        {
            if (predicate == null)
            {
                predicate = x => x.Displayed && x.Enabled;
            }

            driver.WaitForJavaScript();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IEnumerable<IWebElement> foundElements = null;
            wait.Until(d =>
            {
                foundElements = driver.FindElements(by).Where(predicate);
                return foundElements.Count() != 0;
            });
            return foundElements;
        }

        public static string FindElementValue(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement element = null;
            wait.Until(d =>
            {
                element = driver.FindElements(by).FirstOrDefault(x => x.Displayed);
                if (element == null) return false;

                if (element.Text == string.Empty) return false;

                return true;
            });

            return element.Text;
        }

        public static void WaitForJavaScript(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(d => (bool)((IJavaScriptExecutor)d).ExecuteScript("return (typeof jQuery == 'undefined') || jQuery.active == 0"));
        }
    }
}
