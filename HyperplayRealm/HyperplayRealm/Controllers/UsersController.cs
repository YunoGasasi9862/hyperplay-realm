#nullable disable
using Microsoft.AspNetCore.Mvc;
using BLL.Controllers.Bases;
using BLL.Models;
using BLL.Interfaces;
using BLL.DTOs;
using BLL.Services;

// Generated from Custom Template.

namespace HyperplayRealm.Controllers
{
    public class UsersController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<User, UserDTO> UserOperations;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public UsersController(
            IDBOperations<User, UserDTO> userOperations

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            UserOperations = userOperations;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Users
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = UserOperations.Query().ToList();
            return View(list);
        }

        // GET: Users/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = UserOperations.Query().SingleOrDefault(q => q.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                LoadResult result = await UserOperations.Create(user.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = user.Id });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = UserOperations.Query().SingleOrDefault(q => q.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Users/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                LoadResult result = await UserOperations.Update(user.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = user.Id });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = UserOperations.Query().SingleOrDefault(q => q.Id == id);
            return View(item);
        }

        // POST: Users/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = await UserOperations.Delete(id);
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
