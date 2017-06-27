using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public enum TipoDocumento
    {
        CI,
        DNI,
        Pasaporte
    };

    public class Empleado
    {
        public int Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NroDocumento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string NroCelular { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Cargo CargoActual { get; set; }
        public double DiasVacacionesAcumuladas { get; set; }
        public double DiasLibresAFavor { get; set; }
        public string Estado { get; set; }
        public decimal SalarioBaseActual { get; set; }

        public Empleado()
        {
        }

        public Empleado(int codigo, string nombres, string apellidos, string nroDocumento, TipoDocumento tipoDocumento, string nroCelular, DateTime fechaIngreso, Cargo cargoActual, double diasVacacionesAcumuladas, double diasLibresAFavor, string estado, decimal salarioBaseActual)
        {
            Codigo = codigo;
            Nombres = nombres;
            Apellidos = apellidos;
            NroDocumento = nroDocumento;
            TipoDocumento = tipoDocumento;
            NroCelular = nroCelular;
            FechaIngreso = fechaIngreso;
            CargoActual = cargoActual;
            DiasVacacionesAcumuladas = diasVacacionesAcumuladas;
            DiasLibresAFavor = diasLibresAFavor;
            Estado = estado;
            SalarioBaseActual = salarioBaseActual;
        }

        public void AgregarEmpleado()
        {
            
        }

        public void ModificarEmpleado()
        {
            
        }

        public void ObtenerEmpleados()
        {
            
        }

        public void DesvincularEmpleado()
        {
            
        }

        public double GenerarVacaciones(Empleado emp, DateTime fechaIngreso)
        {
            double DiasVaciones = 0;
            return DiasVaciones;
        }
    }
}
