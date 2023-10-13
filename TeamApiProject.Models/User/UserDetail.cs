using TeamApiProject.Data.Entities;

namespace TeamApiProject.Models.User
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? FirstName { get; set; }  
        public string? LastName { get; set; }  
        public virtual List<LikesEntity> Likes {get; set;} = new List<LikesEntity>();
        public virtual List<PostsEntity> Posts {get; set;} = new List<PostsEntity>();
        public DateTime DateCreated { get; set; }
    }
}