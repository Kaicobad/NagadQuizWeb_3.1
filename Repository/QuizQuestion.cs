
using NagadQuizWeb.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace NagadQuizWeb.Repository
{
    public class QuizQuestion : IQuizQuestion
    {
        public ResponseModel GetQuestion(string token)
        {
            ApiUrl apiUrl = new ApiUrl();

            //string url = apiUrl.GetQuestionByCategory + "" + categoryId + "";
            string url = apiUrl.GetQuestionForMatch;
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");

            var response = client.Execute(request);
            var content = response.Content;

            var result = JsonConvert.DeserializeObject<ResponseModel>(content);
            return result;
        }
    }
}
