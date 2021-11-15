using CharacterBuilder.Code.Enums;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CharacterBuilder.Code
{
    public class BodyAttributes
    {

        public int HeadRoundness { get; private set; }
        public FitnessLevel FitnessLevel { get; private set; }
        public string Height { get; private set; }

        public BodyAttributes(int headRoundness, FitnessLevel fitnessLevel, string height)
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
        }




        public bool ValidateHeadRoundness(int headRoundness)
        {
            if (headRoundness >= 0 && headRoundness <= 100)
            {
                return true;
            }
            else
            {
                //return false;
                throw new ArgumentException("Head Roundness is not between 0 and 100 percent.");
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
                throw new ArgumentException("Fitness Level is not defined properly.");

            }

        }

        public bool ValidateHeight(string height)
        {
            //**SOLUTION #1 to validate the height format.
            //***I found solution#1 very long and complicated to implement so I searched for a more concise solution which led me to solution #2.


            //var IsContainFeetSign = height.Contains("'");
            //if (IsContainFeetSign)
            //{
            //    if (height.IndexOf("'") != 0)
            //    {
            //        var FeetSubstring = height.Substring(0, height.IndexOf("'"));
            //        var InchesSubstring = height.Substring(height.IndexOf("'") + 1);

            //        if (Regex.IsMatch(FeetSubstring, @"^\d+$") && Regex.IsMatch(InchesSubstring, @"^\d+$"))
            //        {
            //            int feet = Convert.ToInt32(height.Substring(0, height.IndexOf("'")));
            //            int inches = Convert.ToInt32(height.Substring(height.IndexOf("'") + 1).Trim());
            //            if (feet > 0 && (inches >= 1 || inches <= 11))
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (Regex.IsMatch(height, @"^\d+$"))
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}



            //***SOLUTION #2 to validate the height format: using REGEX


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
                throw new ArgumentException("Height format is not correct. Please check documentation and try again.");
            }
        }


        public bool ValidateBodyAttributes()
        {
            var HeadRoundnessValidationResult = ValidateHeadRoundness(HeadRoundness);
            var FitnessLevelValidationResult = ValidateFitnessLevel(FitnessLevel);
            var HeightValidationResult = ValidateHeight(Height);

            if (HeadRoundnessValidationResult == true && FitnessLevelValidationResult == true && HeightValidationResult == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
