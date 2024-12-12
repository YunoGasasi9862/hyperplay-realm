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
            GameGenreDTO item = _gameGenreService.Query().SingleOrDefault(q => q.GameId == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["GameId"] = new SelectList(_gameService.Query().ToList(), "Id", "Name");
            ViewData["GenreId"] = new SelectList(_genreService.Query().ToList(), "Id", "Name");
            
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
        public async Task<IActionResult> Create(GameGenreDTO gameGenre)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                LoadResult result = await _gameGenreService.Create(gameGenre.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = gameGenre.GameId });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(gameGenre);
        }

        // GET: GameGenres/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            GameGenreDTO item = _gameGenreService.Query().SingleOrDefault(q => q.GameId == id);
            SetViewData();
            return View(item);
        }

        // POST: GameGenres/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GameGenreDTO gameGenre)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                LoadResult result = await _gameGenreService.Update(gameGenre.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = gameGenre.GameId });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(gameGenre);
        }

        // GET: GameGenres/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            GameGenreDTO item = _gameGenreService.Query().SingleOrDefault(q => q.GameId == id);
            return View(item);
        }

        // POST: GameGenres/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete item service logic:
            LoadResult result = await _gameGenreService.Delete(id);
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
