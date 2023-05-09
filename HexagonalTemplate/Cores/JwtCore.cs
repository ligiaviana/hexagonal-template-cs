using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Ports.Ins;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace HexagonalTemplate.Cores
{
    public class JwtCore : IJwtCore
    {
        private readonly byte[] _jwtSecretKey;
        private readonly double _jwtExpirationInMinutes;

        public JwtCore(string jwtSecretKey, double jwtExpirationInMinutes)
        {
            _jwtSecretKey = Encoding.ASCII.GetBytes(jwtSecretKey);
            _jwtExpirationInMinutes = jwtExpirationInMinutes;
        }
        public string GenerateToken(UserDto userDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var key = new byte[128 / 8];
            rng.GetBytes(key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userDto.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtExpirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;

        }

        public void Match(string passwordRequest, string passwordDb)
        {
            if (passwordRequest != passwordDb)
            {
                throw new ArgumentException("The password is invalid.");
            }
        }
    }
}
