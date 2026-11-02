namespace Proyectoo_UES
{
    partial class FrmActividades
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo, lblNombre, lblDescripcion, lblFecha, lblLugar, lblCapacidad;
        private TextBox txtNombre, txtDescripcion, txtLugar;
        private DateTimePicker dtpFecha;
        private NumericUpDown nudCapacidad;
        private DataGridView dgvActividades;
        private Button btnRegistrar, btnEliminar, btnLimpiar, btnActualizar, btnVolver;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new Label();
            this.lblNombre = new Label(); this.lblDescripcion = new Label();
            this.lblFecha = new Label(); this.lblLugar = new Label(); this.lblCapacidad = new Label();
            this.txtNombre = new TextBox(); this.txtDescripcion = new TextBox(); this.txtLugar = new TextBox();
            this.dtpFecha = new DateTimePicker(); this.nudCapacidad = new NumericUpDown();
            this.dgvActividades = new DataGridView();
            this.btnRegistrar = new Button(); this.btnEliminar = new Button();
            this.btnLimpiar = new Button(); this.btnActualizar = new Button(); this.btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).BeginInit();
            this.SuspendLayout();

            this.lblTitulo.Text = "REGISTRO DE ACTIVIDADES";
            this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(25, 75, 125);
            this.lblTitulo.Dock = DockStyle.Top; this.lblTitulo.Height = 48;
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            Label[] etiquetas = { lblNombre, lblDescripcion, lblFecha, lblLugar, lblCapacidad };
            string[] textos = { "Nombre:", "Descripción:", "Fecha:", "Lugar:", "Cupo máximo:" };
            for (int i = 0; i < etiquetas.Length; i++)
            {
                etiquetas[i].Text = textos[i];
                etiquetas[i].TextAlign = ContentAlignment.MiddleRight;
                etiquetas[i].Dock = DockStyle.Fill;
            }

            txtNombre.Dock = DockStyle.Fill;
            txtDescripcion.Dock = DockStyle.Fill;
            txtLugar.Dock = DockStyle.Fill;
            dtpFecha.Dock = DockStyle.Fill; dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.MinDate = DateTime.Today;
            nudCapacidad.Dock = DockStyle.Left; nudCapacidad.Minimum = 1;
            nudCapacidad.Maximum = 500; nudCapacidad.Value = 20;

            TableLayoutPanel formulario = new TableLayoutPanel();
            formulario.Dock = DockStyle.Top; formulario.Height = 190;
            formulario.Padding = new Padding(12); formulario.ColumnCount = 2; formulario.RowCount = 5;
            formulario.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135));
            formulario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int i = 0; i < 5; i++) formulario.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            formulario.Controls.Add(lblNombre, 0, 0); formulario.Controls.Add(txtNombre, 1, 0);
            formulario.Controls.Add(lblDescripcion, 0, 1); formulario.Controls.Add(txtDescripcion, 1, 1);
            formulario.Controls.Add(lblFecha, 0, 2); formulario.Controls.Add(dtpFecha, 1, 2);
            formulario.Controls.Add(lblLugar, 0, 3); formulario.Controls.Add(txtLugar, 1, 3);
            formulario.Controls.Add(lblCapacidad, 0, 4); formulario.Controls.Add(nudCapacidad, 1, 4);

            this.dgvActividades.Dock = DockStyle.Fill;
            this.dgvActividades.ReadOnly = true;
            this.dgvActividades.AllowUserToAddRows = false;
            this.dgvActividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActividades.Columns.Add("Id", "ID");
            this.dgvActividades.Columns.Add("Nombre", "Actividad");
            this.dgvActividades.Columns.Add("Fecha", "Fecha");
            this.dgvActividades.Columns.Add("Lugar", "Lugar");
            this.dgvActividades.Columns.Add("Capacidad", "Capacidad");
            this.dgvActividades.Columns.Add("Inscritos", "Inscritos");
            this.dgvActividades.Columns.Add("Disponibles", "Disponibles");
            this.dgvActividades.Columns.Add("Espera", "En espera");

            this.btnRegistrar.Text = "Registrar"; this.btnRegistrar.Click += new EventHandler(btnRegistrar_Click);
            this.btnEliminar.Text = "Eliminar seleccionada"; this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
            this.btnLimpiar.Text = "Limpiar"; this.btnLimpiar.Click += new EventHandler(btnLimpiar_Click);
            this.btnActualizar.Text = "Actualizar"; this.btnActualizar.Click += new EventHandler(btnActualizar_Click);
            this.btnVolver.Text = "Volver"; this.btnVolver.Click += new EventHandler(btnVolver_Click);

            FlowLayoutPanel botones = new FlowLayoutPanel();
            botones.Dock = DockStyle.Bottom; botones.Height = 48; botones.Padding = new Padding(8);
            botones.Controls.AddRange(new Control[] { btnRegistrar, btnEliminar, btnLimpiar, btnActualizar, btnVolver });

            this.Controls.Add(dgvActividades);
            this.Controls.Add(botones);
            this.Controls.Add(formulario);
            this.Controls.Add(lblTitulo);
            this.Name = "FrmActividades"; this.Text = "UES - Gestión de actividades";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(1050, 650); this.MinimumSize = new Size(850, 550);
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).EndInit();
            this.ResumeLayout(false);
        }
    }
}