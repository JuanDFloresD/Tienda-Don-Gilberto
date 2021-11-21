using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIN
{
    class Producto
    {
        public static char SIMBOLO = '-';
        public string nombre { get; set; }
        public string marca { get; set; }
        public string tipo { get; set; }
        public string compra { get; set; }
        public string venta { get; set; } 
        public string cantidad { get; set; }

        public string DataParaArchivo
        {
            get
            {
                return nombre + SIMBOLO + marca + SIMBOLO + tipo + SIMBOLO + compra +
                    SIMBOLO + venta + SIMBOLO + cantidad;
            }
        }
        public Producto() { }
        public Producto(string linea)
        {
            string[] datos = linea.Split(SIMBOLO);
            nombre = datos[0];
            marca = datos[1];
            tipo = datos[2];
            compra = datos[3];
            venta = datos[4];
            cantidad = datos[5];
        }
    }
}
