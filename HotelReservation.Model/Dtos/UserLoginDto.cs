using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Dtos
{
    public class UserLoginDto
    {
        public string user_name { get; set; }
        public string email_address { get; set; }
        public string token { get; set; }
    }
}
