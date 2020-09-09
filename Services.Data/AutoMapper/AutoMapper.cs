using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Data.AutoMapper
{
    public class AutoMapper : IAutoMapper
    {
        public IMapper Mapper { get; }
        public AutoMapper()
        {
            var mapCnfg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            Mapper = mapCnfg.CreateMapper();
        }
    }
}
