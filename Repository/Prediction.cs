using NagadQuizWeb.Models;
using NagadQuizWeb.ViewModels;
using Newtonsoft.Json;
using NuGet.Common;
using RestSharp;
using System.Collections.Generic;

namespace NagadQuizWeb.Repository
{
    public class Prediction : IPrediction
    {
        public PredictionModel GetPredictionEvent(string token)
        {
            ResponseData<PredictionModel>? Contents = new ResponseData<PredictionModel>();
            try
            {
                var options = new RestClientOptions("https://nagadapi.shadhinquiz.com/api/Events/GetAllEvents");
                var client = new RestClient(options);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.Execute(request);
                var content = response.Content;

                Contents = JsonConvert.DeserializeObject<ResponseData<PredictionModel>>(content);

                return Contents.data;

            }   
            catch
            {
                return null;

            }


        }

        public List<PredictionModel> GetPredictionEventList(string token)
        {
            ResponseModel_dataList<PredictionModel> txtContents = new ResponseModel_dataList<PredictionModel>();

            try
            {
                var options = new RestClientOptions("https://nagadapi.shadhinquiz.com/api/Events/GetAllEvents");
                var client = new RestClient(options);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.Execute(request);
                var content = response.Content;

                txtContents = JsonConvert.DeserializeObject<ResponseModel_dataList<PredictionModel>>(content);

                return txtContents.data;

            }
            catch
            {
                return txtContents.data; ;

            }
        }

        public PredictionModel PostPrediction(int EventId, int PredictedWinningTeamId, string token)
        {
            ResponseData<PredictionModel>? Contents = new ResponseData<PredictionModel>();
            try
            {
                var body = new
                {
                    EventId = EventId,
                    PredictedWinningTeamId = PredictedWinningTeamId
                };

                var options = new RestClientOptions("https://nagadapi.shadhinquiz.com/api/Events/SubmitPrediction")
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
                string? content = response.Content;
                Contents = JsonConvert.DeserializeObject<ResponseData<PredictionModel>>(content);

                return Contents.data;
            }
            catch
            {
                return Contents.data; ;
            }
            
        }
    }
}
