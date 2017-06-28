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
    public enum TipoDocumento
    {
        CI,
        DNI,
        Pasaporte
    };

    public enum Estado
    {
        ACTIVO,
        INACTIVO
    };

    public class Empleado
    {
        public int Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string NroDocumento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string NroCelular { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Cargo CargoActual { get; set; }
        public int DiasVacacionesAcumuladas { get; set; }
        public int DiasLibresAFavor { get; set; }
        public Estado Estado { get; set; }
        public int SalarioBaseActual { get; set; }

        public Empleado()
        {
        }

        public Empleado(int codigo, string nombres, string apellidos, string direccion, string nroDocumento, TipoDocumento tipoDocumento, string nroCelular, DateTime fechaIngreso, Cargo cargoActual, int diasVacacionesAcumuladas, int diasLibresAFavor, Estado estado, int salarioBaseActual)
        {
            Codigo = codigo;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
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

        public override string ToString()
        {
            return this.NroDocumento;
        }

        public static bool AgregarEmpleado(Empleado e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"insert into Empleado (Nombres, Apellidos, Direccion, Nro_Documento, Tipo_Documento, Nro_Celular, Fecha_Ingreso, 
                                                            Cargo_Actual_ID, Dias_Vacaciones_Acumulados, Dias_Libres_Acumulados, Estado, Salario_Base_Actual) 
                                        values (@Nombres, @Apellidos, @Direccion, @Nro_Documento, @Tipo_Documento, @Nro_Celular, @Fecha_Ingreso, 
                                                @Cargo_Actual_ID, @Dias_Vacaciones_Acumulados, @Dias_Libres_Acumulados, @Estado, @Salario_Base_Actual)";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@Nombres", e.Nombres);
                    SqlParameter p2 = new SqlParameter("@Apellidos", e.Apellidos);
                    SqlParameter p3 = new SqlParameter("@Direccion", e.Direccion);
                    SqlParameter p4 = new SqlParameter("@Nro_Documento", e.NroDocumento);
                    SqlParameter p5 = new SqlParameter("@Tipo_Documento", e.TipoDocumento);
                    SqlParameter p6 = new SqlParameter("@Nro_Celular", e.NroCelular);
                    SqlParameter p7 = new SqlParameter("@Fecha_Ingreso", e.FechaIngreso);
                    SqlParameter p8 = new SqlParameter("@Cargo_Actual_ID", e.CargoActual.Codigo);
                    SqlParameter p9 = new SqlParameter("@Dias_Vacaciones_Acumulados", 0);
                    SqlParameter p10 = new SqlParameter("@Dias_Libres_Acumulados", 0);
                    SqlParameter p11 = new SqlParameter("@Estado", "ACTIVO");
                    SqlParameter p12 = new SqlParameter("@Salario_Base_Actual", e.SalarioBaseActual);

                    p1.SqlDbType = SqlDbType.VarChar;
                    p2.SqlDbType = SqlDbType.VarChar;
                    p3.SqlDbType = SqlDbType.VarChar;
                    p4.SqlDbType = SqlDbType.VarChar;
                    p5.SqlDbType = SqlDbType.VarChar;
                    p6.SqlDbType = SqlDbType.VarChar;
                    p7.SqlDbType = SqlDbType.DateTime;
                    p8.SqlDbType = SqlDbType.Int;
                    p9.SqlDbType = SqlDbType.Int;
                    p10.SqlDbType = SqlDbType.Int;
                    p11.SqlDbType = SqlDbType.VarChar;
                    p12.SqlDbType = SqlDbType.Int;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);
                    cmd.Parameters.Add(p6);
                    cmd.Parameters.Add(p7);
                    cmd.Parameters.Add(p8);
                    cmd.Parameters.Add(p9);
                    cmd.Parameters.Add(p10);
                    cmd.Parameters.Add(p11);
                    cmd.Parameters.Add(p12);

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

        public static bool ModificarEmpleado(Empleado em)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"Update Empleado set Nombres = @Nombres,
                                                            Apellidos = @Apellidos,
                                                            Direccion = @Direccion, 
                                                            Nro_Documento = @Nro_Documento, 
                                                            Tipo_Documento = @Tipo_Documento,
                                                            Nro_Celular = @Nro_Celular,
                                                            Fecha_Ingreso = @Fecha_Ingreso,
                                                            Cargo_Actual_ID = @Cargo_Actual_ID, 
                                                            Dias_Vacaciones_Acumulados = @Dias_Vacaciones_Acumulados,                                            
                                                            Dias_Libres_Acumulados = @Dias_Libres_Acumulados, 
                                                            Estado = @Estado, 
                                                            Salario_Base_Actual = @Salario_Base_Actual
                                        where ID_Empleado = @ID_Empleado";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@Nombres", em.Nombres);
                    SqlParameter p2 = new SqlParameter("@Apellidos", em.Apellidos);
                    SqlParameter p3 = new SqlParameter("@Direccion", em.Direccion);
                    SqlParameter p4 = new SqlParameter("@Nro_Documento", em.NroDocumento);
                    SqlParameter p5 = new SqlParameter("@Tipo_Documento", em.TipoDocumento);
                    SqlParameter p6 = new SqlParameter("@Nro_Celular", em.NroCelular);
                    SqlParameter p7 = new SqlParameter("@Fecha_Ingreso", em.FechaIngreso);
                    SqlParameter p8 = new SqlParameter("@Cargo_Actual_ID", em.CargoActual.Codigo);
                    SqlParameter p9 = new SqlParameter("@Dias_Vacaciones_Acumulados", em.DiasVacacionesAcumuladas);
                    SqlParameter p10 = new SqlParameter("@Dias_Libres_Acumulados", em.DiasLibresAFavor);
                    SqlParameter p11 = new SqlParameter("@Estado", em.Estado);
                    SqlParameter p12 = new SqlParameter("@Salario_Base_Actual", em.SalarioBaseActual);
                    SqlParameter p13 = new SqlParameter("@ID_Empleado", em.Codigo);

                    p1.SqlDbType = SqlDbType.VarChar;
                    p2.SqlDbType = SqlDbType.VarChar;
                    p3.SqlDbType = SqlDbType.VarChar;
                    p4.SqlDbType = SqlDbType.VarChar;
                    p5.SqlDbType = SqlDbType.VarChar;
                    p6.SqlDbType = SqlDbType.VarChar;
                    p7.SqlDbType = SqlDbType.DateTime;
                    p8.SqlDbType = SqlDbType.Int;
                    p9.SqlDbType = SqlDbType.Int;
                    p10.SqlDbType = SqlDbType.Int;
                    p11.SqlDbType = SqlDbType.VarChar;
                    p12.SqlDbType = SqlDbType.Int;
                    p12.SqlDbType = SqlDbType.Int;
                    p13.SqlDbType = SqlDbType.Int;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);
                    cmd.Parameters.Add(p6);
                    cmd.Parameters.Add(p7);
                    cmd.Parameters.Add(p8);
                    cmd.Parameters.Add(p9);
                    cmd.Parameters.Add(p10);
                    cmd.Parameters.Add(p11);
                    cmd.Parameters.Add(p12);
                    cmd.Parameters.Add(p13);

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

        public static DataTable ObtenerTablaEmpleados()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = "SELECT * from Empleado";

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
       
        public double GenerarVacaciones(Empleado emp, DateTime fechaIngreso)
        {
            double DiasVaciones = 0;
            return DiasVaciones;
        }
    }
}
