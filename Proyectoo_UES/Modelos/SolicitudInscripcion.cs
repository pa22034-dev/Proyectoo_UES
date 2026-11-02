namespace Proyectoo_UES.Modelos
{
    public class SolicitudInscripcion
    {
        public Estudiante Estudiante { get; }
        public DateTime FechaSolicitud { get; }

        public SolicitudInscripcion(Estudiante estudiante)
        {
            Estudiante = estudiante;
            FechaSolicitud = DateTime.Now;
        }
    }
}
