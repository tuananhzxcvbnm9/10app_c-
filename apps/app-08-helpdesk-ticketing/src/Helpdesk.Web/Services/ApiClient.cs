using System.Net.Http.Json;
using Helpdesk.Web.Models;

namespace Helpdesk.Web.Services;

public sealed class ApiClient(HttpClient httpClient)
{
    public async Task<IReadOnlyList<ListItemModel>> GetItemsAsync(CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetFromJsonAsync<List<ListItemModel>>("tickets", cancellationToken);
        return response ?? [];
    }

    public async Task<ListItemModel?> CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync($"tickets?name={Uri.EscapeDataString(name)}", null, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ListItemModel>(cancellationToken: cancellationToken);
    }
}
