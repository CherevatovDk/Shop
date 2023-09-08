using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Dtos.Characters;
using dotnet.Models;
using dotnet.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService  _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService=characterService;

        }
     
        
        [HttpGet("GetAll")]
        public async Task< ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok( await _characterService.GetAllCharacter());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>>GetSingle(int id){
            return Ok(await _characterService.GetById(id));
        }

        [HttpPost]
        public async Task< ActionResult<ServiceResponse<List<AddCharacterDto>>>>AddCharacter(AddCharacterDto newcharacters)
        {
            return Ok (await _characterService.AddNewCharacter(newcharacters));

        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<UpdateCharacterDto>>>UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            var respons= await _characterService.UpdateCharacter(updateCharacterDto);
            if(respons.Data is null)
            {
                return NotFound(respons);
            }
            return Ok(respons);
        }
    }
}