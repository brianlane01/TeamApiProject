using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamApiProject.Data.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MinLength(1), MaxLength(250)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int AuthorId { get; set; }
        public UserEntity User  {get; set;}

        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public PostEntity Post { get; set; }

        public virtual List<RepliesEntity> Replies {get; set;}

    }
}