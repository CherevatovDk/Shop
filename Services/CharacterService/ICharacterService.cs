using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;

namespace dotnet.Services.CharacterService
{
    public interface ICharacterService
    {
       Task<ServiceResponse< List<Character>>>GetAllCharacter();
       Task< ServiceResponse< Character>> GetById(int id);
       Task<ServiceResponse<List<Character>>>AddNewCharacter(Character NewCharacter);

    }
}