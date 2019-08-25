using BlueBoard.Application.Users.Models;
using System;

namespace BlueBoard.Application.Infrastructure
{
    public interface IAuthHandler
    {
        string GetPasswordHash(string password);
        bool ValidatePassword(string password, string passwordHash);
        AuthTokenModel CreateAuthToken(Guid userId);
    }
}
