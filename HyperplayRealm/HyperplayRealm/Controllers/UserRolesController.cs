#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;
using BLL.Interfaces;
using BLL.DTOs;

// Generated from Custom Template.

namespace HyperplayRealm.Controllers
{
    public class UserRolesController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<UserRole, UserRoleDTO> _userRoleService;
        private readonly IDBOperations<Role, RoleDTO> _roleService;
        private readonly IDBOperations<User, UserDTO> _userService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public UserRolesController(
            IDBOperations<UserRole, UserRoleDTO> userRoleService
            , IDBOperations<Role, RoleDTO> roleService
            , IDBOperations<User, UserDTO> userService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _userRoleService = userRoleService;
            _roleService = roleService;
            _userService = userService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: UserRoles
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _userRoleService.Query().ToList();
            return View(list);
        }

        // GET: UserRoles/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _userRoleService.Query().SingleOrDefault(q => q.UserId == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["RoleId"] = new SelectList(_roleService.Query().ToList(), "Id", "Name");
            ViewData["UserId"] = new SelectList(_userService.Query().ToList(), "Id", "Name");
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: UserRoles/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: UserRoles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRoleDTO userRole)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                LoadResult result = await _userRoleService.Create(userRole.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = userRole.UserId });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(userRole);
        }

        // GET: UserRoles/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _userRoleService.Query().SingleOrDefault(q => q.UserId == id);
            SetViewData();
            return View(item);
        }

        // POST: UserRoles/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserRoleDTO userRole)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                LoadResult result = await _userRoleService.Update(userRole.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = userRole.UserId });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _userRoleService.Query().SingleOrDefault(q => q.UserId == id);
            return View(item);
        }

        // POST: UserRoles/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete item service logic:
            LoadResult result = await _userRoleService.Delete(id);
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
