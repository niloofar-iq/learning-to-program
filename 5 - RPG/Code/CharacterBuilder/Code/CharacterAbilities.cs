using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CharacterBuilder.Code
{
    public class CharacterAbilities
    {
        public const int AbilitiesSum = 60;

        [Range(5, 20)]
        public int Intelligence { get; }

        [Range(5, 20)]
        public int Wisdom { get; }

        [Range(1, 20)]
        public int Dexterity { get; }

        [Range(1, 20)]
        public int Strength { get; }

        [Range(0, 20)]
        public int Charisma { get; }

        [Range(10, 20)]
        public int Constitution { get; }

        public CharacterAbilities(int intelligence, int wisdom, int dexterity, int strength, int charisma, int constitution)
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

            var validationAbilitiesResult = ValidateAbilities();

            if (!validationAbilitiesResult.IsValid)
            {
                throw new Exception(string.Join(Environment.NewLine, validationAbilitiesResult.Errors.Select(x => x.ErrorMessage)));
            }

        }




        public (bool IsValid, List<ValidationResult> Errors) ValidateAbilities()
        {
            var isValid = true;
            var abilitiesList = new List<int> { Intelligence, Wisdom, Dexterity, Strength, Charisma, Constitution };
            var currentContext = new ValidationContext(this);
            var validationResult = new List<ValidationResult>() { };

            Validator.TryValidateObject(this, currentContext, validationResult, true);

            var sum = abilitiesList.Sum();
            if (sum != AbilitiesSum)
            {
                validationResult.Add(new ValidationResult($"Sum of character's ability points should be {AbilitiesSum}. Currently, it is {sum}. "));
            }

            if (validationResult.Count != 0)
            {
                isValid = false;
            }

            return (isValid, validationResult);
        }


    }
}
