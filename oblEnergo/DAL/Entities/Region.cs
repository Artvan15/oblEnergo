using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Region : Parent1
    {
        public List<City> Cities{ get; set; }
    }
}
