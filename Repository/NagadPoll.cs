using NagadQuizWeb.Models;
using NagadQuizWeb.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace NagadQuizWeb.Repository
{
    public class NagadPoll : INagadPoll
    {
        public List<NagadPollModel> GetPoll(string token)
        {
            ResponseModel_dataList<NagadPollModel>? Contents = new ResponseModel_dataList<NagadPollModel>();
            try
            {
                var options = new RestClientOptions("https://nagadapi.shadhinquiz.com/api/Pole/GetPoles");
                var client = new RestClient(options);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.Execute(request);
                var content = response.Content;

                Contents = JsonConvert.DeserializeObject<ResponseModel_dataList<NagadPollModel>>(content);

                return Contents.data;

            }
            catch
            {
               return Contents.data;

            }
        }

        public ResponseModel_NagadPoll PostPoll(string token, int questionId, int choiceId)
        {
            //ResponseData<ResponseModel_NagadPoll>? txtContents = new ResponseData<ResponseModel_NagadPoll>();
            ResponseModel_NagadPoll txtContents = new ResponseModel_NagadPoll();
            try
            {         
                var options = new RestClientOptions("https://nagadapi.shadhinquiz.com/api/Pole/IsCorrectPoleResponse?questionId=" + questionId + "&choiceId=" + choiceId + "");
                var client = new RestClient(options);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.Execute(request);
                var content = response.Content;

                 txtContents = JsonConvert.DeserializeObject<ResponseModel_NagadPoll>(content);

                return txtContents;
            }
            catch
            {
                return txtContents;
            }
        }
    }
}
