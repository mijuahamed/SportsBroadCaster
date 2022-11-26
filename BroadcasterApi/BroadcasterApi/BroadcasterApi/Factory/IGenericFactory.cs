using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroadcasterApi.Factory
{
    public interface IGenericFactory<TEntity> where TEntity : BaseEntity, new()
    {
        Task<(bool result, string mesage, string error)> Insert<TViewModel>(TViewModel model) where TViewModel : class;
        Task<(bool result, string mesage, string error)> Update<TViewModel>(int id, TViewModel model) where TViewModel : class;
        Task<(bool result, string mesage, string error)> Delete(int id);
        Task<List<TViewModel>> Get<TViewModel>() where TViewModel : class;
        Task<TViewModel> DetailsById<TViewModel>(int id) where TViewModel : class;
    }
}
