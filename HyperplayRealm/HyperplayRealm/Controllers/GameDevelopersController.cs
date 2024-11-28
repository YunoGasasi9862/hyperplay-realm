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
    public class GameDevelopersController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<GameDeveloper, GameDeveloperDTO> _gameDeveloperService;
        private readonly IDBOperations<Developer, DeveloperDTO> _developerService;
        private readonly IDBOperations<Game, GameDTO> _gameService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public GameDevelopersController(
              IDBOperations<GameDeveloper, GameDeveloperDTO> gameDeveloperService
            , IDBOperations<Developer, DeveloperDTO> developerService
            , IDBOperations<Game, GameDTO> gameService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _gameDeveloperService = gameDeveloperService;
            _developerService = developerService;
            _gameService = gameService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: GameDevelopers
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _gameDeveloperService.Query().ToList();
            return View(list);
        }

        // GET: GameDevelopers/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _gameDeveloperService.Query().SingleOrDefault(q => q.DeveloperId == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["DeveloperId"] = new SelectList(_developerService.Query().ToList(), "Record.Id", "Name");
            ViewData["GameId"] = new SelectList(_gameService.Query().ToList(), "Record.Id", "Name");
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: GameDevelopers/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: GameDevelopers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameDeveloperDTO gameDeveloper)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                LoadResult result = await _gameDeveloperService.Create(gameDeveloper.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = gameDeveloper.DeveloperId });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(gameDeveloper);
        }

        // GET: GameDevelopers/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _gameDeveloperService.Query().SingleOrDefault(q => q.GameId == id);
            SetViewData();
            return View(item);
        }

        // POST: GameDevelopers/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GameDeveloperDTO gameDeveloper)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                LoadResult result = await _gameDeveloperService.Update(gameDeveloper.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = gameDeveloper.DeveloperId });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(gameDeveloper);
        }

        // GET: GameDevelopers/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _gameDeveloperService.Query().SingleOrDefault(q => q.DeveloperId == id); //fix this we need to be careful when deleting a developer. What about the games?
            return View(item);
        }

        // POST: GameDevelopers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete item service logic:
            LoadResult result = await _gameDeveloperService.Delete(id);
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
