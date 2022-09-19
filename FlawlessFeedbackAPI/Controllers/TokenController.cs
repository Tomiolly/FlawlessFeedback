using FlawlessFeedbackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlawlessFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        #region Setup + Ctor

        public IConfiguration _configuration;
        private readonly SurveyQuestionContext _context;
        public TokenController(IConfiguration config, SurveyQuestionContext context)
        {
            _configuration = config;
            _context = context;
        }

        #endregion

        #region End Points

        // Generate a Token for an existing user
        /// <summary>
        /// Creates a Token for a User
        /// </summary>
        /// <param name="_userData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GenerateToken")]
        public IActionResult GenerateToken(UserInfo _userData)
        {
            // All of the null checks
            if (_userData != null && _userData.UserName != null && _userData.Password != null)
            {
                // retrieve the user for these credentials
                var user = GetUser(_userData.UserName, _userData.Password);
                // If we have a user that matches the credentials
                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    // JWT Subject
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    // JWT ID
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    // JWT Date/Time
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    // JWT User ID
                    new Claim("Id", user.UserInfoId.ToString()),
                    // JWT UserName
                    new Claim("UserName", user.UserName)
                   };
                    // Generate a new key based on the Key we created and stored in appsettings.json
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    // use the generated key to generate new Signing Credentials
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    // Generate a new token based on all of the details generated so far
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        // How long the JWT will be valid for
                        expires: DateTime.UtcNow.AddDays(5),
                        signingCredentials: signIn);
                    // Return the Token via JSON
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion

        #region Custom Methods
        /// <summary>
        /// Gets the User Information
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private UserInfo GetUser(string userName, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }
        
        #endregion
    }
}
