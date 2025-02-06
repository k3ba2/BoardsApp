namespace BoardsApp.Entities
{
    public class Question
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<QuestionTag> QuestionTags { get; set; } = new List<QuestionTag>();

        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
