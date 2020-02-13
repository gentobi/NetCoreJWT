using Microsoft.AspNetCore.Http;
using NetCoreAuth.Utilities;
using System;
using System.Linq;

namespace NetCoreAuth.Configurations
{
    public static class HttpContextExtensions
    {
        private static string GetClaimValue(HttpContext context, string claimName)
        {
            return context.User.Claims.FirstOrDefault(x => x.Type == claimName)?.Value;
        }

        public static int UserId(this HttpContext context)
        {
            return GetClaimValue(context, AppClaimType.Id).ToInt();
        }

        public static string Username(this HttpContext context)
        {
            return GetClaimValue(context, AppClaimType.Username);
        }

        public static string FirstName(this HttpContext context)
        {
            return GetClaimValue(context, AppClaimType.FirstName);
        }

        public static int UserRoleId(this HttpContext context)
        {
            return GetClaimValue(context, AppClaimType.RoleId).ToInt();
        }

        public static string AccessToken(this HttpContext context)
        {
            return GetToken(context?.Request?.Headers?["Authorization"]);
        }

        private static string GetToken(string authorizationHeader)
        {
            if (authorizationHeader == null)
            {
                return null;
            }

            var arr = authorizationHeader.Split(" ");
            if (arr.Length != 2 || arr[1] == "null")
            {
                return null;
            }

            return arr[1];
        }

        private static int ToInt(this object input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch
            {
                return 0;
            }
        }
    }
}
