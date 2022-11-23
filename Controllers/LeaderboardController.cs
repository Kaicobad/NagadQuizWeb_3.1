using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NagadQuizWeb.Repository;
using NuGet.Common;

namespace NagadQuizWeb.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly IProfileService _profileService;
        public LeaderboardController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Profile");
            }

            return View();
        }

        public IActionResult GetYesterdayResult()
        {
            var token = HttpContext.Session.GetString("Token");
            var data = _profileService.GetYesterdaysResult(token);
            ViewBag.data = data;
            return PartialView("GetTodaysResult");
        }


        public PartialViewResult GetTodaysResult()
        {
            var token = HttpContext.Session.GetString("Token");
            var data = _profileService.GetResult(token);
            ViewBag.data = data;
            return PartialView("GetTodaysResult");
        }

        public PartialViewResult GetWeeklyResult()
        {
            var token = HttpContext.Session.GetString("Token");
            var data = _profileService.GetResultWeekly(token);
            ViewBag.data = data;
            return PartialView("GetTodaysResult");
        }


    }
}
