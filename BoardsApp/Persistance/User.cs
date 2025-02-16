namespace BoardsApp.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<AnswerLike> AnswerLikes { get; set; } = new List<AnswerLike>();

        public List<Question> Questions { get; set; } = new List<Question>();

        public List<Answer> Answers { get; set; } = new List<Answer>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
