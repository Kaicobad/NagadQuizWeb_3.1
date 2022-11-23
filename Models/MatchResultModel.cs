using System;

namespace NagadQuizWeb.Models
{
    public class MatchResultModel
    {
        public string Msisdn { get; set; }
        public DateTime OnDate { get; set; }
        public int Score { get; set; }
        public int TimeInSeconds { get; set; }
    }
}
