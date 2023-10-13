using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamApiProject.Data.Entities
{
    public class PostsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(1), MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required, MinLength(1), MaxLength(500)]
        public string Text { get; set; } = string.Empty;
        [Required]
        [ForeignKey(nameof(AuthorId))]
        public int AuthorId { get; set; }
        public UserEntity Author { get; set; } = null!;
        
        

    }
}