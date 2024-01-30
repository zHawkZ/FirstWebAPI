using System.Text.Json.Serialization;

namespace FirstAPI.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TurnosEnum
{
    Manha,
    Tarde,
    Noite
}