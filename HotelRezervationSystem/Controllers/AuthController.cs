using HotelReservation.Business.Concrete;
using HotelReservation.Model.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers
{

    [Route("auth/[action]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAdminBusinessService _adminBusinessService;
        public AuthController(IAdminBusinessService adminBusinessService)
        {

            _adminBusinessService = adminBusinessService;
        }
        [HttpPost]
        public async Task<UserLoginDto> Login(string Email, string Password)
        {
            return await _adminBusinessService.Login(Email, Password);
        }
    }
}
