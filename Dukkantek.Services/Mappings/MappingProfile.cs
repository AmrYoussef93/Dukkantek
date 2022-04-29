using AutoMapper;
using Dukkantek.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(Result<>), typeof(Result<>));

            //CreateMap<Order, OrderDTO>()
            //    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));

            //CreateMap<OrderItems, ItemDTO>()
            //    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name));

        }
    }
}
