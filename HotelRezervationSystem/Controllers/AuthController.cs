using HotelReservation.Business.Concrete;
using HotelReservation.Model.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAdminBusinessService _adminBusinessService;
        public AuthController(IAdminBusinessService adminBusinessService)
        {

            _adminBusinessService = adminBusinessService;
        }
        public async Task<UserLoginDto> Login(string Email, string Password)
        {
            return await _adminBusinessService.Login(Email, Password);
        }
    }
}
