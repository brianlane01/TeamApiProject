using System.ComponentModel.DataAnnotations;


namespace TeamApiProject.Models.Comment
{
    public class CommentCreate
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public int AuthorId { get; set; }
        
        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(250, ErrorMessage = "{0} must be no more than {1} characters long")]
        public string Content { get; set; } = string.Empty;
    }
}