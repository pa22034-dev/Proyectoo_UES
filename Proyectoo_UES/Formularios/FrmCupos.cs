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
    public partial class FrmCupos : Form
    {
        private readonly GestorActividades gestor;

public FrmCupos(GestorActividades gestor)
{
    this.gestor = gestor;
            InitializeComponent();
            ActualizarTabla();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void ActualizarTabla()
        {
            dgvCupos.Rows.Clear();
            foreach (Actividad a in gestor.ObtenerActividades())
                dgvCupos.Rows.Add(a.Id, a.Nombre, a.Fecha.ToString("dd/MM/yyyy"),
                    a.Capacidad, a.Inscritos, a.CuposDisponibles, a.EnEspera);
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            using (FrmActividades ventana = new FrmActividades(gestor))
                ventana.ShowDialog(this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
