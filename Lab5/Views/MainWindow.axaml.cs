using Avalonia.Controls;
using Lab5.ViewModels;
using Avalonia.Interactivity;

namespace Lab5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("OpenBut").Click += async delegate
            {
                var filePath = new OpenFileDialog()
                {
                    Title = "Open file"
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await filePath;

                var context = this.DataContext as MainWindowViewModel;
                if (path != null)
                {
                    context.OpenFile(string.Join(@"\", path));
                }  
            };

            this.FindControl<Button>("SaveBut").Click += async delegate
            {
                var filePath = new SaveFileDialog()
                {
                    Title = "Save file"
                }.ShowAsync((Window)this.VisualRoot);

                string? path = await filePath;

                var context = this.DataContext as MainWindowViewModel;
                if (path != null)
                {
                    context.SaveFile(path);
                }
            };
        }
        
        private async void RegexOpen(object sender, RoutedEventArgs e)
        {
            var newWindow = new RegexWindow();
            var context = this.DataContext as MainWindowViewModel;

            newWindow.FindControl<TextBox>("Text").Text = (this.DataContext as MainWindowViewModel).Regex;
            string? regexAnswer = await newWindow.ShowDialog<string?>((Window)this.VisualRoot);

            if(regexAnswer != null)
            {
                context.Regex = regexAnswer;
            }
        }
    }
}
