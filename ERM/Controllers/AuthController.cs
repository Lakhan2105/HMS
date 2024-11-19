using Azure.Core;
using ERM.Data;
using ERM.Dtos;
using ERM.Helpers;
using ERM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private static ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // POST api/<AuthController>
        [HttpPost("SignUp")]
        public async Task<IActionResult> CreateUser(UserDto req)
            {
            try
            {
                User user = new User();

                var isUserExist = _context.Users.Any(u => u.Email == req.Email);

                if (isUserExist)
                {
                    return new NotFoundObjectResult("User Already Exist");
                }

                user.Email = req.Email;
                user.PasswordHash = CryptoHelper.HashPass(req.Password, out var salt);
                user.PasswordSalt = salt;
                user.Role = req.Role;
                user.ClinicId = req.ClinicId;

                _context.Add(user);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                    return new OkResult();
                else
                    throw new Exception("System Exception");

            }

            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        [HttpPost("SignIn")]

        public async Task<IActionResult> Login([FromBody] LoginDto Request)
            {
            try
            {
                var userDetail = await _context.Users.FirstOrDefaultAsync(u => u.Email == Request.Email);


                if (userDetail == null || !CryptoHelper.isValidPass(Request.Password, userDetail.PasswordHash, userDetail.PasswordSalt))
                {
                    throw new Exception("Invalid Login");
                }

                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, userDetail.UserId.ToString()),
                    new Claim(ClaimTypes.Email, userDetail.Email),
                };

                foreach (var role in userDetail.Role)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                }

                var accessToken = JwtHelper.GenerateAccessToken(
                    _configuration.GetValue<string>("JWT:IssuerSigningKey"),
                    _configuration.GetValue<string>("JWT:ValidIssuer"),
                    _configuration.GetValue<string>("JWT:ValidAudience"),
                    claims);

                var refreshToken = JwtHelper.GenerateRefreshToken();

                var token = new Token
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    AccessTokenExpiry = DateTime.Now.AddDays(1),
                    RefreshTokenExpiry = DateTime.Now.AddDays(7),
                    UserId = userDetail.UserId
                };

                if (token == null || token.RefreshTokenExpiry < DateTime.Now)
                {
                    return BadRequest("Invalid or expired refresh token");
                }

                    _context.Tokens.Add(token);
                await _context.SaveChangesAsync();

                var response = new AuthResponseDto
                {
                    Token = new TokenAuthDto
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshToken,
                    },
                    User = new UserAuthDto
                    {
                        UserId = userDetail.UserId,
                        Role = userDetail.Role
                    }
                };

                // Return both tokens to the client
                return Ok(new { token = response.Token, user = response.User });
            
            }


            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenAuthDto request)
        {
            // Locate the token based on the refresh token from the request
            var token = await _context.Tokens
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.RefreshToken == request.RefreshToken);

            // Validate the token and check for expiration
            if (token == null || token.RefreshTokenExpiry < DateTime.Now)
            {
                return BadRequest("Invalid or expired refresh token");
            }

            // Create claims for the new access token
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, token.User.UserId.ToString())
            };


            // Generate a new Access Token
            var newAccessToken = JwtHelper.GenerateAccessToken(
                _configuration.GetValue<string>("JWT:IssuerSigningKey"),
                _configuration.GetValue<string>("JWT:ValidIssuer"),
                _configuration.GetValue<string>("JWT:ValidAudience"),
                claims
            );

            var newRefreshToken = JwtHelper.GenerateAccessToken(
                _configuration.GetValue<string>("JWT:IssuerSigningKey"),
                _configuration.GetValue<string>("JWT:ValidIssuer"),
                _configuration.GetValue<string>("JWT:ValidAudience"),
                claims
            );

            // Update the token's AccessToken and expiry in the database
            token.AccessToken = newAccessToken;
            token.AccessTokenExpiry = DateTime.Now.AddDays(1);
            token.RefreshToken = newRefreshToken;
            token.RefreshTokenExpiry = DateTime.Now.AddDays(7);
            await _context.SaveChangesAsync();

            // Return the new tokens to the client
            return Ok(new { AccessToken = newAccessToken, RefreshToken = newRefreshToken });
        }


    }
}
