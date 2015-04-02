using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarMachines.Machines
{
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private string name;

        public Pilot(string name)
        {
            this.Name = name;
            this.ListOfMachines = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public List<IMachine> ListOfMachines { get; private set; }

        public void AddMachine(IMachine machine)
        {
            this.ListOfMachines.Add(machine);
        }

        public string Report()
        {
            var result = new StringBuilder();
            
            result.Append(this.Name);
            result.Append(" - ");
            result.Append(this.ListOfMachines.Count == 0 ? ("no ") : this.ListOfMachines.Count + " ");
            result.Append(this.ListOfMachines.Count == 1 ? "machine" : "machines");

            if (this.ListOfMachines.Count > 1)
            {
                result.AppendLine();
                var orderedMachines = this.ListOfMachines.OrderBy(m => m.HealthPoints).ThenBy(m => m.Name);
                result.Append(string.Join(Environment.NewLine, orderedMachines));
            }
            else if (this.ListOfMachines.Count == 1)
            {
                result.AppendLine();
                result.Append(this.ListOfMachines[0].ToString());
            }
            
            return result.ToString();
        }
    }
}
