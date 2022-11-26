using System.Threading.Tasks;
using ViewModel;

namespace BroadcasterApi.Factory.UserFileFactory
{
    public interface IUserFileFactory
    {
        Task<(bool result, string mesage, string error)> Insert(UserFileViewModel model);
    }
}
