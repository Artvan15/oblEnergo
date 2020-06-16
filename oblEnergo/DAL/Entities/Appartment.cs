using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Appartment
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int NumberOfInhabitants { get; set; }
        public double Balance { get; set; }
        //public List<Payment> payments { get; set; }
        public string Tariff { get; set; }
        public int BuildingId { get; set; }
        public double UsedEnergy { get; set; }
    }
}
