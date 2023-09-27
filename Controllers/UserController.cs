using BC_Veterinaria.Interfaces;
using BC_Veterinaria.Interfaces.Repository;
using BC_Veterinaria.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace BC_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _context_user;
        private readonly IJwtTokenRepository _context_jwt;
        private readonly IStorageRepository _context_firebase;
        public UserController(IUserRepository context_user, IJwtTokenRepository context_jwt, IStorageRepository context_Respository) { 
            _context_user = context_user;
            _context_jwt = context_jwt;
            _context_firebase = context_Respository;
        }

        [AllowAnonymous]
        [HttpPost("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromForm] string email, [FromForm] string password) {
            try
            {
                var  user = await _context_user.GetUser(email, Utility.EncriptarClave(password));
                if (user == null) { return NotFound(); }//404
                var token = _context_jwt.GenToken(user.Email, user.Password);


                var response = new
                {
                    User = user,
                    Token = token
                };


                return Ok(response);//200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400
            }
        }

        [AllowAnonymous]
        [HttpPost("Registro")]
        public async Task<IActionResult> Registro(User user) {
            try
            {
                var userE = await _context_user.GetUser(user.Email, Utility.EncriptarClave(user.Password));

                if (userE != null) { return Conflict(); }//409

                user.Password = Utility.EncriptarClave(user.Password);
                await _context_user.PostUser(user);
                return CreatedAtAction("Get", new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpPost("ActualizarPerfil")]
        public async Task<IActionResult> ActualizarPerfil([FromForm] string email, [FromForm] string password, [FromForm] IFormFile image )
        {
            try
            {
                var user = await _context_user.GetUser(email, Utility.EncriptarClave(password));
                if (user == null) { return NotFound(); }//404

       
                //RECIBIR LOS DATOS DEL FORMULARIO
                Stream image_stream = image.OpenReadStream();
                string urlimagen = await _context_firebase.UploadImage(image_stream, image.FileName);


          
                return CreatedAtAction("Get", new {id = user.Id},user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400
            }
        }


    }
}
