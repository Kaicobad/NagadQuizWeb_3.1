namespace NagadQuizWeb.ViewModels
{
    public class ResponseData<T> where T : class {
        public int status { get; set; }
        public string message { get; set; }
        public string error { get; set; }
        public T data { get; set; }

    }
}
