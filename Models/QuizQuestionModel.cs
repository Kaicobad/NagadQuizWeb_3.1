namespace NagadQuizWeb.Models
{
    public class QuizQuestionModel
    {
        public int questionId { get; set; }
        public string question { get; set; }
        public bool isActive { get; set; }
        public int quizCategoryId { get; set; }
        public int quizType { get; set; }
        public object choices { get; set; }
    }
}
