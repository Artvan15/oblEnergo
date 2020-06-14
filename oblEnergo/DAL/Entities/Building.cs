using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Entities
{
    abstract public class Base
    {
        public double Power { get; set; }
        public int UsedHours { get; set; }
        public virtual double CalcUsedEnergy()
        {
            return Power * UsedHours;
        }
    }
    public class BoilerRoom
        : Base
    {

    }

    public class StreetLight
        : Base
    {

    }

    public class Lift
        : Base
    {

    }

    public class Building
    {
        public int Id { get; set; }
        public int BuildingNum { get; set; }
        public double UsedEnergy { get; set; }
        public List<Appartment> Appartments { get; set; }
        public int StreetId { get; }
        public BoilerRoom BoilerRoom { get; set; }
        public List<StreetLight> StreetLights { get; set; }
        public List<Lift> Lifts { get; set; }

        public virtual void CalcUsedEnergy()
        {
            UsedEnergy = Appartments.Sum(x => x.UsedEnergy);
            if (BoilerRoom != null)
                UsedEnergy += BoilerRoom.CalcUsedEnergy();
            if (StreetLights != null)
                UsedEnergy += StreetLights.Sum(x => x.CalcUsedEnergy());
            if (Lifts != null)
                UsedEnergy += Lifts.Sum(x => x.CalcUsedEnergy());
        }
    }

    abstract public class BuildingBuilder
    {
        public Building Building { get; private set; }
        public void CreateBuilding()
        {
            Building = new Building();
        }
        public abstract void SetBoilerRoom();
        public abstract void SetStreetLights();
        public abstract void SetLifts();

        public static T[] CreateList<T>(int count, double power)
            where T : Base, new()
        {
            T[] l = new T[count];
            for (int i = 0; i != l.Length; ++i)
            {
                l[i] = new T() { Power = power };
            }
            return l;
        }
    }

    public class Director
    {
        public Building Create(BuildingBuilder buildingBuilder)
        {
            buildingBuilder.CreateBuilding();
            buildingBuilder.SetBoilerRoom();
            buildingBuilder.SetStreetLights();
            buildingBuilder.SetLifts();
            return buildingBuilder.Building;
        }
    }

    public class BuildingType1Builder : BuildingBuilder
    {
        public readonly int LiftCount = 4;
        public readonly double LiftPower = 3.6;

        public override void SetBoilerRoom()
        {

        }
        public override void SetStreetLights()
        {

        }
        public override void SetLifts()
        {
            this.Building.Lifts = new List<Lift>();
            this.Building.Lifts.AddRange(CreateList<Lift>(LiftCount, LiftPower));
        }
    }

    public class BuildingType2Builder : BuildingBuilder
    {
        public readonly int LiftCount = 2;
        public readonly double LiftPower = 2.4;
        public readonly int LightCount = 30;
        public readonly double LightPower = 0.2;
        public readonly double BoilerRoomPower = 3.5;

        public override void SetBoilerRoom()
        {
            this.Building.BoilerRoom = new BoilerRoom() { Power = BoilerRoomPower };
        }
        public override void SetStreetLights()
        {
            this.Building.StreetLights = new List<StreetLight>();
            this.Building.StreetLights.AddRange(CreateList<StreetLight>(LightCount, LightPower));
        }
        public override void SetLifts()
        {
            this.Building.Lifts = new List<Lift>();
            this.Building.Lifts.AddRange(CreateList<Lift>(LiftCount, LiftPower));
        }
    }
}
