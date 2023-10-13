using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApiProject.Models.User;

namespace TeamApiProject.Services.Likes
{
    public interface ILikesService
    {
        public void AddLike(int userId, int postId);
        int GetLikesCount(int postId);
        bool HasLiked(int userId, int postId);
    }
}