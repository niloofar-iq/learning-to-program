using ObjectOrientedProblems.Code.Enums;
using ObjectOrientedProblems.Code.Interfaces;
using System;
using System.Collections.Generic;

namespace ObjectOrientedProblems.Code
{

    public static class AnimalShelter
    {
        public static List<Animal> StoredAnimal { get; private set; } = new List<Animal> { };

        public static AddAnimalResult AddAnimal(Animal animal)
        {
            try
            {
                bool IsAnimalTransactable = true;
                Animal TransactableAnimal = animal;
                string ErrorMessage = "";


                //if (Enum.IsDefined(typeof(SupportedAnimals), animal.Type.ToString()))
                var supportedAnimalArray = Enum.GetNames(typeof(SupportedAnimals));
                if (Array.Exists(supportedAnimalArray, element => element == animal.Type.ToString()))

                {
                    StoredAnimal.Add(animal);
                    animal.SetAnimalId();
                }
                else
                {
                    IsAnimalTransactable = false;
                    ErrorMessage = "Animal is not supported in this shelter.";
                }

                return new AddAnimalResult(IsAnimalTransactable, TransactableAnimal, ErrorMessage);
            }
            catch (Exception)
            {
                return new AddAnimalResult(false, animal, "Input is invalid. Try adding supported animal. See API doc for more information. ");

            }
        }
        public static List<Animal> GetAnimals(Filters filter)
        {
            switch (filter)
            {
                case Filters.Cats:
                    filter = (Filters)KnownAnimals.Cat;
                    break;
                case Filters.Dogs:
                    filter = (Filters)KnownAnimals.Dog;
                    break;
                case Filters.Flying:
                    filter = (Filters)KnownAnimals.Bird;
                    break;
                case Filters.All:
                    filter = (Filters)KnownAnimals.NotSet;
                    break;
                default:
                    filter = (Filters)KnownAnimals.NotSet;
                    break;
            }

            if (filter == (Filters)KnownAnimals.NotSet)
            {
                return StoredAnimal;
            };

            return StoredAnimal.FindAll(animal => (Filters)animal.Type == filter);
        }

        public static IAnimalResult RemoveAnimal(Animal animal)
        {
            try
            {
                bool IsAnimalTransactable = true;
                Animal TransactableAnimal = animal;
                string ErrorMessage = "";


                if (Enum.IsDefined(typeof(SupportedAnimals), animal.Type.ToString()) && StoredAnimal.Contains(animal) == true)
                {
                    StoredAnimal.Remove(animal);
                }
                else
                {
                    IsAnimalTransactable = false;
                    ErrorMessage = "Animal can not be found in this shelter.";
                }
                return new RemoveAnimalResult(IsAnimalTransactable, TransactableAnimal, ErrorMessage);
            }
            catch (Exception)
            {
                return new RemoveAnimalResult(false, animal, "Input is invalid. Try again. ");

            }
        }

        public static IAnimalResult GetAnimalFromId(string uniqueAnimalId)
        {
            try
            {
                var newUniqueAnimalId = Guid.Parse(uniqueAnimalId);
                var foundAnimal = StoredAnimal.Find(animal => animal.UniqueAnimalId == newUniqueAnimalId);

                bool IsAnimalTransactable = true;
                string ErrorMessage = "";


                if (foundAnimal == null)
                {
                    IsAnimalTransactable = false;
                    ErrorMessage = "Animal does not exist in the system";
                };

                return new GetAnimalFromIdResult(IsAnimalTransactable, foundAnimal, ErrorMessage);
            }
            catch (FormatException)
            {
                return new GetAnimalFromIdResult(false, null, "Animal Id is not a valid format");
            }
        }
    }
}

