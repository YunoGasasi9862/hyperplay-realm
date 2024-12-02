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
    public class GenresController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<Genre, GenreDTO> _genreService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public GenresController(
            IDBOperations<Genre, GenreDTO> genreService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _genreService = genreService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Genres
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _genreService.Query().ToList();
            return View(list);
        }

        // GET: Genres/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _genreService.Query().SingleOrDefault(q => q.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GenreDTO genre)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                LoadResult result = await _genreService.Create(genre.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = genre.Id });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(genre);
        }

        // GET: Genres/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _genreService.Query().SingleOrDefault(q => q.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Genres/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GenreDTO genre)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                LoadResult result = await _genreService.Update(genre.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = genre.Id });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(genre);
        }

        // GET: Genres/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _genreService.Query().SingleOrDefault(q => q.Id == id);
            return View(item);
        }

        // POST: Genres/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = await _genreService.Delete(id);
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
