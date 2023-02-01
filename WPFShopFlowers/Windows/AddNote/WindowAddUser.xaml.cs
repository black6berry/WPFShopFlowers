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
    /// Логика взаимодействия для WindowAddUser.xaml
    /// </summary>
    public partial class WindowAddUser : Window
    {
        public WindowAddUser()
        {
            InitializeComponent();

            CmbRole.Items.Add("User");
            CmbRole.Items.Add("Admin");
        }

        private async void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = $"https://private-public.site/flowers-api/create-user";
                HttpClient client = new HttpClient();

                var request = new User()
                {
                    Name = TxbName.Text,
                    Email = TxbEmail.Text,
                    Role = CmbRole.Text,
                    Login = TxbLogin.Text,
                    Password = TxbPassword.Text,
                    
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
    }
}
