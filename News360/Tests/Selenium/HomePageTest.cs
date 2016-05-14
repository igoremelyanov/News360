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
using OpenQA.Selenium;

namespace News360.Tests.Selenium
{
    public class HomePageTest : SeleniumBaseForNews360Website
    {
        //TitleNews360Page homePage;

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

            //_driver.Manage().Cookies.DeleteAllCookies();
            //_loginPage = new AdminWebsiteLoginPage(_driver);
            //_loginPage.NavigateToAdminWebsite();

        }

        [Test, CategorySmoke, Repeat(10)]
        public void Can_see_HomePage()
        {
            Assert.AreEqual("News360: Your personalized news reader app", _driver.Title);
        }

        [Test, Repeat(10)]
        public void Can_click_and_see_AboutUsCompanyPage() 
        {
           // base.BeforeAll();

           // var titlePage = new TitleNews360Page(_driver);
          //  var aboutusCompanyPage = titlePage.OpenAboutUsCompanyPage();

           // Assert.AreEqual("COMPANY", aboutusCompanyPage.TitleCompanyPage);

           // base.AfterAll();
            
        }

        [Test, Repeat(10)]
        public void Can_click_and_see_AboutUsCareersPage() //example with PageFactory object
        {
            // base.BeforeAll();

           // var titlePage = new TitleNews360Page(_driver);
           // var aboutusCareersPage = titlePage.OpenAboutUsCareersPagePage();

          //  Assert.AreEqual("FLYCOW CAREERS", aboutusCareersPage.TitleCompanyPage);

            // base.AfterAll();

        }


    }
}
