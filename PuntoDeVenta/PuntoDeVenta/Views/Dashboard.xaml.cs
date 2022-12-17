using LiveCharts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_Negocio;
using System.Data;
using PuntoDeVenta.src.Boxes;

namespace PuntoDeVenta.Views
{
    public partial class Dashboard : UserControl
    {
        public ChartValues<decimal> Values { get; set; }
        Error error;

        public Dashboard()
        {
            InitializeComponent();

            try
            {
                CN_Dashboard dash = new CN_Dashboard();
                this.lblTotales.Content = dash.CantidadVentas().ToString();
                this.lblArtDisponibles.Content = dash.Articulos().ToString();

                this.Values = new ChartValues<decimal>();

                foreach (DataRow row in dash.Grafico().Rows)
                {
                    decimal i = decimal.Parse(row["Monto_Total"].ToString());
                    this.Values.Add(i);
                }

                this.DataContext = this;
            }
            catch (Exception ex)
            {
                this.error = new Error();
                this.error.lblError.Text = ex.Message;
                this.error.ShowDialog();
            }
        }
    }
}
