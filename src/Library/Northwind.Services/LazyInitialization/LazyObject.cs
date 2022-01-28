using AutoMapper;
using Northwind.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.LazyInitialization
{
    internal class LazyObject
    {
        static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperFactory>();
            });

            return config.CreateMapper();
        }
       );

        public static IMapper Mapper => lazy.Value;
    }
}
