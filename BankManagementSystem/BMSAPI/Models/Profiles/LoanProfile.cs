using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Models.Profiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Models.Domain.Loan, Models.DTO.Loan>().ReverseMap();

            CreateMap<Models.Domain.User, Models.DTO.User>().ReverseMap();
        }

    }
}
