using System;
using API.Entities;
using API.Interfaces;

namespace API.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        var tokenKey = config["tokenKey"] ?? throw new Exception("Token key not found in configuration");
        if (tokenKey.Length < 64) throw new Exception("Token key must be at least 64 characters long");

        return "";    
    }
}
