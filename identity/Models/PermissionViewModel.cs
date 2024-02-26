
namespace IdClaimsPractice3.Models
{
    public class PermissionViewModel
    {
        public string UserId { get; set; }

        public bool CanCreateDepartment { get; set; }
        public bool CanEditDepartment { get; set; }
        public bool CanDeleteDepartment { get; set; }
        public bool CanViewDepartment { get; set; }

        public bool CanCreateEmployee { get; set; }
        public bool CanEditEmployee { get; set; }
        public bool CanDeleteEmployee { get; set; }
        public bool CanViewEmployee { get; set; }

        public bool CanCreateLocation { get; set; }
        public bool CanEditLocation { get; set; }
        public bool CanDeleteLocation { get; set; }
        public bool CanViewLocation { get; set; }

        public bool CanCreateMachine { get; set; }
        public bool CanEditMachine { get; set; }
        public bool CanDeleteMachine { get; set; }
        public bool CanViewMachine { get; set; }
    }
}
