using App.Application.Interfaces.Auth;
using System;
using System.Security.Cryptography;


/// <summary>
/// Token Factory
/// </summary>

namespace App.Infrastructure.Auth
{
    public sealed class TokenFactory : ITokenFactory
    {
        public string GenerateToken(int size = 32)
        {
            var randomNumber = new byte[size];
            using var rng = RandomNumberGenerator.Create();

            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
