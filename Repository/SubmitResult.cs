using NagadQuizWeb.Models;
using Newtonsoft.Json;
using NuGet.Common;
using RestSharp;

namespace NagadQuizWeb.Repository
{
    public class SubmitResult : ISubmitResult
    {
        public ResponseModel PostSubmitResult(MatchResultModel result,string token)
        {
            ApiUrl apiUrl = new ApiUrl();
            var body = new
            {
                Msisdn = result.Msisdn,
                OnDate = result.OnDate,
                Score = result.Score,
                TimeInSeconds = result.TimeInSeconds
            };

            var options = new RestClientOptions(apiUrl.SubmitMatchResultUrl)
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1  // 1 second
            };
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + token);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            RestResponse response = client.Execute(request);
            var content = response.Content;
            var result2 = JsonConvert.DeserializeObject<ResponseModel>(content);

            return result2;
        }
    }
}
