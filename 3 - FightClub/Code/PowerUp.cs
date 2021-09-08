using ObjectOrientedProblems.Code.Interfaces;

namespace ObjectOrientedProblems.Code
{
    public class PowerUp : IPowerUp
    {
        public int DamageBuff { get => DamageBuff; set => SetDamage(value); }


        public PowerUp() : this(1)
        {
        }

        public PowerUp(int power)
        {
            DamageBuff = power;
        }

        private void SetDamage(int damage)
        {
            if (damage < 0)
            {
                DamageBuff = 1;
            }
            else
            {
                DamageBuff = damage;
            }
        }
    }
}