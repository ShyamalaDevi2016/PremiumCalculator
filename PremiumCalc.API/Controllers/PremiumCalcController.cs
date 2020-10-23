using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumCalc.Services;
using PremiumCalc.API.Models;
using PremiumCalc.API.Utility;
using AutoMapper;
using PremiumCalc.API.Request;
using PremiumCalc.Infra;
using PremiumCalc.API.Response;
using System.Globalization;

namespace PremiumCalc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumCalcController : ControllerBase
    {

        private readonly IPremiumCalcService objPremiumService;
        private readonly IPremiumCalcLogic objPremiumLogic;
        private readonly IMapper objMapper;
        private readonly ILoggerManager _logger;

        /// <summary>
        /// api controller constructor
        /// </summary>
        /// <param name="_objPremiumService">service object</param>
        /// <param name="_objPremiumLogic">premium calculator logic object</param>
        /// <param name="_objMapper">Automapper</param>
        /// <param name="logger">loggerManager object</param>
        public PremiumCalcController(IPremiumCalcService _objPremiumService, IPremiumCalcLogic _objPremiumLogic, 
            IMapper _objMapper, ILoggerManager logger)
        {
            objPremiumService = _objPremiumService;
            objPremiumLogic = _objPremiumLogic;
            objMapper = _objMapper;
            _logger = logger;
        }


        /// <summary>
        /// Gets all the available occupations in the system
        /// </summary>
        /// <returns><List<Occupations></returns>
        [HttpGet]
        [Route("Occupations")]
        public IActionResult GetAllOccupations()
        {
       
            _logger.LogInfo("GetAllOccupations method executing");
            OccupationResponse occupationResponse = new OccupationResponse();
            occupationResponse.Occupations = objMapper.Map<List<Occupations>>(objPremiumService.GetAllOccupations());
            _logger.LogInfo("GetAllOccupations method executed");
            return Ok(occupationResponse);
            
        }

        /// <summary>
        /// Calculate monthly premium amount
        /// </summary>
        /// <param name="request">user info</param>
        [HttpPost]
        [Route("MonthlyPremiumCalculator")]
        public IActionResult MonthlyPremiumCalculator(PremiumCalcRequest request)
        {
           
            _logger.LogInfo("MonthlyPremiumCalculator method executing");

            PremiumCalcResponse premiumCalcResponse = new PremiumCalcResponse();
            premiumCalcResponse.MonthlyPremiumAmout = objPremiumLogic.MonthlyPremiumCalcForUser(request.DeathCoverAmt, request.OccupationId, request.DOB);
            _logger.LogInfo("MonthlyPremiumCalculator method executed");
            return Ok(premiumCalcResponse);
        }

    }
}
