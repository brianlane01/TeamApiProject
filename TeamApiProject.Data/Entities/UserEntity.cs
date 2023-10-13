using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TeamApiProject.Data.Entities;

public class UserEntity : IdentityUser<int>
{
    [Key]
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public virtual List<CommentEntity> {get; set;}
    public virtual List<LikeEntity> {get; set;}

}