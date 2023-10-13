using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamApiProject.Data.Entities
{
    public class LikesEntity
    {

        public int Id { get; set; }

        public int PostId { get; set; }

        [Required]
        [ForeignKey(nameof(LdapStyleUriParser))]
        public int UserId { get; set; }

        public UserEntity User { get; set; }


    }

}
