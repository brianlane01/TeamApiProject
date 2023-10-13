namespace TeamApiProject.Models.Comment
{
    public class CommentDetail
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }
    }
}