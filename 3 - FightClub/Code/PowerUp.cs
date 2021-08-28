using ObjectOrientedProblems.Code.Interfaces;

namespace ObjectOrientedProblems.Code
{

    public class PowerUp : IPowerUp
    {
        public int DamageBuff { get; set; } = 1;
    }
}