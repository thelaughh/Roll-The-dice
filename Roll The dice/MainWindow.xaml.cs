using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RestSharp;

namespace Roll_The_dice
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            int inpt = Convert.ToInt32(input.Text);
            var stisknutyRadiobutton = sender as RadioButton;

            string tagZvoleného = stisknutyRadiobutton.Tag.ToString();
            string urlApi = $"http://numbersapi.com/{inpt}/{tagZvoleného}";

            RestClient client = new RestClient(urlApi);
            RestRequest apiRequest = new RestRequest();
            var apiResponse = client.Get(apiRequest);
            string responseText = apiResponse.Content.ToString();
            MessageBox.Show(responseText);

            
        }
    }
}
