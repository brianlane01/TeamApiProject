using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamApiProject.Models.Posts
{
    public class PostRegister
    {
        public int Id {get;set;}
        [Required, MinLength(1), MaxLength(100)]
        public string Title { get; set; }
        [Required, MinLength(1), MaxLength(500)]
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public DateTime DateCreated {get; set;}
    }
}