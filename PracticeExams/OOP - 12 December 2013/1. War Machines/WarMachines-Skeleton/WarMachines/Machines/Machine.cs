namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        private string name;
        private double attackPoints;
        private double defensePoints;

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null");
                }
                this.name = value;
            }
        }

        public IPilot Pilot { get; set; }

        public double HealthPoints { get; set; }

        public double AttackPoints
        {
            get {
                if (this is Tank && (this as Tank).DefenseMode)
                {
                    return this.attackPoints - 40;
                }
                return this.attackPoints;
            }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Attack points cannot be less than 0");
                }
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                if (this is Tank && (this as Tank).DefenseMode)
                {
                    return this.defensePoints + 30;
                }
                return this.defensePoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Defense points cannot be less than 0");
                }
                this.defensePoints = value;
            }
        }

        public IList<string> Targets { get; set; }

        public abstract void Attack(string target);

        public abstract override string ToString();
    }
}
