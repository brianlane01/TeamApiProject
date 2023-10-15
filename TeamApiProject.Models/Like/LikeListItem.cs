using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TeamApiProject.Data.Entities.Enums;

namespace TeamApiProject.Models.Like
{
    public class LikeListItem
    {
        [Required]
        public int Id { get; set; }
        public string LikeSelection { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        public LikeAction Action { get; set; }
    }
}