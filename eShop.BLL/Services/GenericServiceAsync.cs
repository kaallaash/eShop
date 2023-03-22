using AutoMapper;
using eShop.Core.Interfaces;

namespace eShop.BLL.Services;

public class GenericServiceAsync<TModel, TEntity> : IGenericServiceAsync<TModel> 
    where TModel : class
    where TEntity : class
{
    private readonly IGenericRepositoryAsync<TEntity> _genericRepository;
    private readonly IMapper _mapper;

    public GenericServiceAsync(IGenericRepositoryAsync<TEntity> genericRepository, IMapper mapper)
    {
        _genericRepository = genericRepository;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken) =>
        _mapper.Map<IEnumerable<TModel>>(await _genericRepository.GetAllAsync(cancellationToken));

    public virtual async Task<TModel?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _genericRepository.GetByIdAsync(id, cancellationToken);

        return _mapper.Map<TModel>(entity);
    }

    public virtual async Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken)
    {
        return _mapper.Map<TModel>(await _genericRepository.CreateAsync(
            _mapper.Map<TEntity>(model), cancellationToken));
    }

    public virtual async Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken) =>
        _mapper.Map<TModel>(await _genericRepository.UpdateAsync(_mapper.Map<TEntity>(model), cancellationToken));

    public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _genericRepository.GetByIdAsync(id, cancellationToken);

        if (entity is not null)
        {
            await _genericRepository.DeleteAsync(id, cancellationToken);
        }

        //return _mapper.Map<TModel>(entity);
    }
}