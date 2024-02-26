using Microsoft.AspNetCore.Identity;

namespace IdClaimsPractice3.Models
{
    public class RolePermissionViewModel
    {
        public List<IdentityRole> Roles { get; set; }
        public string SelectedRoleId { get; set; }
        public PermissionViewModel Permissions { get; set; }
    }
}
