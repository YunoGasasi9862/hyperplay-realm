﻿#nullable disable
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
    public class GamesController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<Game, GameDTO> _gameService;
        private readonly IDBOperations<Publisher, PublisherDTO> _publisherService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public GamesController(
            IDBOperations<Game, GameDTO> gameService
            , IDBOperations<Publisher, PublisherDTO> publisherService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _gameService = gameService;
            _publisherService = publisherService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Games
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _gameService.Query().ToList();
           
            return View(list);
        }

        // GET: Games/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            Console.Write(id);
            var item = _gameService.Query().SingleOrDefault(q => q.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["PublisherId"] = new SelectList(_publisherService.Query().ToList(), "Id", "Name");
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Games/Create
        [HttpPost]
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