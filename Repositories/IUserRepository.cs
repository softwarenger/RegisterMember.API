using RegisterMember.API.Models;

namespace RegisterMember.API.Repositories
{
    public interface IUserRepository
    {
        Task<User>AddUser(User user);
        Task<List<User>> GetAllUsers();
    }
}
