using Mera.Quiz.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(User userEntity);
        Task<User> CreateUserAsync(User newUserEntity);
    }
}
