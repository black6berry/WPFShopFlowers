using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using WPFShopFlowers.Models;

namespace WPFShopFlowers.Windows.AddNote
{
    /// <summary>
    /// Логика взаимодействия для WindowAddFlower.xaml
    /// </summary>
    public partial class WindowAddFlower : Window
    {
        public WindowAddFlower()
        {
            InitializeComponent();

        }


        private async void BtnAddFlower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = $"https://private-public.site/flowers-api/create-flower";
                HttpClient client = new HttpClient();

                var request = new Flower()
                {
                    Name = TxbName.Text,
                    Category = TxbCategory.Text,
                    Country = TxbCountry.Text,
                    FloweringSeason = TxbFloweringSeason.Text,
                    Sort = TxbSort.Text,
                    Price = TxbPrice.Text
                };

                var requeestJson = JsonConvert.SerializeObject(request);
                StringContent sc = new StringContent(requeestJson, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, sc);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show("Данные добавлены");
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка в обработке данных");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void TxbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!TxbPrice.Text.Contains(".")
               && TxbPrice.Text.Length != 0)))
            {
                e.Handled = true;
            }

        }
    }
}
