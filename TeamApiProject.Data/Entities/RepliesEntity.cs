using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamApiProject.Data.Entities
{
    public class RepliesEntity
    {
        [Key]
        public int Id {get; set;}
        
        [Required]
        public int RepliesId {get; set;}
        [Required, MinLength(1), MaxLength(256)]
        public string Text {get; set;} = string.Empty;

        [Required]
        [ForeignKey(nameof(Comment))]
      
        public int ParentId {get; set;}
        public CommentEntity Comment {get; set;} = null;
        
        [Required]
        [ForeignKey(nameof(Replies))]
        public int AuthorId {get; set;}
        public UserEntity Replies {get; set;} = null!;




    
    }
}