using System;

namespace Core.Models.Model.Security
{
    public class User
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string ProviderName { get; set; }

        public DateTime? LastLoggedIn { get; set; }

        /// <summary>
        /// every time the user changes his Password,
        /// or an admin changes his Roles or stat/IsActive,
        /// create a new `SerialNumber` GUID and store it in the DB.
        /// </summary>
        public Guid SerialNumber { get; set; }
    }
}
