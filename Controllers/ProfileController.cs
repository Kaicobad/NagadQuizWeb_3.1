using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NagadQuizWeb.Repository;
using NuGet.Common;

namespace NagadQuizWeb.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        // GET: ProfileController
        public ActionResult Index()
        {           
            var token = HttpContext.Session.GetString("Token");
            var Session = HttpContext.Session;
            if ( !string.IsNullOrEmpty(token))
            {
                Session.Remove(token);
                Session.Remove("UserName");
                Session.Remove("Mobile");
            }
            return View();
        }



        public ActionResult Details()
        {
            var token = HttpContext.Session.GetString("Token");
            var data = _profileService.GetUserProfile(token);
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Profile");
            }
            ViewBag.Name = "";
            ViewBag.Msisdn = "0";
            ViewBag.totalPoint = "0";
            ViewBag.timeInSeconds = "0";
            ViewBag.predictionWins = "0";
            ViewBag.quizwins = "0";
            ViewBag.poleScore = "0";
            if (data != null)
            {
                ViewBag.Name = "";
                ViewBag.Msisdn = !string.IsNullOrEmpty(data.msisdn) ? data.msisdn : "0";
                ViewBag.score = !string.IsNullOrEmpty(data.score) ? data.score : "0";
                ViewBag.timeInSeconds = !string.IsNullOrEmpty(data.timeInSeconds) ? data.timeInSeconds : "0";
                ViewBag.predictionWins = !string.IsNullOrEmpty(data.predictionScore) ? data.predictionScore : "0";
                ViewBag.quizwins = !string.IsNullOrEmpty(data.quizwins) ? data.quizwins : "0";
                ViewBag.totalScore = !string.IsNullOrEmpty(data.totalScore) ? data.totalScore : "0";
                ViewBag.poleScore = !string.IsNullOrEmpty(data.poleScore) ? data.poleScore : "0";
            }


            return View();
        }

        // GET: ProfileController/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: ProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
