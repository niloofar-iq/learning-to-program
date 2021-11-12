using System;

namespace CharacterBuilder.Code
{
    public class AbilityPoints
    {
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }
        public int Dexterity { get; private set; }
        public int Strength { get; private set; }
        public int Charisma { get; private set; }
        public int Constitution { get; private set; }

        public AbilityPoints(int intelligence, int wisdom, int dexterity, int strength, int charisma, int constitution)
        {
            bool isIntelligenceNull = string.IsNullOrEmpty(intelligence.ToString());
            bool isWisdomNull = string.IsNullOrEmpty(wisdom.ToString());
            bool isDexterityNull = string.IsNullOrEmpty(dexterity.ToString());
            bool isStrengthNull = string.IsNullOrEmpty(strength.ToString());
            bool isCharismaNull = string.IsNullOrEmpty(charisma.ToString());
            bool isConstitutionNull = string.IsNullOrEmpty(constitution.ToString());

            if (isIntelligenceNull || isWisdomNull || isDexterityNull || isStrengthNull || isCharismaNull || isConstitutionNull)
            {
                throw new ArgumentNullException("One or more Ability Points are Not Set or Null. Please try again.");
            }

            if (ValidateAbilityPoints(intelligence, wisdom, dexterity, strength, charisma, constitution))
            {
                Intelligence = intelligence;
                Wisdom = wisdom;
                Dexterity = dexterity;
                Strength = strength;
                Charisma = charisma;
                Constitution = constitution;

            }
            else
            {
                throw new ArgumentException("Provided Ability Points are not valid.");
            }


        }

        public bool ValidateIntelligence(int intelligence)
        {
            if (intelligence >= 5 && intelligence <= 20)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Intelligence value is out of range. Supported values are between 5 to 20.");
            }
        }

        public bool ValidateWisdom(int wisdom)
        {
            if (wisdom >= 5 && wisdom <= 20)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Wisdom value is out of range. Supported values are between 5 to 20.");
            }
        }

        public bool ValidateDexterity(int dexterity)
        {
            if (dexterity >= 1 && dexterity <= 20)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Dexterity value is out of range. Supported values are between 1 to 20.");
            }
        }

        public bool ValidateStrength(int strength)
        {
            if (strength >= 1 && strength <= 20)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Strength value is out of range. Supported values are between 1 to 20.");
            }
        }


        public bool ValidateCharisma(int charisma)
        {
            if (charisma >= 0 && charisma <= 20)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Charisma value is out of range. Supported values are between 0 to 20.");
            }
        }


        public bool ValidateContitution(int constitution)
        {
            if (constitution >= 10 && constitution <= 20)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Constitution value is out of range. Supported values are between 10 to 20.");
            }
        }

        public bool ValidateAbilityPoints(int intelligence, int wisdom, int dexterity, int strength, int charisma, int constitution)
        {
            var IntelligenceVR = ValidateIntelligence(intelligence);
            var WisdomVR = ValidateWisdom(wisdom);
            var DexterityVR = ValidateDexterity(dexterity);
            var StrengthVR = ValidateStrength(strength);
            var CharismaVR = ValidateCharisma(charisma);
            var ConstitutionVR = ValidateContitution(constitution);
            int AbilityPointsAddResult = (intelligence + wisdom + dexterity + strength + charisma + constitution);


            if ((IntelligenceVR == true && WisdomVR == true && DexterityVR == true && StrengthVR == true && CharismaVR == true && ConstitutionVR == true) && AbilityPointsAddResult == 60)
            {
                return true;

            }
            else
            {
                throw new ArgumentException("Sum of Ability Points must exactly equal to 60. Please try again.");

            }
        }

    }
}
