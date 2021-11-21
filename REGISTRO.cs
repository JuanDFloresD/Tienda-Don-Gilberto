using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace LOGIN
{
    public partial class REGISTRO : Form
    {
        ListaUsuarios lista = new ListaUsuarios();
        public REGISTRO()
        {
            InitializeComponent();
            lista.cargarDesdeArchivo();
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwmd, int wmsg, int wparam, int lparam);
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void REGISTRO_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtnewuser_Enter(object sender, EventArgs e)
        {
            if (txtnewuser.Text == "USUARIO")
            {
                txtnewuser.Text = "";
                txtnewuser.ForeColor = Color.LightGray;
            }
        }

        private void txtnewuser_Leave(object sender, EventArgs e)
        {
            if (txtnewuser.Text == "")
            {
                txtnewuser.Text = "USUARIO";
                txtnewuser.ForeColor = Color.DimGray;
            }
        }

        private void txtnewpass_Enter(object sender, EventArgs e)
        {
            if (txtnewpass.Text == "CONTRASEÑA")
            {
                txtnewpass.Text = "";
                txtnewpass.ForeColor = Color.LightGray;
                txtnewpass.UseSystemPasswordChar = true;
            }
        }

        private void txtnewpass_Leave(object sender, EventArgs e)
        {
            if (txtnewpass.Text == "")
            {
                txtnewpass.Text = "CONTRASEÑA";
                txtnewpass.ForeColor = Color.DimGray;
                txtnewpass.UseSystemPasswordChar = false;
            }
        }

        private void txtconfirmarpass_Enter(object sender, EventArgs e)
        {
            if (txtconfirmarpass.Text == "CONFIRMAR CONTRASEÑA")
            {
                txtconfirmarpass.Text = "";
                txtconfirmarpass.ForeColor = Color.LightGray;
                txtconfirmarpass.UseSystemPasswordChar = true;
            }
        }

        private void txtconfirmarpass_Leave(object sender, EventArgs e)
        {
            if (txtconfirmarpass.Text == "")
            {
                txtconfirmarpass.Text = "CONFIRMAR CONTRASEÑA";
                txtconfirmarpass.ForeColor = Color.DimGray;
                txtconfirmarpass.UseSystemPasswordChar = false;
            }
        }       
        private void msgError(string msg)
        {
            lblErrorMessage.Text = msg;
            lblErrorMessage.Visible = true;
        }
        private void btnregistrarse_Click(object sender, EventArgs e)
        {
            string newuser = txtnewuser.Text;
            string newpass = txtnewpass.Text;
            string confirmar = txtconfirmarpass.Text;

            Usuario user = new Usuario();
            user.usuario = newuser;
            user.contraseña = newpass;
            if (newuser != "USUARIO")
            {
                if (newpass != "CONTRASEÑA")
                {
                    if (confirmar != "CONFIRMAR CONTRASEÑA")
                    {
                        if (newpass == confirmar)
                        {
                            lista.agregarUsuario(user);
                            lista.guardarEnArchivo();
                            msgError("Te registraste correctamente \nSi no quieres registrar otra cuenta, presiona volver al login");
                        }
                        else msgError("Las contraseñas son diferentes \nIntentelo de nuevo");
                    }
                    else msgError("Por favor confirme la contraseña");
                }
                else msgError("Por favor ingrese la contraseña");
            }
            else msgError("Por favor ingrese el usuario");
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }     
    }
}
