using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace IdClaimsPractice3.Models
{
    public class RolePermissionViewModel
    {
        public List<IdentityRole> Roles { get; set; }
        public string SelectedRoleId { get; set; }
        public List<string> SelectedRoles { get; set; }
        public PermissionViewModel Permissions { get; set; }

        public RolePermissionViewModel()
        {
            SelectedRoles = new List<string>();
            Permissions = new PermissionViewModel();
        }
    }
}
