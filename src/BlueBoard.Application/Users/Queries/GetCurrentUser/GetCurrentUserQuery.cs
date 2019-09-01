using BlueBoard.Application.Users.Models;
using MediatR;

namespace BlueBoard.Application.Users.Queries.GetCurrentUser
{
    public class GetCurrentUserQuery : IRequest<SlimUserModel>
    {
    }
}
