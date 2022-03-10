using Mera.Quiz.Data.Database;
using Mera.Quiz.Data.Entities;
using Mera.Quiz.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User newUserEntity)
        {
            _context.Users.Add(newUserEntity);
            await _context.SaveChangesAsync();
            return newUserEntity;

        }

        public async Task<User> GetUserAsync(User userEntity)
        {
            var user = _context.Users.SingleOrDefault(u => (u.UserName == userEntity.UserName && u.Password == userEntity.Password));
            return user;
        }
    }
}
