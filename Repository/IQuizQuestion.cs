using NagadQuizWeb.Models;

namespace NagadQuizWeb.Repository
{
    public interface IQuizQuestion
    {
        public ResponseModel GetQuestion(string token);
    }
}
