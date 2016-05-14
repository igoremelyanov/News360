using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using OpenQA.Selenium;
//using System.Web.Configuration;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace News360.Common.Pages
{
    public abstract class PageBase
    {
        protected IWebDriver _driver;

        protected PageBase(IWebDriver driver)
        {
            _driver = driver;
        }


        public Uri Url
        {
            get { return new Uri(_driver.Url); }
        }

        public bool IsCurrentPage
        {
            get { return GetPageUrl() == _driver.Url; }
        }

        protected virtual string GetPageUrl()
        {
            return "";
        }

        public virtual void Initialize()
        {
            PageFactory.InitElements(_driver, this);
        }

        public virtual void NavigateToMemberWebsite()
        {
           // var url = WebConfigurationManager.AppSettings["MemberWebsiteUrl"] + GetPageUrl();
            //_driver.Navigate().GoToUrl(url);
            //Initialize();
        }

        public virtual void NavigateToTitleFlyCowGamePage()
        {
            var url = WebConfigurationManager.AppSettings["FlyCowGamesWebsiteUrl"];
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(url);
            //_driver.Manage().Cookies.DeleteAllCookies();
            //_driver.Navigate().Refresh();
            //Initialize();
        }




    }
}
