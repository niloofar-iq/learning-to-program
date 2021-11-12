using System;
using System.Collections.Generic;

namespace CharacterBuilder.Code
{
    public static class CharacterBuilder
    {
        public static List<Character> CreatedCharactersList { get; private set; } = new List<Character> { };

        public static CharacterResult AddCharacter(Character newCharacter)
        {
            try
            {
                CreatedCharactersList.Add(newCharacter);
                return new CharacterResult(true, newCharacter);
            }
            catch(Exception)
            {
                return new CharacterResult(false, "Character couldn't be created.");
            }
        }





    }
}
