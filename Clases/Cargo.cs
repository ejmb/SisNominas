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
    public class Cargo
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public static List<Cargo> listaCargos = new List<Cargo>();
        public static string discripcionCargo;
        public Cargo()
        {
        }

        public Cargo(int codigo, string descripcion)
        {
            Codigo = codigo;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return this.Descripcion;
        }

        public static bool AgregarCargo(Cargo c)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
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
                return false;
            }
        }

        public static bool ModificarCargo(Cargo c)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
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
                return false;
            }
        }

        public static List<Cargo> ObtenerListaCargos()
        {
            Cargo cargo;
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
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

        public static DataTable ObtenerTableCargos()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = "SELECT * from Cargo";

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

        public static string ObtenerDescripcionCargo(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"SELECT Descripcion_Cargo from Cargo where ID_Cargo = @ID_Cargo";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@ID_Cargo", id);
                    p1.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(p1);

                    SqlDataReader elLectorDeDatos = cmd.ExecuteReader();
                    while (elLectorDeDatos.Read())
                    {
                        discripcionCargo = elLectorDeDatos.GetString(1);
                    }
                }
                return discripcionCargo;
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
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
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
                return false;
            }
        }

    }
}
