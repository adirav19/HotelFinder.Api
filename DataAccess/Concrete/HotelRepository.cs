using DataAccess;
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                
                hotelDBContext.Hotels.Add(hotel);
                hotelDBContext.SaveChanges();
                return hotel;
            }
        }

        public void DeleteHote(int id)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                var value = GetHotelById(id);
                hotelDBContext.Hotels.Remove(value);
                hotelDBContext.SaveChanges();
            }
        }

        public async Task<List<Hotel>> GetAllHotel()
        {
            using(var hotelDBContext = new HotelDBContext())
            {
                return await hotelDBContext.Hotels.ToListAsync();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                return hotelDBContext.Hotels.Find(id);
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                
                hotelDBContext.Hotels.Update(hotel);
                hotelDBContext.SaveChanges();
                return hotel;
            }
        }
    }
}
