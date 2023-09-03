using BC_Veterinaria.Interfaces;
using BC_Veterinaria.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BC_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {

        private readonly IDogRepository _context_dog;
        private readonly IStorageRepository _context_storage;
        public DogController(IDogRepository context_dog, IStorageRepository context_storage) {
            _context_dog = context_dog;
            _context_storage = context_storage;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
            
                var allDogs = await  _context_dog.GetListDogs();

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
                var dog = await _context_dog.GetDog(id);

                if (dog is null) return NotFound();//404

                await _context_storage.DeleteImage(dog.ImageUrl);

                await _context_dog.DeleteDog(dog);

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
                var dog = JsonConvert.DeserializeObject<Dog>(DogData);

                //RECIBIR LOS DATOS DEL FORMULARIO
                Stream image_stream = image.OpenReadStream();
                string urlimagen = await _context_storage.UploadImage(image_stream, image.FileName);

                dog.ImageUrl = urlimagen;

                await _context_dog.postDog(dog);
                return CreatedAtAction("Get",new { id = dog.Id },dog);
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
                var Dog = JsonConvert.DeserializeObject<Dog>(DogData);

                if (id != Dog.Id) return BadRequest();

                var dogBD = await _context_dog.GetDog(Dog.Id);
                if (dogBD is null) return NotFound();//404

                await _context_storage.DeleteImage(dogBD.ImageUrl);

                Stream imagen = image.OpenReadStream();
                Dog.ImageUrl =  await _context_storage.UploadImage(imagen, image.FileName);

                await _context_dog.putDog(dogBD,Dog);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400
            }

        }







    }

}
