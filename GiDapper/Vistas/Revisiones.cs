using System;
using System.Windows.Forms;
using GiDapper.Database;
using GiDapper.Modelos;

namespace GiDapper.Vistas
{
    public partial class Revisiones : Form
    {
        private Eye _seleccionado;
        private readonly Client _client;
        private readonly EyeDb _db;
        
        public Revisiones(Client client)
        {
            InitializeComponent();
            this._client = client;
            lCliente.Text = client.ToString();
            _db = new EyeDb();
        }


        private void Clientes_Load(object sender, EventArgs e)
        {
            dataGridViewClientes.DataSource = _db.GetByNif(_client.Nif);
        }

        private void dataGridViewClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                string id = dataGridViewClientes.SelectedRows[0].Cells[0].Value.ToString();
                _seleccionado = _db.GetById(id);
                MostrarSeleccionado();
            }
        }

        private void MostrarSeleccionado()
        {
            if (_seleccionado == null)
            {
                dataGridViewClientes.ClearSelection();
                dataGridViewClientes.DataSource = _db.GetByNif(_client.Nif);
                textBox_od_espera.ResetText();
                textBox_oi_espera.ResetText();
                textBox_od_cilindro.ResetText();
                textBox_oi_cilindro.ResetText();
                textBox_od_adicion.ResetText();
                textBox_oi_adicion.ResetText();
                textBox_od_agudeza.ResetText();
                textBox_oi_agudeza.ResetText();
                monthCalendar.SetDate(DateTime.Today);
            }
            else
            {
                textBox_od_espera.Text = _seleccionado.OdEsfera.ToString();
                textBox_oi_espera.Text = _seleccionado.OiEsfera.ToString();
                textBox_od_cilindro.Text = _seleccionado.OdCilindro.ToString();
                textBox_oi_cilindro.Text = _seleccionado.OiCilindro.ToString();
                textBox_od_adicion.Text = _seleccionado.OdAdicion.ToString();
                textBox_oi_adicion.Text = _seleccionado.OiAdicion.ToString();
                textBox_od_agudeza.Text = _seleccionado.OdAgudeza.ToString();
                textBox_oi_agudeza.Text = _seleccionado.OiAgudeza.ToString();
                monthCalendar.SetDate(_seleccionado.Consulta);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            _seleccionado = null;
            MostrarSeleccionado();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            if (_seleccionado == null)
            {
                MessageBox.Show("Seleccione una revisión");
                return;
            }

            try
            {
                _db.Delete(_seleccionado);
                _seleccionado = null;
                MostrarSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                var eye = new Eye
                {
                    Nif = _client.Nif,
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
                _db.Create(eye);
                _seleccionado = null;
                MostrarSeleccionado();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            if (_seleccionado == null)
            {
                MessageBox.Show("Seleccione una revisión");
                return;
            }

            try
            {
                _seleccionado.OdEsfera = Convert.ToDouble(textBox_od_espera.Text);
                _seleccionado.OiEsfera = Convert.ToDouble(textBox_oi_espera.Text);
                _seleccionado.OdCilindro = Convert.ToDouble(textBox_od_cilindro.Text);
                _seleccionado.OiCilindro = Convert.ToDouble(textBox_oi_cilindro.Text);
                _seleccionado.OdAgudeza = Convert.ToDouble(textBox_od_agudeza.Text);
                _seleccionado.OiAgudeza = Convert.ToDouble(textBox_oi_agudeza.Text);
                _seleccionado.OdAdicion = Convert.ToDouble(textBox_od_adicion.Text);
                _seleccionado.OiAdicion = Convert.ToDouble(textBox_oi_adicion.Text);
                _seleccionado.Consulta = monthCalendar.SelectionRange.Start;

                _db.Update(_seleccionado);
                _seleccionado = null;
                MostrarSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }
    }
}
