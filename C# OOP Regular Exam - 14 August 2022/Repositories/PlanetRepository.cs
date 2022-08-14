using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private Dictionary<string, IPlanet> planets;
        public PlanetRepository()
        {
            planets = new Dictionary<string, IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models
        {
            get => planets.Values;
        }

        public void AddItem(IPlanet model)
        {
            //if (planets.ContainsKey(model.GetType().Name))
            //{
                planets.Add(model.Name, model);
            //}
        }

        public IPlanet FindByName(string name)
        {
            if (planets.ContainsKey(name))
            {
                return planets[name];
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            if (planets.ContainsKey(name))
            {
                planets.Remove(name);
                return true;
            }
            return false;
        }
    }
}
