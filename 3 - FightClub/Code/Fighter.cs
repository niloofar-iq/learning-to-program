using ObjectOrientedProblems.Code.Enums;
using ObjectOrientedProblems.Code.Interfaces;

namespace ObjectOrientedProblems.Code
{
    public class Fighter : IFighter
    {
        public int Health { get; set; } = 10;

        public int Damage { get; set; } = 1;

        public FighterState State { get; set; } = FighterState.Healthy;

        public void DrinkPotion(IPotion potion)
        {
            if (Health > 0)
            {
                Health += potion.Healing;
            }


            if (Health >= 10)
            {
                Health = 10;
                State = FighterState.Healthy;
            }

            if (Health == 3)
            {
                State = FighterState.Hurt;
            }

        }

        public void PowerUp(IPowerUp powerUp)
        {
            Damage = Damage + powerUp.DamageBuff;

            if (powerUp.DamageBuff < 0)
            {
                Damage = 1;

            }
        }

        public void TakeDamage(IFighter fighter)
        {
            //Health = Health - fighter.Damage;
            //Health -= fighter.Damage;

            if (Health > 0)
            {
                Health -= fighter.Damage;
            }

            if (Health >= 2 && Health <= 10)
            {
                State = FighterState.Hurt;
            }

            if (Health == 1)
            {
                State = FighterState.KnockedOut;
            }

            if (Health == 0)
            {
                State = FighterState.Dead;
            }
        }
    }
}
