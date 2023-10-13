using TeamApiProject.Models.Comment

namespace TeamApiProject.Services.Comment
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentListItem>> GetAllCommentsAsync();
        Task<CommentListItem?> CreateCommentAsync(CommentCreate request);
        Task<CommentDetail?> GetCommentByPostIdAsync(int postId);
        Task<bool> UpdateCommentAsync(CommentUpdate request);
        task<bool> DeleteCommentAsync(int commentId);

    }
}