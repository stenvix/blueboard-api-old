﻿using BlueBoard.Common.Enums;

namespace BlueBoard.Domain
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Gets or sets user first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets user last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets username
        /// </summary>
        public string Username { get; set; }

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

        /// <summary>
        /// Gets or sets user avatar
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Gets or sets user status
        /// </summary>
        public UserStatus Status { get; set; }
    }
}
