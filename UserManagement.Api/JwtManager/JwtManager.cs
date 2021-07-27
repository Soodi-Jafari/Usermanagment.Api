using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace AuthManager
{
    public static class JwtManager
    {
        private const string SecretKey = "B3e+0cK58MgeiLxwQRg2ZJdFpdXFstn3+UuYGY+6q5FtlCSPzj8Y3SF+HX/1Yp8NuFpZxOiGXQw9EW3uGqxT7A==";
        public static string GenerateToken(string username, int expireMinutes = 600)
        {
            var symmetricKey = Convert.FromBase64String(SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.Name, username)
                    }),
                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
            return token;
        }

        public static ClaimsPrincipal GetClaimsPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                if (jwtToken == null)
                    return null;
                var symmetricKey = Convert.FromBase64String(SecretKey);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);
                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool ValidateCurrentToken(string token)
        {

            try
            {
                if (string.IsNullOrEmpty(token))
                    return false;
                string jwt = token.Replace("Bearer ", string.Empty);
                var tokenHandler = new JwtSecurityTokenHandler();
                var symmetricKey = Convert.FromBase64String(SecretKey);
                tokenHandler.ValidateToken(jwt, new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                }, out SecurityToken validatedToken);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

    }
}