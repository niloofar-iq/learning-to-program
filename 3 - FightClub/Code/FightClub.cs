using ObjectOrientedProblems.Code.Interfaces;

namespace ObjectOrientedProblems.Code
{

    public static class FightClubGame
    {
        public static IPowerUp PurchasePowerUp()
        {
            var i = new PowerUp();
            i.DamageBuff = 4;
            return new PowerUp();
        }

        public static Potion PurchasePotion()
        {
            return new Potion();
        }

        public static IFighter HireFighter()
        {
            Fighter fighter = new Fighter();
            return fighter;
        }
    }
}