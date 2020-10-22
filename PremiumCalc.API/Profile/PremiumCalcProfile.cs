using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PremiumCalc.Services.Models;
using PremiumCalc.API.Models;
namespace PremiumCalc.API.Mapper
{
    public class PremiumCalcProfile : Profile
    {
        public PremiumCalcProfile()
        {
            CreateMap<OccupationRating, Occupations>();
            CreateMap<RatingMaster, Ratings>();
        }
    }
}
