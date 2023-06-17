using HotelReservation.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Concrete
{
    public interface IAdminBusinessService
    {
        Task<UserLoginDto> Login(string EmailAddress, string Password);
    }
}
