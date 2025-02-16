namespace BoardsApp.Entities
{
    public class Answer
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int QuestionId { get; set; }

        public int UserId { get; set; }

        public Question Question { get; set; }

        public User User { get; set; }

        public List<AnswerLike> AnswerLikes { get; set; } = new List<AnswerLike>();
    }
}
