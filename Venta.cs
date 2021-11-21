using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIN
{
    class Venta
    {
        public static char Separador = '-';
        public string nombre_venta { get; set; }
        public string marca_venta { get; set; }
        public string tipo_venta { get; set; }
        public string compra_venta { get; set; }
        public string venta_venta { get; set; }
        public string cantidad_venta { get; set; }

        public string DataParaVenta
        {
            get
            {
                return nombre_venta + Separador + marca_venta + Separador + tipo_venta + Separador + compra_venta +
                    Separador + venta_venta + Separador + cantidad_venta;
            }
        }
        public Venta() { }
        public Venta(string linea)
        {
            string[] datosventas = linea.Split(Separador);
            nombre_venta = datosventas[0];
            marca_venta = datosventas[1];
            tipo_venta = datosventas[2];
            compra_venta = datosventas[3];
            venta_venta = datosventas[4];
            cantidad_venta = datosventas[5];
        }
    }
}
