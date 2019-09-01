using MediatR;
using System;

namespace BlueBoard.Application.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets user first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets user last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets user email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets user phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets user password
        /// </summary>
        public string Password { get; set; }
    }
}
