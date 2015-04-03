using System;
using System.Collections.Generic;
using System.Linq;

namespace Infestation
{
    public class HoldingPenExtension : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "PowerCatalyst":
                    var pCat = new PowerCatalyst();
                    GetUnit(commandWords[2]).AddSupplement(pCat);
                    break;
                case "HealthCatalyst":
                    var hCat = new HealthCatalyst();
                    GetUnit(commandWords[2]).AddSupplement(hCat);
                    break;
                case "AggressionCatalyst":
                    var aggCat = new AggressionCatalyst();
                    GetUnit(commandWords[2]).AddSupplement(aggCat);
                    break;
                case "Weapon": GetUnit(commandWords[2]).AddSupplement(new Weapon());
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Tank": 
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    marine.AddSupplement(new WeaponrySkill());
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var par = new Parasite(commandWords[2]);

                    this.InsertUnit(par);
                    break;
                case "Queen":
                    var q = new Queen(commandWords[2]);

                    this.InsertUnit(q);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = GetUnit(interaction.TargetUnit);
                    Supplement spores = new InfestationSpores();
                    targetUnit.AddSupplement(spores);
                    break;
                default: base.ProcessSingleInteraction(interaction);
                    break;
            }
        }
    }
}
