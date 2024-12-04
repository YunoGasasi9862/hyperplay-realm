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
    public class RolesController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<Role, RoleDTO> _roleService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public RolesController(
            IDBOperations<Role, RoleDTO> roleService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _roleService = roleService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Roles
        public IActionResult Index()
        {
            // Get collection service logic:
            List<RoleDTO> list = _roleService.Query().ToList();
            return View(list);
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Get item service logic:
            RoleDTO item = _roleService.Query().SingleOrDefault(q => q.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleDTO role)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                LoadResult result = await _roleService.Create(role.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = role.Id });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(role);
        }

        // GET: Roles/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            RoleDTO item = _roleService.Query().SingleOrDefault(q => q.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Roles/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleDTO role)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                LoadResult result = await _roleService.Update(role.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = role.Id });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(role);
        }

        // GET: Roles/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            RoleDTO item = _roleService.Query().SingleOrDefault(q => q.Id == id);
            return View(item);
        }

        // POST: Roles/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete item service logic:
            LoadResult result = await _roleService.Delete(id);
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
