using AutoMapper;
using TVScheduler.DataAccess.Dto;
using TVScheduler.WebApi.Models;

namespace TVScheduler.Business.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateChannelRequest, Channel>();
            CreateMap<CreateProgramRequest, Program>();
        }
    }
}
