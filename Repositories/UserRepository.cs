using Microsoft.EntityFrameworkCore;
using RegisterMember.API.Models;

namespace RegisterMember.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            var userAdd = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return userAdd.Entity;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var userList = await _context.Users.ToListAsync();
            return userList;
        }
    }
}
