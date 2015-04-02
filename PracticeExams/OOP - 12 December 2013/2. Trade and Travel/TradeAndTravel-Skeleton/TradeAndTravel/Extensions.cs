using System.Linq;

namespace TradeAndTravel
{
    public class Extensions : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "armor":
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
            }
            return item;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                case "shopkeeper":
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
                case "traveller":
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
            return person;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "town":
                    return base.CreateLocation(locationTypeString, locationName);
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "drop":
                    base.HandlePersonCommand(commandWords, actor);
                    break;
                case "pickup":
                    base.HandlePersonCommand(commandWords, actor);
                    break;
                case "sell":
                    base.HandlePersonCommand(commandWords, actor);
                    break;
                case "buy":
                    base.HandlePersonCommand(commandWords, actor);
                    break;
                case "inventory":
                    base.HandlePersonCommand(commandWords, actor);
                    break;
                case "money":
                    base.HandlePersonCommand(commandWords, actor);
                    break;
                case "travel":
                    base.HandlePersonCommand(commandWords, actor);
                    break;
                case "gather":
                    Gather(commandWords, actor);
                    break;
                case "craft":
                    Craft(commandWords, actor);
                    break;
            }
        }

        private void Craft(string[] commandWords, Person actor)
        {
            if (commandWords[2] == "armor" && actor.ListInventory().Any(x => x is Iron))
            {
                Armor newArmor = new Armor(commandWords[3]);
                actor.AddToInventory(newArmor);
                this.AddToPerson(actor, newArmor);
            }
            else if (commandWords[2] == "weapon" && actor.ListInventory().Any(x => x is Iron) && actor.ListInventory().Any(x => x is Wood))
            {
                Weapon newWeapon = new Weapon(commandWords[3]);
                actor.AddToInventory(newWeapon);
                this.AddToPerson(actor, newWeapon);
            }
        }

        private void Gather(string[] commandWords, Person actor)
        {
            if (actor.ListInventory().Any(x => x is Weapon) && (actor.Location is Forest))
            {
                Wood newWood = new Wood(commandWords[2]);
                actor.AddToInventory(newWood);
                this.AddToPerson(actor, newWood);
            }
            else if (actor.ListInventory().Any(x => x is Armor) && (actor.Location is Mine))
            {
                Iron newIron = new Iron(commandWords[2]);
                actor.AddToInventory(newIron);
                this.AddToPerson(actor, newIron);
            }
        }
    }
}
