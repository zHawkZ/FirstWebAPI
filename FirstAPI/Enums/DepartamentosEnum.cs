using System.Text.Json.Serialization;

namespace FirstAPI.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DepartamentosEnum
{
    Rh,
    Fincanceiro,
    Compras,
    Atendimento,
    Zeladoria
}