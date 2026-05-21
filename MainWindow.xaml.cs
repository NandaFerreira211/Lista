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

    private void BtnRemoveNome_OnClick(object sender, RoutedEventArgs e)
    {
        if (!nomes.Contains(tbNome.Text,StringComparer.CurrentCultureIgnoreCase))
        {
         MessageBox.Show("O nome não existe na lista!");
         return;
        }

        var nomeEcontrado = nomes.FirstOrDefault
            (nomePessoa => nomePessoa.Equals(tbNome.Text , StringComparison.CurrentCultureIgnoreCase));
        
        
        nomes.Remove(nomeEcontrado);
        
    }

    private void BtnEncontraNomes_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tbNome.Text))
        {
            MessageBox.Show("Escreva um nome válido!");
            return;
        }                                                                                                  
        lbNomes.SelectedItems.Clear();
        var termoBusca = tbNome.Text.ToLower();

        foreach (var nome in nomes)
        {
            if (nome.Contains(termoBusca,StringComparison.CurrentCultureIgnoreCase))
            {
              lbNomes.SelectedItems.Add(nome);  
            } 
        }
    }
}