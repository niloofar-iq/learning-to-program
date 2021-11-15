using System;
using System.Collections.Generic;

namespace CharacterBuilder.Code
{

    public static class CharacterBuilder
    {
        public static List<Character> CreatedCharactersList { get; private set; } = new List<Character> { };

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
                Intelligence = intelligence;
                Wisdom = wisdom;
                Dexterity = dexterity;
                Strength = strength;
                Charisma = charisma;
                Constitution = constitution;
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

            public bool ValidateAbilityPoints()
            {
                var IntelligenceVR = ValidateIntelligence(Intelligence);
                var WisdomVR = ValidateWisdom(Wisdom);
                var DexterityVR = ValidateDexterity(Dexterity);
                var StrengthVR = ValidateStrength(Strength);
                var CharismaVR = ValidateCharisma(Charisma);
                var ConstitutionVR = ValidateContitution(Constitution);
                int AbilityPointsAddResult = (Intelligence + Wisdom + Dexterity + Strength + Charisma + Constitution);


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
        public static CharacterResult CreateCharacter(BodyAttributes bodyAttributes, AbilityPoints abilityPoints, string characterName)
        {
            try
            {
                bodyAttributes.ValidateBodyAttributes();
            }
            catch (Exception e)
            {
                return new CharacterResult(false, e.Message);
            };

            try
            {
                abilityPoints.ValidateAbilityPoints();
            }
            catch (Exception e)
            {
                return new CharacterResult(false, e.Message);
            };

            try
            {
                Character newCharacter = new Character(bodyAttributes, abilityPoints, characterName);
                CreatedCharactersList.Add(newCharacter);
                return new CharacterResult(true, newCharacter);

            }
            catch (Exception e)
            {
                return new CharacterResult(false, e.Message);
            };
        }
    }
}
