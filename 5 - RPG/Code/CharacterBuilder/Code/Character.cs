namespace CharacterBuilder.Code
{
    public class Character
    {
        public BodyAttributes BodyAttributes { get; private set; }
        public AbilityPoints AbilityPoints { get; private set; }
        public string CharacterName { get; private set; }

        public Character(BodyAttributes bodyAttributes, AbilityPoints abilityPoints, string characterName)
        {
            BodyAttributes = bodyAttributes;
            AbilityPoints = abilityPoints;
            CharacterName = characterName;
        }

    }
}
           