using BLL.Controllers.Bases;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Web.Mvc;

namespace HyperplayRealm.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        private const string SESSION_KEY = "cart";

        private readonly IHttpService _httpService;
        private readonly IDBOperations<Game, GameDTO> _gameService;
        private int GetUserId() => Convert.ToInt32(User.Claims?.Single(c => c.Type == "Id").Value);

        public CartController(IHttpService httpService, IDBOperations<Game, GameDTO> gameService)
        {
            _httpService = httpService;
            _gameService = gameService;
        }

        private async Task<List<CartDTO>?> GetSession(int userId)
        {
            List<CartDTO> cart = await _httpService.GetSession<List<CartDTO>>(SESSION_KEY);

            return cart?.Where(c => c.UserId == userId).ToList();
        }


        public async Task<IActionResult> Get()
        {
            List<CartDTO> cart = await _httpService.GetSession<List<CartDTO>>(SESSION_KEY);

            return View("List", cart);
        }

        // GET: /Cart/Add?productId=13
        public async Task<IActionResult> Add(int gameId)
        {
            List<CartDTO>? cart = await GetSession(GetUserId());
            cart = cart ?? new List<CartDTO>();
            GameDTO game = _gameService?.Query().SingleOrDefault(p => p.Id == gameId);

            CartDTO cartItem = new CartDTO()
            {
                GameId = game.Id,
                Title = game.Title,
                Price = Convert.ToDecimal(game.Price)
            };

            cart.Add(cartItem);
            await _httpService.SetSession(SESSION_KEY, cart);
            TempData["Message"] = $"\"{cartItem.Title}\" added to cart.";
            return RedirectToAction("Index", "Games"); //fix this later
        }

        public async Task<IActionResult> Remove(int gameId)
        {
            List<CartDTO>? cart = await GetSession(GetUserId());
            CartDTO cartItem = cart.FirstOrDefault(c => c.GameId == gameId);
            cart.Remove(cartItem);
            await _httpService.SetSession(SESSION_KEY, cart);
            return RedirectToAction(nameof(Get));
        }
    }
}
