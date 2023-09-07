using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List <Character> characters=new List<Character>{
            new Character(),
            new Character{Name="Sem"}
        } ;
        
        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get(){return Ok(characters);}
        
        [HttpGet]
        public ActionResult<Character>GetSingle(int id){
            return Ok(characters.FirstOrDefault(c=> c.Id==id));
        }

        [HttpPost]
        public ActionResult<List<Character>>AddCharacter(Character newcharacters)
        {
             characters.Add(newcharacters);
             return characters;

        }
    }
}