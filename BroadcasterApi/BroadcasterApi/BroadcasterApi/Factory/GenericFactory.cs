using AutoMapper;
using BLL;
using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroadcasterApi.Factory
{
    public class GenericFactory<TEntity> : IGenericFactory<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly IGenericService<TEntity> _genericService;
        private readonly IMapper _mapper;
        public GenericFactory(IGenericService<TEntity> genericService,
            IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }
        public virtual async Task<(bool result, string mesage, string error)> Insert<TViewModel>(TViewModel model) where TViewModel : class
        {
            var m = _mapper.Map<TEntity>(model);
             await _genericService.Insert(m);
            return (true, "Data Insersted Successfully", null);
        }
        public virtual async Task<(bool result, string mesage, string error)> Update<TViewModel>(int id, TViewModel model) where TViewModel : class
        {
            var g = await _genericService.GetEntity(x => x.Id == id);
            var m = _mapper.Map<TEntity>(model);
            return await _genericService.Update(m);
        }
        public virtual async Task<(bool result, string mesage, string error)> Delete(int id)
        {
            var data = await _genericService.GetEntity(x => x.Id == id);
            return await _genericService.Delete(data);
        }
        public virtual async Task<List<TViewModel>> Get<TViewModel>() where TViewModel : class
        {
            var data = await _genericService.GetListAsync(x => true);
            var list = _mapper.Map<List<TEntity>, List<TViewModel>>(data);
            return list;
        }
        public virtual async Task<TViewModel> DetailsById<TViewModel>(int id) where TViewModel : class
        {
            var data = await _genericService.GetEntity(x => x.Id == id);
            var model = _mapper.Map<TViewModel>(data);
            return model;
        }
    }
}
