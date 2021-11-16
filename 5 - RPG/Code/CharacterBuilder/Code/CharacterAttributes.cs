using CharacterBuilder.Code.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace CharacterBuilder.Code
{
    public class CharacterAttributes
    {
        [Range(0, 100)]
        public int HeadRoundness { get; private set; }
        public FitnessLevel FitnessLevel { get; private set; }
        public string Height { get; private set; }

        public CharacterAttributes(int headRoundness, FitnessLevel fitnessLevel, string height)
        {
            bool isHeadRoundnessNull = string.IsNullOrEmpty(headRoundness.ToString());
            bool isFitnessLevelNull = string.IsNullOrEmpty(fitnessLevel.ToString());
            bool isHeightNull = string.IsNullOrEmpty(height);

            if (isHeadRoundnessNull || isFitnessLevelNull || isHeightNull || fitnessLevel == FitnessLevel.NotSet)
            {
                throw new ArgumentNullException("Body Attributes should all be set. Please try again.");
            }
            HeadRoundness = headRoundness;
            FitnessLevel = fitnessLevel;
            Height = height;

            var validateAttributesResult = ValidateAttributes();
            if (!validateAttributesResult.IsValid)
            {
                throw new Exception(string.Join(Environment.NewLine, validateAttributesResult.Errors.Select(x => x.ErrorMessage)));
            }
        }



        public bool ValidateFitnessLevel(FitnessLevel fitnessLevel)
        {
            var fitnessLevelArray = Enum.GetNames(typeof(FitnessLevel));

            if (fitnessLevelArray.Contains(fitnessLevel.ToString()))
            {
                return true;
            }
            else
            {
                return false;

            }

        }

        public bool ValidateHeight(string height)
        {

            if (Regex.IsMatch(height, @"^\d+$"))
            {
                return true;
            }
            else
            {
                if (Regex.IsMatch(height, @"^\d{1,}\'([1-9]|1[0-1])$"))
                {
                    return true;
                }
                return false;
            }
        }


        public (bool IsValid, List<ValidationResult> Errors) ValidateAttributes()
        {
            var FitnessLevelValidationResult = ValidateFitnessLevel(FitnessLevel);
            var HeightValidationResult = ValidateHeight(Height);

            var isValid = true;
            var currentContext = new ValidationContext(this);
            var validationResult = new List<ValidationResult>() { };
            Validator.TryValidateObject(this, currentContext, validationResult, true);

          

            if (!FitnessLevelValidationResult)
            {
                validationResult.Add(new ValidationResult("Fitness Level is not defined properly."));
            }
            if (!HeightValidationResult)
            {
                validationResult.Add(new ValidationResult("Height format is not correct. Please check documentation and try again."));
            }
            if (validationResult.Count != 0)
            {
                isValid = false;
            }
            return (isValid, validationResult);
        }

    }
}
