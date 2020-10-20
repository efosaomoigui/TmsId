using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TmsId.Api.Services;
using TmsId.Shared;

namespace TmsId.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LafargeTmsController : ControllerBase
    {
        private ILafargeTmsService _service;
        public LafargeTmsController(ILafargeTmsService service)
        {
            _service = service;
        }

        //Get all truck
        [HttpGet("getTrucks")]
        public ActionResult GetAllTrucks()
        {
            var result = _service.GetAllTrucks();
            return Ok(result);
        }

        //Get all truck drivers
        [HttpGet("getDrivers")]
        public ActionResult GetAllDrivers()
        {
            var result = _service.GetAllDrivers();
            return Ok(result);
        }

        //Get distance from a particular static location
        [HttpPost("distanceInKm")]
        public ActionResult GetDistance([FromBody] FilterCriteriaViewModel filtercriteria) 
        {
            try
            {
                var result = _service.GetDistanceInKm(filtercriteria);
                return Ok(result.Result);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //Get location by using driver as filter criteria
        [HttpPost("getTruckLocationByDriver")]
        public ActionResult GetLocationByDriver([FromBody] FilterCriteriaViewModel filtercriteria) 
        {
            try
            {
                var result = _service.GetLocationByDriver(filtercriteria);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //
        [HttpPost("getTruckLocationByAsset")]
        public ActionResult GetLocationByAsset([FromBody] FilterCriteriaViewModel filtercriteria)
        {
            try
            {
                var result = _service.GetLocationByAssetId(filtercriteria);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }

        }


    }
}
