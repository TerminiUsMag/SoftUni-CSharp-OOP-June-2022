using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var entities = new List<Identifiable>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                var input = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 2)
                {
                    var model = input[0];
                    var id = input[1];
                    entities.Add(new Robot(model, id));
                }
                else
                {
                    var name = input[0];
                    var age = int.Parse(input[1]);
                    var id = input[2];
                    entities.Add(new Citizen(name, age, id));
                }
            }
            var detainedIDs = Console.ReadLine().ToCharArray();
            var detained = new List<Identifiable>();
            foreach (var entity in entities)
            {
                var id = entity.ID.ToCharArray();
                bool match = true;
                for (int i = 0; i < detainedIDs.Length; i++)
                {
                    if (id[id.Length - 1 - i] != detainedIDs[detainedIDs.Length - 1 - i])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    detained.Add(entity);
                }
            }
            foreach (var entity in detained)
            {
                Console.WriteLine(entity.ID);
            }
        }
    }
}
