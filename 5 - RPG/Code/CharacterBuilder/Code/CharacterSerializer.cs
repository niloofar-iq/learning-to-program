using Newtonsoft.Json;
using System.IO;

namespace CharacterBuilder.Code
{
    public class CharacterSerializer
    {
        public const string characterSaveFolder = @"C:\CharacterFolder\";


        public void SerializeCharacter(Character character)
        {
            var characterSaveFullPath = characterSaveFolder + character.CharacterName+".json";

            string jsonCharacter= JsonConvert.SerializeObject(character);
            File.WriteAllText(characterSaveFullPath, jsonCharacter);
        }

        public Character DeserializeCharacter(string characterSaveFullPath)
        {
            //var jsonCharacterFileContent= File.ReadAllText(characterSaveFullPath);
            //var deserializedCharacter = JsonConvert.DeserializeObject<Character>(jsonCharacterFileContent);
            //return deserializedCharacter;

            //short version of the above code
            return JsonConvert.DeserializeObject<Character>(File.ReadAllText(characterSaveFullPath));
        }
    }
}
