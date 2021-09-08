using ObjectOrientedProblems.Code.Enums;
using ObjectOrientedProblems.Code.Interfaces;

namespace ObjectOrientedProblems.Code
{
    public class Fighter : IFighter
    {
        public int Health { get; private set; }

        public int Damage { get; private set; }

        public FighterState State { get; private set; }

        public Fighter() : this(10, 1, FighterState.Healthy)
        {
        }

        public Fighter(int health, int damage, FighterState state)
        {
            Health = health;
            Damage = damage;
            State = state;
        }

        private void SetState()
        {
            if (Health >= 10)
            {
                State = FighterState.Healthy;
            }
            else if (Health >= 2)
            {
                State = FighterState.Hurt;
            }
            else if (Health == 1)
            {
                State = FighterState.KnockedOut;
            }
            else
            {
                State = FighterState.Dead;
            }
        }

        public void DrinkPotion(IPotion potion)
        {
            if (Health > 0)
            {
                Health += potion.Healing;
            }
            if (Health >= 10)
            {
                Health = 10;
            }
            SetState();
        }

        public void PowerUp(IPowerUp powerUp)
        {
            Damage += powerUp.DamageBuff;

            if (Damage < 0)
            {
                Damage = 1;
            }
        }

        public void TakeDamage(IFighter fighter)
        {
            Health -= fighter.Damage;
            SetState();
        }
    }
}
