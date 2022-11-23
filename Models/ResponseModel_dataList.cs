using System.Collections.Generic;

namespace NagadQuizWeb.Models
{
    public class ResponseModel_dataList<T> where T : class
    {
        public int status { get; set; }
        public string message { get; set; }
        public string error { get; set; }
        public List<T> data { get; set; }
    }
}
