using CharacterBuilder.Code;
using CharacterBuilder.Code.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Xml.Serialization;

namespace CharacterBuilder.Tests
{
    [TestClass]
    public class CharacterBuilder_Tests
    {
        [TestMethod]
        public void BodyAttributes_Validation()
        {
            var newAttributes = new CharacterAttributes(30, FitnessLevel.ExtremelyFit, "6");

            Assert.AreEqual(30, newAttributes.HeadRoundness);
            Assert.AreEqual(FitnessLevel.ExtremelyFit, newAttributes.FitnessLevel);
            Assert.AreEqual("6", newAttributes.Height);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Attributes_NotValid_whenFitnessLevelNotSet()
        {
            new CharacterAttributes(30, FitnessLevel.NotSet, "7");

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Attributes_NotValid_whenHeightIsNotCorrectFormat()
        {
            new CharacterAttributes(30, FitnessLevel.ExtremelyFit, "7'25");

        }

        [TestMethod]
        public void Abilities_Validation()
        {
            var newAbilities = new CharacterAbilities(5, 10, 15, 15, 5, 10);

            Assert.AreEqual(5, newAbilities.Intelligence);
            Assert.AreEqual(10, newAbilities.Wisdom);
            Assert.AreEqual(15, newAbilities.Dexterity);
            Assert.AreEqual(15, newAbilities.Strength);
            Assert.AreEqual(5, newAbilities.Charisma);
            Assert.AreEqual(10, newAbilities.Constitution);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Abilities_NotValid_whenPointsAreOutOfRange()
        {
            new CharacterAbilities(5, 5, 10, 10, 5, 25);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateCharacter_shouldNotCreateCharacter_WhenSumOfAllAbilityPointsIsNOTExactlySixty()
        {
            //arrange
            new CharacterAbilities(15, 10, 10, 5, 15, 20);

        }

        [TestMethod]
        public void SetNewAbilities_shouldSetNewAbilitiesForAnExistingCharacter()
        {
            //arrange
            var attributes = new CharacterAttributes(40, FitnessLevel.ExtremelyFit, "10");
            var abilities = new CharacterAbilities(5, 10, 15, 15, 5, 10);
            var character = new Character(attributes, abilities, "Mucho");

            //act
            var newAbilities = new CharacterAbilities(10, 10, 10, 15, 5, 10);
            character.SetNewAbilities(newAbilities);

            //assert
            Assert.AreEqual(10, character.AbilityPoints.Intelligence);
            Assert.AreEqual(10, character.AbilityPoints.Dexterity);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SetNewAbilities_shouldNotSetNewAbilitiesForAnExistingCharacter_whenNewAbilitiesAreNotValid()
        {
            //arrange
            var attributes = new CharacterAttributes(40, FitnessLevel.FarFromFit, "8");
            var abilities = new CharacterAbilities(5, 10, 10, 20, 5, 10);
            var character = new Character(attributes, abilities, "Nero");

            //act
            var newAbilities = new CharacterAbilities(20, 10, 10, 20, 5, 10);
            character.SetNewAbilities(newAbilities);


        }

        [TestMethod]
        public void SerializeCharacter_shouldSaveCharacetrToTheSpecifiedPath()
        {
            //arrange
            var attributes = new CharacterAttributes(50, FitnessLevel.FarFromFit, "10");
            var abilities = new CharacterAbilities(5, 10, 10, 20, 5, 10);
            var character = new Character(attributes, abilities, "Nemo");
            var newSerializeCharacter = new CharacterSerializer();

            //act
            newSerializeCharacter.SerializeCharacter(character);

            //assert
            Assert.IsTrue(File.Exists(@"C:\CharacterFolder\Nemo.json"));
        }

        [TestMethod]
        public void DeSerializeCharacter_shouldReturnCharacetrFromTheSpecifiedPath()
        {
            //arrange
            var attributes = new CharacterAttributes(50, FitnessLevel.FarFromFit, "10");
            var abilities = new CharacterAbilities(5, 10, 10, 20, 5, 10);
            var expectedCharacter = new Character(attributes, abilities, "Nemo");
            var characterFullPath = @"C:\CharacterFolder\Nemo.json";
            var newSerializeCharacter = new CharacterSerializer();

            //act
            var actualDeserializedCharacter = newSerializeCharacter.DeserializeCharacter(characterFullPath);

            //assert
            Assert.AreEqual(expectedCharacter.CharacterName, actualDeserializedCharacter.CharacterName);
        }

    }
}
