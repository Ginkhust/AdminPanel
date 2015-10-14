using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminPanel.Models
{
    public class ServerUserModel
    {
        public string ObjectId { get; set; }
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        public string PasswordConfirmation { get; set; }

        [Required]
        public string Email { get; set; }

        [Compare("Email")]
        public string EmailConfirmation { get; set; }
        public List<Roles> Role { get; set; }
        public string EmailVerify { get; set; }
    }

    public class Roles
    {
        public string ObjectId { get; set; }
        public string name { get; set; }
        public List<ServerUserModel> serverUser { get; set; }
        public List<Roles> roleChild { get; set; }
    }
}
