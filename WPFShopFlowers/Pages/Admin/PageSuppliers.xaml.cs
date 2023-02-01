using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System;
using System.Windows.Controls;
using WPFShopFlowers.Models;
using WPFShopFlowers.Windows.AddNote;

namespace WPFShopFlowers.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для PageSuppliers.xaml
    /// </summary>
    public partial class PageSuppliers : Page
    {
        public PageSuppliers()
        {
            InitializeComponent();
            GetAllSuppliers();
        }

        public async void GetAllSuppliers()
        {
            try
            {
                string url = "https://private-public.site/flowers-api/suppliers";
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var _suppliers = JsonConvert.DeserializeObject<List<Supplier>>(responseContent);
                    GridSuppliersList.ItemsSource = _suppliers;
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

        private async void DeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idSupplier = ((Supplier)GridSuppliersList.SelectedItem).Id;

                string url = $"https://private-public.site/flowers-api/delete-supplier/ + {idSupplier}";
                HttpClient client = new HttpClient();

                var requeestJson = JsonConvert.SerializeObject(idSupplier);
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

        private void AddSupplier_Click(object sender, RoutedEventArgs e) => new WindowAddSupplier().Show();
    }
}
