using EmpleoAPI.Common.DTOS;
using EmpleoAPI.DataAccess.DAO;
using AutoMapper;
using System.Collections.Generic;
using Newtonsoft.Json.Schema;
using EmpleoAPI.Common.Request;
using EmpleoAPI.Common.Constants;

namespace EmpleoAPI.Services.Services
{
    public interface ICityService
    {
        /// <summary>
        /// Obtiene el registo de una ciudad por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entidad CityDTO</returns>
        CityDTO GetCity(int id);
        /// <summary>
        /// Obtiene todos los registros de las ciudades
        /// </summary>
        /// <returns>Lista entidad CityDTO</returns>
        List<CityDTO> GetAllCity();
        /// <summary>
        /// Agrega un nuevo registro de una ciudad
        /// </summary>
        /// <param name="CityRequest"></param>
        /// <returns>Entidad CityDTO</returns>
        CityDTO AddCity(CityRequest city);
        /// <summary>
        /// Actualiza un registro de una ciudad
        /// </summary>
        /// <param name="cityDTO"></param>
        /// <returns>Entidad CityDTO</returns>
        CityDTO ModifyCity(CityDTO cityDTO);
        /// <summary>
        /// Elimina un registro de una ciudad
        /// </summary>
        /// <param name="cityDTO"></param>
        /// <returns>bool</returns>
        string DeleteCity(int id);
    }
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;
        private readonly ICityDAO _cityDAO;
        public CityService(IMapper mapper, ICityDAO cityDAO)
        {
            _mapper = mapper;
            _cityDAO = cityDAO;
        }
        
        public CityDTO GetCity(int id)
        {
            var city = _cityDAO.Get(id);
            return _mapper.Map<CityDTO>(city);
        }
        
        public List<CityDTO> GetAllCity()
        {
            var listCityDTO = _cityDAO.GetAll();
            return _mapper.Map<List<CityDTO>>(listCityDTO);
        }
        
        public CityDTO AddCity(CityRequest city)
        {
            return _cityDAO.AddOrModify(_mapper.Map<CityDTO>(city), false);
        }
        public CityDTO ModifyCity(CityDTO cityDTO)
        {
            return _cityDAO.AddOrModify(_mapper.Map<CityDTO>(cityDTO), true);
        }
        public string DeleteCity(int id)
        {
            _cityDAO.Delete(id);
            return Messages.CITY_SUCCESSFULLY_REMOVED;
        }
    }
}