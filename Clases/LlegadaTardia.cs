using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SisNominas_Clases;

namespace Clases
{
    public class LlegadaTardia
    {
        public int codigo { get; set; }
        public Empleado Empleado { get; set; }
        public TimeSpan DifHorario { get; set; }

        public static DataTable ObtenerTablaLlegadaTardia()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"SELECT em.Nombres, em.Apellidos, em.Nro_Documento, ll.Horas_Minutos_Diferencia
                                        from Empleado em join Llegada_Tardia ll on em.ID_Empleado = ll.Empleado_ID";

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

        public static DataTable ObtenerTablaLlegadaTardiaPorEmpleado(int ID_Empleado)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionBD.CadenaConexionBaseDatos))
                {
                    con.Open();

                    string textoCmd = @"SELECT em.Nro_Documento as doc, ll.Horas_Minutos_Diferencia as dif
                                        from Empleado em join Llegada_Tardia ll on em.ID_Empleado = ll.Empleado_ID
                                        where ll.Empleado_ID = @ID_Empleado";

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

        public static void GenerarPDF(int idEmpleado)
        {
            System.IO.Directory.CreateDirectory(@"C:\PDF");

            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.A4);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\PDF\LLEGADAS_TARDIAS_ID_"+ idEmpleado + ".pdf", FileMode.Create, FileAccess.ReadWrite));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Llegadas Tardias");
            // Abrimos el archivo
            doc.Open();
            
            // Creamos el tipo de Font que vamos utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Llegadas Tardias"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblEmpleado = new PdfPTable(4);
            tblEmpleado.WidthPercentage = 100;

            //PdfPCell titEmpleado = new PdfPCell(new Phrase("Empleado"));
            //titEmpleado.Colspan = 4;
            //titEmpleado.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right

            // Configuramos el título de las columnas de la tabla
            PdfPCell clCodigo = new PdfPCell(new Phrase("Codigo", _standardFont));
            clCodigo.BorderWidth = 0;
            clCodigo.BorderWidthBottom = 0.75f; 

            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clNroDocumento = new PdfPCell(new Phrase("Nro. Documento", _standardFont));
            clNroDocumento.BorderWidth = 0;
            clNroDocumento.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla.
            //tblEmpleado.AddCell(titEmpleado);
            tblEmpleado.AddCell(clCodigo);
            tblEmpleado.AddCell(clNombre);
            tblEmpleado.AddCell(clApellido);
            tblEmpleado.AddCell(clNroDocumento);

            // Llenamos la tabla con información
            Empleado em = Empleado.ObtenerEmpleadosNroDocumento(idEmpleado);

            clCodigo = new PdfPCell(new Phrase(em.Codigo.ToString(), _standardFont));
            clCodigo.BorderWidth = 0;

            clNombre = new PdfPCell(new Phrase(em.Nombres, _standardFont));
            clNombre.BorderWidth = 0;

            clApellido = new PdfPCell(new Phrase(em.Apellidos, _standardFont));
            clApellido.BorderWidth = 0;

            clNroDocumento = new PdfPCell(new Phrase(em.NroDocumento, _standardFont));
            clNroDocumento.BorderWidth = 0;

            // Añadimos las celdas a la tabla
            tblEmpleado.AddCell(clCodigo);
            tblEmpleado.AddCell(clNombre);
            tblEmpleado.AddCell(clApellido);
            tblEmpleado.AddCell(clNroDocumento);

            //---------------------------------------------------------------------------------------------------------------

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblLlegadasTardias = new PdfPTable(2);
            tblLlegadasTardias.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNroDocumentoTardio = new PdfPCell(new Phrase("Nro. Documento", _standardFont));
            clNroDocumentoTardio.BorderWidth = 0;
            clNroDocumentoTardio.BorderWidthBottom = 0.75f;

            PdfPCell clDiferencia = new PdfPCell(new Phrase("Diferencia", _standardFont));
            clDiferencia.BorderWidth = 0;
            clDiferencia.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblLlegadasTardias.AddCell(clNroDocumentoTardio);
            tblLlegadasTardias.AddCell(clDiferencia);

            // Llenamos la tabla con información
            DataTable dt = ObtenerTablaLlegadaTardiaPorEmpleado(idEmpleado);
            foreach (DataRow row in dt.Rows)
            {
                clNroDocumentoTardio = new PdfPCell(new Phrase(Convert.ToString(row["doc"]), _standardFont));
                clNroDocumentoTardio.BorderWidth = 0;

                clDiferencia = new PdfPCell(new Phrase(Convert.ToString(row["dif"]), _standardFont));
                clDiferencia.BorderWidth = 0;

                tblLlegadasTardias.AddCell(clNroDocumentoTardio);
                tblLlegadasTardias.AddCell(clDiferencia);
            }

            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(tblEmpleado);
            doc.Add(tblLlegadasTardias);

            doc.Close();
            writer.Close();

            System.Diagnostics.Process.Start(@"C:\PDF\LLEGADAS_TARDIAS_ID_" + idEmpleado + ".pdf");
        }
    }
}
