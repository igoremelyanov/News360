using System;
using System.Collections.Generic;
using System.Linq;
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
    internal class SignInTests : SeleniumBaseForNews360Website
    {
        private HomePage _homePage;
     
        public override void BeforeAll()
        {
            //Go to Home Page
            base.BeforeAll();
        }

        public override void BeforeEach()
        {
            base.BeforeEach();
            _driver.Manage().Cookies.DeleteAllCookies();
            //Create Page Object
            _homePage = new HomePage(_driver);
             // _homePage.
            //_loginPage = new AdminWebsiteLoginPage(_driver);
            //_loginPage.NavigateToAdminWebsite();

        }

        [Test]
        //[Test, Repeat(10)]
        public void Can_sign_In_with_valid_email_and_password()
        {
           //Open Pop up form for choosing method of account creation
           var createAccountPage = _homePage.OpenCreateAccountPage();
           //Choose Email signIn link
           var signInPage = createAccountPage.OpenSignInPage();
           //Entering valid data

            // Assert.AreEqual("COMPANY", aboutusCompanyPage.TitleCompanyPage);

            // base.AfterAll();

        }
    }
}
