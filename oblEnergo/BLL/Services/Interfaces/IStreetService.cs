using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IStreetService
    {
        IEnumerable<StreetDTO> GetStreets(CityDTO city, int page);
        void AddStreet(StreetDTO street);
        IEnumerable<StreetDTO> GetAllStreets();
    }
}
