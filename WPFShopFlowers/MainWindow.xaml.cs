using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows;
using WPFShopFlowers.Action;
using WPFShopFlowers.Models;
using WPFShopFlowers.Pages.Admin;

namespace WPFShopFlowers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FrmNav.Navigation = FrmMain;
        }


        private async void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = $"https://private-public.site/flowers-api/sign-in?Login={TxbLogin.Text}&Password={PsbPassword.Password}";
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var _signIn = JsonConvert.DeserializeObject<SignIn>(responseContent);

                    switch (_signIn.RoleUser)
                    {
                        case "Admin":
                            MessageBox.Show(_signIn.RoleUser.ToString());
                            FrmMain.Navigate(new PageAdmin());
                            break;
                        case "User":
                            MessageBox.Show("Авторизация выполнена успешно");
                            break;
                        default:
                            MessageBox.Show("Данные введены некорректно");
                            break;


                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
