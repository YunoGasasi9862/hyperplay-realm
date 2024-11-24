#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;
using BLL.Interfaces;
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;

// Generated from Custom Template.

namespace HyperplayRealm.Controllers
{
    public class PublishersController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<Publisher, PublisherDTO> _publisherService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public PublishersController(
            IDBOperations<Publisher, PublisherDTO> publisherService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _publisherService = publisherService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Publishers
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _publisherService.Query().ToList();
            return View(list);
        }

        // GET: Publishers/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _publisherService.Query().SingleOrDefault(q => q.PublisherId == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Publishers/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublisherDTO publisher)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                LoadResult result = await _publisherService.Create(publisher.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = publisher.PublisherId });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _publisherService.Query().SingleOrDefault(q => q.PublisherId == id);
            SetViewData();
            return View(item);
        }

        // POST: Publishers/Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PublisherDTO publisher)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                LoadResult result = await _publisherService.Update(publisher.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = publisher.PublisherId });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _publisherService.Query().SingleOrDefault(q => q.PublisherId == id);
            return View(item);
        }

        // POST: Publishers/Delete
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete item service logic:
            LoadResult result = await _publisherService.Delete(id);
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
