using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApiProject.Models.User;
using TeamApiProject.Models.Like;
using TeamApiProject.Data.Entities.Enums;

namespace TeamApiProject.Services.Likes
{
    public interface ILikesService
    {
        Task<LikeListItem?> CreateLikeAsync(LikeCreate request);
        // public void AddLike(int userId, int postId);
        // int GetLikesCount(int postId);
        // bool HasLiked(int userId, int postId);
    }
}