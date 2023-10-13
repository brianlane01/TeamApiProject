using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeamApiProject.Data.Entities
{
    public class PostEntity
    {
        [Required]
        [ForeignKey(nameof(User))]
        public int PostId { get; set; }

        public UserEntity User { get; set; }
    }
}