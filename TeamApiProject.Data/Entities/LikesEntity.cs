using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeamApiProject.Data.Entities.Enums;

namespace TeamApiProject.Data.Entities
{
    public class LikesEntity
    {

        public int Id { get; set; }

        public LikeAction Action { get; set; }
        public string? LikeSelection { get; set; } = string.Empty;

        [Required]
        public int PostId { get; set; }
        public PostsEntity Post { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public UserEntity User { get; set; }

    }

}
