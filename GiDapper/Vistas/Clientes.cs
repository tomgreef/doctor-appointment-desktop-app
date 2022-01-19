using GiDapper.Database;
using System;
using System.Windows.Forms;


namespace GiDapper
{
    public partial class Clientes : Form
    {
        private Eye seleccionado;
        private readonly Client client;
        private readonly EyeDb db;
        
        public Clientes(Client client)
        {
            InitializeComponent();
            this.client = client;
            db = new EyeDb();
        }


        private void Clientes_Load(object sender, EventArgs e)
        {
            dataGridViewClientes.DataSource = db.GetByNif(client.NIF);
        }

        private void dataGridViewClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                string id = dataGridViewClientes.SelectedRows[0].Cells[0].Value.ToString();
                seleccionado = db.GetById(id);
                MostrarSeleccionado();
            }
        }

        private void MostrarSeleccionado()
        {
            if (seleccionado == null)
            {
                dataGridViewClientes.ClearSelection();
                dataGridViewClientes.DataSource = db.GetByNif(client.NIF);
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
                textBox_oi_agudeza.Text = seleccionado.OiAgudeza.ToString();
                monthCalendar.SetDate(seleccionado.Consulta);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            seleccionado = null;
            MostrarSeleccionado();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                db.Delete(seleccionado);
                seleccionado = null;
                MostrarSeleccionado();
            }
        }

        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            var eye = new Eye
            {
                NIF = client.NIF,
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
            db.Create(eye);
            seleccionado = null;
            MostrarSeleccionado();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            seleccionado.OdEsfera = Convert.ToDouble(textBox_od_espera.Text);
            seleccionado.OiEsfera = Convert.ToDouble(textBox_oi_espera.Text);
            seleccionado.OdCilindro = Convert.ToDouble(textBox_od_cilindro.Text);
            seleccionado.OiCilindro = Convert.ToDouble(textBox_oi_cilindro.Text);
            seleccionado.OdAgudeza = Convert.ToDouble(textBox_od_agudeza.Text);
            seleccionado.OiAgudeza = Convert.ToDouble(textBox_oi_agudeza.Text);
            seleccionado.OdAdicion = Convert.ToDouble(textBox_od_adicion.Text);
            seleccionado.OiAdicion = Convert.ToDouble(textBox_oi_adicion.Text);
            seleccionado.Consulta = monthCalendar.SelectionRange.Start;
            
            db.Update(seleccionado);
            seleccionado = null;
            MostrarSeleccionado();
        }
    }
}
