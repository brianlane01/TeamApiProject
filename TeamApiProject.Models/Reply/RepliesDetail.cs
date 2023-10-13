namespace TeamApiProject.Models.Reply
{
    public class RepliesDetail
    {

        public int Id {get; set;}
        public string Text {get; set;} = string.Empty;
        public int ParentId {get; set;}
        public int AuthorId {get; set;}
    }
}