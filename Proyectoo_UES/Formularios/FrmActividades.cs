using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Proyectoo_UES.Modelos;
using Proyectoo_UES.Servicios;

namespace Proyectoo_UES
{
    public partial class FrmActividades : Form
    {
        private readonly GestorActividades gestor;

        public FrmActividades(GestorActividades gestor)
        {
            this.gestor = gestor;
            InitializeComponent();
            ActualizarTabla();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool correcto = gestor.RegistrarActividad(
                txtNombre.Text, txtDescripcion.Text, dtpFecha.Value.Date,
                txtLugar.Text, (int)nudCapacidad.Value, out string mensaje);

            MessageBox.Show(mensaje, "Gestión de actividades",
                MessageBoxButtons.OK,
                correcto ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (correcto)
            {
                Limpiar();
                ActualizarTabla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvActividades.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una actividad de la tabla.");
                return;
            }

            int id = Convert.ToInt32(dgvActividades.CurrentRow.Cells["Id"].Value);

            if (MessageBox.Show("¿Deseas eliminar la actividad seleccionada?",
                "Confirmar eliminación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            bool correcto = gestor.EliminarActividad(id, out string mensaje);
            MessageBox.Show(mensaje);
            ActualizarTabla();
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => Limpiar();
        private void btnActualizar_Click(object sender, EventArgs e) => ActualizarTabla();
        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void Limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtLugar.Clear();
            nudCapacidad.Value = 20;
            dtpFecha.Value = DateTime.Today;
            txtNombre.Focus();
        }

        private void ActualizarTabla()
        {
            dgvActividades.Rows.Clear();
            foreach (Actividad a in gestor.ObtenerActividades())
                dgvActividades.Rows.Add(a.Id, a.Nombre, a.Fecha.ToString("dd/MM/yyyy"),
                    a.Lugar, a.Capacidad, a.Inscritos, a.CuposDisponibles, a.EnEspera);
        }
    }
}
