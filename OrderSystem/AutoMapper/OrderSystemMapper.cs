using AutoMapper;
using OrderSystem.Models;
using OrderSystem.UserModel;

namespace OrderSystem.AutoMapper
{
    public class OrderSystemMapper : Profile
    {
        public OrderSystemMapper() 
        {
            CreateMap<ItemMaster, ItemMasterDto>().ReverseMap();
            CreateMap<UserMaster, UserMasterDto>().ReverseMap();
            CreateMap<CompanyMaster, CompanyMasterDto>().ReverseMap();
            CreateMap<UserCategoryMaster, UserCategoryMasterDto>().ReverseMap();
            CreateMap<ChangePasswordDto, UserMaster>()
                .ForMember(dst => dst.UserId, src => src.MapFrom(act => act.UserId))
                .ForMember(dst => dst.Email, src => src.MapFrom(act => act.Email))
                .ForMember(dst => dst.Password, src => src.MapFrom(act => act.Password));
            CreateMap<OrderDetailsDto, OrderDetail>().ReverseMap();
            CreateMap<MenuMasterDto,MenuMaster>().ReverseMap();
            CreateMap<MenuPermissionDto, MenuPermission>().ReverseMap();
            CreateMap<OrderPayment,PaymentDto>().ReverseMap();
            CreateMap<PartyMast,PartyMastDto>().ReverseMap();  
        }
    }
}
