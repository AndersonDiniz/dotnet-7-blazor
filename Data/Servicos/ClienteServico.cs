using blazor_desafio21dias_dotnet7.Ambientes;
using blazor_desafio21dias_dotnet7.Data.Models;

namespace blazor_desafio21dias_dotnet7.Data.Servicos;

public class ClienteServico
{
    private HttpClient http = new HttpClient();

    public async Task<Cliente[]?> Todos()
    {
        return await http.GetFromJsonAsync<Cliente[]>($"{Configuracao.Host}/clientes");
    }
    
    public async Task<Cliente?> BuscarPorId(int id)
    {
        return await http.GetFromJsonAsync<Cliente?>($"{Configuracao.Host}/clientes/{id}");
    }

    public async Task Incluir(Cliente cliente)
    {
        await http.PostAsJsonAsync<Cliente>($"{Configuracao.Host}/clientes", cliente);
    }

    public async Task Atualizar(Cliente cliente)
    {
        await http.PutAsJsonAsync<Cliente>($"{Configuracao.Host}/clientes/{cliente.Id}", cliente);
    }

    public async Task Excluir(Cliente cliente)
    {
        await http.DeleteAsync($"{Configuracao.Host}/clientes/{cliente.Id}");
    }
}
