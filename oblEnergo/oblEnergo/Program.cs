using System;
using DAL.Entities;
using CCL.Tariff;

namespace oblEnergo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Director director = new Director();
            BuildingBuilder builder = new BuildingType1Builder();

            Building type1 = director.Create(builder);
            Console.WriteLine(type1.Lifts[0].Power);

            BuildingBuilder builder2 = new BuildingType2Builder();
            Building type2 = director.Create(builder2);
            Console.WriteLine(type2.BoilerRoom.Power);
            */

            Tariff tariff1 = new DayTill100KvtHouseTariff();
            tariff1 = new Tax(tariff1, 0.1);
            tariff1.GetInfo();

            Tariff tariff2 = new DayOver100KvtApartmentTariff();
            tariff2 = new Compensation(tariff2, 0.5);
            tariff2 = new Coefficient(tariff2, 0.8);
            tariff2.GetInfo();
        }
    }
}
