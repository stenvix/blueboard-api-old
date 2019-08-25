using BlueBoard.API.Options;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Application.Users.Models;
using BlueBoard.Common.Extensions;
using CryptoHelper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlueBoard.API.Infrastructure
{
    /// <summary>
    /// Auth handler
    /// </summary>
    public class AuthHandler : IAuthHandler
    {
        private readonly IOptionsMonitor<JwtOptions> _options;

        /// <summary>
        /// Initializes a new instance of <see cref="AuthHandler"/> class
        /// </summary>
        /// <param name="options">Jwt options monitor</param>
        public AuthHandler(IOptionsMonitor<JwtOptions> options)
        {
            _options = options;
        }

        public string GetPasswordHash(string password) => Crypto.HashPassword(password);

        public bool ValidatePassword(string password, string passwordHash) => Crypto.VerifyHashedPassword(passwordHash, password);

        public AuthTokenModel CreateAuthToken(Guid userId)
        {
            if (userId == Guid.Empty) throw new ArgumentException("User id claim can not be empty.", nameof(userId));
            var now = DateTime.UtcNow;

            var jwtClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString()),
            };

            var options = _options.CurrentValue;
            var expires = now.AddMinutes(options.ExpiryMinutes);
            var jwt = new JwtSecurityToken(
                issuer: options.Issuer,
                claims: jwtClaims,
                notBefore: now,
                expires: expires,
                signingCredentials: GetSigningCredentials(options.SecretKey)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AuthTokenModel
            {
                AccessToken = token,
                Expires = expires.ToTimestamp()
            };
        }

        private SigningCredentials GetSigningCredentials(string secretKey)
        {
            var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            return new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
