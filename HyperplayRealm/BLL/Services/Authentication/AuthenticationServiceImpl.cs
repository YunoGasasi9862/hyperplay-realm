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
                new Claim(ClaimTypes.Name, user.Name),
            };

            claims = await AddRoles(claims, user);

            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); //cookie name

            return await Task.FromResult(new ClaimsPrincipal(userIdentity));
        }

        private async Task<List<Claim>> AddRoles(List<Claim> existingClaims, UserDTO user)
        {
            foreach(string role in user.Roles)
            {
                existingClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            return await Task.FromResult(existingClaims);
        }
    }
}
