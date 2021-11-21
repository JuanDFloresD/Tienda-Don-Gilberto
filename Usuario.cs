using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIN
{
    class Usuario
    {
        public static char SIMBOLO = '-';
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string DataParaArchivo 
        { 
            get
            {
                return usuario + SIMBOLO + contraseña;
            }
        }
        public Usuario() { }
        public Usuario(string linea)
        {
            string[] datos = linea.Split(SIMBOLO);
            usuario = datos[0];
            contraseña = datos[1];
        }
    }
}
