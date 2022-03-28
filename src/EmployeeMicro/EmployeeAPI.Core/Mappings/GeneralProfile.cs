using AutoMapper;
using EmployeeAPI.Core.DTOs;
using EmployeeAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Core.Mappings
{
    internal class GeneralProfile : Profile
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
