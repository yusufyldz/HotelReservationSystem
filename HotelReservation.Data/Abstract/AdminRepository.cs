using HotelReservation.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Data.Abstract
{
    public class AdminRepository : GenericRepository, IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
             _context = appDbContext;
        }

    }
}
