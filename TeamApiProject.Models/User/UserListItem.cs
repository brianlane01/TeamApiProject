namespace TeamApiProject.Models.User
{
    public class UserListItem
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTimeOffset DateCreated { get; set; }
    }
}