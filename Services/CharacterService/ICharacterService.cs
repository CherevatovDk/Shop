using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Dtos.Characters;
using dotnet.Models;

namespace dotnet.Services.CharacterService
{
    public interface ICharacterService
    {
       Task<ServiceResponse<List<GetCharacterDto>>>GetAllCharacter();
       Task< ServiceResponse<GetCharacterDto>> GetById(int id);
       Task<ServiceResponse<List<GetCharacterDto>>>AddNewCharacter(AddCharacterDto NewCharacter);
       Task<ServiceResponse<GetCharacterDto>>UpdateCharacter(UpdateCharacterDto updateCharacterDto);

    }
}