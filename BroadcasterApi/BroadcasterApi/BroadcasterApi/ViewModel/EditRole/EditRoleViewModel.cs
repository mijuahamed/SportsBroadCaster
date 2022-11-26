using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BroadcasterApi.ViewModel.EditRole
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }

        [Required]
        public string RoleName { get; set; }

    }
}
