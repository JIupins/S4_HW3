using AutoMapper;
using S4_HW3.Contracts.Requests;
using S4_HW3.Contracts.Responses;
using S4_HW3.Models;

namespace S4_HW3.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>(MemberList.Destination).ReverseMap();
            CreateMap<Product, ProductCreateRequest>(MemberList.Destination).ReverseMap();
            CreateMap<Product, ProductDeleteRequest>(MemberList.Destination).ReverseMap();
            CreateMap<Product, ProductUpdateRequest>(MemberList.Destination).ReverseMap();
        }
    }
}