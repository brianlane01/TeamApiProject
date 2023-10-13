using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamApiProject.Models.Posts
{
    public class PostRegister
    {
        [Required, MinLength(1), MaxLength(100)]
        public string Title { get; set; }
        [Required, MinLength(1), MaxLength(500)]
        public string Text { get; set; }
    }
}