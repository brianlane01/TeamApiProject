using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamApiProject.Models.Reply
{
    public class RepliesListItem
    {        
        public int Id {get; set;}
        public string Text {get; set;} = string.Empty;
        public int ParentId {get; set;}
        public int AuthorId {get; set;}
    }
}