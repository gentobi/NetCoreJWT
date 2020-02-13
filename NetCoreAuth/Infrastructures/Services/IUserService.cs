using NetCoreAuth.Models.DataModels;

namespace NetCoreAuth.Infrastructures.Services
{
    public interface IUserService
    {
        public User GetProfile(int id);
    }
}
