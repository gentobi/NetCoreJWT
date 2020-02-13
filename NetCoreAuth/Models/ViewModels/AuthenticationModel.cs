using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NetCoreAuth.Models.ViewModels
{
    public class AuthenticationModel
    {
        [NotNull, MinLength(3)]
        public string Username { get; set; }
        [NotNull, MinLength(6)]
        public string Password { get; set; }
    }
}