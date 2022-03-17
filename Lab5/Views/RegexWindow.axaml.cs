using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Lab5.ViewModels;

namespace Lab5.Views
{
    public partial class RegexWindow : Window
    {
        public RegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("OkBut").Click += async delegate
            {
                var regexText = this.FindControl<TextBox>("Text").Text;
                Close(regexText);
            };

            this.FindControl<Button>("CancelBut").Click += async delegate
            {
                Close();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
