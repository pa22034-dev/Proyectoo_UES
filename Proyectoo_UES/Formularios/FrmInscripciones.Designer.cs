
using System; // Permite utilizar clases y eventos básicos.
using System.Drawing; // Permite trabajar con colores, fuentes y tamaños.
using System.Windows.Forms; // Permite utilizar los controles de Windows Forms.

namespace Proyectoo_UES.Formularios // Define el espacio de nombres del formulario.
{
    partial class FrmInscripciones // Declara una parte de la clase FrmInscripciones.
    {
        // Declara el contenedor de componentes del formulario.
        private System.ComponentModel.IContainer components = null;

        // Declara las etiquetas que se utilizarán en el formulario.
        private Label lblTitulo, lblActividad, lblCarnet, lblNombre;

        // Declara el ComboBox para seleccionar una actividad.
        private ComboBox cboActividad;

        // Declara los TextBox para escribir el carné y el nombre.
        private TextBox txtCarnet, txtNombre;

        // Declara las tablas para mostrar los estudiantes inscritos y en espera.
        private DataGridView dgvInscritos, dgvEspera;

        // Declara los botones para realizar las diferentes acciones.
        private Button btnInscribir, btnCancelar, btnActualizar, btnVolver;

        // Declara los contenedores que agrupan las tablas.
        private GroupBox grpInscritos, grpEspera;

        // Método encargado de liberar los recursos utilizados por el formulario.
        protected override void Dispose(bool disposing)
        {
            // Comprueba si se deben liberar los recursos administrados.
            if (disposing && components != null)
                components.Dispose(); // Libera los componentes.

            // Ejecuta el método Dispose de la clase principal.
            base.Dispose(disposing);
        }

        // Método que crea y configura todos los controles del formulario.
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblActividad = new Label();
            lblCarnet = new Label();
            lblNombre = new Label();
            cboActividad = new ComboBox();
            txtCarnet = new TextBox();
            txtNombre = new TextBox();
            dgvInscritos = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dgvEspera = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            btnInscribir = new Button();
            btnCancelar = new Button();
            btnActualizar = new Button();
            btnVolver = new Button();
            grpInscritos = new GroupBox();
            grpEspera = new GroupBox();
            datos = new TableLayoutPanel();
            tablas = new TableLayoutPanel();
            botones = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvInscritos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEspera).BeginInit();
            grpInscritos.SuspendLayout();
            grpEspera.SuspendLayout();
            datos.SuspendLayout();
            tablas.SuspendLayout();
            botones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(900, 201);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "GESTIÓN DE INSCRIPCIONES";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActividad
            // 
            lblActividad.BackColor = Color.WhiteSmoke;
            lblActividad.Dock = DockStyle.Fill;
            lblActividad.Location = new Point(15, 12);
            lblActividad.Name = "lblActividad";
            lblActividad.Size = new Size(144, 33);
            lblActividad.TabIndex = 0;
            lblActividad.Text = "Actividad:";
            lblActividad.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCarnet
            // 
            lblCarnet.BackColor = Color.White;
            lblCarnet.Dock = DockStyle.Fill;
            lblCarnet.Location = new Point(15, 45);
            lblCarnet.Name = "lblCarnet";
            lblCarnet.Size = new Size(144, 33);
            lblCarnet.TabIndex = 2;
            lblCarnet.Text = "Carné:";
            lblCarnet.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNombre
            // 
            lblNombre.BackColor = Color.White;
            lblNombre.Dock = DockStyle.Fill;
            lblNombre.Location = new Point(15, 78);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(144, 35);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre completo:";
            lblNombre.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboActividad
            // 
            cboActividad.Dock = DockStyle.Fill;
            cboActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActividad.Location = new Point(165, 15);
            cboActividad.Name = "cboActividad";
            cboActividad.Size = new Size(720, 28);
            cboActividad.TabIndex = 1;
            cboActividad.SelectedIndexChanged += cboActividad_SelectedIndexChanged;
            // 
            // txtCarnet
            // 
            txtCarnet.Dock = DockStyle.Fill;
            txtCarnet.Location = new Point(165, 48);
            txtCarnet.Name = "txtCarnet";
            txtCarnet.Size = new Size(720, 27);
            txtCarnet.TabIndex = 3;
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.Location = new Point(165, 81);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(720, 27);
            txtNombre.TabIndex = 5;
            // 
            // dgvInscritos
            // 
            dgvInscritos.BackgroundColor = Color.Tan;
            dgvInscritos.ColumnHeadersHeight = 29;
            dgvInscritos.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvInscritos.Location = new Point(12, 26);
            dgvInscritos.Name = "dgvInscritos";
            dgvInscritos.RowHeadersWidth = 51;
            dgvInscritos.Size = new Size(304, 209);
            dgvInscritos.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Carné";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Estudiante inscrito";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dgvEspera
            // 
            dgvEspera.BackgroundColor = Color.Tan;
            dgvEspera.ColumnHeadersHeight = 29;
            dgvEspera.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dgvEspera.Location = new Point(12, 23);
            dgvEspera.Name = "dgvEspera";
            dgvEspera.RowHeadersWidth = 51;
            dgvEspera.Size = new Size(429, 209);
            dgvEspera.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Carné";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Estudiante en espera";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Fecha de solicitud";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // btnInscribir
            // 
            btnInscribir.BackColor = Color.White;
            btnInscribir.ForeColor = SystemColors.ActiveCaptionText;
            btnInscribir.Location = new Point(11, 11);
            btnInscribir.Name = "btnInscribir";
            btnInscribir.Size = new Size(89, 37);
            btnInscribir.TabIndex = 0;
            btnInscribir.Text = "Inscribir";
            btnInscribir.UseVisualStyleBackColor = false;
            btnInscribir.Click += btnInscribir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.ForeColor = SystemColors.ActiveCaptionText;
            btnCancelar.Location = new Point(106, 11);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(99, 37);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar por carné";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.White;
            btnActualizar.ForeColor = SystemColors.ActiveCaptionText;
            btnActualizar.Location = new Point(211, 11);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 37);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.White;
            btnVolver.ForeColor = SystemColors.ActiveCaptionText;
            btnVolver.Location = new Point(317, 11);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(93, 37);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // grpInscritos
            // 
            grpInscritos.Controls.Add(dgvInscritos);
            grpInscritos.Dock = DockStyle.Fill;
            grpInscritos.ForeColor = SystemColors.Control;
            grpInscritos.Location = new Point(3, 3);
            grpInscritos.Name = "grpInscritos";
            grpInscritos.Size = new Size(894, 157);
            grpInscritos.TabIndex = 0;
            grpInscritos.TabStop = false;
            grpInscritos.Text = "Inscripciones confirmadas";
            // 
            // grpEspera
            // 
            grpEspera.Controls.Add(dgvEspera);
            grpEspera.Dock = DockStyle.Fill;
            grpEspera.ForeColor = SystemColors.Control;
            grpEspera.Location = new Point(3, 166);
            grpEspera.Name = "grpEspera";
            grpEspera.Size = new Size(894, 157);
            grpEspera.TabIndex = 1;
            grpEspera.TabStop = false;
            grpEspera.Text = "Cola de espera";
            // 
            // datos
            // 
            datos.ColumnCount = 2;
            datos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            datos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            datos.Controls.Add(lblActividad, 0, 0);
            datos.Controls.Add(cboActividad, 1, 0);
            datos.Controls.Add(lblCarnet, 0, 1);
            datos.Controls.Add(txtCarnet, 1, 1);
            datos.Controls.Add(lblNombre, 0, 2);
            datos.Controls.Add(txtNombre, 1, 2);
            datos.Dock = DockStyle.Top;
            datos.Location = new Point(0, 201);
            datos.Name = "datos";
            datos.Padding = new Padding(12);
            datos.RowCount = 3;
            datos.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3F));
            datos.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3F));
            datos.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3F));
            datos.Size = new Size(900, 125);
            datos.TabIndex = 2;
            // 
            // tablas
            // 
            tablas.ColumnCount = 1;
            tablas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tablas.Controls.Add(grpInscritos, 0, 0);
            tablas.Controls.Add(grpEspera, 0, 1);
            tablas.Dock = DockStyle.Fill;
            tablas.Location = new Point(0, 326);
            tablas.Name = "tablas";
            tablas.RowCount = 2;
            tablas.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablas.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablas.Size = new Size(900, 326);
            tablas.TabIndex = 0;
            // 
            // botones
            // 
            botones.Controls.Add(btnInscribir);
            botones.Controls.Add(btnCancelar);
            botones.Controls.Add(btnActualizar);
            botones.Controls.Add(btnVolver);
            botones.Dock = DockStyle.Bottom;
            botones.Location = new Point(0, 652);
            botones.Name = "botones";
            botones.Padding = new Padding(8);
            botones.Size = new Size(900, 48);
            botones.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_ues_blanco_1_838x1024;
            pictureBox1.Location = new Point(55, 47);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // FrmInscripciones
            // 
            BackColor = Color.Brown;
            ClientSize = new Size(900, 700);
            Controls.Add(pictureBox1);
            Controls.Add(tablas);
            Controls.Add(botones);
            Controls.Add(datos);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(750, 600);
            Name = "FrmInscripciones";
            StartPosition = FormStartPosition.CenterParent;
            Text = "UES - Gestión de inscripciones";
            ((System.ComponentModel.ISupportInitialize)dgvInscritos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEspera).EndInit();
            grpInscritos.ResumeLayout(false);
            grpEspera.ResumeLayout(false);
            datos.ResumeLayout(false);
            datos.PerformLayout();
            tablas.ResumeLayout(false);
            botones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        // Método que configura las propiedades generales de una tabla.
        private void ConfigurarTabla(DataGridView tabla)
        {
            // Hace que la tabla ocupe todo el espacio disponible.
            tabla.Dock = DockStyle.Fill;

            // Impide que los usuarios modifiquen los datos directamente.
            tabla.ReadOnly = true;

            // Impide agregar filas manualmente desde la tabla.
            tabla.AllowUserToAddRows = false;

            // Permite seleccionar una fila completa.
            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ajusta automáticamente el ancho de las columnas.
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private TableLayoutPanel datos;
        private TableLayoutPanel tablas;
        private FlowLayoutPanel botones;
        private PictureBox pictureBox1;
    }
}
