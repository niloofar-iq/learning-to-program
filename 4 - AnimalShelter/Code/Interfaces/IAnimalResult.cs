namespace ObjectOrientedProblems.Code.Interfaces
{
    public interface IAnimalResult
    {
        bool IsAnimalTransactable { get; }
        Animal TransactableAnimal { get; }
        string ErrorMessage { get; }
    }
}
