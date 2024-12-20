#nullable disable
using Microsoft.AspNetCore.Mvc;
using BLL.Controllers.Bases;
using BLL.Models;
using BLL.Interfaces;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using BLL.Load;

// Generated from Custom Template.

namespace HyperplayRealm.Controllers
{
    public class UsersController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<User, UserDTO> m_userOperations;
        private readonly IAuthentication m_authentication;
        private readonly IEncrypt m_encrypt;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public UsersController(
            IDBOperations<User, UserDTO> userOperations,
            IAuthentication authentication,
            IEncrypt encrypt

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            m_userOperations = userOperations;
            m_authentication = authentication;
            m_encrypt = encrypt;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Users/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserDTO user)
        {
            //use hashed password and then compare!
            UserDTO userDto = m_userOperations.Query().SingleOrDefault();
            if (userDto is not null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, userDto.Username),
                    new Claim("Id", userDto.Id.ToString())
                };

                claims.AddRange(userDto.GetRoleClaims());

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // CookieAuthenticationDefaults.AuthenticationScheme = cookie name
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, await m_authentication.Authenticate(user));
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                user.Password = await m_encrypt.Encrypt(user.Password);
                Console.WriteLine($"New Password {user.Password}");
                LoadResult loadResult = await m_userOperations.Create(user.MapTo());
                TempData["Message"] = loadResult.Result.Message;
                if (loadResult.Result.IsSuccessfull)
                {
                    return RedirectToAction(nameof(Details), new { id = user.Id });
                }
            }

            return View(user);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
