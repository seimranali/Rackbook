using Microsoft.AspNetCore.Components;
using Rackbook.WebUI.Services;

namespace Rackbook.WebUI
{
    public class BaseComponent : ComponentBase
    {

        [CascadingParameter(Name = "UserSession")]
        public UserSession? UserSesssion { get; set; }

    }
}
