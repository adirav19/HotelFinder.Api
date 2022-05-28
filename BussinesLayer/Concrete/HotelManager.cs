using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class HotelManager : IHotelService
    {
        private IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public Hotel CreateHotel(Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public void DeleteHote(int id)
        {
            _hotelRepository.DeleteHote(id);
        }

        public List<Hotel> GetAllHotel()
        {
            return _hotelRepository.GetAllHotel();
        }

        public Hotel GetHotelById(int id)
        {
            if(id>=1)
            {
                return _hotelRepository.GetHotelById(id);
            }
            throw new Exception("id 1 den küçük olamaz");
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            return _hotelRepository.UpdateHotel(hotel);
        }
    }
}
