using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class City : Parent1, IStreetNumerable
    {
        private List<Street> streets;
        public int RegionId { get; set; }
        public int Count
        {
            get { return streets.Count; }
        }
        public Street this[int index]
        {
            get { return streets[index]; }
        }
        public IStreetIterator CreateNumerator()
        {
            return new StreetNumerator(this);
        }
    }
    
    public class Client
    {
        public void SeeStreets(City city)
        {
            IStreetIterator iterator = city.CreateNumerator();
            while (iterator.HasNext())
            {
                Street street = iterator.Next();
                Console.WriteLine(street.Name);
            }
        }
    }

    public interface IStreetIterator
    {
        bool HasNext();
        Street Next();
    }
    public interface IStreetNumerable
    {
        IStreetIterator CreateNumerator();
        int Count { get; }
        Street this[int index] { get; }
    }

    public class StreetNumerator : IStreetIterator
    {
        IStreetNumerable aggregate;
        int index = 0;
        public StreetNumerator(IStreetNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }
        public Street Next()
        {
            return aggregate[index++];
        }
    }
}
