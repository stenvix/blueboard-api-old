using BlueBoard.Common.Enums;

namespace BlueBoard.Application.Users.Models
{
    public class UserModel : SlimUserModel
    {
        /// <summary>
        /// Gets or sets user email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets user phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets user status
        /// </summary>
        public UserStatus Status { get; set; }
    }
}
