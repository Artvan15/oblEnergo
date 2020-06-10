using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class CityDTO : Parent1DTO
    {
        public List<StreetDTO> Streets { get; set; }
        public int RegionId { get; }

    }
}
