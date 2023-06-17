using HotelReservation.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Data.Abstract
{
    public class AdminRepository : IAdminRepository, IGenericRepository
    {
        private readonly IGenericRepository _genericRepository;
        public AdminRepository(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
