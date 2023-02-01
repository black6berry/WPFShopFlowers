using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFShopFlowers.Action;
using WPFShopFlowers.Models;
using WPFShopFlowers.Windows.AddNote;

namespace WPFShopFlowers.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
            GetAllFlowers();

            FrmNav.Navigation = FrmAdmin;
        }

        public async void GetAllFlowers()
        {
            try
            {
                string url = "https://private-public.site/flowers-api/flowers";
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var _flowers = JsonConvert.DeserializeObject<List<Flower>>(responseContent);
                    GridFlowerList.ItemsSource = _flowers;
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
        private void AddFlower_Click(object sender, RoutedEventArgs e) => new WindowAddFlower().Show();

        private async void DeleteFlower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idFlower = ((Flower)GridFlowerList.SelectedItem).Id;

                string url = $"https://private-public.site/flowers-api/delete-flower/ + {idFlower}";
                HttpClient client = new HttpClient();

                var requeestJson = JsonConvert.SerializeObject(idFlower);
                StringContent sc = new StringContent(requeestJson);

                var response = await client.PostAsync(url, sc);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Данные успешно удалены");
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


        private void TxbSearch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TxbSearch.Clear();
        }

        private void TxbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            FrmAdmin.Navigate(new PageOrders());
        }

        private void Flowers_Click(object sender, RoutedEventArgs e)
        {
            FrmAdmin.Navigate(new PageAdmin());
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            FrmAdmin.Navigate(new PageClients());
        }

        private void ProductSupplier_Click(object sender, RoutedEventArgs e)
        {
            FrmAdmin.Navigate(new PageSuppliers());
        }

        private void FrmAdmin_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
