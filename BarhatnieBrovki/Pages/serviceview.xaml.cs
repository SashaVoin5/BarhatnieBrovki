using BarhatnieBrovki.Model;
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
using System.Windows.Shapes;

namespace BarhatnieBrovki.Pages
{
    /// <summary>
    /// Логика взаимодействия для serviceview.xaml
    /// </summary>
    public partial class serviceview : Window
    {
        
        public serviceview(Client client)
        {
            InitializeComponent();
            try
            {
                DataView.ItemsSource = BarhatnieBrovkiEntities.GetContext().ClientService.Where(Client => Client.ClientID == client.ID).ToList();
                if (client.PhotoPath != null)
                {
                    string imagePath = "C:\\Users\\sasha\\source\\repos\\Rul2\\Rul2\\Resources\\" + client.PhotoPath.Trim();
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(imagePath);
                    bitmapImage.DecodePixelWidth = 100; // Установите желаемую ширину миниатюры (в пикселях)
                    bitmapImage.EndInit();

                    // Установите BitmapImage в элемент Image на вашей форме (назовем его MyImage)
                    AgentImage.Source = bitmapImage;
                }
                FirstName.Text = "Имя " + client.FirstName;
                LastName.Text = "Фамилия " + client.LastName;
                if (client.Patronymic != null)
                {
                    MiddleName.Text = "Отчество " + client.Patronymic;
                }
                else
                {
                    MiddleName.Text = "Отчество отсутствует";
                }
                
                CountVisit.Text = "Кол-во посещений " + BarhatnieBrovkiEntities.GetContext().ClientService.Where(Client => Client.ClientID == client.ID).Count().ToString();
            }
            catch
            {

            }
            
           
        }

        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить эту услугу!", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var SelectedService = DataView.SelectedItem as ClientService;
                BarhatnieBrovkiEntities.GetContext().ClientService.Remove(SelectedService);
                BarhatnieBrovkiEntities.GetContext().SaveChanges();
            }
            else
            {
                MessageBox.Show("Выделите услугу и нажмите на кнопку!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditService_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
