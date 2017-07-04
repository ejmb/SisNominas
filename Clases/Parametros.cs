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
    public class Parametros
    {
        public int Codigo { get; set; }
        public TimeSpan HorarioEntrada { get; set; }
        public TimeSpan HorarioSalida { get; set; }
        public int MinutosTolerancia { get; set; }
        public int CantMaxDiasVacaciones { get; set; }

        public static bool AgregarParametros(Parametros p)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"insert into Parametros_Sistema (Horario_Entrada, Horario_Salida, Minutos_Tolerancia, Cantidad_Maxima_Dias_Vacaciones) 
                                        values (@Entrada, @Salida, @Minutos, @Dias)";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@Entrada", p.HorarioEntrada);
                    SqlParameter p2 = new SqlParameter("@Salida", p.HorarioSalida);
                    SqlParameter p3 = new SqlParameter("@Minutos", p.MinutosTolerancia);
                    SqlParameter p4 = new SqlParameter("@Dias", p.CantMaxDiasVacaciones);

                    p1.SqlDbType = SqlDbType.Time;
                    p2.SqlDbType = SqlDbType.Time;
                    p3.SqlDbType = SqlDbType.Int;
                    p4.SqlDbType = SqlDbType.Int;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException sqle)
                    {
                        throw sqle;
                        return false;
                    }
                }
            }
            catch (Exception ex2)
            {
                throw ex2;
                return false;
            }
        }

        public static bool ModificarParametros(Parametros p)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"Update Parametros_Sistema set Horario_Entrada = @Entrada,
                                                            Horario_Salida = @Salida,
                                                            Minutos_Tolerancia = @Minutos, 
                                                            Cantidad_Maxima_Dias_Vacaciones = @Dias
                                        where ID_Parametro = @ID_Parametro";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@Entrada", p.HorarioEntrada);
                    SqlParameter p2 = new SqlParameter("@Salida", p.HorarioSalida);
                    SqlParameter p3 = new SqlParameter("@Minutos", p.MinutosTolerancia);
                    SqlParameter p4 = new SqlParameter("@Dias", p.CantMaxDiasVacaciones);
                    SqlParameter p5 = new SqlParameter("@ID_Parametro", p.Codigo);

                    p1.SqlDbType = SqlDbType.Time;
                    p2.SqlDbType = SqlDbType.Time;
                    p3.SqlDbType = SqlDbType.Int;
                    p4.SqlDbType = SqlDbType.Int;
                    p5.SqlDbType = SqlDbType.Int;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException sqle)
                    {
                        throw sqle;
                        return false;
                    }
                }
            }
            catch (Exception ex2)
            {
                throw ex2;
                return false;
            }
        }

        public static bool EliminarParametros(Parametros p)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"Delete from Parametros_Sistema 
                                        where ID_Parametro = @ID_Parametro";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@ID_Parametro", p.Codigo);
                    p1.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(p1);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException sqle)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex2)
            {
                return false;
            }
        }

        public static DataTable ObtenerTablaParametros()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = "SELECT * from Parametros_Sistema";

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
    }
}
