using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HexagonalTemplate.Cores
{
    public class AppJwtCore : IAppJwtCore
    {
        private readonly IConfiguration _config;

        public AppJwtCore(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(AppEntity appEntity)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AppJwt:AppKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["AppJwt:AppIssuer"],
              _config["AppJwt:AppIssuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _config["AppJwt:AppIssuer"],
                    ValidAudience = _config["AppJwt:AppIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AppJwt:AppKey"]))
                };
            });
            services.AddMvc();
        }
    }
}
