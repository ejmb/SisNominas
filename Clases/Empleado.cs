using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
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

        public static DataTable ObtenerTablaEmpleados()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = "SELECT * from Empleado  e join Cargo c on e.Cargo_Actual_ID = c.ID_Cargo";

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

        public static Empleado ObtenerEmpleadosNroDocumento(int idEmpleado)
        {
            Empleado em = new Empleado();
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = "SELECT ID_Empleado, Nombres, Apellidos, Nro_Documento from Empleado  where ID_Empleado = @ID_Empleado";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlParameter p1 = new SqlParameter("@ID_Empleado", idEmpleado);
                    p1.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(p1);

                    SqlDataReader elLectorDeDatos = cmd.ExecuteReader();
                    while (elLectorDeDatos.Read())
                    {
                        em.Codigo = elLectorDeDatos.GetInt32(0);
                        em.Nombres = elLectorDeDatos.GetString(1);
                        em.Apellidos = elLectorDeDatos.GetString(2);
                        em.NroDocumento = elLectorDeDatos.GetString(3);
                    }
                    return em;
                }
            }
            catch (Exception ex2)
            {
                return null;
            }
        }

        public static void GenerarVacaciones()
        {
            DateTime fechaActual = DateTime.Today;
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    //Parametros
                    string textoCmd = "select Cantidad_Maxima_Dias_Vacaciones from Parametros_Sistema";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                    int maxVacaciones = 0;
                    while (elLectorDeDatos.Read())
                    {
                        maxVacaciones = elLectorDeDatos.GetInt32(0);
                    }
                    elLectorDeDatos.Close();

                    //Empleado
                    string textoCmd1 = "select ID_Empleado, Fecha_Ingreso, Dias_Vacaciones_Acumulados from Empleado";
                    SqlCommand cmd1 = new SqlCommand(textoCmd1, con);
                    SqlDataReader elLectorDeDatos1 = cmd1.ExecuteReader();

                    while (elLectorDeDatos1.Read())
                    {
                        var codEmpleado = elLectorDeDatos1.GetInt32(0);
                        var fechaIngreso = elLectorDeDatos1.GetDateTime(1).Date;
                        var vacacionesAcumuladas = elLectorDeDatos1.GetInt32(2);

                        var antiguedadMeses = fechaActual.Subtract(fechaIngreso).Days / (365.2425 / 12);
                        var cont = 0;

                        while (cont <= antiguedadMeses && antiguedadMeses <= maxVacaciones && vacacionesAcumuladas < antiguedadMeses)
                        {
                            string textoCmd2 = @"Update Empleado set Dias_Vacaciones_Acumulados = @Dias_Vacaciones_Acumulados
                                                where ID_Empleado = @ID_Empleado";

                            SqlCommand cmd2 = new SqlCommand(textoCmd2, con);

                            SqlParameter p1 = new SqlParameter("@Dias_Vacaciones_Acumulados", vacacionesAcumuladas + 1);
                            SqlParameter p2 = new SqlParameter("@ID_Empleado", codEmpleado);

                            p1.SqlDbType = SqlDbType.Int;
                            p2.SqlDbType = SqlDbType.Int;

                            cmd2.Parameters.Add(p1);
                            cmd2.Parameters.Add(p2);

                            try
                            {
                                cmd2.ExecuteNonQuery();
                               // return true;
                            }
                            catch (SqlException sqle)
                            {
                                throw sqle;
                               // return false;
                            }
                            cont += 1;
                        }
                    }
                }
            }
            catch (Exception ex2)
            {
                throw ex2;
                //return false;
            }
        }

        public static void GenerarPDF()
        {
            System.IO.Directory.CreateDirectory(@"C:\PDF");

            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.A4);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\PDF\LIQUIDACION_SALARIAL_" + DateTime.Today.Month +"_"+ DateTime.Today.Year +".pdf", FileMode.Create, FileAccess.ReadWrite));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Liquidacion Salarial");
            // Abrimos el archivo
            doc.Open();

            // Creamos el tipo de Font que vamos utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Liquidacion Salarial "+DateTime.Today.ToString("MMMM", CultureInfo.InvariantCulture)));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblEmpleado = new PdfPTable(5);
            tblEmpleado.WidthPercentage = 100;

           // Configuramos el título de las columnas de la tabla
            PdfPCell clCodigo = new PdfPCell(new Phrase("Codigo", _standardFont));
            clCodigo.BackgroundColor = new BaseColor(159, 159, 159);
            //clCodigo.BorderWidth = 0;
            //clCodigo.BorderWidthBottom = 0.75f;

            PdfPCell clNroDocumento = new PdfPCell(new Phrase("Nro. Documento", _standardFont));
            clNroDocumento.BackgroundColor = new BaseColor(159, 159, 159);
            //clNroDocumento.BorderWidth = 0;
            //clNroDocumento.BorderWidthBottom = 0.75f;

            PdfPCell clSalarioBruto = new PdfPCell(new Phrase("Salario Bruto", _standardFont));
            clSalarioBruto.BackgroundColor = new BaseColor(159, 159, 159);
            //clSalarioBruto.BorderWidth = 0;
            //clSalarioBruto.BorderWidthBottom = 0.75f;
            clSalarioBruto.HorizontalAlignment = 1;

            PdfPCell clDescuentoIps = new PdfPCell(new Phrase("Descuento IPS (9%)", _standardFont));
            clDescuentoIps.BackgroundColor = new BaseColor(159, 159, 159);
            //clDescuentoIps.BorderWidth = 0;
            //clDescuentoIps.BorderWidthBottom = 0.75f;
            clDescuentoIps.HorizontalAlignment = 1;

            PdfPCell clSalarioNeto = new PdfPCell(new Phrase("Salario Neto", _standardFont));
            clSalarioNeto.BackgroundColor = new BaseColor(159, 159, 159);
            //clSalarioNeto.BorderWidth = 0;
            //clSalarioNeto.BorderWidthBottom = 0.75f;
            clSalarioNeto.HorizontalAlignment = 1;

            // Añadimos las celdas a la tabla.
            //tblEmpleado.AddCell(titEmpleado);
            tblEmpleado.AddCell(clCodigo);
            tblEmpleado.AddCell(clNroDocumento);
            tblEmpleado.AddCell(clSalarioBruto);
            tblEmpleado.AddCell(clDescuentoIps);
            tblEmpleado.AddCell(clSalarioNeto);

            // Llenamos la tabla con información
            int totalSalarioBase = 0;
            int totalDescuento = 0;
            int totalSalarioNeto = 0;
            DataTable dt = ObtenerTablaEmpleados();
            foreach (DataRow row in dt.Rows)
            {
                PdfPCell clCodigo1 = new PdfPCell(new Phrase(Convert.ToString(row["ID_Empleado"]), _standardFont));
                clCodigo1.BorderWidth = 0;
                //clCodigo1.BorderWidthBottom = 0.75f;

                PdfPCell clNroDocumento1 = new PdfPCell(new Phrase(Convert.ToString(row["Nro_Documento"]), _standardFont));
                clNroDocumento1.BorderWidth = 0;
                //clNroDocumento1.BorderWidthBottom = 0.75f;

                PdfPCell clSalarioBruto1 = new PdfPCell(new Phrase(Convert.ToString(row["Salario_Base_Actual"]), _standardFont));
                clSalarioBruto1.BorderWidth = 0;
                clSalarioBruto1.HorizontalAlignment = 2;
                //clSalarioBruto1.BorderWidthBottom = 0.75f;

                int salarioBase = (int)row["Salario_Base_Actual"];
                int descuento = (salarioBase * 9)/100;
                int salarioNeto = salarioBase - descuento;

                totalSalarioBase = totalSalarioBase + salarioBase;
                totalDescuento = totalDescuento + descuento;
                totalSalarioNeto = totalSalarioNeto + salarioNeto;

                PdfPCell clDescuentoIps1 = new PdfPCell(new Phrase(Convert.ToString(descuento), _standardFont));
                clDescuentoIps1.BorderWidth = 0;
                clDescuentoIps1.HorizontalAlignment = 2;
                //clDescuentoIps1.BorderWidthBottom = 0.75f;

                PdfPCell clSalarioNeto1 = new PdfPCell(new Phrase(Convert.ToString(salarioNeto), _standardFont));
                clSalarioNeto1.BorderWidth = 0;
                clSalarioNeto1.HorizontalAlignment = 2;
                //clSalarioNeto1.BorderWidthBottom = 0.75f;

                // Añadimos las celdas a la tabla.
                //tblEmpleado.AddCell(titEmpleado);
                tblEmpleado.AddCell(clCodigo1);
                tblEmpleado.AddCell(clNroDocumento1);
                tblEmpleado.AddCell(clSalarioBruto1);
                tblEmpleado.AddCell(clDescuentoIps1);
                tblEmpleado.AddCell(clSalarioNeto1);
            }

            //PdfPCell clCodigo2 = new PdfPCell(new Phrase("", _standardFont));
            //clCodigo.BorderWidth = 0;
            //clCodigo.BorderWidthBottom = 0.75f;

            //PdfPCell clNroDocumento2 = new PdfPCell(new Phrase("", _standardFont));
            //clNroDocumento.BorderWidth = 0;
            //clNroDocumento.BorderWidthBottom = 0.75f;

            PdfPCell clCodigo2 = new PdfPCell(new Phrase("TOTALES", _standardFont));
            //clCodigo2.BorderWidth = 0;
            //clCodigo2.BorderWidthBottom = 0.75f;
            clCodigo2.Colspan = 2;
            clCodigo2.HorizontalAlignment = 1;
            clCodigo2.BackgroundColor = new BaseColor(159, 159, 159);

            PdfPCell clSalarioBruto2 = new PdfPCell(new Phrase(Convert.ToString(totalSalarioBase), _standardFont));
            clSalarioBruto2.HorizontalAlignment = 2;
            //clSalarioBruto2.BorderWidth = 0;
            //clSalarioBruto2.BorderWidthBottom = 0.75f;

            PdfPCell clDescuentoIps2 = new PdfPCell(new Phrase(Convert.ToString(totalDescuento), _standardFont));
            clDescuentoIps2.HorizontalAlignment = 2;
            //clDescuentoIps2.BorderWidth = 0;
            //clDescuentoIps2.BorderWidthBottom = 0.75f;

            PdfPCell clSalarioNeto2 = new PdfPCell(new Phrase(Convert.ToString(totalSalarioNeto), _standardFont));
            clSalarioNeto2.HorizontalAlignment = 2;
            //clSalarioNeto2.BorderWidth = 0;
            //clSalarioNeto2.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla.
            //tblEmpleado.AddCell(titEmpleado);
            tblEmpleado.AddCell(clCodigo2);
            //tblEmpleado.AddCell(clNroDocumento2);
            tblEmpleado.AddCell(clSalarioBruto2);
            tblEmpleado.AddCell(clDescuentoIps2);
            tblEmpleado.AddCell(clSalarioNeto2);

            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(tblEmpleado);

            doc.Close();
            writer.Close();

            System.Diagnostics.Process.Start(@"C:\PDF\LIQUIDACION_SALARIAL_" + DateTime.Today.Month + "_" + DateTime.Today.Year + ".pdf");
        }
    }
}
