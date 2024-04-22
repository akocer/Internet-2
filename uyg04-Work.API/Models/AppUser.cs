using Microsoft.AspNetCore.Identity;

namespace uyg04_Work.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string PicUrl { get; set; }
    }
}
