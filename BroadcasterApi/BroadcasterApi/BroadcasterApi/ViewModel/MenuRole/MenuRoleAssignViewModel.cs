using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcasterApi.ViewModel.MenuRole
{
    public class MenuRoleAssignViewModel
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public bool IsSelected { get; set; }
    }
}
