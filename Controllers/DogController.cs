using BC_Veterinaria.Interfaces;
using BC_Veterinaria.Model;
using BC_Veterinaria.Model.SqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace BC_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {

        private readonly IDogRepository _context;
        public DogController(IDogRepository context) {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                Thread.Sleep(1000);
                var allDogs = await  _context.GetListDogs();

                if(allDogs is null) return NotFound();//404

                return Ok(allDogs);//200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //400
            }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dog = await _context.GetDog(id);

                if (dog is null) return NotFound();//404

                await _context.DeleteDog(dog);

                return NoContent();//204
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]string DogData, [FromForm]IFormFile image)
        {
            try
            {
                var Dog = JsonConvert.DeserializeObject<dog>(DogData);
                await _context.postDog(Dog, image);
                return CreatedAtAction("Get",new { id = Dog.Id },Dog);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400
            }

        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromForm]string DogData, [FromForm]IFormFile image)
        {
            try
            {
                var Dog = JsonConvert.DeserializeObject<dog>(DogData);

                if (id != Dog.Id) return BadRequest();

                var dogBD = await _context.GetDog(Dog.Id);
                if (dogBD is null) return NotFound();//404

                await _context.putDog(dogBD,Dog, image);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400
            }

        }







    }

}
