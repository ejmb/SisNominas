using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisNominas_Clases
{
    public class ConexionBD
    {
        public static string CadenaConexionBaseDatos = "Data Source = EDUARDO-PC\\SQLEXPRESS; Initial Catalog = Nomina_TP; User ID = sa; Password = Minerva911; MultipleActiveResultSets = True";

        public static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CadenaConexionBaseDatos))
                {
                    con.Open();
                    con.Close();
                    return true;
                }
            }
            catch (Exception ex2)
            {
                return false;
            }
        }
    }
}

