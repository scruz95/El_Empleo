using EmpleoAPI.Common.DTOS;
using EmpleoAPI.DataAccess.DAO;
using AutoMapper;
using System.Collections.Generic;
using Newtonsoft.Json.Schema;
using EmpleoAPI.Common.Request;
using EmpleoAPI.Common.Constants;

namespace EmpleoAPI.Services.Services
{
    public interface ISellerService
    {
        /// <summary>
        /// Obtiene el registo de una usuario por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entidad SellerDTO</returns>
        SellerDTO GetSeller(int id);
        /// <summary>
        /// Obtiene todos los registros de los usuarios
        /// </summary>
        /// <returns>Lista entidad SellerDTO</returns>
        List<SellerDTO> GetAllSeller();
        /// <summary>
        /// Agrega un nuevo registro de un usuario
        /// </summary>
        /// <param name="CityRequest"></param>
        /// <returns>Entidad SellerDTO</returns>
        SellerDTO AddSeller(SellerRequest seller);
        /// <summary>
        /// Actualiza un registro de un usuario
        /// </summary>
        /// <param name="SellerDTO"></param>
        /// <returns>Entidad SellerDTO</returns>
        SellerDTO ModifySeller(SellerDTO sellerDTO);
        /// <summary>
        /// Elimina un registro de un usuario
        /// </summary>
        /// <param name="SellerDTO"></param>
        /// <returns>bool</returns>
        string DeleteSeller(int id);
        /// <summary>
        /// Obtiene todos los registros de los usuarios por código ciudad
        /// </summary>
        /// <param name="SellerDTO"></param>
        /// <returns>Lista entidad SellerDTO</returns>
        List<SellerDTO> GetSellerByCity(int CityId);
    }
    public class SellerService : ISellerService
    {
        private readonly IMapper _mapper;
        private readonly ISellerDAO  _sellerDAO;
        public SellerService(IMapper mapper, ISellerDAO sellerDAO)
        {
            _mapper = mapper;
            _sellerDAO = sellerDAO;
        }

        public SellerDTO GetSeller(int id)
        {
            var city = _sellerDAO.Get(id);
            return _mapper.Map<SellerDTO>(city);
        }

        public List<SellerDTO> GetAllSeller()
        {
            var listSellerDTO = _sellerDAO.GetAll();
            return _mapper.Map<List<SellerDTO>>(listSellerDTO);
        }

        public SellerDTO AddSeller(SellerRequest seller)
        {
            return _sellerDAO.AddOrModify(_mapper.Map<SellerDTO>(seller), false);
        }
        public SellerDTO ModifySeller(SellerDTO SellerDTO)
        {
            return _sellerDAO.AddOrModify(_mapper.Map<SellerDTO>(SellerDTO), true);
        }
        public string DeleteSeller(int id)
        {
            if (_sellerDAO.Delete(id))
                return Messages.USER_SUCCESSFULLY_REMOVED;
            return Messages.USER_COULD_NOT_DELETE;
        }

        public List<SellerDTO> GetSellerByCity(int CityId)
        {
            var lstSeller = _sellerDAO.GetByCity(CityId);
            return _mapper.Map<List<SellerDTO>>(lstSeller);
        }
    }
}
