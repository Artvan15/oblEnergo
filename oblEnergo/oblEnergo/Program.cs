using System;
using DAL.Entities;

namespace oblEnergo
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            BuildingBuilder builder = new BuildingType1Builder();

            Building type1 = director.Create(builder);
            Console.WriteLine(type1.Lifts[0].Power);

            BuildingBuilder builder2 = new BuildingType2Builder();
            Building type2 = director.Create(builder2);
            Console.WriteLine(type2.BoilerRoom.Power);
        }
    }
}
