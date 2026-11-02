using Proyectoo_UES.Modelos;

namespace Proyectoo_UES.Estructuras
{
    // Lista enlazada simple implementada manualmente.
    public class ListaActividades
    {
        private NodoActividad cabeza;
        public int Cantidad { get; private set; }

        public bool Agregar(Actividad actividad)
        {
            if (BuscarPorNombre(actividad.Nombre) != null)
                return false;

            NodoActividad nuevo = new NodoActividad(actividad);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                NodoActividad actual = cabeza;
                while (actual.Siguiente != null)
                    actual = actual.Siguiente;

                actual.Siguiente = nuevo;
            }

            Cantidad++;
            return true;
        }

        public Actividad BuscarPorId(int id)
        {
            NodoActividad actual = cabeza;
            while (actual != null)
            {
                if (actual.Actividad.Id == id)
                    return actual.Actividad;
                actual = actual.Siguiente;
            }
            return null;
        }

        public Actividad BuscarPorNombre(string nombre)
        {
            NodoActividad actual = cabeza;
            while (actual != null)
            {
                if (actual.Actividad.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                    return actual.Actividad;
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool Eliminar(int id)
        {
            NodoActividad actual = cabeza;
            NodoActividad anterior = null;

            while (actual != null)
            {
                if (actual.Actividad.Id == id)
                {
                    if (anterior == null)
                        cabeza = actual.Siguiente;
                    else
                        anterior.Siguiente = actual.Siguiente;

                    Cantidad--;
                    return true;
                }

                anterior = actual;
                actual = actual.Siguiente;
            }

            return false;
        }

        public Actividad[] ObtenerTodas()
        {
            Actividad[] resultado = new Actividad[Cantidad];
            NodoActividad actual = cabeza;
            int i = 0;

            while (actual != null)
            {
                resultado[i++] = actual.Actividad;
                actual = actual.Siguiente;
            }

            return resultado;
        }
    }
}
