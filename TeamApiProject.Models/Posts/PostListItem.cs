namespace TeamApiProject.Models.Posts
{
    public class PostListItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }

    }

}