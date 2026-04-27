namespace Ecommerce.Web.Services;

public sealed class ThemeState
{
    public bool IsDarkMode { get; private set; }
    public event Action? OnChange;

    public void Toggle()
    {
        IsDarkMode = !IsDarkMode;
        OnChange?.Invoke();
    }
}
