using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Tariff
{
    public abstract class Tariff
    {
        public Tariff(string n, double p)
        {
            Name = n;
            Price = p;
        }
        public string Name { get; protected set; }
        public double Price { get; protected set; }

        public void GetInfo()
        {
            Console.WriteLine(Name + $"  Price: {Price}");
        }
    }

    public class DayTill100KvtHouseTariff : Tariff
    {
        public DayTill100KvtHouseTariff()
            : base("Day till 100kvt for house", 0.9){}

    }

    public class DayOver100KvtApartmentTariff : Tariff
    {
        public DayOver100KvtApartmentTariff()
            : base("Day over 100kvt for apartment", 1.68) { }

    }

    public abstract class TariffDecorator : Tariff
    {
        protected Tariff tariff;
        public TariffDecorator(string n, double price, Tariff t)
            : base(n, price)
        {
            tariff = t;
        }
    }

    public class Tax : TariffDecorator
    {
        public Tax(Tariff t, double tax)
            : base(t.Name + $", с налогом {tax}", t.Price + tax, t) { }

    }

    public class Compensation : TariffDecorator
    {
        public Compensation(Tariff t, double comp)
            : base(t.Name + $", с компенсацией {comp}", t.Price - comp, t) { }
    }

    public class Coefficient : TariffDecorator
    {
        public Coefficient(Tariff t, double coef)
            : base(t.Name + $", с коефициентом {coef}", t.Price * coef, t) { }
    }
}
