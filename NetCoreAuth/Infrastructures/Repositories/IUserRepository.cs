using NetCoreAuth.Models.DataModels;
using System;

namespace NetCoreAuth.Infrastructures.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User Login(string username, string password);
        User GetProfile(int id);
    }
}
