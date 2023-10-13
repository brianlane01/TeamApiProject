using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApiProject.Models.Posts;

namespace TeamApiProject.Services.Posts
{
    public interface IPostService
    {
        Task<bool> RegisterPostAsync(PostRegister model);
    }
}