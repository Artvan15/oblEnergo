using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class City : Parent1
    {
        public List<Street> Streets {get; set;}
        public int RegionId { get; }

    }
}
