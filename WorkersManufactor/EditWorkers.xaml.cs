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

namespace WorkersManufactor
{
    /// <summary>
    /// Логика взаимодействия для EditWorkers.xaml
    /// </summary>
    public partial class EditWorkers : Window
    {
        private IEnumerable<ProductType> productTypes;

        public Product CurrentProduct { get; set; }

        public IEnumerable<ProductType> GetProductTypes()
        {
            return productTypes;
        }

        public void SetProductTypes(IEnumerable<ProductType> value)
        {
            productTypes = value;
        }

        public EditWorkers(Product products)
        {
            InitializeComponent();
            DataContext = this;
            CurrentProduct = products;
            SetProductTypes(Core.DB.ProductType.ToArray());
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentProduct.ID == 0)
                    Core.DB.Product.Add(CurrentProduct);
                Core.DB.SaveChanges();
                DialogResult = true;
                MessageBox.Show($"Успешно сохранено");
            }
            catch
            {
                MessageBox.Show($"Возникла ошибка" +
                    $"ERROR");
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
