using Proyectoo_UES.Modelos;

namespace Proyectoo_UES.Estructuras
{
    // Cola FIFO propia: primero en entrar, primero en salir.
    public class ColaInscripciones
    {
        private class NodoSolicitud
        {
            public SolicitudInscripcion Solicitud { get; }
            public NodoSolicitud Siguiente { get; set; }

            public NodoSolicitud(SolicitudInscripcion solicitud)
            {
                Solicitud = solicitud;
            }
        }

        private NodoSolicitud frente;
        private NodoSolicitud final;

        public int Cantidad { get; private set; }
        public bool EstaVacia => frente == null;

        public void Encolar(SolicitudInscripcion solicitud)
        {
            NodoSolicitud nuevo = new NodoSolicitud(solicitud);

            if (EstaVacia)
                frente = final = nuevo;
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }

            Cantidad++;
        }

        public SolicitudInscripcion Desencolar()
        {
            if (EstaVacia)
                return null;

            SolicitudInscripcion resultado = frente.Solicitud;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;

            Cantidad--;
            return resultado;
        }

        public SolicitudInscripcion ConsultarFrente()
        {
            return frente?.Solicitud;
        }

        public bool ContieneCarnet(string carnet)
        {
            NodoSolicitud actual = frente;

            while (actual != null)
            {
                if (actual.Solicitud.Estudiante.Carnet.Equals(
                    carnet, StringComparison.OrdinalIgnoreCase))
                    return true;

                actual = actual.Siguiente;
            }

            return false;
        }

        public SolicitudInscripcion[] ObtenerTodas()
        {
            SolicitudInscripcion[] resultado = new SolicitudInscripcion[Cantidad];
            NodoSolicitud actual = frente;
            int i = 0;

            while (actual != null)
            {
                resultado[i++] = actual.Solicitud;
                actual = actual.Siguiente;
            }

            return resultado;
        }

        // Permite cancelar una solicitud que aún está en espera conservando el orden FIFO.
        public bool EliminarPorCarnet(string carnet)
        {
            ColaInscripciones temporal = new ColaInscripciones();
            bool eliminada = false;

            while (!EstaVacia)
            {
                SolicitudInscripcion solicitud = Desencolar();

                if (!eliminada && solicitud.Estudiante.Carnet.Equals(
                    carnet, StringComparison.OrdinalIgnoreCase))
                {
                    eliminada = true;
                }
                else
                {
                    temporal.Encolar(solicitud);
                }
            }

            while (!temporal.EstaVacia)
                Encolar(temporal.Desencolar());

            return eliminada;
        }
    }
}
