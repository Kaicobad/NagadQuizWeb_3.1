using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NagadQuizWeb.Models;
using NagadQuizWeb.Repository;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using System.Diagnostics;

namespace NagadQuizWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategory _category;
        private readonly IProfileService _profileService;

        public HomeController(ILogger<HomeController> logger, ICategory category, IProfileService profileService)
        {
            _logger = logger;
            _category = category;
            _profileService = profileService;
        }

        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Profile");
            }
            var mobile = HttpContext.Session.GetString("Mobile");
            ViewBag.mobile=mobile;
            return View();
        }

        public IActionResult GetuserScore()
        {
            var token = HttpContext.Session.GetString("Token");
            var data = _profileService.GetUserProfile(token);

            return Ok(data);

        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            string SessionKeyToken = "Token";
            var Session = HttpContext.Session;
            var token = HttpContext.Session.GetString(SessionKeyToken);
            
            if (!string.IsNullOrEmpty(token)) 
            {
                ResponseModel? result = _category.GetCategories(token);
                var data = result.data.ToJson();
                dynamic source = JObject.Parse(data);
               
                ViewBag.category = source;

                return View("Index");
            }
            return RedirectToAction("Index");
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