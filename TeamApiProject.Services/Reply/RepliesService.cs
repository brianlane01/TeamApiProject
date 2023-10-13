
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamApiProject.Data;
using TeamApiProject.Data.Entities;
using TeamApiProject.Models.Reply;

namespace TeamApiProject.Services.Reply
{
    public class RepliesService : IRepliesService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly int _userId;

        public RepliesService(ApplicationDbContext dbContext){
            _dbContext = dbContext;
        }

public async Task<RepliesDetail?> GetUserbyIdAsync(int repliesId)
{
    RepliesEntity? entity = await _dbContext.Replies
        .FirstOrDefaultAsync(e => e.Id == repliesId && e.RepliesId == _userId);

    return entity is null ? null : new RepliesDetail
    {
        Id = entity.Id,
        Text = entity.Text,
        AuthorId = entity.AuthorId,
        ParentId = entity.ParentId
    };
}

        public async Task<RepliesListItem> CreateRepliesAsync(RepliesRegister model)
        {
            RepliesEntity entity = new()
            {
                Text = model.Text,
                AuthorId = model.AuthorId,
                ParentId = model.AuthorId

            };
            
            _dbContext.Replies.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if(numberOfChanges != 1)
                return null;
            
            RepliesListItem response = new()
            {
                Text = entity.Text,
                AuthorId = entity.AuthorId,
                ParentId = entity.ParentId
            };
            return response;
        }

        public async Task<IEnumerable<RepliesListItem>> GetAllRepliesAsync()
        {
            List<RepliesListItem> replies = await _dbContext.Replies
                .Where(entity => entity.AuthorId == _userId && entity.ParentId == _userId)
                .Select(entity => new RepliesListItem{
                    AuthorId = entity.AuthorId,
                    Text = entity.Text,
                    ParentId = entity.ParentId
                })
                .ToListAsync();
            return replies;
        }

        public async Task<bool> UpdateNoteAsync(RepliesUpdate request)
        {
            RepliesEntity? entity = await _dbContext.Replies.FindAsync(request.Id);

            if(entity?.RepliesId != _userId)
                return false;
            
            entity.Text = request.Text;
            entity.AuthorId = request.AuthorId;
            entity.ParentId = request.ParentId;

            int numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteRepliesAsync(int repliesId)
        {
            var repliesEntity = await _dbContext.Replies.FindAsync(repliesId);

            if(repliesEntity?.RepliesId != _userId)
                return false;

            _dbContext.Replies.Remove(repliesEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }

}