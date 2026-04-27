using MudBlazor;

namespace Blog.Web.Services;

public sealed class ToastService(ISnackbar snackbar)
{
    public void Success(string message) => snackbar.Add(message, Severity.Success);
    public void Error(string message) => snackbar.Add(message, Severity.Error);
    public void Info(string message) => snackbar.Add(message, Severity.Info);
}
