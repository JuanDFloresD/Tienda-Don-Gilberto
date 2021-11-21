using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace LOGIN
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            listaINVENTARIO.cargarDesdeArchivo();
            listaVENTAS.cargarventas();
        }
        //////////////     MOVER FORMULARIO     //////////////
        private void MenuPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panelVentas_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwmd, int wmsg, int wparam, int lparam);
        //////////////     MOVER FORMULARIO     //////////////
        
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            pnlBASE.Location = new Point(208, 3);
            pnlBASE.Size = pnlINVENTARIO.Size;
        }

        //========================  MENU  ==========================//
        private void btnMENU_Click(object sender, EventArgs e)
        {
            pnlBASE.Visible = true;
            pnlINVENTARIO.Visible = false;
            pnlVENTAS.Visible = false;
            pnlREPORTES.Visible = false;

        }
        //========================  MENU  ==========================//

        //=====================  INVENTARIO  =======================//
        
        private void btnINVENTARIO_Click(object sender, EventArgs e)
        {
            pnlBASE.Visible = false;
            pnlINVENTARIO.Visible = true;
            pnlVENTAS.Visible = false;
            pnlREPORTES.Visible = false;
            pnlINVENTARIO.Location = pnlBASE.Location;
            pnlINVENTARIO.Size = pnlBASE.Size;
            actualizarGrilla();
        }
        //=====================  INVENTARIO  =======================//

        //=====================  VENTAS  =======================//
        private void btnVENTAS_Click(object sender, EventArgs e)
        {
            pnlBASE.Visible = false;
            pnlINVENTARIO.Visible = false;
            pnlVENTAS.Visible = true;
            pnlREPORTES.Visible = false;
            pnlVENTAS.Location = pnlBASE.Location;
            pnlVENTAS.Size = pnlBASE.Size;
            actualizarDGV_Ventas();
        }
        //=====================  VENTAS  =======================//

        //=====================  REPORTES  =======================//
        private void btnREPORTES_Click(object sender, EventArgs e)
        {
            pnlBASE.Visible = false;
            pnlINVENTARIO.Visible = false;
            pnlVENTAS.Visible = false;
            pnlREPORTES.Visible = true;
            pnlREPORTES.Location = pnlBASE.Location;
            pnlREPORTES.Size = pnlBASE.Size;
            actualizarDGVBalCompras();
            actualizarDGVBalVentas();
        }
        //=====================  REPORTES  =======================//

        ///__________________________CAMPOS AUTOMATICOS_____________________________///
        private void txtproductoINVENTARIO_Enter(object sender, EventArgs e)
        {
            if (txtNomProductoINVENTARIO.Text == "NOMBRE DEL PRODUCTO")
            {
                txtNomProductoINVENTARIO.Text = "";
                txtNomProductoINVENTARIO.ForeColor = Color.LightGray;
            }
        }
        private void txtproductoINVENTARIO_Leave(object sender, EventArgs e)
        {
            if (txtNomProductoINVENTARIO.Text == "")
            {
                txtNomProductoINVENTARIO.Text = "NOMBRE DEL PRODUCTO";
                txtNomProductoINVENTARIO.ForeColor = Color.DimGray;
            }
        }
        ///_________________________________________________________________________///
        private void txtMarcaProductoINVENTARIO_Enter(object sender, EventArgs e)
        {
            if (txtMarcaProductoINVENTARIO.Text == "MARCA DEL PRODUCTO")
            {
                txtMarcaProductoINVENTARIO.Text = "";
                txtMarcaProductoINVENTARIO.ForeColor = Color.LightGray;
            }
        }
        private void txtMarcaProductoINVENTARIO_Leave(object sender, EventArgs e)
        {
            if (txtMarcaProductoINVENTARIO.Text == "")
            {
                txtMarcaProductoINVENTARIO.Text = "MARCA DEL PRODUCTO";
                txtMarcaProductoINVENTARIO.ForeColor = Color.DimGray;
            }
        }
        ///_________________________________________________________________________///
        private void txtTipoProductoINVENTARIO_Enter(object sender, EventArgs e)
        {
            if (txtTipoProductoINVENTARIO.Text == "TIPO DEL PRODUCTO")
            {
                txtTipoProductoINVENTARIO.Text = "";
                txtTipoProductoINVENTARIO.ForeColor = Color.LightGray;
            }
        }
        private void txtTipoProductoINVENTARIO_Leave(object sender, EventArgs e)
        {
            if (txtTipoProductoINVENTARIO.Text == "")
            {
                txtTipoProductoINVENTARIO.Text = "TIPO DEL PRODUCTO";
                txtTipoProductoINVENTARIO.ForeColor = Color.DimGray;
            }
        }
        ///_________________________________________________________________________///
        private void txtPrecioCompraINVENTARIO_Enter(object sender, EventArgs e)
        {
            if (txtPrecioCompraINVENTARIO.Text == "PRECIO DE COMPRA")
            {
                txtPrecioCompraINVENTARIO.Text = "";
                txtPrecioCompraINVENTARIO.ForeColor = Color.LightGray;
            }
        }
        private void txtPrecioCompraINVENTARIO_Leave(object sender, EventArgs e)
        {
            if (txtPrecioCompraINVENTARIO.Text == "")
            {
                txtPrecioCompraINVENTARIO.Text = "PRECIO DE COMPRA";
                txtPrecioCompraINVENTARIO.ForeColor = Color.DimGray;
            }
        }
        ///_________________________________________________________________________///
        private void txtPrecioVentaINVENTARIO_Enter(object sender, EventArgs e)
        {
            if (txtPrecioVentaINVENTARIO.Text == "PRECIO DE VENTA")
            {
                txtPrecioVentaINVENTARIO.Text = "";
                txtPrecioVentaINVENTARIO.ForeColor = Color.LightGray;
            }
        }
        private void txtPrecioVentaINVENTARIO_Leave(object sender, EventArgs e)
        {
            if (txtPrecioVentaINVENTARIO.Text == "")
            {
                txtPrecioVentaINVENTARIO.Text = "PRECIO DE VENTA";
                txtPrecioVentaINVENTARIO.ForeColor = Color.DimGray;
            }
        }
        ///_________________________________________________________________________///
        private void txtCantidadINVENTARIO_Enter(object sender, EventArgs e)
        {
            if (txtCantidadCompraINVENTARIO.Text == "CANTIDAD DE COMPRA")
            {
                txtCantidadCompraINVENTARIO.Text = "";
                txtCantidadCompraINVENTARIO.ForeColor = Color.LightGray;
            }
        }
        private void txtCantidadINVENTARIO_Leave(object sender, EventArgs e)
        {
            if (txtCantidadCompraINVENTARIO.Text == "")
            {
                txtCantidadCompraINVENTARIO.Text = "CANTIDAD DE COMPRA";
                txtCantidadCompraINVENTARIO.ForeColor = Color.DimGray;
            }
        }
        ///_________________________________________________________________________///
        private void txtNomProductoVENTAS_Enter(object sender, EventArgs e)
        {
            if (txtNomProductoVENTAS.Text == "NOMBRE DEL PRODUCTO")
            {
                txtNomProductoVENTAS.Text = "";
                txtNomProductoVENTAS.ForeColor = Color.LightGray;
            }
        }
        private void txtNomProductoVENTAS_Leave(object sender, EventArgs e)
        {
            if (txtNomProductoVENTAS.Text == "")
            {
                txtNomProductoVENTAS.Text = "NOMBRE DEL PRODUCTO";
                txtNomProductoVENTAS.ForeColor = Color.DimGray;
            }
        }
        ///_________________________________________________________________________///
        private void txtMarcaProductoVENTAS_Enter(object sender, EventArgs e)
        {
            if (txtMarcaProductoVENTAS.Text == "MARCA DEL PRODUCTO")
            {
                txtMarcaProductoVENTAS.Text = "";
                txtMarcaProductoVENTAS.ForeColor = Color.LightGray;
            }
        }
        private void txtMarcaProductoVENTAS_Leave(object sender, EventArgs e)
        {
            if (txtMarcaProductoVENTAS.Text == "")
            {
                txtMarcaProductoVENTAS.Text = "MARCA DEL PRODUCTO";
                txtMarcaProductoVENTAS.ForeColor = Color.DimGray;
            }
        }
        ///_________________________________________________________________________///
        private void txtTipoProductoVENTAS_Enter(object sender, EventArgs e)
        {
            if (txtTipoProductoVENTAS.Text == "TIPO DEL PRODUCTO")
            {
                txtTipoProductoVENTAS.Text = "";
                txtTipoProductoVENTAS.ForeColor = Color.LightGray;
            }
        }
        private void txtTipoProductoVENTAS_Leave(object sender, EventArgs e)
        {
            if (txtTipoProductoVENTAS.Text == "")
            {
                txtTipoProductoVENTAS.Text = "TIPO DEL PRODUCTO";
                txtTipoProductoVENTAS.ForeColor = Color.DimGray;
            }
        }
        ///_________________________________________________________________________///
        private void txtPrecioCompraVENTAS_Enter(object sender, EventArgs e)
        {
            if (txtPrecioCompraVENTAS.Text == "PRECIO DE COMPRA")
            {
                txtPrecioCompraVENTAS.Text = "";
                txtPrecioCompraVENTAS.ForeColor = Color.LightGray;
            }
        }
        private void txtPrecioCompraVENTAS_Leave(object sender, EventArgs e)
        {
            if (txtPrecioCompraVENTAS.Text == "")
            {
                txtPrecioCompraVENTAS.Text = "PRECIO DE COMPRA";
                txtPrecioCompraVENTAS.ForeColor = Color.DimGray;
            }
        }
        ///_________________________________________________________________________///
        private void txtPrecioVentasVENTAS_Enter(object sender, EventArgs e)
        {
            if (txtPrecioVentasVENTAS.Text == "PRECIO DE VENTA")
            {
                txtPrecioVentasVENTAS.Text = "";
                txtPrecioVentasVENTAS.ForeColor = Color.LightGray;
            }
        }
        private void txtPrecioVentasVENTAS_Leave(object sender, EventArgs e)
        {
            if (txtPrecioVentasVENTAS.Text == "")
            {
                txtPrecioVentasVENTAS.Text = "PRECIO DE VENTA";
                txtPrecioVentasVENTAS.ForeColor = Color.DimGray;
            }
        }
        ///_________________________________________________________________________///
        private void txtCantidadVentaVENTAS_Enter(object sender, EventArgs e)
        {
            if (txtCantidadVentaVENTAS.Text == "CANTIDAD DE COMPRA")
            {
                txtCantidadVentaVENTAS.Text = "";
                txtCantidadVentaVENTAS.ForeColor = Color.LightGray;
            }
        }
        private void txtCantidadVentaVENTAS_Leave(object sender, EventArgs e)
        {
            if (txtCantidadVentaVENTAS.Text == "")
            {
                txtCantidadVentaVENTAS.Text = "CANTIDAD DE COMPRA";
                txtCantidadVentaVENTAS.ForeColor = Color.DimGray;
            }
        }   
        ///__________________________CAMPOS AUTOMATICOS_____________________________///

        //=====================   SALUDO   =====================//
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblHORA.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFECHA.Text = DateTime.Now.ToLongDateString();
            definirSaludo();
        }
        private void definirSaludo()
        {
            int aux = int.Parse(DateTime.Now.ToString("HH"));

            if (aux >= 12 && aux <= 17)
            {
                lblSaludo.Text = "¡Buenas tardes! ¿Qué deseas hacer hoy?";
            }
            if (aux >= 18 && aux <= 23)
            {
                lblSaludo.Text = "¡Buenas noches! ¿Qué deseas hacer hoy?";
            }
            if (aux >= 00 && aux <= 05)
            {
                lblSaludo.Text = "¡Buenas noches! ¿Qué deseas hacer hoy?";
            }
            if (aux >= 06 && aux <= 11)
            {
                lblSaludo.Text = "¡Buenos días! ¿Qué deseas hacer hoy?";
            }
        }
        //=====================   SALUDO   =====================//

        ///_____________________FUNCION CERRAR Y MINIMIZAR__________________________///
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        ///_____________________FUNCION CERRAR Y MINIMIZAR__________________________///

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }
        //========================= INVENTARIO ============================//
        ListaProductos listaINVENTARIO = new ListaProductos();
        private void BtnGuardarProductos_Click(object sender, EventArgs e)
        {
            string nombre = txtNomProductoINVENTARIO.Text;
            string marca = txtMarcaProductoINVENTARIO.Text;
            string tipo = txtTipoProductoINVENTARIO.Text;
            string compra = txtPrecioCompraINVENTARIO.Text;
            string venta = txtPrecioVentaINVENTARIO.Text;
            string cantidad = txtCantidadCompraINVENTARIO.Text;

            Producto prod = new Producto();
            prod.nombre = nombre;
            prod.marca = marca;
            prod.tipo = tipo;
            prod.compra = compra;
            prod.venta = venta;
            prod.cantidad = cantidad;

            if (nombre != "NOMBRE DEL PRODUCTO")
            {
                if (marca != "MARCA DEL PRODUCTO")
                {
                    if (tipo != "TIPO DEL PRODUCTO")
                    {
                        if (compra != "PRECIO DE COMPRA")
                        {
                            if (venta != "PRECIO DE VENTA")
                            {
                                if (cantidad != "CANTIDAD DE PRODUCTO")
                                {
                                    listaINVENTARIO.agregarproducto(prod);
                                }
                                else MessageBox.Show("Por favor complete los datos correctamente");
                            }
                            else MessageBox.Show("Por favor complete los datos correctamente");
                        }
                        else MessageBox.Show("Por favor complete los datos correctamente");
                    }
                    else MessageBox.Show("Por favor ingrese el tipo del producto");
                }
                else MessageBox.Show("Por favor ingrese la marca del producto");
            }
            else MessageBox.Show("Por favor ingrese un producto");
        }
        private void actualizarGrilla()
        {
            List<Producto> listaAux = listaINVENTARIO.getLista();
            dgvINVENTARIO.Rows.Clear();
            foreach (Producto prod in listaAux)
            {
                int filanueva = dgvINVENTARIO.Rows.Add();
                dgvINVENTARIO.Rows[filanueva].Cells[0].Value = prod.nombre;
                dgvINVENTARIO.Rows[filanueva].Cells[1].Value = prod.marca;
                dgvINVENTARIO.Rows[filanueva].Cells[2].Value = prod.tipo;
                dgvINVENTARIO.Rows[filanueva].Cells[3].Value = prod.compra;
                dgvINVENTARIO.Rows[filanueva].Cells[4].Value = prod.venta;
                dgvINVENTARIO.Rows[filanueva].Cells[5].Value = prod.cantidad;
            }
        }
        private void BtnListar_Click(object sender, EventArgs e)
        {
           actualizarGrilla();
           listaINVENTARIO.guardarEnArchivo();
        }

        ListaVentas listaVENTAS = new ListaVentas();
        private void btnAGREGAR_VENTAS_Click(object sender, EventArgs e)
        {
            string nombreVEN = txtNomProductoVENTAS.Text;
            string marcaVEN = txtMarcaProductoVENTAS.Text;
            string tipoVEN = txtTipoProductoVENTAS.Text;
            string compraVEN = txtPrecioCompraVENTAS.Text;
            string ventaVEN = txtPrecioVentasVENTAS.Text;
            string cantidadVEN = txtCantidadVentaVENTAS.Text;

            Venta prod_vendido = new Venta();
            prod_vendido.nombre_venta = nombreVEN;
            prod_vendido.marca_venta = marcaVEN;
            prod_vendido.tipo_venta = tipoVEN;
            prod_vendido.compra_venta = compraVEN;
            prod_vendido.venta_venta = ventaVEN;
            prod_vendido.cantidad_venta = cantidadVEN;

            if (nombreVEN != "NOMBRE DEL PRODUCTO")
            {
                if (marcaVEN != "MARCA DEL PRODUCTO")
                {
                    if (tipoVEN != "TIPO DEL PRODUCTO")
                    {
                        if (compraVEN != "PRECIO DE COMPRA")
                        {
                            if (ventaVEN != "PRECIO DE VENTA")
                            {
                                if (cantidadVEN != "CANTIDAD DE PRODUCTO")
                                {
                                    listaVENTAS.agregarventa(prod_vendido);
                                }
                                else MessageBox.Show("Por favor complete los datos correctamente");
                            }
                            else MessageBox.Show("Por favor complete los datos correctamente");
                        }
                        else MessageBox.Show("Por favor complete los datos correctamente");
                    }
                    else MessageBox.Show("Por favor ingrese el tipo del producto");
                }
                else MessageBox.Show("Por favor ingrese la marca del producto");
            }
            else MessageBox.Show("Por favor ingrese un producto");
        }

        private void btnLISTAR_VENTAS_Click(object sender, EventArgs e)
        {
            actualizarDGV_Ventas();
            listaVENTAS.guardarventas();
        }
        private void actualizarDGV_Ventas()
        {
            List<Venta> listaAux2 = listaVENTAS.getLista();
            dgvVENTAS.Rows.Clear();
            foreach (Venta prod_vendido in listaAux2)
            {
                int filanueva2 = dgvVENTAS.Rows.Add();
                dgvVENTAS.Rows[filanueva2].Cells[0].Value = prod_vendido.nombre_venta;
                dgvVENTAS.Rows[filanueva2].Cells[1].Value = prod_vendido.marca_venta;
                dgvVENTAS.Rows[filanueva2].Cells[2].Value = prod_vendido.tipo_venta;
                dgvVENTAS.Rows[filanueva2].Cells[3].Value = prod_vendido.compra_venta;
                dgvVENTAS.Rows[filanueva2].Cells[4].Value = prod_vendido.venta_venta;
                dgvVENTAS.Rows[filanueva2].Cells[5].Value = prod_vendido.cantidad_venta;
            }
        }
        private void actualizarDGVBalCompras()
        {
            List<Venta> listaAux3 = listaVENTAS.getLista();
            dgvReporteCOMPRAS.Rows.Clear();
            foreach (Venta prod_vendido in listaAux3)
            {
                int filanueva3 = dgvReporteCOMPRAS.Rows.Add();
                dgvReporteCOMPRAS.Rows[filanueva3].Cells[0].Value = prod_vendido.nombre_venta;
                dgvReporteCOMPRAS.Rows[filanueva3].Cells[1].Value = prod_vendido.marca_venta;
                dgvReporteCOMPRAS.Rows[filanueva3].Cells[2].Value = prod_vendido.tipo_venta;
                dgvReporteCOMPRAS.Rows[filanueva3].Cells[3].Value = prod_vendido.compra_venta;
                dgvReporteCOMPRAS.Rows[filanueva3].Cells[4].Value = prod_vendido.cantidad_venta;
            }
        }
        private void actualizarDGVBalVentas()
        {
            List<Venta> listaAux4 = listaVENTAS.getLista();
            dgvReporteVENTAS.Rows.Clear();
            foreach (Venta prod_vendido in listaAux4)
            {
                int filanueva4 = dgvReporteVENTAS.Rows.Add();
                dgvReporteVENTAS.Rows[filanueva4].Cells[0].Value = prod_vendido.nombre_venta;
                dgvReporteVENTAS.Rows[filanueva4].Cells[1].Value = prod_vendido.marca_venta;
                dgvReporteVENTAS.Rows[filanueva4].Cells[2].Value = prod_vendido.tipo_venta;
                dgvReporteVENTAS.Rows[filanueva4].Cells[3].Value = prod_vendido.venta_venta;
                dgvReporteVENTAS.Rows[filanueva4].Cells[4].Value = prod_vendido.cantidad_venta;
            }
        }
        
    }
}
