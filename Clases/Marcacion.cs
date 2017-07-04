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
    public class Marcacion
    {
        public long Codigo { get; set; }
        public Empleado Empleado { get; set; }
        public DateTime MarcacionEmpleado { get; set; }

        public static bool RegistrarMarcacion(Marcacion m)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = "select Horario_Entrada, Minutos_Tolerancia from Parametros_Sistema";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                    TimeSpan entrada = new TimeSpan();
                    int tolerancia = 0;
                    while (elLectorDeDatos.Read())
                    {
                        entrada = elLectorDeDatos.GetTimeSpan(0);
                        tolerancia = elLectorDeDatos.GetInt32(1);
                    }

                    elLectorDeDatos.Close();

                    if (m.MarcacionEmpleado.TimeOfDay > entrada.Add(TimeSpan.FromMinutes(tolerancia)))
                    {
                        string textoCmd1 = @"insert into Marcacion (Empleado_ID, Fecha_Hora)
                                                                values (@Empleado_ID, @FechaHora)";

                        SqlCommand cmd1 = new SqlCommand(textoCmd1, con);

                        SqlParameter p1 = new SqlParameter("@Empleado_ID", m.Empleado.Codigo);
                        SqlParameter p2 = new SqlParameter("@FechaHora", m.MarcacionEmpleado);
                        p1.SqlDbType = SqlDbType.Int;
                        p2.SqlDbType = SqlDbType.DateTime;

                        cmd1.Parameters.Add(p1);
                        cmd1.Parameters.Add(p2);

                        TimeSpan diferencia = m.MarcacionEmpleado.TimeOfDay - entrada.Add(TimeSpan.FromMinutes(tolerancia));

                        string textoCmd2 = @"insert into Llegada_Tardia (Empleado_ID, Horas_Minutos_Diferencia)
                                                                values (@Empleado_ID, @Horas_Minutos_Diferencia)";

                        SqlCommand cmd2 = new SqlCommand(textoCmd2, con);

                        SqlParameter p3 = new SqlParameter("@Empleado_ID", m.Empleado.Codigo);
                        SqlParameter p4 = new SqlParameter("@Horas_Minutos_Diferencia", diferencia);
                        p3.SqlDbType = SqlDbType.Int;
                        p4.SqlDbType = SqlDbType.Time;

                        cmd2.Parameters.Add(p3);
                        cmd2.Parameters.Add(p4);

                        try
                        {
                            cmd1.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            return true;
                        }
                        catch (SqlException sqle)
                        {
                            throw sqle;
                            return false;
                        }
                    }

                    string textoCmd3 = @"insert into Marcacion (Empleado_ID, Fecha_Hora)
                                                                values (@Empleado_ID, @FechaHora)";

                    SqlCommand cmd3 = new SqlCommand(textoCmd3, con);

                    SqlParameter p5 = new SqlParameter("@Empleado_ID", m.Empleado.Codigo);
                    SqlParameter p6 = new SqlParameter("@FechaHora", m.MarcacionEmpleado);
                    p5.SqlDbType = SqlDbType.Int;
                    p6.SqlDbType = SqlDbType.DateTime;

                    cmd3.Parameters.Add(p5);
                    cmd3.Parameters.Add(p6);

                    try
                    {
                        cmd3.ExecuteNonQuery();
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

        public static DataTable ObtenerTablaMarcacion()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"SELECT m.Empleado_ID, em.Nombres, em.Apellidos, em.Nro_Documento, m.ID_Marcacion, m.Fecha_Hora
                                        from Marcacion m join Empleado em on m.Empleado_ID = em.ID_Empleado";

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

        public static DataTable ObtenerTablaMarcacionPorEmpleado(int ID_Empleado)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"SELECT m.Empleado_ID, em.Nombres, em.Apellidos, em.Nro_Documento, m.ID_Marcacion, m.Fecha_Hora
                                        from Marcacion m join Empleado em on m.Empleado_ID = em.ID_Empleado
                                        where m.Empleado_ID = @ID_Empleado";

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

        public static bool ModificarMarcacion(Marcacion m)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"Update Marcacion set Empleado_ID = @Empleado_ID, Fecha_Hora = @FechaHora
                                        where ID_Marcacion = @ID_Marcacion";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@Empleado_ID", m.Empleado.Codigo);
                    SqlParameter p2 = new SqlParameter("@FechaHora", m.MarcacionEmpleado);
                    SqlParameter p3 = new SqlParameter("@ID_Marcacion", m.Codigo);
                    p1.SqlDbType = SqlDbType.Int;
                    p2.SqlDbType = SqlDbType.DateTime;
                    p3.SqlDbType = SqlDbType.BigInt;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);

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

        public static bool EliminarMarcacion(Marcacion m)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"Delete from Marcacion 
                                        where ID_Marcacion = @ID_Marcacion";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@ID_Marcacion", m.Codigo);
                    p1.SqlDbType = SqlDbType.BigInt;
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
    }
}
