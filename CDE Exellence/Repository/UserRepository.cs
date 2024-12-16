using CDE_Exellence.Data;
using CDE_Exellence.Model;
using Microsoft.EntityFrameworkCore;

namespace CDE_Exellence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }
    }
}
