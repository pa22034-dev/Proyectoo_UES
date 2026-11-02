using Proyectoo_UES.Modelos;

namespace Proyectoo_UES.Estructuras
{
    // Cada nodo guarda una actividad y la referencia al siguiente nodo.
    public class NodoActividad
    {
        public Actividad Actividad { get; set; }
        public NodoActividad Siguiente { get; set; }

        public NodoActividad(Actividad actividad)
        {
            Actividad = actividad;
            Siguiente = null;
        }
    }
}
