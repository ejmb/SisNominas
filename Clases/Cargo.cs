using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Cargo
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public static List<Cargo> listaCargos = new List<Cargo>();

        public Cargo()
        {
        }

        public Cargo(int codigo, string descripcion)
        {
            Codigo = codigo;
            Descripcion = descripcion;
        }

        public static bool AgregarCargo(Cargo c)
        {
            try
            {
                string datosConexion = "Data Source = M201-21; Initial Catalog = Nomina_TP; User ID=sa; Password = @lumno123";

                using (SqlConnection con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();

                    string textoCmd = @"insert into Cargo (Descripcion_Cargo) values (@Descripcion)";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@Descripcion", c.Descripcion);
                    p1.SqlDbType = SqlDbType.VarChar;

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
                //Error
                return false;
            }
        }

        public static bool ModificarCargo(Cargo c)
        {
            try
            {
                string datosConexion = "Data Source = M201-21; Initial Catalog = Nomina_TP; User ID=sa; Password = @lumno123";

                using (SqlConnection con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();

                    string textoCmd = @"Update Cargo set Descripcion_Cargo = @Descripcion
                                        where ID_Cargo = @ID_Cargo";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@Descripcion", c.Descripcion);
                    p1.SqlDbType = SqlDbType.VarChar;
                                        
                    SqlParameter p2 = new SqlParameter("@ID_Cargo", c.Codigo);
                    p2.SqlDbType = SqlDbType.Int;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    
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
                //Error
                return false;
            }
        }

        public static List<Cargo> ObtenerCargos()
        {
            Cargo cargo;
            try
            {
                string datosConexion = "Data Source = M201-21; Initial Catalog = Nomina_TP; User ID=sa; Password = @lumno123";

                using (SqlConnection con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();

                    string textoCmd = "SELECT * from Cargo";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlDataReader elLectorDeDatos = cmd.ExecuteReader();
                    listaCargos.Clear();
                    while (elLectorDeDatos.Read())
                    {
                        cargo = new Cargo();
                        cargo.Codigo = elLectorDeDatos.GetInt32(0);
                        cargo.Descripcion = elLectorDeDatos.GetString(1);

                        listaCargos.Add(cargo);
                    }
                }

                return listaCargos;
            }
            catch (Exception ex2)
            {
                return null;
            }
        }

        public static bool EliminarCargo(Cargo c)
        {
            try
            {
                string datosConexion = "Data Source = M201-21; Initial Catalog = Nomina_TP; User ID=sa; Password = @lumno123";

                using (SqlConnection con = new SqlConnection(datosConexion))
                {
                    con.Open();

                    string textoCmd = @"Delete from Cargo 
                                        where ID_Cargo = @Id_Cargo";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@Id_Cargo", c.Codigo);
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
                //Error
                return false;
            }
        }

    }
}
