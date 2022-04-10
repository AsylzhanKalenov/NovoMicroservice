using ApiGateway.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiGateway.Services
{
    public class CustomerTokenService
    {
        public AuthToken GenerateToken(LoginResponse user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(CustomerJwtSetting.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.UtcNow.AddHours(2);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Lastname ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(audience: CustomerJwtSetting.Audience,
                                              issuer: CustomerJwtSetting.Issuer,
                                              claims: claims,
                                              expires: expirationDate,
                                              signingCredentials: credentials);

            var authToken = new AuthToken();
            authToken.Token = new JwtSecurityTokenHandler().WriteToken(token);
            authToken.ExpirationDate = expirationDate;

            return authToken;
        }
    }
}
