using NagadQuizWeb.ViewModels;
using System.Collections.Generic;

namespace NagadQuizWeb.Repository
{
    public interface IProfileService
    {
        UserProfile GetUserProfile(string token);
        List<TopResult> GetResult(string token);
        List<TopResult> GetResultWeekly(string token);
        List<TopResult> GetYesterdaysResult(string token);
        bool ValidateCaptch(string capresn);
    }
}
