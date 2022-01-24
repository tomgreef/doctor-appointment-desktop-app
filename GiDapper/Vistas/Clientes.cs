using System;
using System.Linq;
using System.Windows.Forms;
using GiDapper.Database;
using GiDapper.Modelos;

namespace GiDapper.Vistas
{
    public partial class Clientes : Form
    {
        private Client _seleccionado;
        private const int MaxAge = 130;
        
        private readonly ClientDb _db;

        public Clientes()
        {
            InitializeComponent();
            _db = new ClientDb();
        }

        private void Revisiones_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = _db.GetAll().ToList();

                for (var i = 0; i < MaxAge; i++)
                {
                    lEdad.Items.Add(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void MuestraSeleccionado()
        {
            if (_seleccionado == null)
            {
                this.dataGridView1.ClearSelection();
                dataGridView1.DataSource = _db.GetAll().ToList();

                tNIF.ResetText();
                tNombre.ResetText();
                tApellidos.ResetText();
                lEdad.ClearSelected();
            }
            else
            {
                tNIF.Text = _seleccionado.Nif;
                tNombre.Text = _seleccionado.Nombre;
                tApellidos.Text = _seleccionado.Apellidos;
                lEdad.SelectedItem = _seleccionado.Edad;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string nif = (string)dataGridView1.SelectedRows[0].Cells[0].Value;

                _seleccionado = _db.GetById(nif);

                MuestraSeleccionado();
            }
        }

        private void buttonRevisiones_Click(object sender, EventArgs e)
        {
            if (_seleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            Revisiones cliente = new(_seleccionado);
            Visible = false;
            cliente.ShowDialog();
            Visible = true;
        }

        private void bIns_Click(object sender, EventArgs e)
        {
            if(lEdad.SelectedIndex == -1
                || string.IsNullOrEmpty(tNIF.Text)
                || string.IsNullOrWhiteSpace(tNombre.Text)
                || string.IsNullOrWhiteSpace(tApellidos.Text))
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }

            try
            {
                Client c = new()
                {
                    Nif = tNIF.Text,
                    Nombre = tNombre.Text,
                    Apellidos = tApellidos.Text,
                    Edad = (int)lEdad.SelectedItem,
                };

                _db.Create(c);

                _seleccionado = null;
                MuestraSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void bUpd_Click(object sender, EventArgs e)
        {
            if (_seleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            try
            {

                var id = _seleccionado.Nif;
                _seleccionado.Nif = tNIF.Text;
                _seleccionado.Nombre = tNombre.Text;
                _seleccionado.Apellidos = tApellidos.Text;
                _seleccionado.Edad = (int)lEdad.SelectedItem;

                _db.Update(id, _seleccionado);

                _seleccionado = null;
                MuestraSeleccionado();
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (_seleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            try
            {
                _db.Delete(_seleccionado);

                _seleccionado = null;
                MuestraSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            _seleccionado = null;
            MuestraSeleccionado();
        }
    }
}
