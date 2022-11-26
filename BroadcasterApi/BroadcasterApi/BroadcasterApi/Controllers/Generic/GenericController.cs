using BroadcasterApi.Factory;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BroadcasterApi.Controllers.Generic
{
    [ApiController]
    public class GenericController<TEntity, TViewModel> : ControllerBase where TEntity : BaseEntity, new() where TViewModel : class
    {
        private readonly IGenericFactory<TEntity> _genericFactory;
        public GenericController(IGenericFactory<TEntity> genericFactory)
        {
            _genericFactory = genericFactory;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Insert(TViewModel model)
        {
            var result = await _genericFactory.Insert(model);
            return Ok(new { success = true, message = "Created Successfully", error = "", data = result });
        }
        [HttpPost]
        public virtual async Task<IActionResult> Update(int id, TViewModel model)
        {
            var result = await _genericFactory.Update(id, model);
            return Ok(new { success = true, message = "Updated Successfully", error = "", data = result });
        }
        [HttpGet]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _genericFactory.Delete(id);
            return Ok(new { success = true, message = "Deleted Successfully", error = "", data = result });
        }
        [HttpGet]
        public virtual async Task<IActionResult> Details(int id)
        {
            var data = await _genericFactory.DetailsById<TViewModel>(id);
            return Ok(data);
        }

        [HttpGet]
        public virtual async Task<IActionResult> List()
        {
            var list = await _genericFactory.Get<TViewModel>();
            return Ok(new { message = string.Format("{0} List Fetched Successfully", typeof(TEntity)), result = list });
        }
    }
}
