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
    public class GameGenresController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<GameGenre, GameGenreDTO> _gameGenreService;
        private readonly IDBOperations<Game, GameDTO> _gameService;
        private readonly IDBOperations<Genre, GenreDTO> _genreService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public GameGenresController(
            IDBOperations<GameGenre, GameGenreDTO> gameGenreService
            , IDBOperations<Game, GameDTO> gameService
            , IDBOperations<Genre, GenreDTO> genreService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _gameGenreService = gameGenreService;
            _gameService = gameService;
            _genreService = genreService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: GameGenres
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _gameGenreService.Query().ToList();
            return View(list);
        }

        // GET: GameGenres/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _gameGenreService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["GameId"] = new SelectList(_gameService.Query().ToList(), "Record.Id", "Name");
            ViewData["GenreId"] = new SelectList(_genreService.Query().ToList(), "Record.Id", "Name");
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: GameGenres/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: GameGenres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GameGenreModel gameGenre)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _gameGenreService.Create(gameGenre.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = gameGenre.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(gameGenre);
        }

        // GET: GameGenres/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _gameGenreService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: GameGenres/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GameGenreModel gameGenre)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _gameGenreService.Update(gameGenre.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = gameGenre.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(gameGenre);
        }

        // GET: GameGenres/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _gameGenreService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: GameGenres/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _gameGenreService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
