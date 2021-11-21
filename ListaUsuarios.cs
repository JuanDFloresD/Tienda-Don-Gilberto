using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LOGIN
{
    class ListaUsuarios
    {
        List<Usuario> usuarios = new List<Usuario>();
        public void agregarUsuario(Usuario usuario) 
        {  
            usuarios.Add(usuario);
        }
        public bool existeUsuario(Usuario usuariocomprobar)
        {
            foreach(Usuario aux in usuarios)
            {
                if (aux.usuario == usuariocomprobar.usuario)
                {
                    if (aux.contraseña == usuariocomprobar.contraseña)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public string guardarEnArchivo()
        {
            string error = "";
            try
            {
                StreamWriter sw = new StreamWriter("Usuarios.txt");

                foreach (Usuario aux in usuarios)
                {
                    sw.WriteLine(aux.DataParaArchivo);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return error;
        }
        public string cargarDesdeArchivo()
        {
            string error = "";
            try
            {
                usuarios = new List<Usuario>();

                StreamReader sr = new StreamReader("Usuarios.txt");
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    usuarios.Add(new Usuario(linea));
                    //Leer linea
                }
                sr.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return error;
        }
    }
}
