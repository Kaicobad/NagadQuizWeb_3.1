using static System.Net.WebRequestMethods;

namespace NagadQuizWeb.Models
{
    public class ApiUrl
    {
        public string RegisterUrl = "https://nagadapi.shadhinquiz.com/api/User/Register";
        public string SignInUrl = "https://nagadapi.shadhinquiz.com/api/User/NagadSignIn";
        public string OtpGetUrl = "https://gakkpay.bkash.shadhin.co/api/otpreq";
        public string OtpValidateUrl = "https://gakkpay.bkash.shadhin.co/api/otpcheck";
        public string UpdatePasswordUrl = "https://nagadapi.shadhinquiz.com/api/User/UpdatePassword";
        public string GameCategoryUrl = "https://nagadapi.shadhinquiz.com/api/Quiz/Categories";
        public string GetQuestionByCategory = "https://nagadapi.shadhinquiz.com/api/Quiz/QuestionsByCategory?categoryId=";
        public string GetQuestionForMatch = "https://nagadapi.shadhinquiz.com/api/Quiz/GetQuestionsForAMatch";
        public string GetAnswerStatus = "https://nagadapi.shadhinquiz.com/api/Quiz/IsCorrectChoice";
        public string SubmitMatchResultUrl = "https://nagadapi.shadhinquiz.com/api/Quiz/MatchResult";
    }
}
