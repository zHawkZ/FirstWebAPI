using System.ComponentModel.DataAnnotations;
using FirstAPI.Enums;

namespace FirstAPI.Models;

public class FuncionarioModel
{
    [Key]
    public int Id { set; get; }

    public string Nome { get; set; }

    public string Sobrenome { get; set; }

    public DepartamentosEnum Departamento { get; set; }

    public TurnosEnum Turno { get; set; }

    public bool IsAtivo { get; set; }

    public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();

    public DateTime DataDeAtualizacao { get; set; } = DateTime.Now.ToLocalTime();

}