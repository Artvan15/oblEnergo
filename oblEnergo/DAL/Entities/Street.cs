using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Street:Parent1
    {
        public List<Building> Buildings {get; set; }
        public int CityId { get; set; }
    }
}
