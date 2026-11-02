using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Proyectoo_UES.Modelos;
using Proyectoo_UES.Servicios;

namespace Proyectoo_UES.Formularios
{
    public partial class FrmInscripciones : Form
    {
        private readonly GestorActividades gestor;

        public FrmInscripciones(GestorActividades gestor)
        {
            this.gestor = gestor;
            InitializeComponent();
            CargarActividades();
        }

        private Actividad ActividadSeleccionada => cboActividad.SelectedItem as Actividad;

        private void cboActividad_SelectedIndexChanged(object sender, EventArgs e) => ActualizarTablas();

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            Actividad actividad = ActividadSeleccionada;
            if (actividad == null)
            {
                MessageBox.Show("Primero registra y selecciona una actividad.");
                return;
            }

            bool correcto = gestor.Inscribir(actividad.Id, txtCarnet.Text,
                txtNombre.Text, out string mensaje);

            MessageBox.Show(mensaje, "Inscripciones", MessageBoxButtons.OK,
                correcto ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (correcto)
            {
                txtCarnet.Clear(); txtNombre.Clear();
                CargarActividades(); ActualizarTablas();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Actividad actividad = ActividadSeleccionada;
            if (actividad == null)
            {
                MessageBox.Show("Selecciona una actividad.");
                return;
            }

            bool correcto = gestor.Cancelar(actividad.Id, txtCarnet.Text, out string mensaje);
            MessageBox.Show(mensaje, "Cancelar inscripción", MessageBoxButtons.OK,
                correcto ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (correcto)
            {
                txtCarnet.Clear(); CargarActividades(); ActualizarTablas();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarActividades();
            ActualizarTablas();
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void CargarActividades()
        {
            int idAnterior = ActividadSeleccionada?.Id ?? -1;
            cboActividad.Items.Clear();
            foreach (Actividad a in gestor.ObtenerActividades()) cboActividad.Items.Add(a);

            for (int i = 0; i < cboActividad.Items.Count; i++)
            {
                if (((Actividad)cboActividad.Items[i]).Id == idAnterior)
                {
                    cboActividad.SelectedIndex = i;
                    return;
                }
            }

            if (cboActividad.Items.Count > 0) cboActividad.SelectedIndex = 0;
            else ActualizarTablas();
        }

        private void ActualizarTablas()
        {
            dgvInscritos.Rows.Clear();
            dgvEspera.Rows.Clear();
            Actividad actividad = ActividadSeleccionada;
            if (actividad == null) return;

            foreach (Estudiante e in actividad.ObtenerInscritos())
                dgvInscritos.Rows.Add(e.Carnet, e.Nombre);

            foreach (SolicitudInscripcion s in actividad.ColaEspera.ObtenerTodas())
                dgvEspera.Rows.Add(s.Estudiante.Carnet, s.Estudiante.Nombre,
                    s.FechaSolicitud.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }
}
