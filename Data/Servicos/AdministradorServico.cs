using System.Text;
using System.Text.Json;
using blazor_desafio21dias_dotnet7.Ambientes;
using blazor_desafio21dias_dotnet7.Data.DTOs;
using blazor_desafio21dias_dotnet7.Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace blazor_desafio21dias_dotnet7.Data.Servicos;

public class AdministradorServico
{
    private HttpClient http = new HttpClient();

    public async Task<Administrador?> LoginAsync(LoginDTO login)
    {
        var content = new StringContent(JsonSerializer.Serialize(login), Encoding.UTF8, "application/json");
        var response = await http.PostAsync($"{Configuracao.Host}/login", content);

        if(response.StatusCode != System.Net.HttpStatusCode.OK) return null;

        var result = await response.Content.ReadAsStringAsync();
        var administrador = JsonSerializer.Deserialize<Administrador>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return administrador;
    }

    public static async Task RedirectLoginSeNaoLogado(ProtectedLocalStorage browserStorage, NavigationManager navManager)
    {
        var token = await GetToken(browserStorage);
        if(string.IsNullOrEmpty(token))
        {
            navManager.NavigateTo("/login");
        }
    }

    public static async Task<string> GetToken(ProtectedLocalStorage BrowserStorage)
    {
        var json = await BrowserStorage.GetAsync<string>("admLogado");

        if(json.Value is null) return "";

        var adm = JsonSerializer.Deserialize<Administrador>(json.Value, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return adm?.Token ?? "";
    }
}
