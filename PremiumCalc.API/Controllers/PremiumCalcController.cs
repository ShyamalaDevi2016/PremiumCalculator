using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumCalc.Services;
using PremiumCalc.API.Models;
using PremiumCalc.API.Utility;
using AutoMapper;


namespace PremiumCalc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumCalcController : ControllerBase
    {

        private readonly IPremiumCalcService objPremiumService;
        private readonly IPremiumCalcLogic objPremiumLogic;
        private readonly IMapper objMapper;

        public PremiumCalcController(IPremiumCalcService _objPremiumService, IPremiumCalcLogic _objPremiumLogic, IMapper _objMapper)
        {
            objPremiumService = _objPremiumService;
            objPremiumLogic = _objPremiumLogic;
            objMapper = _objMapper;
        }


        // GET api/values
        [HttpGet]
        [Route("Occupations")]
        public IActionResult GetAllOccupations()
        {
            return Ok(objMapper.Map<List<Occupations>>(objPremiumService.GetAllOccupations()));
        }


        [HttpGet]
        [Route("MonthlyPremiumCalculator/{DeathCoverAmt}/{OccupationId}/{Age}")]
        public IActionResult MonthlyPremiumCalculator(int DeathCoverAmt, int OccupationId, int Age)
        {
            try
            {
                if(OccupationId == 0)
                     return UnprocessableEntity("Occupation Id is not valid");

                var PremiumAmt = objPremiumLogic.MonthlyPremiumCalcForUser(DeathCoverAmt, OccupationId, Age);

                return Ok(PremiumAmt);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
