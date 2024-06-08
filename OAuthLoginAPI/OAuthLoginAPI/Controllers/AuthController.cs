using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OAuthLoginAPI.Models;
using OAuthLoginAPI.Services;

namespace OAuthLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthService _jwtAuthService;

        public AuthController(IJwtAuthService authService)
        {
            _jwtAuthService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel model)
        {
            // Authenticate user against static data (you can replace this with your actual authentication logic)
            if (model.Username == "user" && model.Password == "password")
            {
                var roles = new List<string> { "player" }; // Default role for all users
                var scopes = new List<string> { "b_game" }; // Default region for all users

                // Add VIP role and scope for VIP users
                if (model.Username == "vipuser")
                {
                    roles.Add("admin");
                    scopes.Add("vip_character_personalize");
                }

                var token = _jwtAuthService.GenerateJwtToken(model.Username, roles, scopes);

                return Ok(new { token });
            }

            return Unauthorized();
        }

       
    }
}
