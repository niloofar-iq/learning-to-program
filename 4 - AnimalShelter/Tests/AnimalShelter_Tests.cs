using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectOrientedProblems.Code;
using ObjectOrientedProblems.Code.Enums;
using System;
using System.Collections.Generic;

namespace animalshelter.tests
{

    [TestClass]
    public class AnimalShelter_Tests
    {

        [TestMethod]
        public void AddAnimal_shouldAddAnimalToShelter_whenTheAnimalIsSupported()
        {
            var cat1 = new Animal(KnownAnimals.Cat);
            AnimalShelter.AddAnimal(cat1);
            Assert.AreEqual(true, AnimalShelter.StoredAnimal.Contains(cat1));
        }

        [TestMethod]
        public void AddAnimal_shouldNotAddAnimalToShelter_whenTheAnimalIsNotSupported()
        {
            var bear1 = new Animal(KnownAnimals.Bear);
            AnimalShelter.AddAnimal(bear1);
            Assert.AreEqual(false, AnimalShelter.StoredAnimal.Contains(bear1));
        }


        [TestMethod]
        public void AddAnimal_shouldNotAddAnimalToShelter_whenTheAnimalDoesNotExist()
        {
            var dunkey1 = new Animal((KnownAnimals)9999); //this known animal will not exist
            AnimalShelter.AddAnimal(dunkey1);

            Assert.AreEqual(false, AnimalShelter.StoredAnimal.Contains(dunkey1));
        }


        [TestMethod]
        public void AddAnimal_shouldReturnAResultWithTypeOfAnimalAndWithNoErrorMessage_whenTheAnimalIsSupported()
        {
            var cat1 = new Animal(KnownAnimals.Cat);

            var AddResult = AnimalShelter.AddAnimal(cat1);

            Assert.AreEqual(true, AddResult.IsAnimalTransactable);
            Assert.AreEqual("", AddResult.ErrorMessage);
            Assert.AreEqual(cat1, AddResult.TransactableAnimal);
        }


        [TestMethod]
        public void AddAnimal_shouldNotAddAnimalToShelterAndShouldReturnErrorMessage_whenTheAnimalIsNotSupported()
        {
            var deer1 = new Animal(KnownAnimals.Deer);

            var actual = AnimalShelter.AddAnimal(deer1);
            //var expected = new AddAnimalResult(false, KnownAnimals.Deer, "Animal is not supported in this shelter.");

            //Assert.AreEqual(expected, actual);
            Assert.AreEqual(false, actual.IsAnimalTransactable);
            Assert.AreEqual(deer1, actual.TransactableAnimal);
            Assert.AreEqual("Animal is not supported in this shelter.", actual.ErrorMessage);

        }

        [TestMethod]
        public void AddAnimal_ShouldAddUniqueIdToAnimal_whenAnimalIsStored()
        {
            var snake1 = new Animal(KnownAnimals.Snake);
            AnimalShelter.AddAnimal(snake1);
            Assert.AreNotEqual(Guid.Empty, snake1.UniqueAnimalId);

        }

        [TestMethod]
        public void AddAnimal_ShouldNotAddUniqueIdToAnimal_whenAnimalIsNotSupported()
        {
            var bear1 = new Animal(KnownAnimals.Bear);
            AnimalShelter.AddAnimal(bear1);
            Assert.AreEqual(Guid.Empty, bear1.UniqueAnimalId);

        }

        [TestMethod]
        public void GetAnimals_shouldReturnListOfFilteredAnimalsFromStoredAnimals()
        {
            var dog1 = new Animal(KnownAnimals.Dog);
            var bird1 = new Animal(KnownAnimals.Bird);
            var bird2 = new Animal(KnownAnimals.Bird);
            AnimalShelter.AddAnimal(dog1);
            AnimalShelter.AddAnimal(bird1);
            AnimalShelter.AddAnimal(bird2);

            var expectedDog = new List<Animal> { dog1 };
            var expectedFlying = new List<Animal> { bird1, bird2 };


            var dogList = AnimalShelter.GetAnimals(Filters.Dogs);
            var birdList = AnimalShelter.GetAnimals(Filters.Flying);
            var animalList = AnimalShelter.GetAnimals(Filters.All);

            CollectionAssert.AreEqual(expectedDog, dogList);
            CollectionAssert.AreEqual(expectedFlying, birdList);
            CollectionAssert.AreEqual(AnimalShelter.StoredAnimal, animalList);
        }




        [TestMethod]
        public void RemoveAnimal_shouldRemoveAnimalFromShelter_whenTheAnimalIsSupported()
        {
            var cat1 = new Animal(KnownAnimals.Cat);
            AnimalShelter.AddAnimal(cat1);

            AnimalShelter.RemoveAnimal(cat1);
            Assert.AreEqual(false, AnimalShelter.StoredAnimal.Contains(cat1));
        }


        [TestMethod]
        public void RemoveAnimal_shouldReturnErrorMessage_whenTheAnimalIsSupportedButNotFound()
        {
            var cat1 = new Animal(KnownAnimals.Cat);
            var cat2 = new Animal(KnownAnimals.Cat);
            AnimalShelter.AddAnimal(cat1);
            var actual = AnimalShelter.RemoveAnimal(cat2);

            Assert.AreEqual(false, AnimalShelter.StoredAnimal.Contains(cat2));
            Assert.AreEqual("Animal can not be found in this shelter.", actual.ErrorMessage);
        }

        [TestMethod]
        public void GetAnimalFromId_shouldReturnAnAnimal_whenTheAnimalIsFound()
        {
            var cat1 = new Animal(KnownAnimals.Cat);
            AnimalShelter.AddAnimal(cat1);
            var newCat1Id = cat1.UniqueAnimalId.ToString();

            var actual = AnimalShelter.GetAnimalFromId(newCat1Id);

            Assert.AreEqual(true, actual.IsAnimalTransactable);
        }


        [TestMethod]
        public void GetAnimalFromId_shouldReturnError_whenTheAnimalIsNotFound()
        {
            var cat1 = new Animal(KnownAnimals.Cat);
            var newCat1Id = cat1.UniqueAnimalId.ToString();

            var actual = AnimalShelter.GetAnimalFromId(newCat1Id);

            Assert.AreEqual("Animal does not exist in the system", actual.ErrorMessage);
        }


        [TestMethod]
        public void GetAnimalFromId_shouldReturnError_whenTheAnimalIdIsNotValidFormat()
        {
            var newCat1Id = "22-555-66666-3232";

            var actual = AnimalShelter.GetAnimalFromId(newCat1Id);

            Assert.AreEqual("Animal Id is not a valid format", actual.ErrorMessage);

        }



    }
}

