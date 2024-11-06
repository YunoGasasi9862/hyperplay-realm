using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BLL.Controllers.Bases
{
    public class BaseController: Controller, ICulture
    {
        protected BaseController()
        {
            SetCulture("en-US");
        }

        public void SetCulture(string culture)
        {
            CultureInfo cultureInfo = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}
