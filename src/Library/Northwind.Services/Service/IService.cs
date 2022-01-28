using Northwind.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Service
{
    public interface IService<T, TModel> where T : class where TModel : class
    {
        List<TModel> GetAll();
        TModel GetById(int id);
        TModel Add(TModel model);
        bool Delete(int id);
        TModel Update(TModel model);
    }
}