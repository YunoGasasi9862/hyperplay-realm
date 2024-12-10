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
    public class PurchasesController : BaseController
    {
        // Service injections:
        private readonly IDBOperations<Purchase, PurchaseDTO> _purchaseService;
        private readonly IDBOperations<Game, GameDTO> _gameService;
        private readonly IDBOperations<User, UserDTO> _userService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public PurchasesController(
            IDBOperations<Purchase, PurchaseDTO> purchaseService
            , IDBOperations<Game, GameDTO> gameService
            , IDBOperations<User, UserDTO> userService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _purchaseService = purchaseService;
            _gameService = gameService;
            _userService = userService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Purchases
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _purchaseService.Query().ToList();
            return View(list);
        }

        // GET: Purchases/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            PurchaseDTO item = _purchaseService.Query().SingleOrDefault(q => q.UserId == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["GameId"] = new SelectList(_gameService.Query().ToList(), "Id", "Name");
            ViewData["UserId"] = new SelectList(_userService.Query().ToList(), "Id", "Name");
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Purchases/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseDTO purchase)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                LoadResult result = await _purchaseService.Create(purchase.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.IsSuccessfull;
                    return RedirectToAction(nameof(Details), new { id = purchase.UserId });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _purchaseService.Query().SingleOrDefault(q => q.UserId == id);
            SetViewData();
            return View(item);
        }

        // POST: Purchases/Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PurchaseDTO purchase)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                LoadResult result = await _purchaseService.Update(purchase.MapTo());
                if (result.Result.IsSuccessfull)
                {
                    TempData["Message"] = result.Result.Message;
                    return RedirectToAction(nameof(Details), new { id = purchase.UserId });
                }
                ModelState.AddModelError("", result.Result.Message);
            }
            SetViewData();
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            PurchaseDTO item = _purchaseService.Query().SingleOrDefault(q => q.GameId == id);
            return View(item);
        }

        // POST: Purchases/Delete
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete item service logic:
            LoadResult result = await _purchaseService.Delete(id);
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
