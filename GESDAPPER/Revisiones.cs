using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESDAPPER
{
    public partial class Revisiones : Form
    {
        private Client seleccionado = null; //hay que completar esto, cuando el usuario selecciona una persona y selecciona revisiones usamos esto para pasar el cliente  
        private int MAX_AGE = 100;

        public Revisiones()
        {
            InitializeComponent();
        }

        private void Revisiones_Load(object sender, EventArgs e)
        {
            try
            {
                Db db = new Db();
                List<Client> clients = db.GetAll<Client>().ToList();

                foreach (Client c in clients)
                    this.dataGridView1.Rows.Add(c.NIF, c.Nombre, c.Apellidos, c.Edad);

                for (int i = 0; i < MAX_AGE; i++)
                    lEdad.Items.Add(i);

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
                this.dataGridView1.Rows.Clear();
                Revisiones_Load(null, null);

                tNIF.Text = "";
                tNombre.Text = "";
                tApellidos.Text = "";
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

                try
                {
                    Db db = new Db();
                    seleccionado = db.GetById<Client>(NIF);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }

                MuestraSeleccionado();
            }
        }

        private void buttonRevisiones_Click(object sender, EventArgs e)
        {
            if (seleccionado == null)
                MessageBox.Show("Seleccione un cliente");
            else
            {
                Clientes cliente = new Clientes(seleccionado);
                this.Visible = false;
                cliente.ShowDialog();
                this.Visible = true;
            }
        }

        private void bIns_Click(object sender, EventArgs e)
        {
            try
            {
                if (seleccionado == null)
                    seleccionado = new Client();

                seleccionado.NIF = tNIF.Text;
                seleccionado.Nombre = tNombre.Text;
                seleccionado.Apellidos = tApellidos.Text;
                seleccionado.Edad = (int)lEdad.SelectedItem;

                Db db = new Db();
                db.Save(seleccionado);

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
                seleccionado.NIF = tNIF.Text;
                seleccionado.Nombre = tNombre.Text;
                seleccionado.Apellidos = tApellidos.Text;
                seleccionado.Edad = (int) lEdad.SelectedItem;

                Db db = new Db();
                db.Update(seleccionado);

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
                Db db = new Db();
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
