using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using dotnet.Data;
using dotnet.Dtos.Characters;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        
       

        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CharacterService(IMapper mapper, DataContext dataContext)
        {
            _mapper=mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetById(int id)
        {   var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter =await _dataContext.Characters.FirstOrDefaultAsync(c=> c.Id==id);
            serviceResponse.Data=_mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
             
            
        }

        
        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var character= await _dataContext.Characters.FirstAsync(c=> c.Id==id);
                if(character is null)
                    throw new Exception($"Character wis id'{id}' not found");

                _dataContext.Characters.Remove(character);
                serviceResponse.Data=_dataContext.Characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
                
                
            }
            catch(Exception ex)
            {
                serviceResponse.Sucsess=false;
                serviceResponse.Mage=ex.Message;

            }
            await _dataContext.SaveChangesAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse< List<GetCharacterDto>>> GetAllCharacter()
        {   
            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacter=await _dataContext.Characters.ToListAsync();
            serviceResponse.Data=dbCharacter.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
           
        }

        
        public async Task<ServiceResponse< List<GetCharacterDto>>> AddNewCharacter(AddCharacterDto NewCharacter)
        {   
            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();
            var character= _mapper.Map<Character>(NewCharacter);
            //character.Id=_dataContext.Characters.Max(c=> c.Id)+1;
            _dataContext.Characters.Add(character);
            serviceResponse.Data=_dataContext.Characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            await _dataContext.SaveChangesAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            var serviceResponse=new ServiceResponse<GetCharacterDto>();
            
            try{
            var character= await _dataContext.Characters.FirstOrDefaultAsync(c=>c.Id==updateCharacterDto.Id);
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
            await _dataContext.SaveChangesAsync();
            return serviceResponse;
        }
    }
}