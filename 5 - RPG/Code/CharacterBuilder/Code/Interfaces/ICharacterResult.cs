namespace CharacterBuilder.Code.Interfaces
{
    public interface ICharacterResult
    {
        bool WasOperationSuccessful { get; }
        Character Character { get; }
        string ErrorMessage { get; }
    }
}
