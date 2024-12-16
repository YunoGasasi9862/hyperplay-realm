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
    public class GamesController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<Game, GameDTO> _gameService;
        private readonly IDBOperations<Publisher, PublisherDTO> _publisherService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        private readonly IDBOperations<Genre, GenreDTO> _genreService;
        private readonly IDBOperations<Developer, DeveloperDTO> _developerService;

        public GamesController(
            IDBOperations<Game, GameDTO> gameService
            , IDBOperations<Publisher, PublisherDTO> publisherService
            , IDBOperations<Genre, GenreDTO> genreService
            , IDBOperations<Developer, DeveloperDTO> developerService

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _gameService = gameService;
            _publisherService = publisherService;
            _genreService = genreService;
            _developerService = developerService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Games
        public IActionResult Index()
        {
            // Get collection service logic:
            List<GameDTO> list = _gameService.Query().ToList();
           
            return View(list);
        }

        // GET: Games/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _gameService.Query().SingleOrDefault(q => q.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            ViewData["PublisherId"] = new SelectList(_publisherService.Query().ToList(), "PublisherId", "Name");

            /* Can be uncommented and used for many to many relationships. Store may be replaced with the related entiy name in the controller and views. */
            ViewBag.GenreIds = new MultiSelectList(_genreService.Query().ToList(), "Id", "GenreName");

            ViewBag.DeveloperIds = new MultiSelectList(_developerService.Query().ToList(), "Id", "Name");

        }

        // GET: Games/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameDTO game)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                LoadResult result = await _gameService.Create(game.MapTo());
                 if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = game.Id });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(game);
        }

        // GET: Games/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _gameService.Query().SingleOrDefault(q => q.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Games/Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GameDTO game)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                LoadResult result = await _gameService.Update(game.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = game.Id });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(game);
        }

        // GET: Games/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _gameService.Query().SingleOrDefault(q => q.Id == id);
            return View(item);
        }

        // POST: Games/Delete
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete item service logic:
            LoadResult result = await _gameService.Delete(id);
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
