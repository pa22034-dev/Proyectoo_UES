
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

            // Centrar el logo al iniciar
            centrarlogo();

            // Volver a centrar cuando cambie el tamaño de la ventana
            this.Resize += (s, e) => centrarlogo();
        }

        // Método para centrar el logo horizontalmente
        private void centrarlogo()
        {
            pictureBox1.Left =
                (this.ClientSize.Width - pictureBox1.Width) / 2;

            // Centrar la imagen dentro del PictureBox
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
