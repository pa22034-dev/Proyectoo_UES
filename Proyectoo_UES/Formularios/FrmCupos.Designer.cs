namespace Proyectoo_UES.Formularios
{
    partial class FrmCupos
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private DataGridView dgvCupos;
        private Button btnActualizar, btnVolver;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new Label(); this.dgvCupos = new DataGridView();
            this.btnActualizar = new Button(); this.btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCupos)).BeginInit();
            this.SuspendLayout();

            this.lblTitulo.Text = "CONSULTA DE CUPOS Y LISTA DE ESPERA";
            this.lblTitulo.Dock = DockStyle.Top; this.lblTitulo.Height = 55;
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(25, 75, 125);

            this.dgvCupos.Dock = DockStyle.Fill; this.dgvCupos.ReadOnly = true;
            this.dgvCupos.AllowUserToAddRows = false;
            this.dgvCupos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCupos.Columns.Add("Id", "ID");
            this.dgvCupos.Columns.Add("Actividad", "Actividad");
            this.dgvCupos.Columns.Add("Fecha", "Fecha");
            this.dgvCupos.Columns.Add("Capacidad", "Cupo total");
            this.dgvCupos.Columns.Add("Inscritos", "Ocupados");
            this.dgvCupos.Columns.Add("Disponibles", "Disponibles");
            this.dgvCupos.Columns.Add("Espera", "En espera");

            this.btnActualizar.Text = "Actualizar"; this.btnActualizar.Click += new EventHandler(btnActualizar_Click);
            this.btnVolver.Text = "Volver"; this.btnVolver.Click += new EventHandler(btnVolver_Click);
            FlowLayoutPanel botones = new FlowLayoutPanel();
            botones.Dock = DockStyle.Bottom; botones.Height = 50; botones.Padding = new Padding(8);
            botones.Controls.AddRange(new Control[] { btnActualizar, btnVolver });

            this.Controls.Add(dgvCupos); this.Controls.Add(botones); this.Controls.Add(lblTitulo);
            this.Name = "FrmCupos"; this.Text = "UES - Consulta de cupos";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(950, 550); this.MinimumSize = new Size(750, 450);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCupos)).EndInit();
            this.ResumeLayout(false);
        }
    }
}