using System.Net.Http.Headers;
using blazor_desafio21dias_dotnet7.Ambientes;
using blazor_desafio21dias_dotnet7.Data.Models;

namespace blazor_desafio21dias_dotnet7.Data.Servicos;

public class ClienteServico
{
    private HttpClient http = new HttpClient();

    public async Task<Cliente[]?> Todos(string? token)
    {
        this.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return await http.GetFromJsonAsync<Cliente[]>($"{Configuracao.Host}/clientes");
    }
    
    public async Task<Cliente?> BuscarPorId(int id, string? token)
    {
        this.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return await http.GetFromJsonAsync<Cliente?>($"{Configuracao.Host}/clientes/{id}");
    }

    public async Task Incluir(Cliente cliente, string? token)
    {
        this.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        await http.PostAsJsonAsync<Cliente>($"{Configuracao.Host}/clientes", cliente);
    }

    public async Task Atualizar(Cliente cliente, string? token)
    {
        this.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        await http.PutAsJsonAsync<Cliente>($"{Configuracao.Host}/clientes/{cliente.Id}", cliente);
    }

    public async Task Excluir(Cliente cliente, string? token)
    {
        this.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        await http.DeleteAsync($"{Configuracao.Host}/clientes/{cliente.Id}");
    }
}
