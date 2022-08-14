using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    using Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly Dictionary<string, IFormulaOneCar> cars;
        public FormulaOneCarRepository()
        {
            cars = new Dictionary<string, IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models
        {
            get => cars.Values;
        }

        public void Add(IFormulaOneCar model) => cars.Add(model.Model, model);

        public IFormulaOneCar FindByName(string name) => cars.ContainsKey(name) ? cars[name] : null;
        //{
        //    if(cars.ContainsKey(name)) return cars[name];
        //    return null;
        //}

        public bool Remove(IFormulaOneCar model)
        {
            if (cars.ContainsKey(model.Model))
            {
                cars.Remove(model.Model);
                return true;
            }
            return false;
        }
    }
}
