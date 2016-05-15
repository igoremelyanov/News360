using System;
using System.Collections.Generic;
using System.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Web.Management;
using News360.Common.Extensions;
using News360.Common.Pages;
using News360.Common.Base;
using NUnit.Framework;
using System.Web.Configuration;
using News360.Common.Pages.FrontEnd;
using OpenQA.Selenium;

namespace News360.Tests.Selenium
{
    public class HomePageTests : SeleniumBaseForNews360Website
    {
        private HomePage _homePage;

        public override void BeforeAll()
        {
            base.BeforeAll();
            
        }

        public override void BeforeEach()
        {
            base.BeforeEach();
            //Logout
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().Refresh();

            //Create Page Object
            _homePage = new HomePage(_driver);
        }

        [Test, CategorySmoke, Repeat(1)]
        public void Can_see_HomePage()
        {
            Assert.That(_homePage.TitleHomePage, Is.StringContaining("News360: Your personalized news reader app"));
            //Assert.AreEqual("News360: Your personalized news reader app", _driver.Title);
        }

        [Test]
        public void Can_click_and_see_StartReadingLink() 
        {
            // var titlePage = new TitleNews360Page(_driver);
            //  var aboutusCompanyPage = titlePage.OpenAboutUsCompanyPage();
            // Assert.AreEqual("EXPLORE", aboutusCompanyPage.TitleCompanyPage);
            //Assert.That(errorMsg, Is.StringContaining("Invalid login or password"));
        }

        [Test]
        public void Can_click_and_see_AboutUsCareersPage()
        {
           // var titlePage = new TitleNews360Page(_driver);
           // var aboutusCareersPage = titlePage.OpenAboutUsCareersPagePage();
           //Assert.AreEqual("News360 CAREERS", aboutusCareersPage.TitleCompanyPage);
        }

    }
}
