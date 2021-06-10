using System;


/// <summary>
/// Refresh Token Entity
/// </summary>


namespace App.Domain.Entities.Identity
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string UserId { get; set; }
        public bool Active => DateTime.UtcNow <= Expires;
        public string RemoteIpAddress { get; set; }
    }
}