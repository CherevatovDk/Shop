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
        private static List <Character> characters=new List<Character>{
            new Character(),
            new Character{Id=1,  Name="Sem"}
        } ;
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        } 

        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get()
        {
            return _characterService.GetAllCharacter();
        }
        
        [HttpGet]
        public ActionResult<Character>GetSingle(int id)
        {
           return _characterService.GetById(id);
        }

        [HttpPost]
        public ActionResult<List<Character>>AddCharacter(Character newcharacters)
        {
           return _characterService.AddNewCharacter(newcharacters);
             

        }
    }
}