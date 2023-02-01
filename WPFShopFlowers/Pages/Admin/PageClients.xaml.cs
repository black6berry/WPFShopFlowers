using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPFShopFlowers.Models;
using WPFShopFlowers.Windows.AddNote;

namespace WPFShopFlowers.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для PageClients.xaml
    /// </summary>
    public partial class PageClients : Page
    {
        public PageClients()
        {
            InitializeComponent();
            GetAllClients();
        }

        public async void GetAllClients()
        {
            try
            {
                string url = "https://private-public.site/flowers-api/users";
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var _clients = JsonConvert.DeserializeObject<List<User>>(responseContent);
                    GridClientsList.ItemsSource = _clients;
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

        private async void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idUser = ((User)GridClientsList.SelectedItem).Id;

                string url = $"https://private-public.site/flowers-api/delete-user/ + {idUser}";
                HttpClient client = new HttpClient();

                var requeestJson = JsonConvert.SerializeObject(idUser);
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

        private void AddClient_Click(object sender, RoutedEventArgs e) =>  new WindowAddUser().Show();
    }
}
