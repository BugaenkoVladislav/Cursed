using System.Windows;
using Сursovaya.Context;
using Сursovaya.ReportForms;

namespace Сursovaya;

public partial class Reports : Window
{
    public Reports()
    {
        InitializeComponent();
    }

    private void ProductsBuy_OnClick(object sender, RoutedEventArgs e)
    {
        ProductBuyForm pbf = new ProductBuyForm();
        pbf.Show();
    }

    private void ProductsProvide_OnClick(object sender, RoutedEventArgs e)
    {
        ProductProvideForm ppf = new ProductProvideForm();
        ppf.Show();
    }
}