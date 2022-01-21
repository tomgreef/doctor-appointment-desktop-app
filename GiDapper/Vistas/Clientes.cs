using GiDapper.Database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GiDapper
{
    public partial class Clientes : Form
    {
        private Client seleccionado = null;
        private const int MAX_AGE = 130;

        private readonly ClientDb db;

        public Clientes()
        {
            InitializeComponent();
            db = new ClientDb();
        }

        private void Revisiones_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = db.GetAll().ToList();

                for (int i = 0; i < MAX_AGE; i++)
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
            if (seleccionado == null)
            {
                this.dataGridView1.ClearSelection();
                dataGridView1.DataSource = db.GetAll().ToList();

                tNIF.ResetText();
                tNombre.ResetText();
                tApellidos.ResetText();
                lEdad.ClearSelected();
            }
            else
            {
                tNIF.Text = seleccionado.NIF;
                tNombre.Text = seleccionado.Nombre;
                tApellidos.Text = seleccionado.Apellidos;
                lEdad.SelectedItem = (int)seleccionado.Edad;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string NIF = (string)this.dataGridView1.SelectedRows[0].Cells[0].Value;

                seleccionado = db.GetById(NIF);

                MuestraSeleccionado();
            }
        }

        private void buttonRevisiones_Click(object sender, EventArgs e)
        {
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente");
            }
            else
            {
                Revisiones cliente = new(seleccionado);
                this.Visible = false;
                cliente.ShowDialog();
                this.Visible = true;
            }
        }

        private void bIns_Click(object sender, EventArgs e)
        {
            try
            {
                Client c = new()
                {
                    NIF = tNIF.Text,
                    Nombre = tNombre.Text,
                    Apellidos = tApellidos.Text,
                    Edad = (int)lEdad.SelectedItem,
                };

                db.Insert(c);

                seleccionado = null;
                MuestraSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void bUpd_Click(object sender, EventArgs e)
        {
            try
            {

                string id = seleccionado.NIF;
                seleccionado.NIF = tNIF.Text;
                seleccionado.Nombre = tNombre.Text;
                seleccionado.Apellidos = tApellidos.Text;
                seleccionado.Edad = (int)lEdad.SelectedItem;

                db.Update(id, seleccionado);

                seleccionado = null;
                MuestraSeleccionado();
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            try
            {
                db.Delete(seleccionado);

                seleccionado = null;
                MuestraSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            seleccionado = null;
            MuestraSeleccionado();
        }

    }
}
