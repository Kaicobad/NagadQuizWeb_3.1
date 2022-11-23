using NagadQuizWeb.Models;
using Newtonsoft.Json;
using NuGet.Common;
using RestSharp;

namespace NagadQuizWeb.Repository
{
    public class CheckAnswer : ICheckAnswer
    {
        public ResponseModel AnswerStatus(int questionId, int choiceId,string token)
        {
            ApiUrl apiUrl = new ApiUrl();
            //string url = apiUrl.GetAnswerStatus;
            var client = new RestClient("https://nagadapi.shadhinquiz.com/api/Quiz/IsCorrectChoice?questionId=" + questionId +"&choiceId="+ choiceId + "");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("questionId", questionId);

            var response = client.Execute(request);
            var content = response.Content;

            var result = JsonConvert.DeserializeObject<ResponseModel>(content);
            return result;
        }
    }
}
