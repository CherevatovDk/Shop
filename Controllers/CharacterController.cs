using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task< ActionResult<List<Character>>> Get()
        {
            return Ok( await _characterService.GetAllCharacter());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>>GetSingle(int id){
            return Ok(await _characterService.GetById(id));
        }

        [HttpPost]
        public async Task< ActionResult<List<Character>>>AddCharacter(Character newcharacters)
        {
            return Ok (await _characterService.AddNewCharacter(newcharacters));

        }
    }
}