using Microsoft.AspNetCore.Identity;

namespace DotNetCore8Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
