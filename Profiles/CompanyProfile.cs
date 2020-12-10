using AutoMapper;
using Routine.Api.Entities;
using Routine.Api.Model;

namespace Routine.Api.Profiles
{
    /// <summary>
    /// 使用 AutoMap 进行 实体和viewmodel之间 映射
    /// </summary>
    public class CompanyProfile:Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(
                           dest => dest.CompanyName,
                           opt => opt.MapFrom(src => src.Name));
        }
    }
}
