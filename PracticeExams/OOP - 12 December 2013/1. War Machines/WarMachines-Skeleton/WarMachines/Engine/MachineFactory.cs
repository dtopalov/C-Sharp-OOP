using System;

namespace WarMachines.Engine
{
    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class MachineFactory : IMachineFactory
    {
        public IPilot HirePilot(string name)
        {
            Pilot newPilot = new Pilot(name);
            return newPilot;
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            Tank newTank = new Tank(name, attackPoints, defensePoints);
            return newTank;
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            Fighter newFighter = new Fighter(name, attackPoints, defensePoints, stealthMode);
            return newFighter;
        }
    }
}
