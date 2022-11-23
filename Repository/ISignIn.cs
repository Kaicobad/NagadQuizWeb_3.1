using NagadQuizWeb.Models;

namespace NagadQuizWeb.Repository
{
    public interface ISignIn
    {
        public ResponseModel GetUserStatus(string UserName);
    }
}
