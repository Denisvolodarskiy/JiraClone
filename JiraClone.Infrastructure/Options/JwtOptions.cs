﻿namespace JiraClone.Infrastructure.Options
{
    public class JwtOptions
    {
        public required string SecretKey { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public int Expires { get; set; }
    }
}
