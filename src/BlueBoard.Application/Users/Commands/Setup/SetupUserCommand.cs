using BlueBoard.Application.Common;
using BlueBoard.Application.Users.Common;
using System;

namespace BlueBoard.Application.Users.Commands.Setup
{
    public class SetupUserCommand : BaseCommand<Guid>, IUserNameInfo
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
