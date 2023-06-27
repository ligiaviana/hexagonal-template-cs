using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HexagonalTemplate.Cores
{
    public class JwtCore : IJwtCore
    {
        private readonly IConfiguration _config;

        public JwtCore(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(string key, string issuer) 
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer,
              issuer,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void Match(string passwordRequest, string passwordDb)
        {
            if (passwordRequest != passwordDb)
            {
                throw new UnauthorizedAccessException("The password is invalid.");
            }
        }

    }
}
