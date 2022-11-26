using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BroadcastClient.ViewComponents
{
    public class LoginStatusViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            throw new System.Exception();
            //return await Task.FromResult((IViewComponentResult)View("Sidebar"));
        }
    }
}
