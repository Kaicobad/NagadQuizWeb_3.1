namespace NagadQuizWeb.Models
{
    public class ResponseModel_NagadPoll
    {
        public int status { get; set; }
        public string message { get; set; }
        public bool data { get; set; }
        public dynamic error { get; set; }

        //    "status": 200,
        //"message": "You know the deal",
        //"data": true,
        //"error": null
    }
}
