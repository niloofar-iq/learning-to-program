namespace CharacterBuilder.Code
{
    public class Character
    {
        public CharacterAttributes BodyAttributes { get; private set; }
        public CharacterAbilities AbilityPoints { get; private set; }
        public string CharacterName { get; private set; }

        public Character(CharacterAttributes bodyAttributes, CharacterAbilities abilityPoints, string characterName)
        {
            BodyAttributes = bodyAttributes;
            AbilityPoints = abilityPoints;
            CharacterName = characterName;
        }
    }
}
