using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interface;
using SchoolManagement.WebApi.Helpers;

namespace SchoolManagement.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTableController : ControllerBase
    {
        private readonly ITimeTableService timeTableService;

        public TimeTableController(ITimeTableService timeTableService)
        {
            this.timeTableService = timeTableService;
        }


        [HttpPost("generateTimeTable")]
        public async Task<IActionResult> GenerateTimeTable()
        {
            var response = await timeTableService.GenerateTimeTable(IdentityHelper.GetUsername());

            return Ok(response);
        }

        [HttpGet("getAcademicYears")]
        public IActionResult GetAcademicYears()
        {
            var response =  timeTableService.GetAcademicYears();

            return Ok(response);
        }

        [HttpGet("getGeneratedTimeTables/{acaemicYearId:int}")]
        public IActionResult GetGeneratedTimeTables(long acaemicYearId)
        {
            var response = timeTableService.GetGeneratedTimeTable(acaemicYearId);

            return Ok(response);
        }
    }
}