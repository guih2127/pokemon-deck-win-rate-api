using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.Services.Interfaces;
using PokemonDeckWinRateAPI.ViewModel;
using System;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace PokemonDeckWinRateAPI.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginViewModel userLoginViewModel)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(userLoginViewModel.Username);

                if (user == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                if (!BC.Verify(userLoginViewModel.Password, user.Password))
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                var userLogged = new UserLoggedViewModel
                {
                    Token = _userService.GenerateToken(user),
                    User = _mapper.Map<User, GetUserViewModel>(user)
                };

                return Ok(userLogged);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] InsertUserViewModel userRegisterViewModel)
        {
            try
            {
                if (userRegisterViewModel.Password != userRegisterViewModel.ConfirmPassword)
                    return NotFound("A senha e sua confirmação não conferem");

                userRegisterViewModel.Password = BC.HashPassword(userRegisterViewModel.Password);

                var user = _mapper.Map<InsertUserViewModel, User>(userRegisterViewModel);
                user.Role = "Usuário";

                var userInserted = await _userService.InsertUserAsync(user);

                var userLogged = new UserLoggedViewModel
                {
                    Token = _userService.GenerateToken(user),
                    User = _mapper.Map<User, GetUserViewModel>(userInserted)
                };

                return Ok(userLogged);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}