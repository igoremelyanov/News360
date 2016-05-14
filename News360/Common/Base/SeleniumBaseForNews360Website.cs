using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Configuration;

namespace News360.Common.Base
{
   public abstract class SeleniumBaseForNews360Website : SeleniumBase
    {
        protected override string GetWebsiteUrl()
        {
            return WebConfigurationManager.AppSettings["News360Url"];
        }
    }
}
