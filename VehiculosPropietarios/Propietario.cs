using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiculosPropietarios
{
    public class Propietario
    {
        private string rut;
        private string nombre;
        private string telefono;
        private Vehiculo[] vehiculos = new Vehiculo[10];
        private int cantidad = 0;

        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Telefono
        { 
            get { return telefono;}
            set { telefono = value; }
        }
        public Vehiculo this[int index]
        {
            get { return vehiculos[index]; }
            set { 
                vehiculos[index] = value; 
                cantidad++;
            }
        }
        public int Cantidad
        {
            get { return cantidad; }
               
        }

    }
}
