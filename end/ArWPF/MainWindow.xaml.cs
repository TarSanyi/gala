using System.IO;
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

namespace ArakWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void dtgAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgAdatok.SelectedIndex > -1)
            {
                termekNeve.Content = EvVegiArakCLI.Program.arak[dtgAdatok.SelectedIndex].Megnevezés;

                pbAllapot.Value = EvVegiArakCLI.Program.arak[dtgAdatok.SelectedIndex].Valtozas();
            }
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            EvVegiArakCLI.Program.arak.RemoveAt(dtgAdatok.SelectedIndex);
            dtgAdatok.Items.Refresh();
            termekNeve.Content = "Termék";
            pbAllapot.Value = 0;
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Termekek.txt"))
                {
                    foreach (var item in EvVegiArakCLI.Program.arak)
                    {
                        sw.WriteLine($"{item.Megnevezés} ==> {(item.Valtozas() < 0 ? "" : "+")}{item.Valtozas()}");
                    }
                    MessageBox.Show("Sikeres mentés");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EvVegiArakCLI.Program.Beolvas();
            dtgAdatok.ItemsSource = EvVegiArakCLI.Program.arak;

        }
    }
}