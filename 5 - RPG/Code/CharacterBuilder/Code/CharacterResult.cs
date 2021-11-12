using CharacterBuilder.Code.Interfaces;

namespace CharacterBuilder.Code
{
    public class CharacterResult : ICharacterResult

    {
        public bool WasOperationSuccessful { get; private set; }
        public Character Character { get; private set; }
        public string ErrorMessage { get; private set; }

        public CharacterResult(bool wasOperationSuccessful, Character character, string errorMessage)
        {
            WasOperationSuccessful = wasOperationSuccessful;
            Character = character;
            ErrorMessage = errorMessage;
        }
        public CharacterResult(bool wasOperationSuccessful, Character character)
        {
            WasOperationSuccessful = wasOperationSuccessful;
            Character = character;
            ErrorMessage = string.Empty;
        }
        public CharacterResult(bool wasOperationSuccessful, string errorMessage)
        {
            WasOperationSuccessful = wasOperationSuccessful;
            Character = null;
            ErrorMessage = errorMessage;
        }

    }
}
