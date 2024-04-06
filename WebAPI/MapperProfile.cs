using AutoMapper;

namespace WebAPI
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<SharedDto.ProductDto, SharedLibrary.Product>().ReverseMap();
            CreateMap<SharedDto.CategoryDto, SharedLibrary.Category>().ReverseMap();
        }
    }
}
