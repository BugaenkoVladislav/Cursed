using System.Windows;

namespace Сursovaya;

public partial class Menu : Window
{
    public Menu()
    {
        InitializeComponent();
    }

    private void Results_OnClick(object sender, RoutedEventArgs e)
    {
        Reports reports = new Reports();
        reports.Show();
    }

    private void WatchNChange_OnClick(object sender, RoutedEventArgs e)
    {
        Tables tables = new Tables();
        tables.Show();
    }
}