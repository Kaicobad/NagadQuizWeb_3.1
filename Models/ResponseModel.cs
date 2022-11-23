using System;

namespace NagadQuizWeb.Models
{
    public class ResponseModel
    {
        public string status { get; set; }
        public string message { get; set; }

        public Object data { get; set; }
        public string error { get; set; }
    }

    //public class Data
    //{
    //    public string message { get; set; }
    //    public bool isAuthenticated { get; set; }
    //    public string userName { get; set; }
    //    public string email { get; set; }
    //    //public string[,] roles { get; set; }
    //    public string token { get; set; }
    //}
}
