namespace dotnet.Models
{
    public class Character
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