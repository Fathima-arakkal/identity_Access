using IdClaimsPractice3.Data;
using IdClaimsPractice3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
 
namespace IdClaimsPractice3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PermissionsController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
 
        public PermissionsController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        [HttpGet]
        public IActionResult ManagePermissions()
        {
            var roles = _roleManager.Roles.ToList();
            return View(new RolePermissionViewModel { Roles = roles });
        }
 
        [HttpGet("{userId}")]
        public async Task<IActionResult> ManagePermissions(string userId)
        {
            var role = await _roleManager.FindByIdAsync(userId);
 
            var model = new RolePermissionViewModel
            {
                Roles = _roleManager.Roles.ToList(),
                SelectedRoleId = userId,
                Permissions = new PermissionViewModel
                {
                    CanCreateDepartment = await _roleManager.RoleExistsAsync("CanCreateDepartment"),
                    CanEditDepartment = await _roleManager.RoleExistsAsync("CanEditDepartment"),
                    CanDeleteDepartment = await _roleManager.RoleExistsAsync("CanDeleteDepartment"),
                    CanViewDepartment = await _roleManager.RoleExistsAsync("CanViewDepartment"),
 
                    CanCreateEmployee = await _roleManager.RoleExistsAsync("CanCreateEmployee"),
                    CanEditEmployee = await _roleManager.RoleExistsAsync("CanEditEmployee"),
                    CanDeleteEmployee = await _roleManager.RoleExistsAsync("CanDeleteEmployee"),
                    CanViewEmployee = await _roleManager.RoleExistsAsync("CanViewEmployee"),
 
                    CanCreateMachine = await _roleManager.RoleExistsAsync("CanCreateMachine"),
                    CanEditMachine = await _roleManager.RoleExistsAsync("CanEditMachine"),
                    CanDeleteMachine = await _roleManager.RoleExistsAsync("CanDeleteMachine"),
                    CanViewMachine = await _roleManager.RoleExistsAsync("CanViewMachine"),
 
                    CanCreateLocation = await _roleManager.RoleExistsAsync("CanCreateLocation"),
                    CanEditLocation = await _roleManager.RoleExistsAsync("CanEditLocation"),
                    CanDeleteLocation = await _roleManager.RoleExistsAsync("CanDeleteLocation"),
                    CanViewLocation = await _roleManager.RoleExistsAsync("CanViewLocation"),
                }
            };
 
            return View(model);
        }
 
        [HttpPost]
        public async Task<IActionResult> UpdatePermissions(RolePermissionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.SelectedRoleId);
            if (model.Permissions != null) // Check if Permissions is not null
            {
                await UpdateRolePermission(role, "CanCreateDepartment", model.Permissions.CanCreateDepartment);
                await UpdateRolePermission(role, "CanEditDepartment", model.Permissions.CanEditDepartment);
                await UpdateRolePermission(role, "CanDeleteDepartment", model.Permissions.CanDeleteDepartment);
                await UpdateRolePermission(role, "CanViewDepartment", model.Permissions.CanViewDepartment);
 
                await UpdateRolePermission(role, "CanCreateEmployee", model.Permissions.CanCreateEmployee);
                await UpdateRolePermission(role, "CanEditEmployee", model.Permissions.CanEditEmployee);
                await UpdateRolePermission(role, "CanDeleteEmployee", model.Permissions.CanDeleteEmployee);
                await UpdateRolePermission(role, "CanViewEmployee", model.Permissions.CanViewEmployee);
 
                await UpdateRolePermission(role, "CanCreateMachine", model.Permissions.CanCreateMachine);
                await UpdateRolePermission(role, "CanEditMachine", model.Permissions.CanEditMachine);
                await UpdateRolePermission(role, "CanDeleteMachine", model.Permissions.CanDeleteMachine);
                await UpdateRolePermission(role, "CanViewMachine", model.Permissions.CanViewMachine);
 
                await UpdateRolePermission(role, "CanCreateLocation", model.Permissions.CanCreateLocation);
                await UpdateRolePermission(role, "CanEditLocation", model.Permissions.CanEditLocation);
                await UpdateRolePermission(role, "CanDeleteLocation", model.Permissions.CanDeleteLocation);
                await UpdateRolePermission(role, "CanViewLocation", model.Permissions.CanViewLocation);
            }
            return RedirectToAction(nameof(Index));
        }
        private async Task UpdateRolePermission(IdentityRole role, string permission, bool isSelected)
        {
            if (isSelected)
            {
                if (!await _roleManager.RoleExistsAsync(permission))
                {
                    await _roleManager.CreateAsync(new IdentityRole(permission));
                }
 
                var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
                foreach (var user in usersInRole)
                {
                    await _userManager.AddToRoleAsync(user, permission);
                }
            }
            else
            {
                var usersInPermissionRole = await _userManager.GetUsersInRoleAsync(permission);
                foreach (var user in usersInPermissionRole)
                {
                    await _userManager.RemoveFromRoleAsync(user, permission);
                }
            }
        }
    }
}