using EmpleoAPI.Common.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoAPI.DataAccess.DAO
{
    public interface ISellerDAO
    {
        Seller Get(int id);
        List<Seller> GetAll();
        SellerDTO AddOrModify(SellerDTO entity, bool exists);
        bool Delete(int id);
        IList<Seller> GetByCity(int cityID);
    }
    public class SellerDAO : ISellerDAO
    {
        //Se inyecta depencia sobre la interfaz de métodos genericos
        private readonly IBaseDAO<Seller> _daoBase;
        public SellerDAO(IBaseDAO<Seller> daoBase)
        {
            _daoBase = daoBase;
        }
        #region Inicio Métodos
        public Seller Get(int id) => _daoBase.GetById(id);
        public List<Seller> GetAll() => _daoBase.GetAll();
        public SellerDTO AddOrModify(SellerDTO entity, bool exists)
        {
            Seller user = new()
            {
                Code = entity.Code,
                Name = entity.Name,
                LastName = entity.LastName,
                Document = entity.Document, 
                CityId = entity.CityId
            };
            if (exists)
            {
                _daoBase.Modify(user);
                return entity;
            }
            //Obtenemos el id creado en la inserción del registro
            entity.Code = _daoBase.Add(user).Code;
            return entity;
        }
        public bool Delete(int id) => _daoBase.Delete(id);
        public IList<Seller> GetByCity(int cityID) => _daoBase.GetByFilter(p => p.CityId == cityID);

        #endregion
    }
}
