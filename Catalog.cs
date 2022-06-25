using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;
        private string name;
        private int neededRenovators;
        private string project;

        public Catalog(string name, int neededRenovators, string project)
        {
            renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public string Name { get => name; set => name = value; }
        public int NeededRenovators { get => neededRenovators; set => neededRenovators = value; }
        public string Project { get => project; set => project = value; }

        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (NeededRenovators > renovators.Count)
            {
               
                if (String.IsNullOrWhiteSpace(renovator.Name))
                {
                    return "Invalid renovator's information.";
                }
                else if (renovator.Rate > 350)
                {
                    return "Invalid renovator's rate.";
                }
                else
                {
                    renovators.Add(renovator);
                    return $"Successfully added {renovator.Name} to the catalog.";
                }



            }
            else
            {
                return "Renovators are no more needed.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            if (renovators.Contains(renovators.Find(x => x.Name == name)))
            {
                renovators.Remove(renovators.Find(x => x.Name == name));
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RemoveRenovatorBySpecialty (string type)
        {
            int count = 0;
            if (renovators.Contains(renovators.Find(x => x.Type == type)))
            {
                foreach (var item in renovators)
                {
                    renovators.Remove(renovators.Find(x => x.Type == type));
                    count++;
                    
                }
            }
           
            return count;
            
        }

        public Renovator HireRenovator(string name)
        {
            if (renovators.Contains(renovators.Find(x => x.Name == name)))
            {
                Renovator renovator = renovators.Find(x => x.Name == name);
                renovator.Hired = true;
            }
            
                return null;
            
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovatorsWorking = new List<Renovator>();
            foreach (var item in renovators)
            {
                if (item.Days == days || item.Days > days)
                {
                    renovatorsWorking.Add(item);
                }
            }
            return renovatorsWorking;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}");
            foreach (var item in renovators)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
