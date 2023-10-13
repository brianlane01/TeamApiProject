using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TeamApiProject.Models.Posts;

namespace TeamApiProject.Services.Posts
{
    public interface IPostService
    {
        Task<PostListItem?> CreatePostAsync(PostCreate request);
        
        Task<IEnumerable<PostRegister>> GetAllPostsAsync();
        
    }
}