using Microsoft.AspNetCore.Identity;

namespace IdClaimsPractice3.Models
{
    public class UserPermissionViewModel
    {
        public List<IdentityUser> Users { get; set; }
        public string SelectedUserId { get; set; }
        public PermissionViewModel Permissions { get; set; }
    }
}
