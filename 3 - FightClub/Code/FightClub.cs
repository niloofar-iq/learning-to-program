using ObjectOrientedProblems.Code.Interfaces;

namespace ObjectOrientedProblems.Code
{

    public static class FightClubGame
    {
        public static PowerUp PurchasePowerUp()
        {

            PowerUp power = new PowerUp();
            return power;
        }

        public static Potion PurchasePotion()
        {
            Potion potion = new Potion();
            return potion;
        }

        public static IFighter HireFighter()
        {
            Fighter fighter = new Fighter();
            return fighter;
        }
    }
}