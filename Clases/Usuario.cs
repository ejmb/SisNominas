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
    public class Usuario
    {
        public int codigo { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }

        public static bool Autenticar(string usuario, string password)
        {
            ////Definir la cadena de conexion: Servidor, base de datos, usuario y contrasenha..
            //string cadenaConexion = "Data Source = M201-21; Initial Catalog = Nomina_TP; User ID=sa; Password = @lumno123";

            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos)) //Crear un objeto SqlConnection
                {
                    //Abrir la conexión
                    con.Open();

                    //Query que se ejecutara en el servidor de base de datos...
                    string textoCmd = "SELECT Usuario, Clave from Usuario where Usuario = @Usuario and Clave = @SuPassword";

                    //Creamos un objeto comando que es el que 'ejecutara' el comando sql, utilizando la conexion creada..
                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    //Agregamos el parametro de usuario
                    SqlParameter p1 = new SqlParameter("@Usuario", usuario.Trim());
                    p1.SqlDbType = SqlDbType.VarChar; //indicamos el tipo de dato del parametro

                    //Agregamos el parametro password
                    SqlParameter p2 = new SqlParameter("@SuPassword", password.Trim());
                    p2.SqlDbType = SqlDbType.VarChar; //indicamos el tipo de dato del parametro

                    //asignamos los parametros al objeto comando
                    cmd.Parameters.Add(p1); //parametro usuario
                    cmd.Parameters.Add(p2); //parametro password

                    //Ejecutar el comando
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader(); //Ejecutamos y guardamos el resultado en el reader

                        if (reader.HasRows) //Preguntamos si hay filas de retorno (si hay resultset)
                        {
                            reader.Close(); //Cerramos la conexion                                                                                    
                            return true; //Retornamos true, porque encontro un usuario y contrasenha que coincide en la base de datos..
                        }
                        else
                        {
                            reader.Close(); //Cerramos la conexion                                                     
                            return false; //retornamos falsse, porque no habia ninguna combinacion de usuario y password en la base de datos..
                        }
                    }
                    catch (SqlException sqle)
                    {
                        throw sqle;
                    }
                }
            }
            catch (Exception ex2)
            {
                throw ex2;
            }

        }
    }
}
