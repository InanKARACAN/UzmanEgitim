using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.Extensions;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Responses;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class Service<TEntity, TDto> : IService<TEntity, TDto> where TEntity : class, IEntity where TDto : class, IDto
    {
        public readonly IRepository<TEntity> _repository;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        #region Reponse dönen methotlar

        public async Task<GResponse<TDto>> GetByIdWithResponseAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            var dtoData = _mapper.Map<TDto>(data);
            return data != null ? new GResponse<TDto>(dtoData) : new GResponse<TDto>("Kayıt bulunamadı.");
        }

        public async Task<GResponse<IEnumerable<TDto>>> GetAllWithResponseAsync()
        {
            var data = await _repository.GetAllAsync();
            var dtoData = _mapper.Map<IEnumerable<TDto>>(data);
            return data != null
                ? new GResponse<IEnumerable<TDto>>(dtoData)
                : new GResponse<IEnumerable<TDto>>("Kayıt bulunamadı.");
        }

        public async Task<GResponse<IEnumerable<TDto>>> WhereWithResponse(Expression<Func<TEntity, bool>> predicate)
        {
            var data = await _repository.Where(predicate);
            var dtoData = _mapper.Map<IEnumerable<TDto>>(data);
            return data != null
                ? new GResponse<IEnumerable<TDto>>(dtoData)
                : new GResponse<IEnumerable<TDto>>("Kayıt bulunamadı.");
        }

        public async Task<GResponse<TDto>> SingleOrDefaultWithResponseAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var data = await _repository.SingleOrDefaultAsync(predicate);
            var dtoData = _mapper.Map<TDto>(data);
            return data != null ? new GResponse<TDto>(dtoData) : new GResponse<TDto>("Kayıt bulunamadı.");
        }

        public async Task<GResponse<TDto>> AddWithResponseAsync(TEntity entity)
        {
            try
            {
                await _repository.AddAsync(entity);
                await _unitOfWork.CommitAsync();
                var dtoData = _mapper.Map<TDto>(entity);
                return entity != null ? new GResponse<TDto>(dtoData) : new GResponse<TDto>("Kayıt bulunamadı.");
            }
            catch (Exception ex)
            {
                var msg = ex.GetAllInnerException();
                return new GResponse<TDto>(
                    $"Kayıt yapılırken bir hata oluştu::{_mapper.Map<TDto>(entity).GetType().Name}::{msg}");
            }
        }

        public async Task<GResponse<IEnumerable<TDto>>> AddRangeWithResponseAsync(List<TEntity> entities)
        {
            try
            {
                await _repository.AddRangeAsync(entities);
                await _unitOfWork.CommitAsync();
                var dtoData = _mapper.Map<IEnumerable<TDto>>(entities);
                return entities != null
                    ? new GResponse<IEnumerable<TDto>>(dtoData)
                    : new GResponse<IEnumerable<TDto>>("Kayıt bulunamadı.");
            }
            catch (Exception ex)
            {
                var msg = ex.GetAllInnerException();
                return new GResponse<IEnumerable<TDto>>(
                    $"Kayıt yapılırken bir hata oluştu::{_mapper.Map<IEnumerable<TDto>>(entities).GetType().Name}::{msg}");
            }
        }

        public async Task<GResponse<TDto>> RemoveWithResponseAsync(int id)
        {
            try
            {
                var t = await GetByIdAsync(id);
                if (t == null)
                {
                    return new GResponse<TDto>($"{typeof(TEntity).Name}=>{id} kaydı bulunamamıştır.");
                }

                _repository.Remove(t);
                _unitOfWork.Commit();
                var dtoData = _mapper.Map<TDto>(t);
                return new GResponse<TDto>(dtoData);
            }
            catch (Exception ex)
            {
                var msg = ex.GetAllInnerException();
                return new GResponse<TDto>($"{typeof(TEntity).Name}=>{id} silme sırasında bir hata oluştu::{msg}");
            }
        }

        public GResponse<IEnumerable<TDto>> RemoveRangeReponse(IEnumerable<TEntity> entities)
        {
            try
            {
                var list = entities.ToArray();
                _repository.RemoveRange(list);
                _unitOfWork.Commit();
                var dtoData = _mapper.Map<IEnumerable<TDto>>(entities);
                return new GResponse<IEnumerable<TDto>>(dtoData);
            }
            catch (Exception ex)
            {
                var msg = ex.GetAllInnerException();
                return new GResponse<IEnumerable<TDto>>(
                    $"{typeof(TEntity).Name}=> güncelleme sırasında bir hata oluştu::{msg}");
            }
        }

        public GResponse<TDto> UpdateWithResponse(TEntity entity)
        {
            try
            {
                var updatedEntity = _repository.Update(entity);
                _unitOfWork.Commit();
                var dtoData = _mapper.Map<TDto>(updatedEntity);
                return new GResponse<TDto>(dtoData);
            }
            catch (Exception ex)
            {
                var msg = ex.GetAllInnerException();
                return new GResponse<TDto>($"{typeof(TEntity).Name}=> güncelleme sırasında bir hata oluştu::{msg}");
            }
        }

        public GResponse<DbSet<TEntity>> GetTableWithResponse()
        {
            return new GResponse<DbSet<TEntity>>(_repository.GetTable());
        }

        #endregion

        #region Entity Dönen methotlar

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            return data;
        }

        public async Task<TEntity> GetByIdAsNoTrackingAsync(int id)
        {
            var data = await _repository.GetByIdAsNoTrackingAsync(id);
            return data;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return data;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var data = await _repository.Where(predicate);
            return data;
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var data = await _repository.SingleOrDefaultAsync(predicate);
            return data;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                await _repository.AddAsync(entity);
                await _unitOfWork.CommitAsync();
                return entity;
            }
            catch (Exception ex)
            {
                var msg = ex.GetAllInnerException();
                throw new Exception($"Kayıt yapılırken bir hata oluştu::{entity.GetType().Name}::{msg}");
            }
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            try
            {
                await _repository.AddRangeAsync(entities);
                await _unitOfWork.CommitAsync();
                return entities;
            }
            catch (Exception ex)
            {
                var msg = ex.GetAllInnerException();
                throw new Exception($"Çoklu kayıt yapılırken bir hata oluştu::{entities.GetType().Name}::{msg}");
            }
        }

        public async Task<TEntity> Remove(int id)
        {
            try
            {
                var t = await GetByIdAsync(id);
                if (t == null)
                {
                    throw new Exception($"{typeof(TEntity).Name}=>{id} kaydı bulunamamıştır.");
                }

                _repository.Remove(t);
                _unitOfWork.Commit();
                return t;
            }
            catch (Exception ex)
            {
                var msg = ex.GetAllInnerException();
                throw new Exception($"{typeof(TEntity).Name}=>{id} silme sırasında bir hata oluştu::{msg}");
            }
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                var updatedEntity = _repository.Update(entity);
                _unitOfWork.Commit();
                return updatedEntity;
            }
            catch (Exception ex)
            {
                var msg = ex.GetAllInnerException();
                throw new Exception($"{typeof(TEntity).Name}=> güncelleme sırasında bir hata oluştu::{msg}");
            }
        }

        public DbSet<TEntity> GetTable()
        {
            return _repository.GetTable();
        }

        #endregion

    }
}
