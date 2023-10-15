using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamApiProject.Models.User;
using TeamApiProject.Models.Like;
using TeamApiProject.Data;
using TeamApiProject.Data.Entities;
using TeamApiProject.Data.Entities.Enums;

namespace TeamApiProject.Services.Likes
{
    public class LikesService : ILikesService
    {
        private readonly ApplicationDbContext _dbContext;

        public LikesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LikeListItem?> CreateLikeAsync(LikeCreate request)
        {

            if (request.Action == LikeAction.Like)
            {
                request.LikeSelection = $"User with Id: {request.UserId} liked the post.";
            }
            else if (request.Action == LikeAction.Disliked)
            {
                request.LikeSelection = $"User with Id: {request.UserId} has disliked the post.";
            }

            LikesEntity entity = new LikesEntity()
            {
                PostId = request.PostId,
                UserId = request.UserId,
                Action = request.Action,
                LikeSelection = request.LikeSelection
            };

            _dbContext.Likes.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges != 1)
                return null;

            LikeListItem response = new()
            {
                Id = entity.Id,
                PostId = entity.PostId,
                UserId = entity.UserId,
                Action = entity.Action,
                LikeSelection = entity.LikeSelection
            };

            return response;
        }

        // public async Task<bool> LikePostAsync(int postId, int userId, LikeAction action)
        // {
        //     // Check if the user has already liked or disliked the post.
        //     bool hasLikedOrDisliked = await _dbContext.Likes
        //         .AnyAsync(like => like.PostId == postId && like.UserId == userId);

        //     if (hasLikedOrDisliked)
        //     {
        //         // The user has already liked or disliked the post, handle accordingly (e.g., return false or update the like action).
        //         // You can implement logic to update the action if needed.
        //         return false;
        //     }

        //     // Create a new like entity with the specified action.
        //     LikesEntity like = new LikesEntity
        //     {
        //         PostId = postId,
        //         UserId = userId,
        //         Action = action
        //     };

        //     _dbContext.Likes.Add(like);
        //     await _dbContext.SaveChangesAsync();

        //     return true;

        // }


        // private Dictionary<int, List<int>> postLikes = new Dictionary<int, List<int>>();

        // public void AddLike(int userId, int postId)
        // {
        //     if (!postLikes.ContainsKey(postId))
        //     {
        //         postLikes[postId] = new List<int>();
        //     }

        //     if (!postLikes[postId].Contains(userId))
        //     {
        //         postLikes[postId].Add(userId);
        //     }

        // }

        // public int GetLikesCount(int postId)
        // {
        //     if (postLikes.ContainsKey(postId))
        //     {
        //         return postLikes[postId].Count;
        //     }

        //     return 0;
        // }

        // public bool HasLiked(int userId, int postId)
        // {
        //     if (postLikes.ContainsKey(postId))
        //     {
        //         return postLikes[postId].Contains(userId);
        //     }

        //     return false;
        // }
    }
}

