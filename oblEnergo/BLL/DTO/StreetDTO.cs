using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class StreetDTO : Parent1DTO
    {
        public List<BuildingDTO> Buildings { get; set; }
        public int CityId { get; }
        public StreetDTO(CityDTO city)
        {
            CityId = city.Id;
        }
    }
}
