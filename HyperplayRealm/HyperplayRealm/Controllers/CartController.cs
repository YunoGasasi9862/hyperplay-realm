using BLL.Controllers.Bases;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HyperplayRealm.Controllers
{
    public class CartController : BaseController
    {
        private const string SESSION_KEY = "cart";

        private readonly IHttpService _httpService;

        public CartController(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IActionResult> Get()
        {
            List<CartDTO> cart = await _httpService.GetSession<List<CartDTO>>(SESSION_KEY);

            return View("List", cart);
        }
    }
}
