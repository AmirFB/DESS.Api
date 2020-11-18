using System;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Dess.Api.Entities
{
    [Owned]
    public class RefreshToken : EntityBase
    {
        public int UserId { get; set; }

        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedBy { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}