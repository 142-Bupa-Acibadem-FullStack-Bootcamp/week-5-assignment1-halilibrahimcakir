using Northwind.Data.Context;
using Northwind.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Service
{
    public interface IProductService : IService<Product, ProductModel>
    {
    }
}
