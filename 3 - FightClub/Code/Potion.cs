using ObjectOrientedProblems.Code.Enums;
using ObjectOrientedProblems.Code.Interfaces;

namespace ObjectOrientedProblems.Code
{

    public class Potion : IPotion
    {
        public int Healing { get; set; } = 2;
        public PotionType Type { get; set; } = PotionType.Basic;


        public void SetType(PotionType potionType)
        {
            Type = potionType;
            if (potionType == PotionType.Greater)
            {
                Healing = 5;
            }

        }
    }
}