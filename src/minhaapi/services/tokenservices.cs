using Microsoft.IdentityModel.Tokens;
using minhaapi.modulo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace minhaapi.services
{
    public class Tokenservices
    {
        public static object GenerateToken (Employee employee)
        {
            var kay = Encoding.ASCII.GetBytes(Key.Secret);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("emloyeeId", employee.id.ToString()),
                }),
               
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials =new SigningCredentials(new SymmetricSecurityKey(Key),SecurityAlgorithms.HmacSha256Signature)
            };
            var totenHandLer = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(tokenConfig);
            var tokenString = TokenHandler.writeToken(token);

            return new
    }
}
