using NagadQuizWeb.Models;
using System.Collections.Generic;

namespace NagadQuizWeb.Repository
{
    public interface INagadPoll
    {
        public List<NagadPollModel> GetPoll(string token);
        public ResponseModel_NagadPoll PostPoll(string token, int questionId, int choiceId);
    }
}
