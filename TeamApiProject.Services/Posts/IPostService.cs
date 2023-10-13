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
        
        async Task<IEnumerable<PostRegister>> GetAllPostsAsync()
        {
            List<PostRegister> posts = await _dbContext.Posts
                .Where(entity => entity.AuthourId == _userId)
                .Select(EntityEntry => new PostRegister
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Text = entity.Text,
                    DateCreated = entity.DateCreated
                })
                .ToListAsync();
                return posts;
        }
    }
}