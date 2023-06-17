using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Models
{
    public class HotelRoom
    {
        public string id { get; set; }
        public int hotel_id { get; set; }
        public string name { get; set; }
        public long capacity { get; set; }
        public string? description { get; set; }

    }

    public class RoomReservation
    {
        public string id { get; set; }
        public string room_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string customer_name { get; set; }
        public string customer_email { get; set; }
        public int customer_phonenumber { get; set; }
        public DateTime request_date { get; set; }
        public RoomStatus status { get; set; }
    }

    public enum RoomStatus
    {
        Avaiable = 0,
        Hold = 1,
        Reserved = 2


    }

}
