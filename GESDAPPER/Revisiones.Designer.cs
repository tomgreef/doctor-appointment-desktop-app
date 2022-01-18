namespace GESDAPPER
{
    partial class Revisiones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelNIF = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelEdad = new System.Windows.Forms.Label();
            this.labelApellidos = new System.Windows.Forms.Label();
            this.buttonAñadir = new System.Windows.Forms.Button();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.buttonRevisiones = new System.Windows.Forms.Button();
            this.tNIF = new System.Windows.Forms.TextBox();
            this.tNombre = new System.Windows.Forms.TextBox();
            this.tApellidos = new System.Windows.Forms.TextBox();
            this.lEdad = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(253, 5);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(221, 31);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Revisión Ocular";
            // 
            // labelNIF
            // 
            this.labelNIF.AutoSize = true;
            this.labelNIF.Location = new System.Drawing.Point(75, 176);
            this.labelNIF.Name = "labelNIF";
            this.labelNIF.Size = new System.Drawing.Size(24, 13);
            this.labelNIF.TabIndex = 2;
            this.labelNIF.Text = "NIF";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(75, 207);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 3;
            this.labelNombre.Text = "Nombre";
            // 
            // labelEdad
            // 
            this.labelEdad.AutoSize = true;
            this.labelEdad.Location = new System.Drawing.Point(75, 267);
            this.labelEdad.Name = "labelEdad";
            this.labelEdad.Size = new System.Drawing.Size(32, 13);
            this.labelEdad.TabIndex = 4;
            this.labelEdad.Text = "Edad";
            // 
            // labelApellidos
            // 
            this.labelApellidos.AutoSize = true;
            this.labelApellidos.Location = new System.Drawing.Point(75, 238);
            this.labelApellidos.Name = "labelApellidos";
            this.labelApellidos.Size = new System.Drawing.Size(49, 13);
            this.labelApellidos.TabIndex = 5;
            this.labelApellidos.Text = "Apellidos";
            // 
            // buttonAñadir
            // 
            this.buttonAñadir.Location = new System.Drawing.Point(78, 310);
            this.buttonAñadir.Name = "buttonAñadir";
            this.buttonAñadir.Size = new System.Drawing.Size(75, 23);
            this.buttonAñadir.TabIndex = 6;
            this.buttonAñadir.Text = "Añadir";
            this.buttonAñadir.UseVisualStyleBackColor = true;
            this.buttonAñadir.Click += new System.EventHandler(this.bIns_Click);
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Location = new System.Drawing.Point(198, 310);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(75, 23);
            this.buttonActualizar.TabIndex = 7;
            this.buttonActualizar.Text = "Actualizar";
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.bUpd_Click);
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.Location = new System.Drawing.Point(328, 310);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(75, 23);
            this.buttonBorrar.TabIndex = 8;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = true;
            this.buttonBorrar.Click += new System.EventHandler(this.bDel_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(449, 310);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 9;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(559, 310);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 10;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // buttonRevisiones
            // 
            this.buttonRevisiones.Location = new System.Drawing.Point(510, 269);
            this.buttonRevisiones.Name = "buttonRevisiones";
            this.buttonRevisiones.Size = new System.Drawing.Size(75, 23);
            this.buttonRevisiones.TabIndex = 11;
            this.buttonRevisiones.Text = "Revisiones";
            this.buttonRevisiones.UseVisualStyleBackColor = true;
            this.buttonRevisiones.Click += new System.EventHandler(this.buttonRevisiones_Click);
            // 
            // tNIF
            // 
            this.tNIF.Location = new System.Drawing.Point(144, 173);
            this.tNIF.Name = "tNIF";
            this.tNIF.Size = new System.Drawing.Size(490, 20);
            this.tNIF.TabIndex = 12;
            // 
            // tNombre
            // 
            this.tNombre.Location = new System.Drawing.Point(144, 207);
            this.tNombre.Name = "tNombre";
            this.tNombre.Size = new System.Drawing.Size(490, 20);
            this.tNombre.TabIndex = 13;
            // 
            // tApellidos
            // 
            this.tApellidos.Location = new System.Drawing.Point(144, 238);
            this.tApellidos.Name = "tApellidos";
            this.tApellidos.Size = new System.Drawing.Size(490, 20);
            this.tApellidos.TabIndex = 14;
            // 
            // lEdad
            // 
            this.lEdad.FormattingEnabled = true;
            this.lEdad.Location = new System.Drawing.Point(144, 269);
            this.lEdad.Name = "lEdad";
            this.lEdad.Size = new System.Drawing.Size(120, 30);
            this.lEdad.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NIF,
            this.Nombre,
            this.Apellidos,
            this.Edad});
            this.dataGridView1.Location = new System.Drawing.Point(78, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(556, 128);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // NIF
            // 
            this.NIF.HeaderText = "NIF";
            this.NIF.Name = "NIF";
            this.NIF.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "NOMBRE";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellidos
            // 
            this.Apellidos.HeaderText = "APELLIDOS";
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.ReadOnly = true;
            // 
            // Edad
            // 
            this.Edad.HeaderText = "EDAD";
            this.Edad.Name = "Edad";
            this.Edad.ReadOnly = true;
            // 
            // Revisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 345);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lEdad);
            this.Controls.Add(this.tApellidos);
            this.Controls.Add(this.tNombre);
            this.Controls.Add(this.tNIF);
            this.Controls.Add(this.buttonRevisiones);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.buttonAñadir);
            this.Controls.Add(this.labelApellidos);
            this.Controls.Add(this.labelEdad);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelNIF);
            this.Controls.Add(this.labelTitulo);
            this.Name = "Revisiones";
            this.Text = "Revisiones";
            this.Load += new System.EventHandler(this.Revisiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelNIF;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelEdad;
        private System.Windows.Forms.Label labelApellidos;
        private System.Windows.Forms.Button buttonAñadir;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Button buttonRevisiones;
        private System.Windows.Forms.TextBox tNIF;
        private System.Windows.Forms.TextBox tNombre;
        private System.Windows.Forms.TextBox tApellidos;
        private System.Windows.Forms.ListBox lEdad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edad;
    }
}