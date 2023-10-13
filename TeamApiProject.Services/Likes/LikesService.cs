using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApiProject.Models.User;

namespace TeamApiProject.Services.Likes
{
    public class LikesService : ILikesService
    {

        private Dictionary<int, List<int>> postLikes = new Dictionary<int, List<int>>();

        public void AddLike(int userId, int postId)
        {
            if (!postLikes.ContainsKey(postId))
            {
                postLikes[postId] = new List<int>();
            }

            if (!postLikes[postId].Contains(userId))
            {
                postLikes[postId].Add(userId);
            }
        
        }

        public int GetLikesCount(int postId)
        {
            if (postLikes.ContainsKey(postId))
            {
                return postLikes[postId].Count;
            }

            return 0;
        }

        public bool HasLiked(int userId, int postId)
        {
            if (postLikes.ContainsKey(postId))
            {
                return postLikes[postId].Contains(userId);
            }

            return false;
        }
    }
}

