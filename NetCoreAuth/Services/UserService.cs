using NetCoreAuth.Infrastructures.Repositories;
using NetCoreAuth.Infrastructures.Services;
using NetCoreAuth.Models.DataModels;
using NetCoreAuth.Repositories;
using System;

namespace NetCoreAuth.Services
{
    public class UserService : IUserService
    {
        private readonly Func<IUserRepository> _userRepositoryFactory;

        public UserService()
        {
            _userRepositoryFactory = () => new UserRepository();
        }


        public User GetProfile(int id)
        {
            using var userRepo = _userRepositoryFactory.Invoke();
            return userRepo.GetProfile(id);
        }
    }
}
