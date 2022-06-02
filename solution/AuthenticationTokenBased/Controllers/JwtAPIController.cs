using JwtTokenGenerationAPI.Models;
using JwtTokenGenerationAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace JwtTokenGenerationAPI.Controllers
{

    [Route("api/Jwt")]
    public class JwtAPIConroller : ControllerBase
    {
        private IJwtService _jwtService;
        public JwtAPIConroller(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet("Token/{userName}/{password}")]
        [AllowAnonymous]
        public async Task<string> Token(string userName, string password)
        {
            var user = await _jwtService.GetByUserAndPass(userName, password);
            if (user == null)
            {
                throw new BadHttpRequestException("کاربر با این مشخصات یافت نشد");
            }
            var jwt = _jwtService.Generate(user);

            return jwt;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _jwtService.GetAllUsers();

            return users;
        }

        [HttpPost]
        public async void AddUser(UserDto user)
        {
            var newUser = await _jwtService.AddUser(user);

        }

    }
}
