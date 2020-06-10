using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class RegionDTO : Parent1DTO
    {
        public List<CityDTO> Cities { get; set; }
    }
}
