using NagadQuizWeb.Models;
using NagadQuizWeb.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace NagadQuizWeb.Repository
{
    public class UserProfileServices : IProfileService
    {
        public List<TopResult> GetResult(string token)
        {
            var textContents = new ResponseData<List<TopResult>>();

            try
            {
                var options = new RestClientOptions("https://nagadapi.shadhinquiz.com/api/Quiz/GetDailyLeaderboard?numberOfResults=20");
                var client = new RestClient(options);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.Execute(request);
                var content = response.Content;
                textContents = JsonConvert.DeserializeObject<ResponseData<List<TopResult>>>(content);
                return textContents.data;

            }
            catch
            {
                return textContents.data;

            }
        }

        public List<TopResult> GetYesterdaysResult(string token)
        {
            var textContents = new ResponseData<List<TopResult>>();
            try
            {
                var options = new RestClientOptions("https://nagadapi.shadhinquiz.com/api/Quiz/GetDailyWinners?numberOfResults=20");
                var client = new RestClient(options);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.Execute(request);
                var content = response.Content;
                textContents = JsonConvert.DeserializeObject<ResponseData<List<TopResult>>>(content);
                return textContents.data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public List<TopResult> GetResultWeekly(string token)
        {
            var textContents = new ResponseData<List<TopResult>>();

            try
            {
                var options = new RestClientOptions("https://nagadapi.shadhinquiz.com/api/Quiz/GetWeeklyLeaderboard?numberOfResults=20");
                var client = new RestClient(options);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.Execute(request);
                var content = response.Content;
                textContents = JsonConvert.DeserializeObject<ResponseData<List<TopResult>>>(content);
                return textContents.data;

            }
            catch
            {
                return textContents.data;

            }
        }

        public UserProfile GetUserProfile(string token)
        {
            var textContents = new ResponseData<UserProfile>();

            try
            {
                var options = new RestClientOptions("https://nagadapi.shadhinquiz.com/api/User/GetUserDetails");
                var client = new RestClient(options);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.Execute(request);
                var content = response.Content;
                textContents = JsonConvert.DeserializeObject<ResponseData<UserProfile>>(content);
                return textContents.data;

            }
            catch
            {
                return textContents.data;

            }


        }

        public bool ValidateCaptch(string capresn)
        {
            var options = new RestClientOptions(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", "6LdTSyEjAAAAAPGE7pjsAr-p7MilxiQmtVlAr14H", capresn));
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Post;
            RestResponse response = client.Execute(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<CaptchaResponse>(content);

            return false;
        }
    }
}
