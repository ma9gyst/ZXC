using AutoMapper;

namespace Services.Data.AutoMapper
{
    public interface IAutoMapper
    {
        public IMapper Mapper { get; }
    }
}