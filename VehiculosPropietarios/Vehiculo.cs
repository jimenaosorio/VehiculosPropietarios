using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiculosPropietarios
{
    public class Vehiculo
    {
        private string patente;
        private string marca;
        private string modelo;
        private Propietario propietario;

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
        }
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        public Propietario PropietarioVehiculo
        {
            get { return propietario; }
            set { propietario = value; }
        }
    }
}
