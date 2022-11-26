using System.ComponentModel.DataAnnotations;

namespace BroadcasterApi.ViewModel.CreateRole
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
