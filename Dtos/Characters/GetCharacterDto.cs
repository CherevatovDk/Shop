using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;

namespace dotnet.Dtos.Characters
{
    public class GetCharacterDto
    {
         public int Id{get; set;}
        public string Name{get; set;}= "frodo";
        public int HitPoinst{get;set;}=10;
        public int Strength{get;set;}
        public int Defense{get;set;}
        public int Intelligence{get;set;}
        public RpgClass Class{get;set;}=RpgClass.knight;
    }
}