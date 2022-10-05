using EmpleoAPI.Common.Constants;
using EmpleoAPI.Common.DTOS;
using EmpleoAPI.Services.Services;
using System;
using System.Linq;

namespace EmpleoAPI.Services.Validators
{
    public interface ICityValidator
    {
        void ValiderCityToDelete(int id);
        void ExistsCity(int id);
    }
    public class CityValidator : ICityValidator
    {
        private readonly ICityService _cityService;
        private readonly ISellerService _sellerService;
        public CityValidator(ICityService cityService, ISellerService sellerService)
        {
            _cityService = cityService;
            _sellerService = sellerService;
        }
        public void ValiderCityToDelete(int id)
        {
            //Se valida si la ciudad existe
            ExistsCity(id);
            //Se valida si la ciudad esta vinculada a un usuario
            if (_sellerService.GetSellerByCity(id).Any())
                throw new Exception(Messages.CITY_COULD_NOT_DELETE);
        }
        public void ExistsCity(int id)
        {
            if(_cityService.GetCity(id) == null)
                throw new Exception(Messages.CITY_DOES_NOT_EXIST);
        }
    }
}
