using System.Text.Json.Serialization;

namespace dotnet.Models
{[JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        knight=1,
        Mage=2,
        cleric=3
    }
}