using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;

namespace dotnet.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character>GetAllCharacter();
        Character GetById(int id);
        List<Character>AddNewCharacter(Character NewCharacter);

    }
}