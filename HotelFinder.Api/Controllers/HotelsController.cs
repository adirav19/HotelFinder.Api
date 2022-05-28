using BussinesLayer.Abstract;
using BussinesLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;   
        }
        /// <summary>
        /// Bütün otelleri listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var values = _hotelService.GetAllHotel();
            return Ok(values);//reponse kodu olarak 200 öndür ve bunu da ekle
        }
        /// <summary>
        /// id si verilen oteli getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHotelById/{id}")]
        public IActionResult Get(int id)
        {
            var values =  _hotelService.GetHotelById(id);
            if(values != null)
            {
                return Ok(values);//200 + data
            }
            return NotFound();//404
        }
        /// <summary>
        /// otel ekler
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Hotel hotel)
        {
            if (ModelState.IsValid)//model datasında gerekli alanlar var mı ?
            {
                var create = _hotelService.CreateHotel(hotel);
                return CreatedAtAction("Get", new { id = create.Id }, create);
            }
            return BadRequest(ModelState) ;

        }
        /// <summary>
        /// otel günceller
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Hotel hotel)
        {
            if(_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }
        /// <summary>
        /// id si verilen oteli siler
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
