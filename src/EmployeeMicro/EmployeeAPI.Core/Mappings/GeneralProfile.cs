using AutoMapper;
using EmployeeAPI.Core.DTOs;
using EmployeeAPI.Core.Entities;

namespace EmployeeAPI.Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateEmployeeRequest, Employee>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.CreatedAt,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.UpdatedAt,
                    opt => opt.Ignore()
                );
        }
    }
}
