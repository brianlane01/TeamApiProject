using TeamApiProject.Data;
using TeamApiProject.Entities;
using Microsoft.AspNetCore.Identity;

namespace TeamApiProject.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly int _userId;
        private readonly int _postId

        public CommentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommentListItem?> CreateCommentAsync(CommentCreate request)
        {
            CommentEntity entity = new CommentEntity();
            {
                Content = request.Content,
                PostId = request.Post,
                AuthorId = request.AuthorId,
                DateCreated = DateTimeOffset.Now
            };

            _dbContext.Comments.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges != 1)
                return null;

            CommentListItem response = new()
            {
                Id = entity.Id,
                Content = entity.Content,
                DateCreated = entity.DateCreated,
                PostId = entity.PostId,
                AuthorId = entity.AuthorId
            };

            return response; 
        }

        public async Task<IEnumerable<CommentListItem>> GetAllCommentsAsync()
        {
            List<CommentListItem> comments = await _dbContext.Comments
            .Select(entity => new CommentListItem
            {
                Id = entity.Id,
                PostId = entity.PostId,
                Content = entity.Content,
                DateCreated = entity.DateCreated
            })
            .ToListAsync();

            return comments;
        }

        public async Task<CommentDetail?> GetCommentByPostId(int postId)
        {
            CommentEntity? entity = await _dbContext.Comments
                .FirstOrDefaultAsync(e => e.Id == postId);

            return entity is null ? null : new CommentDetail
            {
                Id = entity.Id,
                Content = entity.Content,
                AuthorId = entity.AuthorId,
                DateCreated = entity.DateCreated,
                DateModified = entity.DateModified
            }; 
        }

        public async Task<bool> UpdateCommentAsync(CommentUpdate request)
        {
            CommentEntity? entity await _dbContext.Comments.FindAsync(request.Id);

            if(entity?)
                return false;

            entity.Content = request.Content;
            entity.AuthorId = request.AuthorId;
            entity.PostId = request.postId;
            entity.DateModified = DateTimeOffset.Now;

            int numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1; 
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var commentEntity = await _dbContext.Comments.FindAsync(commentId);

            if (commentEntity?)
                return false;

            _dbContext.Comments.Remove(commentEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }       
    }
}