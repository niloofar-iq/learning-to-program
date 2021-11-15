using CharacterBuilder.Code;
using CharacterBuilder.Code.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CharacterBuilder.Code.Interfaces;
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
        public void CreateCharacter_shouldNotCreateCharacter_WhenTheHeightFormatIsNOTCorrect()
        {
            //arrange
            var newBodyAttributes = new BodyAttributes(40, FitnessLevel.FarFromFit, "24'52");
            var newAbilityPoints = new Code.CharacterBuilder.AbilityPoints(10, 10, 5, 15, 5, 15);
            var newCharacterName = "Ninja";

            //act
            var result = Code.CharacterBuilder.CreateCharacter(newBodyAttributes, newAbilityPoints, newCharacterName);

            //assert

            Assert.AreEqual("Height format is not correct. Please check documentation and try again.", result.ErrorMessage);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Body Attributes should all be set. Please try again.")]
        public void BodyAttributes_shouldNotBeSet_WhenAnyIsNull()
        {
            new BodyAttributes(30, FitnessLevel.NotSet, "4'5");
        }

        [TestMethod]
        public void CreateCharacter_shouldNotCreateCharacter_WhenSumOfAllAbilityPointsIsNOTExactlySixty()
        {

            //arrange
            var newBodyAttributes = new BodyAttributes(40, FitnessLevel.FarFromFit, "24");
            var newAbilityPoints = new Code.CharacterBuilder.AbilityPoints(15, 10, 10, 5, 15, 15);
            var newCharacterName = "Binja";

            //act
            var result = Code.CharacterBuilder.CreateCharacter(newBodyAttributes, newAbilityPoints, newCharacterName);

            //assert

            Assert.AreEqual("Sum of Ability Points must exactly equal to 60. Please try again.", result.ErrorMessage);

        }


        [TestMethod]
        public void CreateCharacter_ShouldBuildCharacter_WhenBodyAttributesAndAbilityPointsAndNameAreSet()
        {
            //arrange
            var newBodyAttributes = new BodyAttributes(30, FitnessLevel.ExtremelyFit, "5");
            var newAbilityPoints = new Code.CharacterBuilder.AbilityPoints(15, 10, 10, 5, 5, 15);
            var newCharacterName = "Batman";

            //act
            var newCharacterResult = Code.CharacterBuilder.CreateCharacter(newBodyAttributes, newAbilityPoints, newCharacterName);

            //assert
            Assert.AreEqual("Batman", newCharacterResult.Character.CharacterName);

        }

        [TestMethod]
        public void CreateCharacter_ShouldAddCharacterToTheCreatedCharactersList_WhenBodyAttributesAndAbilityPointsAndNameAreSet()
        {
            //arrange
            var newBodyAttributes = new BodyAttributes(40, FitnessLevel.FarFromFit, "5'6");
            var newAbilityPoints = new Code.CharacterBuilder.AbilityPoints(10, 10, 5, 15, 5, 15);
            var newCharacterName = "Ninja";

            //act
            var result = Code.CharacterBuilder.CreateCharacter(newBodyAttributes, newAbilityPoints, newCharacterName);
            var doesCharacterExistInList = Code.CharacterBuilder.CreatedCharactersList.Contains(result.Character);

            //assert

            Assert.IsTrue(doesCharacterExistInList);
        }

    }
}
