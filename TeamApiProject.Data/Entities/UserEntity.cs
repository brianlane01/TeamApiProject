using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TeamApiProject.Data.Entities;

public class UserEntity : IdentityUser<int>
{
    [Key]
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;

    [Required]
    public DateTime DateCreated { get; set; }

    public virtual List<PostEntity> Posts {get; set;} = new List<PostEntity>();
    public virtual List<LikesEntity> Likes {get; set;} = new List<LikesEntity>();

}