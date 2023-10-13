using TeamApiProject.Models.Reply;

namespace TeamApiProject.Services.Reply
{
    public interface IRepliesService
    {
        Task<RepliesListItem> CreateRepliesAsync(RepliesRegister model);

        Task<IEnumerable<RepliesListItem>> GetAllRepliesAsync();
        Task<RepliesDetail?> GetUserbyIdAsync(int repliesId);
        Task<bool> UpdateNoteAsync(RepliesUpdate request);
        Task<bool> DeleteRepliesAsync(int repliesId);
    }
}