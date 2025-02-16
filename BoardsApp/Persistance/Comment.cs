﻿namespace BoardsApp.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
