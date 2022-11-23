using NagadQuizWeb.Models;

namespace NagadQuizWeb.Repository
{
    public interface ICheckAnswer
    {
        public ResponseModel AnswerStatus(int questionId, int choiceId, string token);
    }
}
