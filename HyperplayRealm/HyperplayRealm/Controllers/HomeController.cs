using BLL.Configuration.Model;
using BLL.DTOs;
using BLL.Interfaces;
using HyperplayRealm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HyperplayRealm.Controllers
{
    public class HomeController : Controller
    {
        //change this to login page!!
        private readonly ILogger<HomeController> _logger;

        private readonly IAppSettings _appSettings;
        private AppSettings? AppSettings { get; set; }

        public HomeController(IAppSettings appSettings, ILogger<HomeController> logger)
        {
            _logger = logger;

            //get this when you need send it in index
            _appSettings = appSettings;
            Debug.Write(_appSettings);
        }

        public IActionResult Index()
        {
            AppSettings = _appSettings.GetAppSettings();

            if (AppSettings == null)
            {
                throw new ApplicationException("Application Settings Are Needed!");
            }

            return View(AppSettings);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
