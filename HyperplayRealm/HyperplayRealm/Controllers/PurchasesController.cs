#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;

// Generated from Custom Template.

namespace HyperplayRealm.Controllers
{
    public class PurchasesController : MvcController
    {
        // Service injections:
        private readonly IPurchaseService _purchaseService;
        private readonly IGameService _gameService;
        private readonly IUserService _userService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public PurchasesController(
			IPurchaseService purchaseService
            , IGameService gameService
            , IUserService userService

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
            var item = _purchaseService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["GameId"] = new SelectList(_gameService.Query().ToList(), "Record.Id", "Name");
            ViewData["UserId"] = new SelectList(_userService.Query().ToList(), "Record.Id", "Name");
            
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
        public IActionResult Create(PurchaseModel purchase)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _purchaseService.Create(purchase.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = purchase.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _purchaseService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Purchases/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PurchaseModel purchase)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _purchaseService.Update(purchase.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = purchase.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _purchaseService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Purchases/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _purchaseService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
