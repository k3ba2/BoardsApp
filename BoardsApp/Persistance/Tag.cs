namespace BoardsApp.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public List<QuestionTag> QuestionTags { get; set; } = new List<QuestionTag>();
    }
}
