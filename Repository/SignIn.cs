using NagadQuizWeb.Models;
using Newtonsoft.Json;
using RestSharp;

namespace NagadQuizWeb.Repository
{
    public class SignIn : ISignIn
    {
        ApiUrl apiurl = new ApiUrl();
        public ResponseModel GetUserStatus(string UserName)
        {
            var body = new
            {
                UserName = UserName
            };

            var options = new RestClientOptions(apiurl.SignInUrl)
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1  // 1 second
            };
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            RestResponse response = (RestResponse)client.Execute(request);
            var content = response.Content;

            var result = JsonConvert.DeserializeObject<ResponseModel>(content);
            return result;

        }
    }
}
