using Proyectoo_UES.Estructuras;
using Proyectoo_UES.Modelos;

namespace Proyectoo_UES.Modelos
{
    public class Actividad
    {
        public int Id { get; }
        public string Nombre { get; }
        public string Descripcion { get; }
        public DateTime Fecha { get; }
        public string Lugar { get; }

        // El arreglo representa los cupos físicos disponibles para esta actividad.
        private readonly Estudiante[] cupos;

        // Cada actividad administra su propia cola de espera.
        public ColaInscripciones ColaEspera { get; } = new ColaInscripciones();

        public int Capacidad => cupos.Length;
        public int Inscritos => cupos.Count(e => e != null);
        public int CuposDisponibles => Capacidad - Inscritos;
        public int EnEspera => ColaEspera.Cantidad;

        public Actividad(int id, string nombre, string descripcion,
                         DateTime fecha, string lugar, int capacidad)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Fecha = fecha;
            Lugar = lugar;
            cupos = new Estudiante[capacidad];
        }

        public bool EstaInscrito(string carnet)
        {
            return cupos.Any(e => e != null &&
                e.Carnet.Equals(carnet, StringComparison.OrdinalIgnoreCase));
        }

        public bool EstaEnEspera(string carnet)
        {
            return ColaEspera.ContieneCarnet(carnet);
        }

        public bool AgregarEstudiante(Estudiante estudiante)
        {
            // Evita duplicados incluso si el método se llama desde otro lugar.
            if (EstaInscrito(estudiante.Carnet) || EstaEnEspera(estudiante.Carnet))
                return false;

            for (int i = 0; i < cupos.Length; i++)
            {
                if (cupos[i] == null)
                {
                    cupos[i] = estudiante;
                    return true;
                }
            }

            return false; // No había posiciones libres.
        }

        public bool CancelarInscripcion(string carnet, out Estudiante estudianteCancelado)
        {
            estudianteCancelado = null;

            for (int i = 0; i < cupos.Length; i++)
            {
                if (cupos[i] != null &&
                    cupos[i].Carnet.Equals(carnet, StringComparison.OrdinalIgnoreCase))
                {
                    estudianteCancelado = cupos[i];
                    cupos[i] = null; // Libera el cupo.
                    return true;
                }
            }

            return false;
        }

        public Estudiante[] ObtenerInscritos()
        {
            return cupos.Where(e => e != null).ToArray();
        }

        public Estudiante[] ObtenerCupos()
        {
            // Devuelve una copia para que la interfaz no modifique el arreglo original.
            return (Estudiante[])cupos.Clone();
        }

        public override string ToString()
        {
            return $"{Id} - {Nombre} ({CuposDisponibles} cupos libres)";
        }
    }
}
