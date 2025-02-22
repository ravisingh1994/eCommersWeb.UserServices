using eCommerce.Core.DTO;
using eCommerce.Core.ServicesContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommersWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("register")] // api/Auth/register
        public async Task<IActionResult> Regiter(RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid Registration Model");
            }

            // call UserServic for handle Registration Process
            AuthenticationResponce? responce = await _userServices.RegisterUser(request);
            if (responce == null || responce.Sucess == false)
            {
                return BadRequest(responce); 
            }
            return Ok(responce);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LogInRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid login Data");
            }

            AuthenticationResponce? authenticationResponce= await _userServices.Login(request);

            if(authenticationResponce==null || authenticationResponce.Sucess == false)
                { return Unauthorized(authenticationResponce); }
            return Ok(authenticationResponce);
        }
    }
}
