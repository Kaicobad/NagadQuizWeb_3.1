using NagadQuizWeb.Models;
using System.Collections.Generic;

namespace NagadQuizWeb.Repository
{
    public interface IPrediction
    {
        public PredictionModel GetPredictionEvent(string token);
        public PredictionModel PostPrediction(int EventId, int PredictedWinningTeamId, string token);

        public List<PredictionModel> GetPredictionEventList(string token);
    }
}
