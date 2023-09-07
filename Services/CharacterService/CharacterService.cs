using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;

namespace dotnet.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        
        private static List<Character> characters=new List<Character>
        {
            new Character(),
            new Character{Id=1 ,Name="Sem"}

        };
        public List<Character> AddNewCharacter(Character NewCharacter)
        {
            characters.Add(NewCharacter);
            return characters;
        }

        public List<Character> GetAllCharacter()
        {
            return characters;
           
        }

        public Character GetById(int id)
        {   
            var character=characters.FirstOrDefault(c=>c.Id==id);
            if(character is not null)
            {
                return character;
            }
            throw new Exception("Character is not found");
             
            
        }
    }
}