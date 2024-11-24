#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;

// Generated from Custom Template.

namespace HyperplayRealm.Controllers
{
    public class GameDevelopersController : MvcController
    {
        // Service injections:
        private readonly IGameDeveloperService _gameDeveloperService;
        private readonly IDeveloperService _developerService;
        private readonly IGameService _gameService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public GameDevelopersController(
			IGameDeveloperService gameDeveloperService
            , IDeveloperService developerService
            , IGameService gameService

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
            var item = _gameDeveloperService.Query().SingleOrDefault(q => q.Record.Id == id);
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
        public IActionResult Create(GameDeveloperModel gameDeveloper)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _gameDeveloperService.Create(gameDeveloper.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = gameDeveloper.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(gameDeveloper);
        }

        // GET: GameDevelopers/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _gameDeveloperService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: GameDevelopers/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GameDeveloperModel gameDeveloper)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _gameDeveloperService.Update(gameDeveloper.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = gameDeveloper.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(gameDeveloper);
        }

        // GET: GameDevelopers/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _gameDeveloperService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: GameDevelopers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _gameDeveloperService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
