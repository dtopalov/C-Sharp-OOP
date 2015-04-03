namespace Infestation
{
    public abstract class Supplement : ISupplement
    {
        protected Supplement(int power = 0, int health = 0, int aggression = 0)
        {
            this.PowerEffect = power;
            this.HealthEffect = health;
            this.AggressionEffect = aggression;
        }

        public int PowerEffect { get; protected set; }

        public int HealthEffect { get; protected set; }

        public int AggressionEffect { get; protected set; }

        public abstract void ReactTo(ISupplement otherSupplement);
    }
}
