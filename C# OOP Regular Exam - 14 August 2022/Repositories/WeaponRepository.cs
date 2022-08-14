using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private Dictionary<string,IWeapon> weapons;
        public WeaponRepository()
        {
            weapons = new Dictionary<string,IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models
        {
            get => weapons.Values;
        }

        public void AddItem(IWeapon model)
        {
            //if (!weapons.ContainsKey(model.GetType().Name))
            //{
                weapons.Add(model.GetType().Name, model);
            //}
        }

        public IWeapon FindByName(string name)
        {
            if (weapons.ContainsKey(name))
            {
                return weapons[name];
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            if (weapons.ContainsKey(name))
            {
                weapons.Remove(name);
                return true;
            }
            return false;
        }
    }
}
