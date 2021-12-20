using System.Xml.Serialization;
using System.Xml;
using System.Collections;
using System.IO;

namespace CharacterBuilder.Code
{
    public class Character
    {
        public CharacterAttributes BodyAttributes { get; private set; }
        public CharacterAbilities AbilityPoints { get; internal set; }
        public string CharacterName { get; private set; }

        public Character(CharacterAttributes bodyAttributes, CharacterAbilities abilityPoints, string characterName)
        {
            BodyAttributes = bodyAttributes;
            AbilityPoints = abilityPoints;
            CharacterName = characterName;
        }
        public void SetNewAbilities(CharacterAbilities newCharacterAbilities)
        {
            AbilityPoints = newCharacterAbilities;
        }


    }
}
