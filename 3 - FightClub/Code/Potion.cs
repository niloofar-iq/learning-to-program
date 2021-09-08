using ObjectOrientedProblems.Code.Enums;
using ObjectOrientedProblems.Code.Interfaces;

namespace ObjectOrientedProblems.Code
{
    public class Potion : IPotion
    {
        public int Healing { get; private set; } 

        public PotionType Type { get; private set; } 

        public Potion() : this(2, PotionType.Basic)
        {              
        }

        public Potion(int healing, PotionType type)
        {
            Healing = healing;
            Type = type;
        }

        public void SetType(PotionType potionType)
        {
            Type = potionType;
            if (potionType == PotionType.Greater)
            {
                Healing = 5;
            }
            if (potionType == PotionType.Basic)
            {
                Healing = 2;
            }
        }
    }
}