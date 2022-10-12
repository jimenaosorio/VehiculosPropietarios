namespace VehiculosPropietarios
{
    public partial class Form1 : Form
    {
        private Vehiculo[] vehiculos = new Vehiculo[100];
        private int cantidad = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            salir();
        }
        public void salir()
        {
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            salir();
        }
        public void limpiar()
        {
            txtPatente.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtRutNuevo.Clear();
            txtNombreNuevo.Clear();
            txtTelefonoNuevo.Clear();
            txtNombreExistente.Clear();
            txtTelefonoExistente.Clear();
            txtPatente.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private Propietario buscarPropietario(string rut)
        {
            Propietario p;
            for(int i=0; i<cantidad; i++)
            {
                p = vehiculos[i].PropietarioVehiculo;
                if(p.Rut.Equals(rut))
                    return p;
            }
            return null;
        }
        private void enlazarVehiculoPropietario(Vehiculo v,Propietario p)
        {
            v.PropietarioVehiculo = p;
            p[p.Cantidad] = v;
            //p.Cantidad++;
        }
        private void mostrar(Vehiculo v, Propietario p)
        {
            string nuevo = "Vehiculo: " + v.Patente + " " + v.Marca + " " + v.Modelo
                + ". Propietario: " + p.Rut + " " + p.Nombre + " " + p.Telefono;
            lstMostrar.Items.Add(nuevo);
            MessageBox.Show("Vehiculo ingresado");
            limpiar();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtPatente.Text!="" && txtMarca.Text!="" && txtModelo.Text!="") //Están los datos del Vehículo
            {
                //Creamos el vehículo
                Vehiculo v = new Vehiculo();
                v.Patente = txtPatente.Text;
                v.Marca = txtMarca.Text;
                v.Modelo = txtModelo.Text;

                if(txtNombreNuevo.Text!="" && txtRutNuevo.Text!="" && txtTelefonoNuevo.Text!="")
                {
                    //Propietario nuevo
                    Propietario p=new Propietario();
                    p.Rut=txtRutNuevo.Text;
                    p.Nombre = txtNombreNuevo.Text;
                    p.Telefono = txtTelefonoNuevo.Text;

                    //Enlazar
                    enlazarVehiculoPropietario(v, p);
                    mostrar(v, p);

                    //Agregar el RUT del propietario al ComboBox
                    cboRutExistente.Items.Add(p.Rut);

                    //Agregar el vehiculo al arreglo
                    vehiculos[cantidad] = v;
                    cantidad++;
                }
                else if(cboRutExistente.SelectedItem!=null)
                {
                    //Seleccionó un propietario existente
                    Propietario p = buscarPropietario(cboRutExistente.Text);
                    enlazarVehiculoPropietario(v, p);
                    mostrar(v, p);

                    //Agregar el vehiculo al arreglo
                    vehiculos[cantidad] = v;
                    cantidad++;

                }
                else
                {
                    MessageBox.Show("Debe seleccionar un propietario existente o ingresar uno nuevo");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos del vehículo");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(cboRutExistente.SelectedItem!=null)
            {
                Propietario p;
                p= buscarPropietario(cboRutExistente.Text);
                if(p!=null)
                {
                    txtNombreExistente.Text = p.Nombre;
                    txtTelefonoExistente.Text = p.Telefono;
                }
                else
                {
                    MessageBox.Show("Seleccione un RUT o ingrese un propietario nuevo");
                }
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }
    }
}