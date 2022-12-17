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

namespace PuntoDeVenta.src.Boxes
{
    public partial class Ingresar : Window
    {
        public decimal Total { get; set; }
        public decimal Efectivo { get; set; }

        public Ingresar()
        {
            InitializeComponent();
            this.tbCantidad.Focus();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            bool esNumerico = decimal.TryParse(this.tbCantidad.Text, out _);

            if (esNumerico)
            {
                this.Total = decimal.Parse(this.tbCantidad.Text);
                this.Efectivo = decimal.Parse(this.tbCantidad.Text);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
