using Proyectoo_UES.Formularios;
using Proyectoo_UES.Servicios;

namespace Proyectoo_UES
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Se crea un solo gestor para compartir los datos entre los formularios.
            GestorActividades gestor = new GestorActividades();
            Application.Run(new FrmPrincipal(gestor));
        }
    }
}