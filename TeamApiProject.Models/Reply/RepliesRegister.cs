using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamApiProject.Models.Reply
{
    public class RepliesRegister
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string Text {get; set;} = string.Empty;

        [Required]
        public int ParentId {get; set;}
        
        [Required]
        public int AuthorId {get; set;}
    }
}