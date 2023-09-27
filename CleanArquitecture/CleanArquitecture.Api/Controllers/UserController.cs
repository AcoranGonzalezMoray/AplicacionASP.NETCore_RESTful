using AutoMapper;
using CleanArquitecture.Core.Entities;
using CleanArquitecture.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArquitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService artistService, IMapper mapper)
        {
            _userService = artistService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get() 
        {
            try
            {
                var users = await _userService.GetAllAsync();
               
               
                if (users is null) return NotFound();//404
                return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);//400
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserModel value)
        {

            try
            {
                //ArtistModel model = new();
                //await _artistService.AddAsync(_mapper.Map<SaveArtistModel, Artist>(value));
                //return Ok(model)


                UserModel model = new();

                await _userService.AddAsync(_mapper.Map<UserModel, User>(value));

                return CreatedAtAction("Get",new {id=value.Id}, value);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
