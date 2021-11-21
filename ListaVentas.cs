using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LOGIN
{
    class ListaVentas
    {
        List<Venta> ventas = new List<Venta>();

        public void agregarventa(Venta venta)
        {
            ventas.Add(venta);
        }
        public List<Venta> getLista()
        {
            return ventas;
        }
        public string guardarventas()
        {
            string error = "";
            try
            {
                StreamWriter sw = new StreamWriter("Ventas.txt");

                foreach (Venta aux in ventas)
                {
                    sw.WriteLine(aux.DataParaVenta);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return error;
        }
        public string cargarventas()
        {
            string error = "";
            try
            {
                ventas = new List<Venta>();

                StreamReader sr = new StreamReader("Ventas.txt");
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    ventas.Add(new Venta(linea));
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
