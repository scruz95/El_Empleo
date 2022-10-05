using EmpleoAPI.Common.Constants;
using EmpleoAPI.Common.DTOS;
using EmpleoAPI.Services.Services;
using System;

namespace EmpleoAPI.Services.Validators
{
    public interface ISellerValidator
    {
        void ValiderSellerToModify(SellerDTO sellerDTO);
        void ValiderSellerCity(SellerDTO sellerDTO);
        void ExistsSeller(int id);
    }
    public class SellerValidator : ISellerValidator
    {
        private readonly ISellerService _sellerService;
        private readonly ICityValidator _cityValidator;
        public SellerValidator(ISellerService sellerService, ICityValidator cityValidator)
        {
            _sellerService = sellerService;
            _cityValidator = cityValidator;
        }
        public void ValiderSellerToModify(SellerDTO sellerDTO)
        {
            //Se valida la existencia del usuario
            ExistsSeller(sellerDTO.Code);
            //Se valida la existencia de la ciudad
            ValiderSellerCity(sellerDTO);
        }
        public void ValiderSellerCity(SellerDTO sellerDTO)
        {
            //Se valida la existencia de la ciudad
            _cityValidator.ExistsCity(sellerDTO.CityId);
        }
        public void ExistsSeller(int id)
        {
            if(_sellerService.GetSeller(id) != null)
                throw new Exception(Messages.USER_DOES_NOT_EXIST);
        }
    }
}
