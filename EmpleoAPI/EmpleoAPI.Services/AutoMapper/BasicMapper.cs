using EmpleoAPI.Common.DTOS;
using EmpleoAPI.Common.Request;

namespace EmpleoAPI.Services.AutoMapper
{
    public class BasicMapper : global::AutoMapper.Profile
    {
        public BasicMapper()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<CityRequest, CityDTO>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(u => u.Name));

            CreateMap<Seller, SellerDTO>().ReverseMap();
            CreateMap<SellerRequest, SellerDTO>();

        }
    }
}