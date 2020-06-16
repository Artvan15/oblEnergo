using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface ICityService
    {
        IEnumerable<CityDTO> GetCities(RegionDTO region, int page);
        void AddCity(CityDTO city);
        IEnumerable<CityDTO> GetAllCities();
    }
}
