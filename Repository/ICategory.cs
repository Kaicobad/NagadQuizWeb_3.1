using NagadQuizWeb.Models;

namespace NagadQuizWeb.Repository
{
    public interface ICategory
    {
        public ResponseModel GetCategories(string token);
    }
}
