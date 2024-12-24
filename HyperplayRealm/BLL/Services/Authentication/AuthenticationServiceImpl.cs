using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace BLL.Services.Authentication
{
    public class AuthenticationServiceImpl : IAuthentication
    {
        public async Task<ClaimsPrincipal> Authenticate(UserDTO user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("Id", user.Id.ToString()),
                new Claim("ProfilePicture", user.ProfilePicturePath ?? Constants.Constants.DEFAULT_PROFILE)
            };

            claims.AddRange(user.GetRoleClaims(user.MapTo()));

            Console.WriteLine(claims.Count);

            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); //cookie name

            return await Task.FromResult(new ClaimsPrincipal(userIdentity));
        }
    }
}
