using ObjectOrientedProblems.Code.Enums;
using System;

namespace ObjectOrientedProblems.Code.Interfaces
{
    public interface IAnimal
    {
        KnownAnimals Type { get; }
        Guid UniqueAnimalId { get; }
        void SetAnimalId();
    }
}
