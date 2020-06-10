using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class BuildingDTO
    {
        public int Id { get; set; }
        public int BuildingNum { get; set; }
        public double UsedEnergy { get; set; }
        public List<AppartmentDTO> Appartments { get; set; }
        public int StreetId { get; }
    }
}
