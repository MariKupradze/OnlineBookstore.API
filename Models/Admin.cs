using Microsoft.AspNetCore.Identity;

namespace OnlineBookstore.API.Models
{
    public class Admin : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName{ get; set; }

    }
}
