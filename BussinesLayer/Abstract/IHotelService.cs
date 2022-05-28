using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IHotelService
    {
        List<Hotel> GetAllHotel();
        Hotel GetHotelById(int id);
        Hotel CreateHotel(Hotel hotel);
        Hotel UpdateHotel(Hotel hotel);
        void DeleteHote(int id);
    }
}
