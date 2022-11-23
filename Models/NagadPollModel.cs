using System;

namespace NagadQuizWeb.Models
{
    public class NagadPollModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public bool IsActive { get; set; }
        public int QuizCategoryId { get; set; }
        public int QuizType { get; set; }
        public DateTime OnDate { get; set; }
        public int QuestionScore { get; set; }
        public string ImageLocation { get; set; }
        public object Choices { get; set; }

        //"questionId": 641,
        //    "question": "১) নগদ অ্যাপ থেকে ক্যাশআউট চার্জ কতো ?",
        //    "isActive": true,
        //    "quizCategoryId": 3,
        //    "quizType": 3,
        //    "onDate": "2022-11-17T00:00:00",
        //    "questionScore": 1,
        //    "imageLocation": null,
        //    "choices":
        
    }
}
