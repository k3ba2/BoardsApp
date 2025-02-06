namespace BoardsApp.Entities
{
    public class AnswerLike
    {
        public int UserId { get; set; }
        public int AnswerId { get; set; }
        public bool IsUpvote { get; set; }  // true = like, false = dislike

        public Answer Answer { get; set; }
        public User User { get; set; }
    }
}
