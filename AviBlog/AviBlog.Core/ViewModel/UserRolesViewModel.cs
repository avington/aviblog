using System.Collections.Generic;
using System.Web.Mvc;

namespace AviBlog.Core.ViewModel
{
    public class UserRolesViewModel : BaseViewModel 
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<RolesViewModel> Roles { get; set; }

        public MultiSelectList MultiSelectRoles { get; set; }

        public string[] SelectedRoleIds { get; set; }
    }
}