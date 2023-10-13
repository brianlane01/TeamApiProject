using System.ComponentModel.DataAnnotations;

namespace TeamApiProject.Models.Posts
{
    public class PostCreate
    {
        [Required, MinLength(1), MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required, MinLength(1), MaxLength(500)]
        public string Text { get; set; } = string.Empty;

        [Required]
        public int AuthorId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}