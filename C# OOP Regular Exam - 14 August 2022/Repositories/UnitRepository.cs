using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private Dictionary<string, IMilitaryUnit> units;
        public UnitRepository()
        {
            units = new Dictionary<string, IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models
        {
            get => units.Values;
        }

        public void AddItem(IMilitaryUnit model)
        {
            //if (!units.ContainsKey(model.GetType().Name))
            //{
                units.Add(model.GetType().Name, model);
            //}
        }

        public IMilitaryUnit FindByName(string name)
        {
            if (units.ContainsKey(name))
            {
                return units[name];
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            if (units.ContainsKey(name))
            {
                units.Remove(name);
                return true;
            }
            return false;
        }
    }
}
