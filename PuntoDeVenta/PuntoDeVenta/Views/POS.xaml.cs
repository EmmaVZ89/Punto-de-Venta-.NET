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
using Microsoft.Win32;

using iTextSharp.text;
using iTextSharp.tool.xml;
using iTextSharp.text.pdf;
using System.IO;
using Rectangle = iTextSharp.text.Rectangle;

namespace PuntoDeVenta.Views
{
    public partial class POS : UserControl
    {
        private decimal can;
        private decimal efectivo;
        private decimal cambio;
        private decimal total;
        private CN_Carrito cN_Carrito;

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
                else
                {
                    this.can = 0;
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

        #region PAGAR E IMPRIMIR
        private void CargarPago(object sender, RoutedEventArgs e)
        {
            if(this.GridProductos.Items.Count >= 1)
            {
                this.Venta();
                this.efectivo = 0;
                this.Precio();
            }
            else
            {
                MessageBox.Show("No se han agregado productos!");
            }
        }

        private void Venta()
        {
            string factura = "F-" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "-" + Properties.Settings.Default.IdUsuario;
            int idUsuario = Properties.Settings.Default.IdUsuario;
            DateTime fecha = DateTime.Now;
            this.cN_Carrito = new CN_Carrito();

            if(this.cambio >= 0)
            {
                this.cN_Carrito.Venta(factura, this.total, fecha, idUsuario);
                this.Venta_detalle(factura);
                this.GridProductos.Items.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese un pago mayor o igual a la venta!");
            }
        }

        private void Venta_detalle(string factura)
        {
            this.cN_Carrito = new CN_Carrito();
            for (int i = 0; i < this.GridProductos.Items.Count; i++)
            {
                string codigo;
                decimal totalArticulo;
                decimal cantidad;

                int j = 0;
                DataGridCell cell = this.GetCelda(i, j);
                TextBlock tb = cell.Content as TextBlock;
                codigo = tb.Text;

                int k = 3;
                DataGridCell cell2 = this.GetCelda(i, k);
                TextBlock tb2 = cell2.Content as TextBlock;
                cantidad = Decimal.Parse(tb2.Text, CultureInfo.InvariantCulture);

                int l = 4;
                DataGridCell cell3 = this.GetCelda(i, l);
                TextBlock tb3 = cell3.Content as TextBlock;
                totalArticulo = Decimal.Parse(tb3.Text, CultureInfo.InvariantCulture);

                this.cN_Carrito.Venta_Detalle(codigo, cantidad, factura, totalArticulo);
            }
            this.Imprimir(factura);
        }

        private void Imprimir(string factura)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = factura + ".pdf"
            };

            string Pagina = Properties.Resources.Ticket.ToString();
            Pagina = Pagina.Replace("@Ticket", factura);
            Pagina = Pagina.Replace("@efectivo", efectivo.ToString("###,###.00"));
            Pagina = Pagina.Replace("@cambio", cambio.ToString());
            Pagina = Pagina.Replace("@Usuario", Properties.Settings.Default.IdUsuario.ToString());
            Pagina = Pagina.Replace("@Fecha", DateTime.Now.ToString("dd/MM/yyyy"));

            string filas = string.Empty;

            for (int i = 0; i < this.GridProductos.Items.Count; i++)
            {
                string nombre;
                string cantidad;
                decimal precioUnitario;
                decimal totalArticulo;

                int j = 1;
                DataGridCell cell1 = this.GetCelda(i, j);
                TextBlock tb1 = cell1.Content as TextBlock;
                nombre = tb1.Text;

                int k = 3;
                DataGridCell cell2 = this.GetCelda(i, k);
                TextBlock tb2 = cell2.Content as TextBlock;
                cantidad = tb2.Text;

                int l = 4;
                DataGridCell cell3 = this.GetCelda(i, l);
                TextBlock tb3 = cell3.Content as TextBlock;
                totalArticulo = Decimal.Parse(tb3.Text, CultureInfo.InvariantCulture);

                int m = 2;
                DataGridCell cell4 = this.GetCelda(i, m);
                TextBlock tb4 = cell4.Content as TextBlock;
                precioUnitario = Decimal.Parse(tb4.Text, CultureInfo.InvariantCulture);

                filas += "<tr>";
                filas += "<td align=\"center\">" + cantidad.ToString() + "</td>";
                filas += "<td align=\"center\">" + nombre.ToString() + "</td>";
                filas += "<td align=\"center\">" + precioUnitario.ToString() + "</td>";
                filas += "<td align=\"center\">" + totalArticulo.ToString() + "</td>";
                filas += "</tr>";
            }
            int cant = this.GridProductos.Items.Count;
            Pagina = Pagina.Replace("@cant_articulos", cant.ToString());
            Pagina = Pagina.Replace("@grid", filas);
            Pagina = Pagina.Replace("@TOTAL", this.total.ToString());

            if (saveFile.ShowDialog() == true)
            {
                using(FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    int artFilas = this.GridProductos.Items.Count;
                    Rectangle pageSize = new Rectangle(298, 420 + (artFilas * 10));
                    Document pdfDoc = new Document(pageSize, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    using (StringReader sr = new StringReader(Pagina))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("Venta realizada con exito!");
            }
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
