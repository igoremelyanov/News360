using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Configuration;
using NUnit.Framework;
using News360.Common;
using System.Configuration;
using System.Drawing;
//using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace News360.Common.Base
{
    [Category("Selenium")]
    public abstract class SeleniumBase : TestsBase
    {
        protected IWebDriver _driver;

        public override void BeforeAll()
        {
            base.BeforeAll();

            _driver = CreateFireFoxWebDriver();
            _driver.Url = GetWebsiteUrl();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
           // _driver.Manage().Window.Size = new Size(1500, 900);

        }
        
        public override void BeforeEachFailed(Exception ex)
        {
            base.BeforeEachFailed(ex);
            SaveScreenshot();
        }

        public override void BeforeAllFailed(Exception ex)
        {
            try
            {
                base.BeforeAllFailed(ex);
                SaveScreenshot();
            }
            finally
            {
                QuitWebDriver();
            }
        }

        public override void AfterEachFailed()
        {
            base.AfterEachFailed();
            SaveScreenshot();
        }

        public override void AfterAll()
        {
            try
            {
                base.AfterAll();
            }
            finally
            {
                QuitWebDriver();
            }
        }

        
        public void SaveScreenshot()
        {
            if (_driver == null)
                return;
            var path = WebConfigurationManager.AppSettings["ScreenshotsPath"];
            Directory.CreateDirectory(path);
            var testName = TestContext.CurrentContext.Test.Name;
            var fileName = string.Format("{0:yyyy-MM-dd_hh-mm}-{1}.{2}", DateTime.Now, testName, "png");
            var fullPath = Path.Combine(path, fileName);

            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            Thread.Sleep(500);
            screenshot.SaveAsFile(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            Thread.Sleep(500);
        }

        protected void QuitWebDriver()
        {
            if (_driver == null) return;

            var exceptionThrown = false;
            var retries = 0;
            do
            {
                try
                {
                    retries++;
                    _driver.Quit();
                }
                catch (Exception)
                {
                    exceptionThrown = true;
                    SaveScreenshot();
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                }

            } while (exceptionThrown && retries <= 3);
        }

        protected abstract string GetWebsiteUrl();


        static IWebDriver CreateFireFoxWebDriver()
        {
            return new FirefoxDriver();
        }


        public class CategorySmoke : CategoryAttribute
        {
            public CategorySmoke() : base("Smoke") { }
        }


    }
}
