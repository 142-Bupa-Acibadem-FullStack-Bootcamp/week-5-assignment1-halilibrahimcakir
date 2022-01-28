using AutoMapper;
using Northwind.Data.Context;
using Northwind.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Mapper
{
    public class MapperFactory : Profile
    {
        public MapperFactory()
        {
            CreateMap<Product, ProductModel>().MaxDepth(1).ReverseMap();
            CreateMap<Order, OrderModel>().MaxDepth(1).ReverseMap();
            CreateMap<OrderDetail, OrderDetailModel>().MaxDepth(1).ReverseMap();
            CreateMap<Customer, CustomerModel>().MaxDepth(1).ReverseMap();
            CreateMap<Employee, EmployeeModel>().MaxDepth(1).ReverseMap();
        }
    }
}