using ObjectOrientedProblems.Code.Interfaces;

namespace ObjectOrientedProblems.Code
{
    public class RemoveAnimalResult : IAnimalResult
    {
        public bool IsAnimalTransactable { get; private set; }
        public Animal TransactableAnimal { get; private set; }
        public string ErrorMessage { get; private set; }

        public RemoveAnimalResult(bool isAnimalTransacted, Animal transactedAnimal, string errorMessage)
        {
            IsAnimalTransactable = isAnimalTransacted;
            TransactableAnimal = transactedAnimal;
            ErrorMessage = errorMessage;
        }
    }
}
