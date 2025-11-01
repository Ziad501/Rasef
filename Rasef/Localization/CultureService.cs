using System.Globalization;

namespace Rasef.Localization
{
    public class CultureService
    {
        private CultureInfo _current;

        public CultureInfo Current
        {
            get => _current;
            private set
            {
                _current = value;
                // Update all thread cultures
                CultureInfo.DefaultThreadCurrentCulture = value;
                CultureInfo.DefaultThreadCurrentUICulture = value;
                CultureInfo.CurrentCulture = value;
                CultureInfo.CurrentUICulture = value;
                Thread.CurrentThread.CurrentCulture = value;
                Thread.CurrentThread.CurrentUICulture = value;
            }
        }

        public bool IsArabic => Current.TwoLetterISOLanguageName == "ar";

        public event Action? OnChange;

        public CultureService()
        {
            // Initialize with Arabic as default
            _current = new CultureInfo("ar");
            Current = _current;
        }

        public void Set(string culture)
        {
            var ci = new CultureInfo(culture);
            Current = ci;
            OnChange?.Invoke();
        }

        public void Toggle()
        {
            Set(IsArabic ? "en" : "ar");
        }
    }
}
