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
using System.Xml.Linq;
using WPFShopFlowers.Models;

namespace WPFShopFlowers.Windows.AddNote
{
    /// <summary>
    /// Логика взаимодействия для WindowAddSupplier.xaml
    /// </summary>
    public partial class WindowAddSupplier : Window
    {
        public WindowAddSupplier()
        {
            InitializeComponent();
        }

        private async void BtnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = "https://private-public.site/flowers-api/create-supplie";
                HttpClient client = new HttpClient();

                var request = new Supplier()
                {
                    FIO = TxbFIO.Text,
                    HouseholdType = TxbHouseholdType.Text,
                    PaymentAccount = TxbPaymentAccount.Text,

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
