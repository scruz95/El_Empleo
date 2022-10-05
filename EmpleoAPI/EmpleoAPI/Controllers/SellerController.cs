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
    public class SellerController : Controller
    {
        private readonly ISellerService _sellerService;
        private readonly ISellerValidator _sellerValidator;
        public SellerController(ISellerService sellerService, ISellerValidator sellerValidator)
        {
            _sellerService = sellerService;
            _sellerValidator = sellerValidator;
        }
        [HttpGet]
        [Route(ApiRoutes.Seller.GetSellerById)]
        public IActionResult Get(int id)
        {
            _sellerValidator.ExistsSeller(id);
            return Ok(_sellerService.GetSeller(id));
        }

        [HttpGet]
        [Route(ApiRoutes.Seller.GetAllSeller)]
        public IActionResult GetAll()
        {
            return Ok(_sellerService.GetAllSeller());
        }

        [HttpPost]
        [Route(ApiRoutes.Seller.AddSeller)]
        public IActionResult Add([FromBody] SellerRequest request)
        {
            return Ok(_sellerService.AddSeller(request));
        }

        [HttpPut]
        [Route(ApiRoutes.Seller.ModifySeller)]
        public IActionResult Modify([FromBody] SellerDTO request)
        {
            return Ok(_sellerService.ModifySeller(request));
        }

        [HttpDelete]
        [Route(ApiRoutes.Seller.DeleteSeller)]
        public IActionResult Delete(int id)
        {
            _sellerValidator.ExistsSeller(id);
            return Ok(_sellerService.DeleteSeller(id));
        }
    }
}
