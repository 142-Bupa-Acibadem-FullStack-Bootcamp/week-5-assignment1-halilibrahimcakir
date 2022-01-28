using Northwind.Data.Repository;
using Northwind.Data.UnitOfWork;
using Northwind.Services.LazyInitialization;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Northwind.Services.Service
{
    public class ServiceBase<T, TModel> : IService<T, TModel> where T : class where TModel : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;
        private readonly IServiceProvider _service;

        public ServiceBase(IServiceProvider service)
        {
            _unitOfWork = service.GetService<IUnitOfWork>();
            _repository = _unitOfWork.GetRepository<T>();
            _service = service;
        }
        public TModel Add(TModel model)
        {
            try
            {

                var entity = LazyObject.Mapper.Map<TModel, T>(model);
                var result = _repository.Add(entity);
                _unitOfWork.SaveChanges();

                return LazyObject.Mapper.Map<T, TModel>(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _repository.GetById(id);
                var result = _repository.Delete(entity);
                _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TModel> GetAll()
        {
            try
            {
                var list = _repository.GetAll().ToList();
                return list.Select(LazyObject.Mapper.Map<T, TModel>).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TModel GetById(int id)
        {
            try
            {
                var entity = _repository.GetById(id);
                return LazyObject.Mapper.Map<T, TModel>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TModel Update(TModel model)
        {
            try
            {
                var entity = LazyObject.Mapper.Map<TModel, T>(model);
                var result = _repository.Update(entity);
                _unitOfWork.SaveChanges();

                return LazyObject.Mapper.Map<T, TModel>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}