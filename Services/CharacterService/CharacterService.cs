using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using dotnet.Dtos.Characters;
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

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper=mapper;
        }

        

        public async Task<ServiceResponse< List<GetCharacterDto>>> AddNewCharacter(AddCharacterDto NewCharacter)
        {   
            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();
            var character=_mapper.Map<Character>(NewCharacter);
            character.Id=characters.Max(c=> c.Id)+1;
            characters.Add(character);

            serviceResponse.Data=characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var character=characters.First(c=> c.Id==id);
                if(character is null)
                    throw new Exception($"Character wis id'{id}' not found");

                characters.Remove(character);
                serviceResponse.Data=characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Sucsess=false;
                serviceResponse.Mage=ex.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse< List<GetCharacterDto>>> GetAllCharacter()
        {   var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data=characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
           
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetById(int id)
        {   var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character=characters.FirstOrDefault(c=>c.Id==id);
            serviceResponse.Data=_mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
             
            
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            var serviceResponse=new ServiceResponse<GetCharacterDto>();
            try{
            var character=characters.FirstOrDefault(c=>c.Id==updateCharacterDto.Id);
            if(character is null)
            throw new Exception($"Character with id'{updateCharacterDto.Id}' not found"); 

            character.Name=updateCharacterDto.Name;
            character.HitPoinst=updateCharacterDto.HitPoinst;
            character.Strength=updateCharacterDto.Strength;
            character.Defense=updateCharacterDto.Defense;
            character.Intelligence=updateCharacterDto.Intelligence;
            character.Class=updateCharacterDto.Class;

            serviceResponse.Data=_mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex)
            {
                serviceResponse.Sucsess=false;
                serviceResponse.Mage=ex.Message;

            }
            return serviceResponse;
        }
    }
}