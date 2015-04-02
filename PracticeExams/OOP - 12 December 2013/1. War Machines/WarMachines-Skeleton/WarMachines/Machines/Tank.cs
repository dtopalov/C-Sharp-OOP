using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        public Tank(string name, double attPoints, double defPoints) : base(name, attPoints, defPoints)
        {
            this.DefenseMode = true;
            this.HealthPoints = 100;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
        }

        public override void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("- {0}", this.Name));
            result.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            result.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            result.AppendLine(string.Format(" *Targets: {0}", this.Targets.Any() ? string.Join(", ", this.Targets) : "None"));
            result.Append(string.Format(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF"));
            return result.ToString();
        }
    }
}
