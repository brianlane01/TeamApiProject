using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamApiProject.Services.Likes
{
    public interface ILikesService
    {
        public async Task<UserDetail?> AddLike(int userId, int postId);
        int GetLikesCount(int postId);
        bool HasLiked(int userId, int postId);
    }
}