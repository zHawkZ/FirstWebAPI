namespace FirstAPI.Models;

public class ServiceResponse <T>
{
    public T? Dados { get; set; }

    public string Message { get; set; } = string.Empty;

    public bool Sucesso { get; set; } = true;
}