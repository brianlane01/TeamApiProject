using TeamApiProject.Models.User;
using TeamApiProject.Data.Entities;
using TeamApiProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TeamApiProject.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserService(ApplicationDbContext dbContext,
                            UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserDetail?> GetUserByIdAsync(int userId)
        {
            UserEntity? entity = await _dbContext.Users.FindAsync(userId);
            if(entity is null)
                return null;
            
            UserDetail detail = new UserDetail()
            {
                Id = entity.Id,
                Email = entity.Email,
                UserName = entity.UserName!,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Posts = entity.Posts,
                Likes = entity.Likes,
                DateCreated = entity.DateCreated
            };

            return detail;
        }

        public async Task<bool> RegisterUserAsync(UserRegister model)
        {   
            if(await CheckEmailAvailability(model.Email) == false)
            {
                System.Console.WriteLine("Please Try a Different Email, Email Entered Linked To Existing Account.");
                return false;
            }

            if(await CheckUserNameAvailability(model.UserName) == false)
            {
                System.Console.WriteLine("UserName already taken please try again");
                return false; 
            }

            UserEntity entity = new UserEntity()
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateCreated = DateTime.Now
            };

            IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);

            return registerResult.Succeeded;
        }

        public async Task<IEnumerable<UserListItem>> GetAllUsersAsync()
        {
            List<UserListItem> users = await _dbContext.Users
            .Select(entity => new UserListItem
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateCreated = entity.DateCreated
            })
            .ToListAsync();

            return users;
        }

        private async Task<bool> CheckUserNameAvailability(string userName)
        {
            UserEntity? existingUser = await _userManager.FindByNameAsync(userName);
            return existingUser is null;
        }

        private async Task<bool> CheckEmailAvailability(string email)
        {
            UserEntity? existingUser = await _userManager.FindByEmailAsync(email);
            return existingUser is null; 
        }
    }
}