using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetUserAsync(UserModel userModel);
        Task<UserModel> CreateUserAsync(UserModel userModel);
    }
}
