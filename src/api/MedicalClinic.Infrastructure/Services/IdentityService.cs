using MedicalClinic.Application.DTOs.Identity;
using MedicalClinic.Application.DTOs.Settings;
using MedicalClinic.Application.Exceptions;
using MedicalClinic.Application.Interfaces.Shared;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Resource.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedicalClinic.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        public IdentityService(
                UserManager<IdentityUser> userManager,
                IConfiguration configuration
            )
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<Result<UserResponse>> Register(RegisterRequest request)
        {
            //Check email already exist
            var userExist = await _userManager.FindByEmailAsync(request.Email);
            if (userExist != null)
            {
                throw new MdException(SharedResource.MESSAGE_IDENTITY_USER_EXIST, request.Email);
            }

            //Create a user
            var newUser = new IdentityUser()
            {
                Email = request.Email,
                UserName = request.Name
            };

            var isCreated = await _userManager.CreateAsync(newUser, request.Password);

            if (isCreated.Succeeded)
            {
                //Generate the token
                var token = await GenerateToken(newUser);
                var refreshToken = GenerateRefreshToken(newUser);

                var userResponse = new UserResponse()
                {
                    Username = request.Name,
                    Email = request.Email,
                    Token = token,
                    RefreshToken = refreshToken.Token
                };
                return Result<UserResponse>.Success(userResponse);
            }
            else
            {
                throw new MdException(JsonSerializer.Serialize(isCreated.Errors));
            }
        }

        public async Task<Result<UserResponse>> SignIn(LoginRequest userLoginRequest)
        {
            //Check if the user exist
            var user = await _userManager.FindByEmailAsync(userLoginRequest.Email);
            if (user == null)
            {
                throw new MdException(SharedResource.MESSAGE_IDENTITY_USER_NOT_FOUND, userLoginRequest.Email);
            }

            //Check Password
            var isCorrectPassword = await _userManager.CheckPasswordAsync(user, userLoginRequest.Password);

            if (!isCorrectPassword)
            {
                throw new MdException(SharedResource.MESSAGE_IDENTITY_PASSWORD_INVALID);
            }

            var token = await GenerateToken(user);
            var refreshToken = GenerateRefreshToken(user);

            var userResponse = new UserResponse()
            {
                Username = user.UserName,
                Email = user.Email,
                Token = token,
                RefreshToken = refreshToken.Token
            };

            return Result<UserResponse>.Success(userResponse);
        }

        public async Task<string> GenerateToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);

            //Token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var tokenString = jwtTokenHandler.WriteToken(token);

            return tokenString;
        }

        private RefreshToken GenerateRefreshToken(IdentityUser user)
        {
            var refreshToken = new RefreshToken
            {
                UserId = user.Id,
                // ExpiryDate = DateTime.UtcNow.AddMinutes(int.Parse(_configuration.GetSection("JwtConfig:Secret").Value)),
                ExpiryDate = DateTime.UtcNow.AddMinutes(2160),
                AddedDate = DateTime.UtcNow,
                Token = EncryptString(23)
            };

            return refreshToken;
        }

        private string EncryptString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYX1234567890abcdefghijklmnopqrstuvwxyz_";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }
    }
}
