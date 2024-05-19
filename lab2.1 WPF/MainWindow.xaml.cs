using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2._1_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }






        #region MenuItemsClicks
        private void NewClick(object sender, RoutedEventArgs e)
        {
            var exePath = Process.GetCurrentProcess()?.MainModule?.FileName;
            Process.Start(exePath, "");
        }
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void LeaveClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://zakonbiznesa.ru/blanks/zayavlenie-na-otchislenie-iz-kolledzha",
                UseShellExecute = true
            });

        }
        private void ConnectClick(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            MessageBox.Show("Для связи напишите в телеграмм: https://brush.me/sigely", menuItem?.Header.ToString(), MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void OpenHelpClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://uotula.ru/uchrezhdeniya/psihologicheskie-sluzhby-goroda/",
                UseShellExecute = true
            }); 

        }
        private void OpenAuthorClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "https://brush.me/sigely", UseShellExecute = true });
        }
        private void AboutClick(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            MessageBox.Show("Приложение разработано Серегиной А.В.", menuItem?.Header.ToString(), MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ChangeColorClick(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            var bytes = new byte[6];
            random.NextBytes(bytes);
            var brush = new LinearGradientBrush(Color.FromRgb(bytes[0], bytes[1], bytes[2]), Color.FromRgb(bytes[3], bytes[4], bytes[5]), random.NextDouble());
            MainMenu.Background = brush;
        }
        private void OpenCalcClick(object sender, RoutedEventArgs e)
        {
            Process.Start("calc.exe");
        }
        private void BeepClick(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            Console.Beep(random.Next(), random.Next());
        }
        #endregion
    }
}