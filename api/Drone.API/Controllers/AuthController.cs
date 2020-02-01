using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Drone.API.Models.Requests;
using Drone.API.Models.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Drone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenSettings _tokenSettings;

        public AuthController(
            TokenSettings tokenSettings)
        {
            _tokenSettings = tokenSettings;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult RequestToken(TokenRequest tokenRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token;
            if (IsAuthenticated(tokenRequest, out token))
            {
                var tokenJson = new Dictionary<string, string>();
                tokenJson.Add("token", token);

                return Ok(tokenJson);
            }

            return BadRequest("Invalid Request");
        }

        [AllowAnonymous]
        [HttpGet("users/me")]
        public IActionResult GetCurrentUser()
        {
            try
            {
                var userJson = new Dictionary<string, string>();
                userJson.Add("user", "Administrator");

                return new OkObjectResult(userJson);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private bool IsAuthenticated(TokenRequest tokenRequest, out string token)
        {
            token = string.Empty;
            if (!IsValidUser(tokenRequest.Username, tokenRequest.Password)) return false;

            var defaultPassword = "p@$$w0rd";
            var defaultUsername = "admin";

            if (tokenRequest.Username == defaultUsername &&
                tokenRequest.Password == defaultPassword)
            {
                var adminClaims = new[]
                {
                    new Claim("user", "administrator")
                };

                var adminKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));
                var adminCredentials = new SigningCredentials(adminKey, SecurityAlgorithms.HmacSha256);

                var adminJwtToken = new JwtSecurityToken(
                    _tokenSettings.Issuer,
                    _tokenSettings.Audience,
                    adminClaims,
                    expires: DateTime.Now.AddMinutes(_tokenSettings.AccessExpiration),
                    signingCredentials: adminCredentials
                );

                token = new JwtSecurityTokenHandler().WriteToken(adminJwtToken);
                return true;
            }

            return false;
        }

        private bool IsValidUser(string username, string password)
        {
            return true;
        }

        private JwtSecurityToken ReadToken(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            return jwtSecurityTokenHandler.ReadToken(token) as JwtSecurityToken;
        }
    }
}
