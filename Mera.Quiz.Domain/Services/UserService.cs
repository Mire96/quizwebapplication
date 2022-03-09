using AutoMapper;
using Mera.Quiz.Data.Entities;
using Mera.Quiz.Data.Interfaces;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> CreateUserAsync(UserModel userModel)
        {
            var newUserEntity = _mapper.Map<UserModel, User>(userModel);
            var createdUserEntity = await _userRepository.CreateUserAsync(newUserEntity);

            var createdUserModel = _mapper.Map<User, UserModel>(createdUserEntity);
            return createdUserModel;
        }

        public async Task<UserModel> GetUserAsync(UserModel userModel)
        {
            var userEntity = _mapper.Map<UserModel, User>(userModel);
            var verifiedUserEntity = await _userRepository.GetUserAsync(userEntity);

            var verifiedUserModel = _mapper.Map<User, UserModel>(verifiedUserEntity);

            return verifiedUserModel;
        }
    }
}
