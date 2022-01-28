using Northwind.Data.Context;
using Northwind.Data.Repository;
using Northwind.Data.UnitOfWork;
using Northwind.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Services.LazyInitialization;

namespace Northwind.Services.Service
{
    public class ProductService : ServiceBase<Product, ProductModel>, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _repository;
        public ProductService(IServiceProvider service) : base(service)
        {
            _unitOfWork = service.GetService<IUnitOfWork>();
            _repository = _unitOfWork.GetRepository<Product>();
        }  
    }
}
