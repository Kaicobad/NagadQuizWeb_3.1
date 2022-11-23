using NagadQuizWeb.Models;

namespace NagadQuizWeb.Repository
{
    public interface ISubmitResult
    {
        public ResponseModel PostSubmitResult(MatchResultModel result, string token);
    }
}
