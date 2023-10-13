namespace TeamApiProject.Models.Comment
{
    public class CommentListItem
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; } = string.Empty;
        public virtual List<RepliesEntity> Replies {get; set;}
        public DateTimeOffset DateCreated { get; set; }
    }
}