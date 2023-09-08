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

        public CharacterService()
        {
        }

        public async Task<ServiceResponse< List<Character>>> AddNewCharacter(Character NewCharacter)
        {   
            var serviceResponse=new ServiceResponse<List<Character>>();
            characters.Add(NewCharacter);
            serviceResponse.Data=characters;
            
            return serviceResponse;
        }

        public async Task<ServiceResponse< List<Character>>> GetAllCharacter()
        {   var serviceResponse=new ServiceResponse<List<Character>>();
            serviceResponse.Data=characters;
            return serviceResponse;
           
        }

        public async Task<ServiceResponse< Character>> GetById(int id)
        {   var serviceResponse = new ServiceResponse<Character>();
            var character=characters.FirstOrDefault(c=>c.Id==id);
            serviceResponse.Data=character;
            return serviceResponse;
             
            
        }
    }
}