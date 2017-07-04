using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisNominas_Clases;

namespace Clases
{
    public class LlegadaTardia
    {
        public int codigo { get; set; }
        public Empleado Empleado { get; set; }
        public TimeSpan DifHorario { get; set; }

        public static DataTable ObtenerTablaLlegadaTardia()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"SELECT em.Nombres, em.Apellidos, em.Nro_Documento, ll.Horas_Minutos_Diferencia
                                        from Empleado em join Llegada_Tardia ll on em.ID_Empleado = ll.Empleado_ID";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    DataTable datos = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(datos);

                    return datos;
                }
            }
            catch (Exception ex2)
            {
                return null;
            }
        }

        public static DataTable ObtenerTablaLlegadaTardiaPorEmpleado(int ID_Empleado)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"SELECT em.Nombres, em.Apellidos, em.Nro_Documento, ll.Horas_Minutos_Diferencia
                                        from Empleado em join Llegada_Tardia ll on em.ID_Empleado = ll.Empleado_ID
                                        where ll.Empleado_ID = ID_Empleado";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    SqlParameter p1 = new SqlParameter("@ID_Empleado", ID_Empleado);
                    p1.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(p1);

                    DataTable datos = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(datos);

                    return datos;
                }
            }
            catch (Exception ex2)
            {
                return null;
            }
        }

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
