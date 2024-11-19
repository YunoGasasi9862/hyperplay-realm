#nullable disable
using Microsoft.AspNetCore.Mvc;
using BLL.Controllers.Bases;
using BLL.Models;
using BLL.Interfaces;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

// Generated from Custom Template.

namespace HyperplayRealm.Controllers
{
    public class UsersController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<User, UserDTO> m_userOperations;
        private readonly IAuthentication m_authentication;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public UsersController(
            IDBOperations<User, UserDTO> userOperations,
            IAuthentication authentication

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            m_userOperations = userOperations;
            m_authentication = authentication;

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
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, await m_authentication.Authenticate(user));
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

    }
}
