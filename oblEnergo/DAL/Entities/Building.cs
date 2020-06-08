using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public int BuildingNum { get; set; }
        public double UsedEnergy { get; set; }
        public List<Appartment> Appartments {get; set; }
        public int StreetId { get; }
    }
}
