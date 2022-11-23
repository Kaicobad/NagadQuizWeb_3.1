using Microsoft.AspNetCore.Mvc;
using NagadQuizWeb.Models;
using NagadQuizWeb.Repository;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Text.Json;
using NagadQuizWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Routing;

namespace NagadQuizWeb.Controllers
{
    public class QuizQuestionController : Controller
    {
        private readonly IQuizQuestion quizQuestion;
        private readonly ICheckAnswer checkAnswer;
        private readonly ISubmitResult submitResult;
        private readonly IPrediction prediction;
        private readonly INagadPoll nagadPoll;

        public QuizQuestionController(IQuizQuestion quizQuestion, ICheckAnswer checkAnswer, ISubmitResult submitResult, IPrediction prediction,INagadPoll nagadPoll)
        {
            this.quizQuestion = quizQuestion;
            this.checkAnswer = checkAnswer;
            this.submitResult = submitResult;
            this.prediction = prediction;
            this.nagadPoll = nagadPoll;
        }
        public IActionResult QuizStep()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Profile");
            }
            var result = quizQuestion.GetQuestion(token);
            var data = result.data.ToJson();

            JArray obj = JsonConvert.DeserializeObject<JArray>(data);

            foreach (var items in obj)
            {
                int questionScore = Convert.ToInt32(items["questionScore"]);
                ViewBag.Qmark = questionScore;
                break;
            }



            ViewBag.quentions = obj;

            return View("Index");
        }
        [HttpGet]
        public ResponseModel CheckAnswer(int questionId, int choiceId)
        {
            var token = HttpContext.Session.GetString("Token");
            //if (string.IsNullOrEmpty(token))
            //{
            //    return RedirectToAction("Index", "Profile");
            //}
            var result = checkAnswer.AnswerStatus(questionId, choiceId, token);

            return result;
        }

        public IActionResult SubmitMatchResult(int Score, int timetoAnswer)
        {
            MatchResultModel resultmodel = new MatchResultModel();
            resultmodel.Score = Score;
            resultmodel.OnDate = DateTime.Now;
            resultmodel.TimeInSeconds = timetoAnswer > 22 ? timetoAnswer - 1 : timetoAnswer;
            var token = HttpContext.Session.GetString("Token");
            var result = submitResult.PostSubmitResult(resultmodel, token);
            if (result.status == "200")
            {
                var QuizResult = new QuizResult
                {
                    score = Score.ToString(),
                    scoretime = resultmodel.TimeInSeconds.ToString(),
                    bestscore = "0",
                    bestscoretime = "0",
                };

                return RedirectToAction("QuizResult", new RouteValueDictionary(QuizResult));
            }
            else
            {
                ViewBag.msg = "Something went wrong";
                return View("ErrorView");
            }
        }

        public IActionResult PoleQuestion()
        {
            var token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Profile");
            }

            var predictlistOfTheDay = prediction.GetPredictionEventList(token);

            if (predictlistOfTheDay == null)
            {
                return RedirectToAction("PoleTime", "QuizQuestion");
            }
            ViewBag.QuestionOptions = predictlistOfTheDay;
            return View();
        }
        public IActionResult SubmitPrediction(int PredictedWinningTeamId, int EventId)
        {
            var token = HttpContext.Session.GetString("Token");

            var result = prediction.PostPrediction(EventId, PredictedWinningTeamId, token);

            return Ok("Success");
        }

        public IActionResult QuizResult(QuizResult result)
        {
            ViewBag.score = result.score;
            ViewBag.scoretime = result.scoretime;
            int dsr = int.Parse(result.scoretime);
            
            double nbd = Math.Round((double)dsr / 1000,2);

            ViewBag.bstt  = nbd.ToString();
            ViewBag.totalQestion = int.Parse(result.score) / 5; ;
            return View();

        }
        public IActionResult PoleTime()
        {
            return View();
        }

        public IActionResult NagadPoll()
        {
            var token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Profile");
            }
            var nagadPolls = nagadPoll.GetPoll(token);
            if (nagadPolls == null)
            {
                return RedirectToAction("PoleTime", "QuizQuestion");
            }
            ViewBag.NagadPoles = nagadPolls;
            return View();
        }
        public IActionResult SubmitNagadPoll(int questionId, int choiceId)
        {
            var token = HttpContext.Session.GetString("Token");
            var pollresult = nagadPoll.PostPoll(token, questionId, choiceId);
            return Ok("Success");
        }
        public IActionResult GotoHome()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
