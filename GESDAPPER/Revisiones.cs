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
        public Revisiones()
        {
            InitializeComponent();
        }

        private void buttonRevisiones_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            Client cl = db.GetById<Client>("07622649Y");//esto es como una prueba
            Clientes cliente = new Clientes(cl);//dentro hay que poner seleccionado por ahora es solamente una prueba
            this.Visible = false;
            cliente.ShowDialog();
            this.Visible = true;
        }
    }
}
