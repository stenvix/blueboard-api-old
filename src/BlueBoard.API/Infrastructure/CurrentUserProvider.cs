using BlueBoard.Application.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;

namespace BlueBoard.API.Infrastructure
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Guid UserId => Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
