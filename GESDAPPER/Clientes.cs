using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GESDAPPER
{
    public partial class Clientes : Form
    {
        private Eye seleccionado;
        private Client main;
        private static readonly string _connectionString = Properties.Settings.Default.ConnectionString;
        public Clientes(Client client)
        {
            InitializeComponent();
            main = client; 
        }


        private void Clientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gIODataSet.tEye' Puede moverla o quitarla según sea necesario.
           // this.tEyeTableAdapter.Fill(this.gIODataSet.tEye);
            var select = "SELECT * FROM GIO.dbo.tClient c  JOIN GIO.dbo.tEye e on (c.NIF =e.NIF) where c.Nif ='" + main.NIF +"';";
            var c = new SqlConnection("Data Source=DESKTOP-6289C7L;Initial Catalog=GIO;Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridViewClientes.ReadOnly = true;
            dataGridViewClientes.DataSource = ds.Tables[0];

        }

        private void dataGridViewClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                string id = dataGridViewClientes.SelectedRows[0].Cells[0].Value.ToString();
                Db db = new Db();
                seleccionado = db.GetById<Eye>(id);
                MostrarSeleccionado();
                
            }
        }

        private void MostrarSeleccionado()
        {
            if (seleccionado == null)
            {
                this.tEyeTableAdapter.Fill(this.gIODataSet.tEye);
                dataGridViewClientes.ClearSelection();
                textBox_od_espera.Text = "";
                textBox_oi_espera.Text = "";
                textBox_od_cilindro.Text = "";
                textBox_oi_cilindro.Text = "";
                textBox_od_adicion.Text = "";
                textBox_oi_adicion.Text = "";
                textBox_od_agudeza.Text = "";
                textBox_oi_agudeza.Text = "";
                monthCalendar.SetDate(DateTime.Today);
            }
            else
            {
                textBox_od_espera.Text = seleccionado.OdEsfera.ToString();
                textBox_oi_espera.Text = seleccionado.OiEsfera.ToString();
                textBox_od_cilindro.Text = seleccionado.OdCilindro.ToString();
                textBox_oi_cilindro.Text = seleccionado.OiCilindro.ToString();
                textBox_od_adicion.Text = seleccionado.OdAdicion.ToString();
                textBox_oi_adicion.Text = seleccionado.OiAdicion.ToString();
                textBox_od_agudeza.Text = seleccionado.OdAgudeza.ToString();
                textBox_oi_agudeza.Text = seleccionado.OiAgudeza.ToString(); ;
                monthCalendar.SetDate(seleccionado.Consulta);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            
            this.tEyeTableAdapter.Fill(this.gIODataSet.tEye);
            dataGridViewClientes.ClearSelection();
            textBox_od_espera.Text = "";
            textBox_oi_espera.Text = "";
            textBox_od_cilindro.Text = "";
            textBox_oi_cilindro.Text = "";
            textBox_od_adicion.Text = "";
            textBox_oi_adicion.Text = "";
            textBox_od_agudeza.Text = "";
            textBox_oi_agudeza.Text = "";
            monthCalendar.SetDate(DateTime.Today);
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                Db db = new Db();
                db.Delete(seleccionado);
                this.tEyeTableAdapter.Fill(this.gIODataSet.tEye);
                dataGridViewClientes.ClearSelection();
                MostrarSeleccionado();
            }
        }

        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            Db db = new Db();
            var eye = new Eye
            {

                
                Cliente = main,
                Consulta = monthCalendar.SelectionRange.Start,
                OdEsfera = Convert.ToDouble(textBox_od_espera.Text),
                OiEsfera = Convert.ToDouble(textBox_oi_espera.Text),
                OdCilindro = Convert.ToDouble(textBox_od_cilindro.Text),
                OiCilindro = Convert.ToDouble(textBox_oi_cilindro.Text),
                OdAgudeza = Convert.ToDouble(textBox_od_agudeza.Text),
                OiAgudeza = Convert.ToDouble(textBox_oi_agudeza.Text),
                OdAdicion = Convert.ToDouble(textBox_od_adicion.Text),
                OiAdicion = Convert.ToDouble(textBox_oi_adicion.Text)
            };
            db.Save(eye);
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {/*
            if (!seleccionado.NIF_Paciente.Equals(tNIF.Text))
                seleccionado.NIF_Paciente = tNIF.Text;
            if (seleccionado.NumeroSS_Paciente != int.Parse(tNumSS.Text))
                seleccionado.NumeroSS_Paciente = int.Parse(tNumSS.Text);
            if (!seleccionado.Apellidos_Paciente.Equals(tApellidos.Text))
                seleccionado.Apellidos_Paciente = tApellidos.Text;
            if (!seleccionado.Nombre_Paciente.Equals(tNombre.Text))
                seleccionado.Nombre_Paciente = tNombre.Text;
            if (!seleccionado.Sexo_Paciente.Equals(lSexo.SelectedItem.ToString()))
                seleccionado.Sexo_Paciente = lSexo.SelectedItem.ToString();
            if (!seleccionado.FechaNacimiento_Paciente.Equals(mFecha.SelectionStart))
                seleccionado.FechaNacimiento_Paciente = mFecha.SelectionStart;
            if (!seleccionado.Direccion_Paciente.Equals(tDireccion.Text))
                seleccionado.Direccion_Paciente = tDireccion.Text;
            if (!seleccionado.CodigoPostal_Paciente.Equals(tCP.Text))
                seleccionado.CodigoPostal_Paciente = tCP.Text;
            if (!seleccionado.Poblacion_Paciente.Equals(tPoblacion.Text))
                seleccionado.Poblacion_Paciente = tPoblacion.Text;
            if (!seleccionado.Telefono_Paciente.Equals(tTelefono.Text))
                seleccionado.Telefono_Paciente = tTelefono.Text;
            if (!seleccionado.Provincia_Paciente.Equals(lProvincia.SelectedItem))
                seleccionado.Provincia_Paciente = (Provincia)lProvincia.SelectedItem;
            if (!seleccionado.e_mail_Paciente.Equals(tEmail.Text))
                seleccionado.e_mail_Paciente = tEmail.Text; */
        }

        private int getLastId()
        {

            string sql = "select max(ID) from GIO.dbo.tEye ";
            //como ejecuto esto ?
            return 0;
            
        }
    }
}
