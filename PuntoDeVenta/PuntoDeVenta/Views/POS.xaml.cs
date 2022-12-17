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
using System.Windows.Controls.Primitives;
using PuntoDeVenta.src.Boxes;
using System.Globalization;

namespace PuntoDeVenta.Views
{
    public partial class POS : UserControl
    {
        private decimal can;
        private decimal efectivo;
        private decimal cambio;
        private decimal total;

        #region INICIO
        public POS()
        {
            InitializeComponent();
            this.Precio();
        }
        #endregion

        #region BUSCAR
        private void BuscarProducto(object sender, RoutedEventArgs e)
        {
            if(this.tbBuscar.Text == string.Empty)
            {
                MessageBox.Show("Busqueda vacia!");
            }
            else
            {
                CN_Carrito cc = new CN_Carrito();
                var carrito = cc.Buscar(this.tbBuscar.Text);

                if(carrito.Nombre != null)
                {
                    this.tbNombre.Text = carrito.Nombre.ToString();
                    this.tbPrecio.Text = carrito.Precio.ToString();
                    this.tbCantidad.Focus();
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el producto!");
                    this.tbBuscar.Text = "";
                }
            }
        }
        #endregion

        #region ELIMINAR PRODUCTO
        private void EliminarProducto(object sender, RoutedEventArgs e)
        {
            var seleccionado = this.GridProductos.SelectedItem;
            if(seleccionado != null)
            {
                this.GridProductos.Items.Remove(seleccionado);
                if(this.GridProductos.Items.Count < 1)
                {
                    this.efectivo = 0;
                }
            }
            this.Precio();
        }
        #endregion

        #region LIMPIAR CAMPOS
        private void Limpiar()
        {
            this.tbBuscar.Text = "";
            this.tbNombre.Text = "";
            this.tbCantidad.Text = "";
            this.tbPrecio.Text = "";
            this.Precio();
        }
        #endregion

        #region AGREGAR
        private void AgregarProducto(object sender, RoutedEventArgs e)
        {
            if(this.tbNombre.Text == string.Empty || this.tbCantidad.Text == string.Empty)
            {
                MessageBox.Show("No se ha seleccionado un producto!");
            }
            else
            {
                string producto = this.tbNombre.Text;
                decimal cantidad = decimal.Parse(this.tbCantidad.Text);
                this.Agregar(producto, cantidad);
                this.Limpiar();
            }
        }

        public ref decimal Existe(string valor)
        {
            for (int i = 0; i < this.GridProductos.Items.Count; i++)
            {
                int j = 1;
                DataGridCell celda = this.GetCelda(i, j);
                TextBlock tb = celda.Content as TextBlock;

                int k = 3;
                DataGridCell celda2 = this.GetCelda(i, k);
                TextBlock tb2 = celda2.Content as TextBlock;
                this.can = decimal.Parse(tb2.Text);

                if(tb.Text == valor)
                {
                    this.GridProductos.Items.RemoveAt(i);
                    return ref this.can;
                }
            }
            return ref this.can;
        }

        private void Agregar(string producto, decimal cantidad)
        {
            CN_Carrito carrito = new CN_Carrito();
            DataTable dTable;
            if (this.GridProductos.HasItems)
            {
                cantidad += this.Existe(producto);
                dTable = carrito.Agregar(producto, cantidad);
                this.GridProductos.Items.Add(dTable);
            }
            else
            {
                dTable = carrito.Agregar(producto, cantidad);
                this.GridProductos.Items.Add(dTable);
            }
            this.Precio();
        }
        #endregion

        #region PRECIO
        private void Precio()
        {
            this.total = 0;
            for (int i = 0; i < this.GridProductos.Items.Count; i++)
            {
                decimal precio;
                int j = 4;
                DataGridCell celda = this.GetCelda(i, j);
                TextBlock tb = celda.Content as TextBlock;
                precio = Decimal.Parse(tb.Text, CultureInfo.InvariantCulture);
                this.total += precio;
            }
            this.cambio = this.efectivo - total;

            this.lblCambio.Content = "Cambio: $" + cambio.ToString();
            this.lblEfectivo.Content = "Efectivo: $" + this.efectivo.ToString("###,###.00");
            this.lblTotal.Content = "Total: $" + this.total.ToString();
        }
        #endregion

        #region CAMBIAR CANTIDAD
        private void CambiarCantidad(object sender, RoutedEventArgs e)
        {
            var seleccionado = this.GridProductos.SelectedItem;
            if(seleccionado != null)
            {
                var celda = this.GridProductos.SelectedCells[0];
                var codigo = (celda.Column.GetCellContent(celda.Item) as TextBlock).Text;

                var ingresar = new Ingresar();
                ingresar.ShowDialog();

                if(ingresar.Total > 0)
                {
                    this.GridProductos.Items.Remove(seleccionado);
                    this.Agregar(codigo, ingresar.Total);
                    this.Precio();
                }
            }
        }
        #endregion

        #region RECIBIR EFECTIVO
        private void RecibirEfectivo(object sender, RoutedEventArgs e)
        {
            var ingresar = new Ingresar();
            ingresar.ShowDialog();

            if(ingresar.Efectivo > 0)
            {
                this.efectivo = ingresar.Efectivo;
                this.Precio();
            } 
            else
            {
                MessageBox.Show("Debes ingresar un numero mayor a 0");
            }
        }
        #endregion

        #region ANULAR ORDEN
        private void AnularOrden(object sender, RoutedEventArgs e)
        {
            this.efectivo = 0;
            this.GridProductos.Items.Clear();
            this.Limpiar();
        }
        #endregion

        #region CARGAR PAGO
        private void CargarPago(object sender, RoutedEventArgs e)
        {

        }
        #endregion


        #region FILAS, COLUMNAS Y CELDAS

        public static T GetVisualChild<T>(Visual padre) where T : Visual
        {
            T hijo = default;
            int num = VisualTreeHelper.GetChildrenCount(padre);
            for (int i = 0; i < num; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(padre, i);
                hijo = v as T;
                if(hijo == null)
                {
                    hijo = GetVisualChild<T>(v);
                }

                if(hijo != null)
                {
                    break;
                }
            }

            return hijo;
        }

        public DataGridRow GetFila(int index)
        {
            DataGridRow fila = (DataGridRow)this.GridProductos.ItemContainerGenerator.ContainerFromIndex(index);
            if(fila == null)
            {
                this.GridProductos.UpdateLayout();
                this.GridProductos.ScrollIntoView(this.GridProductos.Items[index]);
                fila = (DataGridRow)this.GridProductos.ItemContainerGenerator.ContainerFromIndex(index);
            }

            return fila;
        }

        public DataGridCell GetCelda(int fila, int columna)
        {
            DataGridRow filaCon = GetFila(fila);
            if(filaCon != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(filaCon);
                DataGridCell celda = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columna);

                if(celda == null)
                {
                    this.GridProductos.ScrollIntoView(filaCon, this.GridProductos.Columns[columna]);
                    celda = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columna);
                }
                return celda;
            }
            return null;
        }

        #endregion
    }
}
