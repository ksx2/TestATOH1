using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestATOH1.Helpers;
using TestATOH1.Models.UserModels;


namespace TestATOH1.Helpers.Authorize
{
    public interface IJWTGenerate
    {
        public string GenerateToken(UserModel user);

    }

    public class JWTGenerate : IJWTGenerate
    {
        private readonly AppSettings _appSettings;

        public JWTGenerate(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateToken(UserModel user)
        {

            var userRole = user.Admin ? "admin" : "user";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Guid",user.Guid.ToString()),
                                                    new Claim(ClaimTypes.Role, userRole) ,
                                                    new Claim(ClaimTypes.Name, user.Login)}),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
