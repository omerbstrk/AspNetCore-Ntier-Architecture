using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;

    namespace Ticket.ServiceHelper
    {
        public static class Mapping
        {
            private static readonly Lazy<IMapper> Lazy = new(() => {
                MapperConfiguration config = new(cfg => {
                    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                    cfg.AddProfile<MappingProfile>();
                });
                IMapper mapper = config.CreateMapper();
                return mapper;
            });

            public static IMapper Mapper => Lazy.Value;
        }
        //public class MappingProfile : Profile
        //{
        //    public MappingProfile()
        //    {
        //        CreateMap<EventCategori, EventCategoriDTO>().ReverseMap();
        //        CreateMap<Order, OrderDTO>().ReverseMap();
        //        CreateMap<Review, ReviewDTO>().ReverseMap();
        //        CreateMap<SupportRequest, SupportRequestDTO>().ReverseMap();
        //        CreateMap<TicketEntity, TicketDTO>().ReverseMap();
        //        CreateMap<User, UserDTO>().ReverseMap();
        //        CreateMap<User, AuthDTO>();
        //        CreateMap<EmailConfirm, EmailConfirmDTO>().ReverseMap();
        //        CreateMap<ResetPassword, ResetPasswordDTO>().ReverseMap();
        //    }
        //}
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                
            }
        }

    }

}
