using System.ComponentModel.DataAnnotations;

namespace blazor_desafio21dias_dotnet7.Data.DTOs;

public record LoginDTO
{
    [Required(ErrorMessage = "O Email não pode ser vazio")]
    public string Email { get;set; } = default!;
    [Required(ErrorMessage = "O Senha não pode ser vazio")]
    public string Senha { get;set; } = default!;
}