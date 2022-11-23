namespace NagadQuizWeb.Models
{
    public class CategoryModel
    {
        public int QuizCategoryId { get; set; }
        public string? Title { get; set; }
        public string? ParentId { get; set; }
        public string? BackgroundSource { get; set; }
        public int Level { get; set; }
    }
}