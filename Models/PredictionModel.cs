using System;

namespace NagadQuizWeb.Models
{
    public class PredictionModel
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public int TeamA_Id { get; set; }
        public int TeamB_Id { get; set; }
        public DateTime EventDateTime { get; set; }
        public DateTime LastPredictionTime { get; set; }
        public string PredictionStatus { get; set; }
        public string UserEligibleForPrediction { get; set; }

    }
}
