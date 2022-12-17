using System.ComponentModel.DataAnnotations;

namespace blazor_desafio21dias_dotnet7.Data.Models;

public record Administrador
{
    public string Email { get;set; } = default!;
    public string Permissao { get;set; } = default!;
    public string Token { get;set; } = default!;
}
