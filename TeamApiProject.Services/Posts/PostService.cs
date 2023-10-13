using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Identity;
using TeamApiProject.Data;
using TeamApiProject.Data.Entities;
using TeamApiProject.Models.Posts;
using TeamApiProject.Models.Posts;

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
    }
    public async Task<PostListItem?> CreatePostAsync(PostCreate request)
    {
        PostsEntity entity = new()
        {
            Title = entity.Title,
                    Text = entity.Text,
                    DateCreated = entity.DateCreated
        };
        return response;
    }
}