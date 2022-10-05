using EmpleoAPI.Common.DTOS;
using System.Collections.Generic;

namespace EmpleoAPI.DataAccess.DAO
{
    public interface ICityDAO
    {
        City Get(int id);
        List<City> GetAll();
        CityDTO AddOrModify(CityDTO entity, bool exists);
        bool Delete(int id);
    }
    public class CityDAO : ICityDAO
    {
        //Se inyecta depencia sobre la interfaz de métodos genericos
        private readonly IBaseDAO<City> _daoBase;
        public CityDAO(IBaseDAO<City> daoBase)
        {
            _daoBase = daoBase;
        }
        #region Inicio Métodos
        public City Get(int id) => _daoBase.GetById(id);
        public List<City> GetAll() => _daoBase.GetAll();
        public CityDTO AddOrModify(CityDTO entity, bool exists)
        {
            City city = new()
            {
                Code = entity.Code,
                Description = entity.Description
            };
            if(exists)
            {
                _daoBase.Modify(city);
                return entity;
            }
            //Obtenemos el id creado en la inserción del registro
            entity.Code = _daoBase.Add(city).Code;
            return entity;
        }
        public bool Delete(int id) => _daoBase.Delete(id);
        #endregion
    }
}