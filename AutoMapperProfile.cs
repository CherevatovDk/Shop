using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet.Dtos.Characters;
using dotnet.Models;

namespace dotnet
{
    public class AutomaperProfile:Profile
    {
        public AutomaperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
            CreateMap<UpdateCharacterDto, Character>();

        }

    

        
    }
}