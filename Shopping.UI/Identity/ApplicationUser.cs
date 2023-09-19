using Microsoft.AspNetCore.Identity;

namespace Shopping.UI.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
