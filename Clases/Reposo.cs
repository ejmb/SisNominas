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
    public class Reposo
    {  
        public int codigo { get; set; }
        public Empleado Empleado { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaInicial { get; set; }
        public int CantDiasReposo { get; set; }

        public static bool AgregarReposo(Reposo r)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"insert into Reposo (Empleado_ID, Motivo, Fecha_Desde, Cantidad_Dias) 
                                        values (@Empleado_ID, @Motivo, @FechaDesde, @CantDias)";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@Empleado_ID", r.Empleado.Codigo);
                    SqlParameter p2 = new SqlParameter("@Motivo", r.Observacion);
                    SqlParameter p3 = new SqlParameter("@FechaDesde", r.FechaInicial);
                    SqlParameter p4 = new SqlParameter("@CantDias", r.CantDiasReposo);

                    p1.SqlDbType = SqlDbType.Int;
                    p2.SqlDbType = SqlDbType.VarChar;
                    p3.SqlDbType = SqlDbType.DateTime;
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
                        //throw sqle;
                        return false;
                    }
                }
            }
            catch (Exception ex2)
            {
                //throw ex2;
                return false;
            }
        }

        public static bool ModificarReposo(Reposo r)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"Update Reposo set Empleado_ID = @Empleado_ID,
                                                            Motivo = @Motivo,
                                                            Fecha_Desde = @Fecha_Desde, 
                                                            Cantidad_Dias = @Cantidad_Dias
                                        where ID_Reposo = @ID_Reposo";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@Empleado_ID", r.Empleado.Codigo);
                    SqlParameter p2 = new SqlParameter("@Motivo", r.Observacion);
                    SqlParameter p3 = new SqlParameter("@Fecha_Desde", r.FechaInicial);
                    SqlParameter p4 = new SqlParameter("@Cantidad_Dias", r.CantDiasReposo);
                    SqlParameter p5 = new SqlParameter("@ID_Reposo", r.codigo);

                    p1.SqlDbType = SqlDbType.Int;
                    p2.SqlDbType = SqlDbType.VarChar;
                    p3.SqlDbType = SqlDbType.DateTime;
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
                        //throw sqle;
                        return false;
                    }
                }
            }
            catch (Exception ex2)
            {
                //throw ex2;
                return false;
            }
        }

        public static DataTable ObtenerTablaReposo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"SELECT e.Nombres as Nombre, 
                                                e.Apellidos as Apellido, 
		                                        e.Nro_Documento as Documento,
		                                        r.Fecha_Desde as Fecha,
		                                        r.Cantidad_Dias as CantDias,
		                                        r.Motivo
                                        from Reposo r
                                        join Empleado e on r.Empleado_ID = e.ID_Empleado";

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

        public static DataTable ObtenerTablaReposoPorEmpleado(int ID_Empleado)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"SELECT  e.ID_Empleado,
                                                e.Nombres as Nombre, 
                                                e.Apellidos as Apellido, 
		                                        e.Nro_Documento as Documento,
                                                r.ID_Reposo,
		                                        r.Fecha_Desde as Fecha,
		                                        r.Cantidad_Dias as CantDias,
		                                        r.Motivo
                                        from Reposo r
                                        join Empleado e on r.Empleado_ID = e.ID_Empleado
                                        where r.Empleado_ID = @ID_Empleado";

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

        public static bool EliminarReposo(Reposo r)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"Delete from Reposo 
                                        where ID_Reposo = @ID_Reposo";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@ID_Reposo", r.codigo);
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
    }
}
