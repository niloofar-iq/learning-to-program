using ObjectOrientedProblems.Code.Enums;
using ObjectOrientedProblems.Code.Interfaces;
using System;

namespace ObjectOrientedProblems.Code
{
    public class Animal : IAnimal
    {
        public KnownAnimals Type { get; private set; }
        public Guid UniqueAnimalId { get; private set; }

        //constructor
        public Animal(KnownAnimals type)
        {
            Type = type;
        }
        public void SetAnimalId()
        {
            UniqueAnimalId = Guid.NewGuid();
        }
    }
}
