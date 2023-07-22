using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Models
{
    public class User : Entity
    {
        public string full_name { get; set; }
        public string  email_address { get; set; }
        public string phone_number { get; set; }
        public string password { get; set; }
        public bool active { get; set; } //0-aktif 1-pasif
    }


    public class Entity
    {

        [Key] public int id { get; set; }
        public int hotel_id { get; set; }
    }
}
