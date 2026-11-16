namespace Proyectoo_UES.Modelos
{
    // Declara la clase pública SolicitudInscripcion para almacenar los datos de un alumno en la cola de espera.
    public class SolicitudInscripcion
    {
        // Propiedad de solo lectura que almacena la información del estudiante asociado a la solicitud.
        public Estudiante Estudiante { get; }
        // Propiedad de solo lectura que almacena la fecha y hora exacta en que se creó la solicitud.
        public DateTime FechaSolicitud { get; }

        // Constructor que recibe el estudiante y registra la fecha/hora actual del sistema.
        public SolicitudInscripcion(Estudiante estudiante)
        {
            // Asigna el estudiante recibido a la propiedad Estudiante.
            Estudiante = estudiante;
            // Asigna la fecha y hora actual del sistema a la propiedad FechaSolicitud.
            FechaSolicitud = DateTime.Now;
        }
    }
}
