using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;

namespace Lista;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<string> nomes { get; set; } = new();
        
    public MainWindow()
    {
        InitializeComponent();
        
        this.DataContext = this;
    }

    private void BtnAdicionaNome_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tbNome.Text))
        {
            MessageBox.Show("Escreva um nome válido!");
            return;
        }
        nomes.Add(tbNome.Text);
    }
}