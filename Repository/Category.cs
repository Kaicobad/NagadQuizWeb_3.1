using NagadQuizWeb.Models;
using Newtonsoft.Json;
using NuGet.Common;
using RestSharp;

namespace NagadQuizWeb.Repository
{
    public class Category : ICategory
    {
        ApiUrl apiUrl = new ApiUrl();
        public ResponseModel GetCategories(string token)
        {
            var client = new RestClient(apiUrl.GameCategoryUrl);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("bearer", token);
            request.AddHeader("Content-Type", "application/json");

            var response = client.Execute(request);
            var content = response.Content;

            var result = JsonConvert.DeserializeObject<ResponseModel>(content);
            return result;
        }
    }
}
