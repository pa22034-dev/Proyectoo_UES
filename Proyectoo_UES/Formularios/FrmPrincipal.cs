using Proyectoo_UES.Servicios;

namespace Proyectoo_UES.Formularios
{
    public partial class FrmPrincipal : Form
    {
        private readonly GestorActividades gestor;

        public FrmPrincipal(GestorActividades gestor)
        {
            this.gestor = gestor;
            InitializeComponent();
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            using (FrmActividades ventana = new FrmActividades(gestor))
                ventana.ShowDialog(this);
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            using (FrmInscripciones ventana = new FrmInscripciones(gestor))
                ventana.ShowDialog(this);
        }

        private void btnCupos_Click(object sender, EventArgs e)
        {
            using (FrmCupos ventana = new FrmCupos(gestor))
                ventana.ShowDialog(this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
