using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TeamApiProject.Data.Entities;

public class UserEntity : IdentityUser <int>
{
    [Key]
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(100)]

    public string Email { get; set; } = string.Empty;
    [MaxLength(100)]
    public string? FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string? LastName { get; set; } = string.Empty;

    [Required]
    public DateTime DateCreated { get; set; }

    public virtual List<PostsEntity> Posts {get; set;} = new List<PostsEntity>();
    public virtual List<LikesEntity> Likes {get; set;} = new List<LikesEntity>();
    public List<RepliesEntity> Replies {get; set;} = new List<RepliesEntity>();
    public virtual List<CommentEntity> Comments {get; set;}

}
