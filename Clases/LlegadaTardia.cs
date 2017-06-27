using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class LlegadaTardia
    {
        public Empleado Empleado { get; set; }
        public double DifHorario { get; set; }
        public DateTime HoraLlegada { get; set; }

        public double CalcularDiferencia(DateTime horaLlegada, DateTime horaLlegadaParam)
        {
            double minutosDif = 0;
            return minutosDif;
        }

        public int ObtenerRegistrosEmpleado(Empleado emp)
        {
            int cantLlegadasTardias = 0;
            return cantLlegadasTardias;
        }
    }
}
