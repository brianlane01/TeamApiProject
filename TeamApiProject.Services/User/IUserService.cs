using ElevenNote.Models.User;

namespace TeamApiProject.Services.User
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegister model);
        Task<UserDetail?> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserListItem>> GetAllUsersAsync();
    }
}