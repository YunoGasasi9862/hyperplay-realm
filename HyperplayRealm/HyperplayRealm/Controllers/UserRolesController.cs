#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;

// Generated from Custom Template.

namespace HyperplayRealm.Controllers
{
    public class UserRolesController : MvcController
    {
        // Service injections:
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public UserRolesController(
			IUserRoleService userRoleService
            , IRoleService roleService
            , IUserService userService

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
            var item = _userRoleService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["RoleId"] = new SelectList(_roleService.Query().ToList(), "Record.Id", "Name");
            ViewData["UserId"] = new SelectList(_userService.Query().ToList(), "Record.Id", "Name");
            
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
        public IActionResult Create(UserRoleModel userRole)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _userRoleService.Create(userRole.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = userRole.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(userRole);
        }

        // GET: UserRoles/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _userRoleService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: UserRoles/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserRoleModel userRole)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _userRoleService.Update(userRole.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = userRole.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _userRoleService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: UserRoles/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _userRoleService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
