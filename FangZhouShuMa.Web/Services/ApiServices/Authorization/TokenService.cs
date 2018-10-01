using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace FangZhouShuMa.Web.Services.ApiServices.Authorization
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        //private const string OrderbotClaimName = "obdata";

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public JwtSecurityToken GenerateToken(UserIdentity authenticatedUser)
        //{
        //    var encryptedCustomClaim = GenerateEncryptedUserClaim(authenticatedUser);

        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, authenticatedUser.UserName),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(OrderbotClaimName, encryptedCustomClaim)
        //    };

        //    var daysUntilTokenExpires = Convert.ToDouble(_configuration["DefaultTokenExpiryInDays"]);
        //    var issuer = _configuration["Issuer"];
        //    var audience = _configuration["Audience"];
        //    var secretKey = _configuration["ApiSecretKey"];

        //    var token = new JwtSecurityToken
        //    (
        //        issuer: issuer,
        //        audience: audience,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddDays(daysUntilTokenExpires),
        //        notBefore: DateTime.UtcNow,
        //        signingCredentials: new SigningCredentials(
        //            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        //            SecurityAlgorithms.HmacSha256)
        //    );

        //    return token;
        //}

        //// Use this method to save Orderbot-specific data that you need to retrieve from the token.
        //public string GenerateEncryptedUserClaim(UserIdentity authenticatedUser)
        //{
        //    var customClaim = new CustomClaim(authenticatedUser.CompanyInformationId, authenticatedUser.SiteUserId);
        //    var customClaimString = JsonConvert.SerializeObject(customClaim);

        //    // Note: If this key is changed, we need to also change the token secret key.
        //    // Otherwise previously-generated (and still valid) tokens will contain Orderbot data that can no longer be decrypted.
        //    var key = _configuration["CustomClaimKey"];
        //    var encryptedCustomClaim = EncryptProvider.AESEncrypt(customClaimString, key);

        //    return encryptedCustomClaim;
        //}

        //public CustomClaim DecryptCustomClaim(ClaimsIdentity identity)
        //{
        //    var customClaim = new CustomClaim();

        //    if (identity == null)
        //        return customClaim;

        //    var key = _configuration["CustomClaimKey"];

        //    var orderbotData = identity.FindFirst(OrderbotClaimName).Value;
        //    var decryptedString = EncryptProvider.AESDecrypt(orderbotData, key);
        //    customClaim = JsonConvert.DeserializeObject<CustomClaim>(decryptedString);

        //    return customClaim;
        //}
    }
}
