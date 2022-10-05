using EmpleoAPI.Common.Constants;
using EmpleoAPI.Common.DTOS;
using EmpleoAPI.Common.Request;
using EmpleoAPI.Config;
using EmpleoAPI.Services.Services;
using EmpleoAPI.Services.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmpleoAPI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICityValidator _cityValidator;
        public CityController(ICityService cityService , ICityValidator cityValidator)
        {
            _cityService = cityService;
            _cityValidator = cityValidator;
        }

        [HttpGet]
        [Route(ApiRoutes.City.GetCityById)]
        public IActionResult Get(int id)
        {
            _cityValidator.ExistsCity(id);
            return Ok(_cityService.GetCity(id));
        }

        [HttpGet]
        [Route(ApiRoutes.City.GetAllCity)]
        public IActionResult GetAll()
        {
            return Ok(_cityService.GetAllCity());
        }

        [HttpPost]
        [Route(ApiRoutes.City.AddCity)]
        public IActionResult Add([FromBody] CityRequest request)
        {
            return Ok(_cityService.AddCity(request));
        }

        [HttpPut]
        [Route(ApiRoutes.City.ModifyCity)]
        public IActionResult Modify([FromBody] CityDTO request)
        {
            return Ok(_cityService.ModifyCity(request));
        }

        [HttpDelete]
        [Route(ApiRoutes.City.DeleteCity)]
        public IActionResult Delete(int id)
        {
            _cityValidator.ValiderCityToDelete(id);
            return Ok(_cityService.DeleteCity(id));
        }
    }
}
