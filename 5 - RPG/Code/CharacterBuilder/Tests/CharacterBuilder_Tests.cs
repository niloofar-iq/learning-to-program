using CharacterBuilder.Code;
using CharacterBuilder.Code.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CharacterBuilder.Tests
{
    [TestClass]
    public class CharacterBuilder_Tests
    {
        [TestMethod]
        public void BodyAttributes_ValidateHeadRoundness_WhenHeadRoundnessIsWithinRange()
        {
            var newBodyAttributes = new BodyAttributes(30, FitnessLevel.ExtremelyFit, "6");
            var isHeadroundnessValid = newBodyAttributes.ValidateHeadRoundness(40);

            Assert.IsTrue(isHeadroundnessValid);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Height format is not correct. Please check documentation and try again.")]
        public void BodyAttributes_shouldNotBeSet_WhenTheHeightFormatIsNOTCorrect()
        {
            new BodyAttributes(30, FitnessLevel.ExtremelyFit, "24'52");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Body Attributes should all be set. Please try again.")]
        public void BodyAttributes_shouldNotBeSet_WhenAnyIsNull()
        {
            new BodyAttributes(30, FitnessLevel.NotSet, "4'5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Sum of Ability Points must exactly equal to 60. Please try again.")]
        public void AbilityPoints_shouldNotBeSet_WhenSumOfAllAbilityPointsIsNOTExactlySixty()
        {
            new AbilityPoints(15, 10, 10, 5, 15, 15);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Charisma value is out of range. Supported values are between 0 to 20.")]
        public void AbilityPoints_shouldNotBeSet_WhenAnyAbilityPointsIsOutOfRange()
        {
            new AbilityPoints(15, 10, 5, 5, 25, 5);
        }


        [TestMethod]
        public void AddCharacter_ShouldBuildCharacter_WhenBodyAttributesAndAbilityPointsAndNameAreSet()
        {
            //arrange
            var newBodyAttributes = new BodyAttributes(30, FitnessLevel.ExtremelyFit, "5");
            var newAbilityPoints = new AbilityPoints(15, 10, 10, 5, 5, 15);
            var newCharacterName = "Batman";
            var newCharacter = new Character(newBodyAttributes, newAbilityPoints, newCharacterName);

            //act
            var newCharacterResult = Code.CharacterBuilder.AddCharacter(newCharacter);

            //assert
            Assert.AreEqual("Batman", newCharacterResult.Character.CharacterName);

        }

        [TestMethod]
        public void AddCharacter_ShouldAddCharacterToTheCreatedCharactersList_WhenBodyAttributesAndAbilityPointsAndNameAreSet()
        {
            //arrange
            var newBodyAttributes = new BodyAttributes(40, FitnessLevel.FarFromFit, "5'6");
            var newAbilityPoints = new AbilityPoints(10, 10, 5, 15, 5, 15);
            var newCharacterName = "Ninja";
            var newCharacter = new Character(newBodyAttributes, newAbilityPoints, newCharacterName);

            //act
            var result = Code.CharacterBuilder.AddCharacter(newCharacter);
            var doesCharacterExistInList = Code.CharacterBuilder.CreatedCharactersList.Contains(result.Character);

            //assert

            Assert.IsTrue(doesCharacterExistInList);
        }

    }
}
