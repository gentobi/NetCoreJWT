using NetCoreAuth.Infrastructures.Repositories;
using NetCoreAuth.Models.DataModels;
using NetCoreAuth.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreAuth.Repositories
{
    public class UserRepository : IUserRepository
    {
        public static List<User> Users = DataHelper.GenerateUsers();

        public UserRepository()
        {
        }

        public User Login(string username, string password)
        {
            return Users.SingleOrDefault(_ => _.Username == username && _.Password == password)
                   ?? throw new Exception("Invalid user name or password");
        }

        public User GetProfile(int id)
        {
            return Users.SingleOrDefault(_ => _.Id == id);
        }

        public void Dispose()
        {
            // TODO: release resources
        }
    }
}
