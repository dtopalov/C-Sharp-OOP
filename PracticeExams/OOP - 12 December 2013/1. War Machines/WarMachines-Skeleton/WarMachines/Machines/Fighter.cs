using System;
using System.Linq;
using System.Text;

namespace WarMachines.Machines
{
    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter
    {
        public Fighter(string name, double attPoints, double defPoints, bool stealthMode) : base(name, attPoints, defPoints)
        {
            this.StealthMode = stealthMode;
            this.HealthPoints = 200;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
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
            result.Append(string.Format(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF"));
            return result.ToString();
        }
    }
}
