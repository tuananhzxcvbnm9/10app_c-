namespace Helpdesk.Web.Models;

public sealed class ListItemModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }
}
