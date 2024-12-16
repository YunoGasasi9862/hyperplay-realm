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
    public class DevelopersController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<Developer, DeveloperDTO> _developerService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public DevelopersController(
             IDBOperations<Developer, DeveloperDTO> developerService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _developerService = developerService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Developers
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _developerService.Query().ToList();
            return View(list);
        }

        // GET: Developers/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _developerService.Query().SingleOrDefault(q => q.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Developers/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Developers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeveloperDTO developer)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                LoadResult result = await _developerService.Create(developer.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = developer.Id });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(developer);
        }

        // GET: Developers/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            DeveloperDTO item = _developerService.Query().SingleOrDefault(q => q.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Developers/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DeveloperDTO developer)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                LoadResult result = await _developerService.Update(developer.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = developer.Id });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(developer);
        }

        // GET: Developers/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            DeveloperDTO item = _developerService.Query().SingleOrDefault(q => q.Id == id);
            return View(item);
        }

        // POST: Developers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete item service logic:
            LoadResult result = await _developerService.Delete(id);
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
