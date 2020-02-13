using Bogus;
using NetCoreAuth.Models.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreAuth.Utilities
{
    public static class DataHelper
    {
        public static readonly List<string> AppPermissions = new List<string> { "view", "edit", "create", "delete" };

        public static Faker<string> PermissionFaker => new Faker<string>().RuleFor(_ => _, r => r.PickRandom(AppPermissions));

        public static List<Role> Roles = new List<Role>
        {
            new Role { Id = 1, Name = "Admin", Permissions = AppPermissions },
            new Role { Id = 3, Name = "User", Permissions = new List<string> { "view" } }
        };

        public static List<User> GenerateUsers()
        {

            var startId = 2;
            var faker = new Faker<User>()
                .RuleFor(_ => _.Id, r => startId++)
                .RuleFor(_ => _.Username, r => r.Internet.ExampleEmail())
                .RuleFor(_ => _.Password, r => r.Internet.Password())
                .RuleFor(_ => _.FirstName, r => r.Name.FirstName())
                .RuleFor(_ => _.LastName, r => r.Name.LastName())
                .RuleFor(_ => _.RoleId, r => r.PickRandom(1, 2));

            var result = faker.Generate(20).ToList();

            result.Add(new User
            {
                Id = 1,
                Username = "admin",
                Password = "123123",
                FirstName = "first name",
                LastName = "last name",
                RoleId = 1
            });

            return result;
        }
    }
}
