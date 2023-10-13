using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Identity;
using TeamApiProject.Data;
using TeamApiProject.Data.Entities;
using TeamApiProject.Models.Posts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TeamApiProject.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly int _userId;
        public PostService(UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager,
                            ApplicationDbContext dbContext)
        {
            var currentUser = signInManager.Context.User;
            var userIdClaim = userManager.GetUserId(currentUser);
            var hasValidId = int.TryParse(userIdClaim, out _userId);

            if (hasValidId == false)
                throw new Exception("Attempted to build without ID claim.");

            _dbContext = dbContext;
        }

        public async Task<PostListItem?> CreatePostAsync(PostCreate request)
        {
            PostsEntity entity = new()
            {
                Title = request.Title,
                Text = request.Text,
                AuthorId = request.AuthorId,
                DateCreated = DateTime.Now
            };

            _dbContext.Posts.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            
            if(numberOfChanges != 1)
                return null;

            PostListItem response = new()
            {
                Id = entity.Id,
                Title = entity.Title,
                AuthorId = entity.AuthorId,
                Text = entity.Text,
                DateCreated = DateTime.Now
            };
            return response;
        }
        public async Task<IEnumerable<PostRegister>> GetAllPostsAsync()
        {
            List<PostRegister> posts = await _dbContext.Posts
                .Where(entity => entity.AuthorId == _userId)
                .Select(entity => new PostRegister
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