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
    public class CargoAscenso
    {
        public int Codigo { get; set; }
        public DateTime FechaCambio { get; set; }
        public Empleado Empleado { get; set; }
        public Cargo CargoSaliente { get; set; }
        public Cargo CargoEntrante { get; set; }
        public int SalarioEntrante { get; set; }

        public CargoAscenso(int codigo, DateTime fechaCambio, Empleado empleado, Cargo cargoSaliente, Cargo cargoEntrante, int salarioEntrante)
        {
            Codigo = codigo;
            FechaCambio = fechaCambio;
            Empleado = empleado;
            CargoSaliente = cargoSaliente;
            CargoEntrante = cargoEntrante;
            SalarioEntrante = salarioEntrante;
        }

        public CargoAscenso()
        {
        }

        public static bool RegistrarCargoAscenso(CargoAscenso ca)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"insert into Historico_Cargo_Empleado (Fecha_Cambio, Empleado_ID, Cargo_Anterior_ID, Cargo_Nuevo_ID, Nuevo_Salario)
                                                                values (@Fecha_Cambio, @Empleado_ID, @Cargo_Anterior_ID, @Cargo_Nuevo_ID, @Nuevo_Salario)";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@Fecha_Cambio", ca.FechaCambio);
                    SqlParameter p2 = new SqlParameter("@Empleado_ID", ca.Empleado.Codigo);
                    SqlParameter p3 = new SqlParameter("@Cargo_Anterior_ID", ca.CargoSaliente.Codigo);
                    SqlParameter p4 = new SqlParameter("@Cargo_Nuevo_ID", ca.CargoEntrante.Codigo);
                    SqlParameter p5 = new SqlParameter("@Nuevo_Salario", ca.SalarioEntrante);
                    p1.SqlDbType = SqlDbType.DateTime;
                    p2.SqlDbType = SqlDbType.Int;
                    p3.SqlDbType = SqlDbType.Int;
                    p4.SqlDbType = SqlDbType.Int;
                    p5.SqlDbType = SqlDbType.Int;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);

                    string textoCmd1 = @"Update Empleado set Cargo_Actual_ID = @Cargo_Actual_ID,  
                                                            Salario_Base_Actual = @Salario_Base_Actual
                                        where ID_Empleado = @ID_Empleado";

                    SqlCommand cmd1 = new SqlCommand(textoCmd1, con);

                    SqlParameter p11 = new SqlParameter("@Cargo_Actual_ID", ca.CargoEntrante.Codigo);
                    SqlParameter p12 = new SqlParameter("@Salario_Base_Actual", ca.SalarioEntrante);
                    SqlParameter p13 = new SqlParameter("@ID_Empleado", ca.Empleado.Codigo);
                    p11.SqlDbType = SqlDbType.Int;
                    p12.SqlDbType = SqlDbType.Int;
                    p13.SqlDbType = SqlDbType.Int;

                    cmd1.Parameters.Add(p11);
                    cmd1.Parameters.Add(p12);
                    cmd1.Parameters.Add(p13);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
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

        public static DataTable ObtenerTablaCargoAscenso()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"SELECT hce.Fecha_Cambio, e.Nro_Documento, c.Descripcion_Cargo as CargoAnterior, ca.Descripcion_Cargo as CargoActual, hce.Nuevo_Salario
                                        from Historico_Cargo_Empleado hce join Empleado e on hce.Empleado_ID = e.ID_Empleado
									                                        join Cargo c on hce.Cargo_Anterior_ID = c.ID_Cargo 
									                                        join Cargo ca on hce.Cargo_Nuevo_ID = ca.ID_Cargo";

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

        public static bool ActualizarEmpleado(Empleado emp)
        {
            return true;
        }
    }
}
