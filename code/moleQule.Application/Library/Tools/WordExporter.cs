using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.IO;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction;
using moleQule.Library.Quality;


namespace moleQule.Library.Application.Tools
{
    public class WordExporter : moleQule.Library.WordExporter
    {

        #region Business Methods

        public void ExportInformeAuditoria(AuditoriaPrint auditoria)
        {
            string extension = string.Empty;

            Word.Document oDoc = NewDocument();
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            Word.Paragraph oParaAux;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oParaAux = oDoc.Content.Paragraphs.Add(ref oRng);
            oParaAux.Range.Text = string.Empty;
            oParaAux.Range.InsertParagraph();
            oParaAux.Range.InsertParagraph();

            //Título
            Word.Table oTableTitulo;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableTitulo = oDoc.Tables.Add(wrdRng, 1, 1, ref oMissing, ref oMissing);

            oTableTitulo.Range.ParagraphFormat.SpaceAfter = 6;
            oTableTitulo.Range.ParagraphFormat.SpaceBefore = 6;

            oTableTitulo.Borders.Enable = 1;
            oTableTitulo.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableTitulo.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            oTableTitulo.Cell(1, 1).Range.Text = auditoria.NumeroClaseAuditoria + ".- " + auditoria.NombreClaseAuditoriaUpper;
            oTableTitulo.Cell(1, 1).Range.Font.Size = 14;
            oTableTitulo.Cell(1, 1).Range.Font.Name = "Arial";
            oTableTitulo.Cell(1, 1).Range.Font.Bold = 1;
            oTableTitulo.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Subtítulo
            Word.Paragraph oParaSubTitulo;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oParaSubTitulo = oDoc.Content.Paragraphs.Add(ref oRng);
            oParaSubTitulo.Range.Text = auditoria.CodigoTipoAuditoria + " " + auditoria.NombreTipoAuditoriaUpper;
            oParaSubTitulo.Range.Font.Size = 12;
            oParaSubTitulo.Range.Font.Name = "Arial";
            oParaSubTitulo.Range.Font.Bold = 1;
            oParaSubTitulo.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Tabla datos
            Word.Table oTableDatos;
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableDatos = oDoc.Tables.Add(wrdRng, 2, 2, ref oMissing, ref oMissing);
            oTableDatos.Range.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;
            oTableDatos.Range.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;

            oTableDatos.Columns[1].Width = 250F;
            oTableDatos.Columns[2].Width = 250F;

            oTableDatos.Range.ParagraphFormat.SpaceAfter = 6;
            oTableDatos.Range.ParagraphFormat.SpaceBefore = 6;

            oTableDatos.Borders.Enable = 1;
            oTableDatos.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            oTableDatos.Cell(1, 1).Range.Text = Environment.NewLine + "Auditoría Nº: " +
                auditoria.Referencia + " (" + auditoria.CodigoTipoAuditoria + ") " + auditoria.NombreTipoAuditoriaUpper + 
                Environment.NewLine;
            oTableDatos.Cell(1, 1).Range.Font.Size = 12;
            oTableDatos.Cell(1, 1).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(1, 1).Range.Font.Bold = 1;
            oTableDatos.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTableDatos.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(1, 2).Range.Text = Environment.NewLine + "Efectuada por: " +
                auditoria.Auditor + Environment.NewLine;
            oTableDatos.Cell(1, 2).Range.Font.Size = 12;
            oTableDatos.Cell(1, 2).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(1, 2).Range.Font.Bold = 1;
            oTableDatos.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTableDatos.Cell(1, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(2, 1).Range.Text = Environment.NewLine + "Fecha de inicio: " +
                auditoria.FechaInicioString + Environment.NewLine;
            oTableDatos.Cell(2, 1).Range.Font.Size = 12;
            oTableDatos.Cell(2, 1).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(2, 1).Range.Font.Bold = 1;
            oTableDatos.Cell(2, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTableDatos.Cell(2, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(2, 2).Range.Text = Environment.NewLine + "Fecha de finalización: " +
                auditoria.FechaFinString + Environment.NewLine;
            oTableDatos.Cell(2, 2).Range.Font.Size = 12;
            oTableDatos.Cell(2, 2).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(2, 2).Range.Font.Bold = 1;
            oTableDatos.Cell(2, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTableDatos.Cell(2, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Area
            Word.Paragraph oParaArea;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oParaArea = oDoc.Content.Paragraphs.Add(ref oRng);
            oParaArea.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oParaArea.Range.Font.Name = "Arial";
            oParaArea.Range.Text = "AREA: " + auditoria.NombreClaseAuditoria;

            oDoc.Paragraphs.Add(ref oMissing);

            //Auditoria
            Word.Paragraph oParaAuditoria;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oParaAuditoria = oDoc.Content.Paragraphs.Add(ref oRng);
            oParaAuditoria.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oParaAuditoria.Range.Font.Name = "Arial";
            oParaAuditoria.Range.Text = "AUDITORIA: " + auditoria.NombreTipoAuditoriaUpper;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Criterios
            Word.Paragraph oTituloCriterios;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTituloCriterios = oDoc.Content.Paragraphs.Add(ref oRng);
            oTituloCriterios.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTituloCriterios.Range.Font.Name = "Arial";
            oTituloCriterios.Range.Font.Bold = 1;
            oTituloCriterios.Range.Text = "CRITERIOS DE VALORACIÓN: ";

            oDoc.Paragraphs.Add(ref oMissing);

            TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(auditoria.OidTipoAuditoria, true);

            int i = 1;
            foreach (CriterioInfo criterio in tipo.Criterios)
            {
                oDoc.Paragraphs.Add(ref oMissing);
                oDoc.Paragraphs.Last.Range.Text = i.ToString() + ".- " + criterio.Nombre;
                oDoc.Paragraphs.Last.Range.Font.Name = "Arial";
                oDoc.Paragraphs.Last.Range.Font.Bold = 0;
                oDoc.Paragraphs.Last.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oDoc.Paragraphs.Add(ref oMissing);
                i++;
            }


            Word.Section seccion2; 
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            seccion2 = oDoc.Sections.Add(ref oRng, ref oEndOfDoc);
            seccion2.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

            //TituloSeccion2
            Word.Paragraph oTitulo2;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTitulo2 = oDoc.Content.Paragraphs.Add(ref oRng);
            oTitulo2.Range.Text = "LISTA DE COMPROBACIÓN.";
            oTitulo2.Range.Font.Size = 12;
            oTitulo2.Range.Font.Name = "Arial";
            oTitulo2.Range.Font.Bold = 1;
            oTitulo2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Area
            Word.Paragraph oParaArea2;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oParaArea2 = oDoc.Content.Paragraphs.Add(ref oRng);
            oParaArea2.Range.Font.Name = "Arial";
            oParaArea2.Range.Text = "AREA: " + auditoria.NombreClaseAuditoria;
            oParaArea2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oDoc.Paragraphs.Add(ref oMissing);

            //Auditoria
            Word.Paragraph oParaAuditoria2;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oParaAuditoria2 = oDoc.Content.Paragraphs.Add(ref oRng);
            oParaAuditoria2.Range.Font.Name = "Arial";
            oParaAuditoria2.Range.Text = "AUDITORIA: " + auditoria.NumeroClaseAuditoria + " " +
                auditoria.NombreClaseAuditoriaUpper + " " + auditoria.CodigoTipoAuditoria + " " + auditoria.NombreTipoAuditoriaUpper;
            oParaAuditoria2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Tabla cuestiones
            Word.Table oTableCuestiones;
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableCuestiones = oDoc.Tables.Add(wrdRng, 1, 4, ref oMissing, ref oMissing);
            oTableCuestiones.Range.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            oTableCuestiones.Range.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            oTableCuestiones.Columns[1].Width = 250F;
            oTableCuestiones.Columns[2].Width = 40F;
            oTableCuestiones.Columns[3].Width = 200F;
            oTableCuestiones.Columns[4].Width = 250F;
            oTableCuestiones.Rows.HeightRule = Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightAtLeast;
            oTableCuestiones.Rows.Height = 25F;
            oTableCuestiones.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableCuestiones.Range.ParagraphFormat.SpaceAfter = 6;
            oTableCuestiones.Range.ParagraphFormat.SpaceBefore = 6;

            oTableCuestiones.Borders.Enable = 1;
            oTableCuestiones.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTableCuestiones.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            oTableCuestiones.Cell(1, 1).Range.Text = "Cuestiones";
            oTableCuestiones.Cell(1, 1).Range.Font.Size = 12;
            oTableCuestiones.Cell(1, 1).Range.Font.Name = "Arial";
            oTableCuestiones.Cell(1, 1).Range.Font.Bold = 1;
            oTableCuestiones.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            oTableCuestiones.Cell(1, 2).Range.Text = "A";
            oTableCuestiones.Cell(1, 2).Range.Font.Size = 12;
            oTableCuestiones.Cell(1, 2).Range.Font.Name = "Arial";
            oTableCuestiones.Cell(1, 2).Range.Font.Bold = 1;
            oTableCuestiones.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            oTableCuestiones.Cell(1, 3).Range.Text = "Referencia";
            oTableCuestiones.Cell(1, 3).Range.Font.Size = 12;
            oTableCuestiones.Cell(1, 3).Range.Font.Name = "Arial";
            oTableCuestiones.Cell(1, 3).Range.Font.Bold = 1;
            oTableCuestiones.Cell(1, 3).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            oTableCuestiones.Cell(1, 4).Range.Text = "Observaciones";
            oTableCuestiones.Cell(1, 4).Range.Font.Size = 12;
            oTableCuestiones.Cell(1, 4).Range.Font.Name = "Arial";
            oTableCuestiones.Cell(1, 4).Range.Font.Bold = 1;
            oTableCuestiones.Cell(1, 4).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            i = 1;
            CuestionList lista_cuestiones = CuestionList.GetList();
            foreach (CuestionAuditoriaInfo cuestion in auditoria.Cuestiones)
            {
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                //object last = oTableCuestiones.Rows.Last.Range;
                oTableCuestiones.Rows.Add(ref oRng);

                CuestionInfo info = lista_cuestiones.GetItem(cuestion.OidCuestion);
                if (info != null)
                {
                    oTableCuestiones.Cell(i + 1, 1).Range.Text = i.ToString() + ".- " + info.Texto;
                    oTableCuestiones.Cell(i + 1, 1).Range.Bold = 0;
                    oTableCuestiones.Cell(i + 1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    oTableCuestiones.Cell(i + 1, 1).Range.Font.Size = 10;
                    oTableCuestiones.Cell(i + 1, 3).Range.Text = info.Referencias;
                    oTableCuestiones.Cell(i + 1, 3).Range.Font.Bold = 1;
                    oTableCuestiones.Cell(i + 1, 3).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    oTableCuestiones.Cell(i + 1, 3).Range.Font.Size = 10;
                }
                if (cuestion.Aceptado)
                    oTableCuestiones.Cell(i + 1, 2).Range.Text = "SI";
                else
                    oTableCuestiones.Cell(i + 1, 2).Range.Text = "NO";
                oTableCuestiones.Cell(i + 1, 2).Range.Bold = 0;
                oTableCuestiones.Cell(i + 1, 2).Range.Font.Size = 10;
                oTableCuestiones.Cell(i + 1, 4).Range.Text = cuestion.Observaciones;
                oTableCuestiones.Cell(i + 1, 4).Range.Bold = 0;
                oTableCuestiones.Cell(i + 1, 4).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oTableCuestiones.Cell(i + 1, 4).Range.Font.Size = 10;

                i++;
            }


            Word.Section seccion3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            seccion3 = oDoc.Sections.Add(ref oRng, ref oEndOfDoc);
            seccion3.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;

            //Area
            Word.Paragraph oParaArea3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oParaArea3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oParaArea3.Range.Font.Name = "Arial";
            oParaArea3.Range.Text = "AREA: " + auditoria.NombreClaseAuditoria;
            oParaArea3.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oDoc.Paragraphs.Add(ref oMissing);

            //Auditoria
            Word.Paragraph oParaAuditoria3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oParaAuditoria3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oParaAuditoria3.Range.Font.Name = "Arial";
            oParaAuditoria3.Range.Text = "AUDITORIA: " + auditoria.NumeroClaseAuditoria + " " +
                auditoria.NombreClaseAuditoriaUpper + " " + auditoria.CodigoTipoAuditoria + " " + auditoria.NombreTipoAuditoriaUpper;
            oParaAuditoria3.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //TituloSeccion3
            Word.Paragraph oTitulo3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTitulo3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oTitulo3.Range.Text = "DOCUMENTACIÓN QUE VA A SER AFECTADA:";
            oTitulo3.Range.Font.Size = 12;
            oTitulo3.Range.Font.Name = "Arial";
            oTitulo3.Range.Font.Bold = 1;
            oTitulo3.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Documentación
            Word.Paragraph oDocumentacion;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oDocumentacion = oDoc.Content.Paragraphs.Add(ref oRng);
            oDocumentacion.Range.Text = tipo.Documentacion;
            oDocumentacion.Range.Font.Size = 10;
            oDocumentacion.Range.Bold = 1;
            oDocumentacion.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oDocumentacion.LeftIndent = 20F;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Apreciaciones
            Word.Paragraph oApreciaciones;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oApreciaciones = oDoc.Content.Paragraphs.Add(ref oRng);
            oApreciaciones.Range.Text = "APRECIACIONES:";
            oApreciaciones.Range.Font.Size = 12;
            oApreciaciones.Range.Font.Name = "Arial";
            oApreciaciones.Range.Font.Bold = 1;
            oApreciaciones.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oApreciaciones.LeftIndent = 0F;
            

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Informe de Auditoría
            Word.Paragraph oInforme;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oInforme = oDoc.Content.Paragraphs.Add(ref oRng);
            oInforme.Range.Text = "INFORME DE AUDITORÍA.";
            oInforme.Range.Font.Size = 12;
            oInforme.Range.Font.Name = "Arial";
            oInforme.Range.Font.Bold = 1;
            oInforme.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //TEXTO
            Word.Paragraph oTexto;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTexto = oDoc.Content.Paragraphs.Add(ref oRng);
            oTexto.Range.Text = tipo.TextoInforme;
            oTexto.Range.Font.Size = 11;
            oTexto.Range.Font.Name = "Arial";
            oTexto.Range.Font.Bold =0;
            oTexto.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;

            oDoc.Paragraphs.Add(ref oMissing);

            if (auditoria.Informes != null && auditoria.Informes.Count > 0)
            {
                InformeDiscrepanciaInfo informe = auditoria.Informes[auditoria.Informes.Count - 1];

                foreach (CuestionAuditoriaInfo cuestion in auditoria.Cuestiones)
                {
                    bool tiene_discrepancias = false;
                    foreach (DiscrepanciaInfo disc in informe.Discrepancias)
                    {
                        if (disc.OidCuestion == cuestion.Oid)
                        {
                            if (!tiene_discrepancias)
                            {
                                //Cuestión con discrepancias
                                oDoc.Paragraphs.Add(ref oMissing);
                                CuestionInfo cuestion_asociada = lista_cuestiones.GetItem(cuestion.OidCuestion);
                                oDoc.Paragraphs.Last.Range.Text = cuestion.Numero.ToString() + ".- " 
                                    + cuestion_asociada.Texto;
                                oDoc.Paragraphs.Last.Range.Font.Size = 11;
                                oDoc.Paragraphs.Last.Range.Font.Name = "Arial";
                                oDoc.Paragraphs.Last.Range.Font.Bold = 1;
                                oDoc.Paragraphs.Last.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;


                                tiene_discrepancias = true;
                            }

                            //Discrepancia
                            if (disc.Texto != string.Empty)
                            {
                                oDoc.Paragraphs.Add(ref oMissing);
                                oDoc.Paragraphs.Last.Range.Text = "Discrepancia nº" + disc.Numero.ToString()
                                    + ": " + disc.Texto;
                                oDoc.Paragraphs.Last.Range.Font.Size = 11;
                                oDoc.Paragraphs.Last.Range.Font.Name = "Arial";
                                oDoc.Paragraphs.Last.Range.Font.Bold = 0;
                                oDoc.Paragraphs.Last.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                            }

                            if (disc.Observaciones != string.Empty)
                            {
                                oDoc.Paragraphs.Add(ref oMissing);
                                oDoc.Paragraphs.Last.Range.Text = "Recomendación nº" + disc.Numero.ToString()
                                    + ": " + disc.Observaciones;
                                oDoc.Paragraphs.Last.Range.Font.Size = 11;
                                oDoc.Paragraphs.Last.Range.Font.Name = "Arial";
                                oDoc.Paragraphs.Last.Range.Font.Bold = 0;
                                oDoc.Paragraphs.Last.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                            }

                        }
                    }
                }
            }

            //Pie de informe
            Word.Table oTableFirmas;
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableFirmas = oDoc.Tables.Add(wrdRng, 2, 3, ref oMissing, ref oMissing);
            oTableFirmas.Range.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            oTableFirmas.Range.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            oTableFirmas.Rows[1].Height = 100F;
            oTableFirmas.Rows[2].Height = 30F;

            oTableFirmas.Range.ParagraphFormat.SpaceAfter = 6;
            oTableFirmas.Range.ParagraphFormat.SpaceBefore = 6;

            oTableFirmas.Borders.Enable = 1;
            oTableFirmas.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTableFirmas.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;
            oTableFirmas.Range.Font.Size = 12;
            oTableFirmas.Range.Font.Name = "Arial";
            oTableFirmas.Range.Font.Bold = 1;

            oTableFirmas.Cell(1, 1).Range.Text = Environment.NewLine + "FIRMA RESPONSABLE DE ÁREA:";
            oTableFirmas.Cell(1, 2).Range.Text = Environment.NewLine + "FIRMA AUDITOR:";
            oTableFirmas.Cell(1, 3).Range.Text = Environment.NewLine + "FIRMA RESPONSABLE DE CALIDAD:";

            oTableFirmas.Cell(2, 1).Range.Text = "FECHA";
            oTableFirmas.Cell(2, 2).Range.Text = "FECHA";
            oTableFirmas.Cell(2, 3).Range.Text = "FECHA";

       
            //Encabezado y pie de página
            foreach (Word.Section wordSection in oDoc.Sections)
            {
                oDoc.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;

                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Text = auditoria.TextoPie;
                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Font.Size = 10;
                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Borders.DistanceFromTop = 10;

                wordSection.Range.ParagraphFormat.SpaceAfter = 0;
                wordSection.Range.ParagraphFormat.SpaceBefore = 0;

                wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Borders.DistanceFromTop = 10;
                wordSection.Headers[
                    Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.ShowFirstPageNumber = true;
                wordSection.Range.ParagraphFormat.SpaceAfter = 0;
                wordSection.Range.ParagraphFormat.SpaceBefore = 0;


                //Tabla de encabezado
                Word.Table oTable;

                Word.Range headerRng = wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;

                if (wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Tables.Count == 0)
                {
                    oTable = wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Tables.Add(headerRng, 1, 1, ref oMissing, ref oMissing);

                    oTable.Range.ParagraphFormat.SpaceAfter = 6;
                    oTable.Range.ParagraphFormat.SpaceBefore = 6;

                    oTable.Borders.Enable = 1;

                    oTable.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

                    oTable.Columns[1].Width = 100F;

                    oTable.Cell(1, 1).Range.Font.Bold = 0;
                    oTable.Cell(1, 1).Range.Font.Size = 12;
                    oTable.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    oTable.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    oDoc.ActiveWindow.Selection.TypeText("Página ");
                    Object CurrentPage = Word.WdFieldType.wdFieldPage;
                    oDoc.ActiveWindow.Selection.Fields.Add(oDoc.ActiveWindow.Selection.Range, ref CurrentPage, ref oMissing, ref oMissing);
                    oDoc.ActiveWindow.Selection.TypeText(" de ");
                    Object total_paginas = Word.WdFieldType.wdFieldNumPages;
                    oDoc.ActiveWindow.Selection.Fields.Add(oDoc.ActiveWindow.Selection.Range, ref total_paginas, ref oMissing, ref oMissing);

                    object celda = oTable.Cell(1, 1).Range;
                    oTable.Range.Cells.Add(ref celda);
                    oTable.Range.Cells.Add(ref celda);

                    oTable.Columns[2].Width = 300F;
                    oTable.Columns[1].Width = 100F;

                    extension = AuditoriaController.DevuelveExtensionReferencia(auditoria);

                    oTable.Cell(1, 2).Range.Text = "INFORME DE AUDITORÍA" +
                        Environment.NewLine +
                        "Nº. " + auditoria.Referencia + extension + ", (" +
                        auditoria.CodigoTipoAuditoria + ") " +
                        auditoria.NombreTipoAuditoria; ;
                    oTable.Cell(1, 2).Range.Font.Bold = 1;
                    oTable.Cell(1, 2).Range.Font.Size = 14;
                    oTable.Cell(1, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    oTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    string logo = CompanyInfo.GetLogoPath(AppContext.ActiveSchema.Oid);
                    if (!File.Exists(logo)) MessageBox.Show("No se ha encontrado la imagen: " + logo);
                    else oTable.Cell(1, 1).Range.InlineShapes.AddPicture(logo, ref oMissing, ref oMissing, ref oMissing);
                    oTable.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    oTable.Borders.InsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;
                    oTable.Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;

                    //SETTING FOCUS BACK TO DOCUMENT
                    oDoc.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
                }

            }

            //Márgenes (1cm aprox.)

            oDoc.PageSetup.LeftMargin = 50;
            oDoc.PageSetup.RightMargin = 50;

            object fileName = "C:\\Temp\\InformeAuditoría_" + auditoria.Referencia.Replace('/', '-') + 
                extension + ".doc";
            oDoc.SaveAs(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            Close();
        }

        public void ExportSeguimientoAuditorias(AuditoriaList auditorias)
        {
            Word.Document oDoc = NewDocument();

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

            Word.Paragraph oParaAux;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oParaAux = oDoc.Content.Paragraphs.Add(ref oRng);
            oParaAux.Range.Text = string.Empty;
            oParaAux.Range.InsertParagraph();
            oParaAux.Range.InsertParagraph();

            //Título
            Word.Table oTableTitulo;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableTitulo = oDoc.Tables.Add(wrdRng, 1, 1, ref oMissing, ref oMissing);

            oTableTitulo.Range.ParagraphFormat.SpaceAfter = 6;
            oTableTitulo.Range.ParagraphFormat.SpaceBefore = 6;

            oTableTitulo.Borders.Enable = 0;
            oTableTitulo.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableTitulo.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            oTableTitulo.Cell(1, 1).Range.Text = "SEGUIMIENTO Y SITUACIÓN" + Environment.NewLine +
                "DE AUDITORÍAS DE AEROTRAINING";
            oTableTitulo.Cell(1, 1).Range.Font.Size = 14;
            oTableTitulo.Cell(1, 1).Range.Font.Name = "Arial";
            oTableTitulo.Cell(1, 1).Range.Font.Bold = 1;
            oTableTitulo.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            oDoc.Paragraphs.Add(ref oMissing);

            //Tabla datos
            Word.Table oTableDatos;
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableDatos = oDoc.Tables.Add(wrdRng, 1, 14, ref oMissing, ref oMissing);
            oTableDatos.Range.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;
            oTableDatos.Range.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;

            oTableDatos.Columns[1].Width = 45F;
            oTableDatos.Columns[2].Width = 50F;
            oTableDatos.Columns[3].Width = 45F;
            oTableDatos.Columns[4].Width = 40F;
            oTableDatos.Columns[5].Width = 50F;
            oTableDatos.Columns[6].Width = 50F;
            oTableDatos.Columns[7].Width = 25F;
            oTableDatos.Columns[8].Width = 50F;
            oTableDatos.Columns[9].Width = 40F;
            oTableDatos.Columns[10].Width = 45F;
            oTableDatos.Columns[11].Width = 50F;
            oTableDatos.Columns[12].Width = 45F;
            oTableDatos.Columns[13].Width = 60F;
            oTableDatos.Columns[14].Width = 125F;

            oTableDatos.Range.ParagraphFormat.SpaceAfter = 6;
            oTableDatos.Range.ParagraphFormat.SpaceBefore = 6;

            oTableDatos.Borders.Enable = 1;
            oTableDatos.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            oTableDatos.Range.Font.Size = 7;
            oTableDatos.Range.Font.Name = "Times New Roman";
            oTableDatos.Range.Font.Bold = 1;
            oTableDatos.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Columns[1].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[2].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[3].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[4].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[5].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[6].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[7].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[8].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[9].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[10].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[11].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[12].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[13].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTableDatos.Columns[14].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(1, 1).Range.Text = "Nº de Orden y de Auditoría";
            oTableDatos.Cell(1, 2).Range.Text = "Fecha de comunicación";
            oTableDatos.Cell(1, 3).Range.Text = "Fecha de realización";
            oTableDatos.Cell(1, 4).Range.Text = "Informe Auditoría";
            oTableDatos.Cell(1, 5).Range.Text = "Informe de discrepancias";
            oTableDatos.Cell(1, 6).Range.Text = "Nº Discrepancia";
            oTableDatos.Cell(1, 7).Range.Text = "Nivel";
            oTableDatos.Cell(1, 8).Range.Text = "Nº de informe comunicación interna";
            oTableDatos.Cell(1, 9).Range.Text = "Fecha max de cierre";
            oTableDatos.Cell(1, 10).Range.Text = "Petición ampliación plazo cierre";
            oTableDatos.Cell(1, 11).Range.Text = "Fecha de cumplimiento de ampliación";
            oTableDatos.Cell(1, 12).Range.Text = "Fecha real de cierre";
            oTableDatos.Cell(1, 13).Range.Text = "Nº de informe de acciones correctoras";
            oTableDatos.Cell(1, 14).Range.Text = "OBSERVACIONES (" +
                DateTime.Today.Day.ToString("00") + "." +
                DateTime.Today.Month.ToString("00") + "." +
                DateTime.Today.Year.ToString("0000") + ")";

            Plan_TipoList planes_tipos = Plan_TipoList.GetList(false);
            TipoAuditoriaList tipos_auditorias = TipoAuditoriaList.GetList();
            PlanAnualList planes_anuales = PlanAnualList.GetList(false);

            foreach (AuditoriaInfo item in auditorias)
            {
                Plan_TipoInfo plan_tipo = planes_tipos.GetItem(item.OidPlanTipo);
                PlanAnualInfo plan_anual = planes_anuales.GetItem(plan_tipo.OidPlan);
                TipoAuditoriaInfo tipo_auditoria = tipos_auditorias.GetItem(plan_tipo.OidTipo);

                foreach (InformeDiscrepanciaInfo informe_discrepancia in item.Informes)
                {
                    if (!informe_discrepancia.Notificado) continue;
                    foreach (DiscrepanciaInfo discrepancia in informe_discrepancia.Discrepancias)
                    {
                        if (!discrepancia.EsDiscrepancia) continue;
                        oTableDatos.Rows.Add(ref oMissing);
                        oTableDatos.Rows.Last.Range.Bold = 0;
                        oTableDatos.Rows.Last.Range.Font.Size = 7; 

                        oTableDatos.Rows.Last.Cells[1].Range.Text = plan_tipo.Orden.ToString("00") +
                            "-" + tipo_auditoria.Numero + "_" + plan_anual.Ano;

                        oTableDatos.Rows.Last.Cells[2].Range.Text = item.FechaComunicacion.Day.ToString("00") +
                            "." + item.FechaComunicacion.Month.ToString("00") + "." +
                            item.FechaComunicacion.Year.ToString("0000");

                        string fecha_realizacion = "(" + item.FechaInicio.Day.ToString("00");

                        if (item.FechaInicio.Month == item.FechaFin.Month)
                            fecha_realizacion += "-" + item.FechaFin.Day.ToString("00") + ")." +
                                item.FechaInicio.Month.ToString("00") + "." +
                                item.FechaInicio.Year.ToString("00");
                        else
                        {
                            fecha_realizacion += "." + item.FechaInicio.Month.ToString("00");
                            if (item.FechaInicio.Year == item.FechaFin.Year)
                            {
                                fecha_realizacion += "-" + item.FechaFin.Day.ToString("00") +
                                    "." + item.FechaFin.Month.ToString("00") + ")." +
                                    item.FechaInicio.Year.ToString("00");

                            }
                            else
                            {
                                fecha_realizacion += "." + item.FechaInicio.Year.ToString("00") +
                                    "-" + item.FechaFin.Day.ToString("00") + "." +
                                    item.FechaFin.Month.ToString("00") + "." +
                                    item.FechaFin.Year.ToString("00");
                            }
                        }

                        oTableDatos.Rows.Last.Cells[3].Range.Text = fecha_realizacion;

                        if (item.Estado > (long)EstadoAuditoria.COMUNICADA)
                            oTableDatos.Rows.Last.Cells[4].Range.Text = "SI";
                        else
                            oTableDatos.Rows.Last.Cells[4].Range.Text = "NO";

                        oTableDatos.Rows.Last.Cells[5].Range.Text = informe_discrepancia.Fecha.Day.ToString("00") +
                            "." + informe_discrepancia.Fecha.Month.ToString("00") +
                            "." + informe_discrepancia.Fecha.Year.ToString("00");

                        oTableDatos.Rows.Last.Cells[6].Range.Text = discrepancia.Numero.ToString();
                        oTableDatos.Rows.Last.Cells[7].Range.Text = discrepancia.Nivel.ToString();
                        oTableDatos.Rows.Last.Cells[8].Range.Text = informe_discrepancia.Numero;
                        oTableDatos.Rows.Last.Cells[9].Range.Text = discrepancia.FechaDebida.Day.ToString("00") +
                            "." + discrepancia.FechaDebida.Month.ToString("00") + "." +
                            discrepancia.FechaDebida.Year.ToString("00");

                        bool peticion_ampliacion = false;

                        foreach (InformeAmpliacionInfo informe_ampliacion in informe_discrepancia.Ampliaciones)
                        {
                            foreach (AmpliacionInfo ampliacion in informe_ampliacion.Ampliaciones)
                            {
                                if (ampliacion.OidDiscrepancia == discrepancia.Oid)
                                {
                                    peticion_ampliacion = true;
                                    oTableDatos.Rows.Last.Cells[10].Range.Text = informe_ampliacion.Numero;
                                    oTableDatos.Rows.Last.Cells[11].Range.Text = discrepancia.FechaAmpliacion.Day.ToString("00") +
                            "." + discrepancia.FechaAmpliacion.Month.ToString("00") + "." +
                            discrepancia.FechaAmpliacion.Year.ToString("00");
                                    break;
                                }
                            }
                            if (peticion_ampliacion) break;
                        }

                        if (!peticion_ampliacion)
                        {
                            oTableDatos.Rows.Last.Cells[10].Range.Text = "-";
                            oTableDatos.Rows.Last.Cells[11].Range.Text = "-";
                        }

                        if (discrepancia.FechaCierre.Date != DateTime.MaxValue.Date)
                            oTableDatos.Rows.Last.Cells[12].Range.Text =
                                discrepancia.FechaCierre.Day.ToString("00") +
                                "." + discrepancia.FechaCierre.Month.ToString("00") + "." +
                                discrepancia.FechaCierre.Year.ToString("00");
                        else
                            oTableDatos.Rows.Last.Cells[12].Range.Text = "-";

                        if (informe_discrepancia.Correctores.Count > 0)
                            oTableDatos.Rows.Last.Cells[13].Range.Text = informe_discrepancia.Correctores[0].Numero;
                        else
                            oTableDatos.Rows.Last.Cells[13].Range.Text = "-";

                        oTableDatos.Rows.Last.Cells[14].Range.Text = discrepancia.Observaciones;

                    }
                }
            }

            oTableDatos.Rows.Add(ref oMissing);
            oTableDatos.Rows.Last.Cells[14].Merge(oTableDatos.Rows.Last.Cells[13]);
            oTableDatos.Rows.Last.Cells[13].Merge(oTableDatos.Rows.Last.Cells[12]);
            oTableDatos.Rows.Last.Cells[12].Merge(oTableDatos.Rows.Last.Cells[11]);
            oTableDatos.Rows.Last.Cells[11].Merge(oTableDatos.Rows.Last.Cells[10]);
            oTableDatos.Rows.Last.Cells[10].Merge(oTableDatos.Rows.Last.Cells[9]);
            oTableDatos.Rows.Last.Cells[9].Merge(oTableDatos.Rows.Last.Cells[8]);
            oTableDatos.Rows.Last.Cells[8].Merge(oTableDatos.Rows.Last.Cells[7]);
            oTableDatos.Rows.Last.Cells[7].Merge(oTableDatos.Rows.Last.Cells[6]);
            oTableDatos.Rows.Last.Cells[6].Merge(oTableDatos.Rows.Last.Cells[5]);
            oTableDatos.Rows.Last.Cells[5].Merge(oTableDatos.Rows.Last.Cells[4]);
            oTableDatos.Rows.Last.Cells[4].Merge(oTableDatos.Rows.Last.Cells[3]);
            oTableDatos.Rows.Last.Cells[3].Merge(oTableDatos.Rows.Last.Cells[2]);
            oTableDatos.Rows.Last.Cells[2].Merge(oTableDatos.Rows.Last.Cells[1]);

            oTableDatos.Rows.Last.Cells[1].Range.Text = "Auditor Responsable (Nombre, fecha y firma):";
            oTableDatos.Rows.Last.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTableDatos.Rows.Last.Height = 50F;
            oTableDatos.Rows.Last.Cells[1].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalTop;

            oTableDatos.Rows.Add(ref oMissing);

            oTableDatos.Rows.Last.Cells[1].Range.Text = "Responsable de Calidad (Nombre, fecha y firma):";
            oTableDatos.Rows.Last.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTableDatos.Rows.Last.Height = 50F;
            oTableDatos.Rows.Last.Cells[1].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalTop;

            //intento de agrupar casillas con información repetida
            for (int i = oTableDatos.Rows.Count - 2; i > 2; i--)
            {
                if (oTableDatos.Cell(i, 1).Range.Text == oTableDatos.Cell(i - 1, 1).Range.Text)
                {
                    oTableDatos.Cell(i - 1, 1).Range.Text = string.Empty;
                    oTableDatos.Cell(i, 1).Merge(oTableDatos.Cell(i - 1, 1));
                    oTableDatos.Cell(i - 1, 2).Range.Text = string.Empty;
                    oTableDatos.Cell(i, 2).Merge(oTableDatos.Cell(i - 1, 2));
                    oTableDatos.Cell(i - 1, 3).Range.Text = string.Empty;
                    oTableDatos.Cell(i, 3).Merge(oTableDatos.Cell(i - 1, 3));
                    oTableDatos.Cell(i - 1, 4).Range.Text = string.Empty;
                    oTableDatos.Cell(i, 4).Merge(oTableDatos.Cell(i - 1, 4));

                    if (oTableDatos.Cell(i, 5).Range.Text == oTableDatos.Cell(i - 1, 5).Range.Text)
                    {
                        oTableDatos.Cell(i - 1, 5).Range.Text = string.Empty;
                        oTableDatos.Cell(i, 5).Merge(oTableDatos.Cell(i - 1, 5));
                    }
                    if (oTableDatos.Cell(i, 13).Range.Text == oTableDatos.Cell(i - 1, 13).Range.Text)
                    {
                        oTableDatos.Cell(i - 1, 13).Range.Text = string.Empty;
                        oTableDatos.Cell(i, 13).Merge(oTableDatos.Cell(i - 1, 13));
                    }
                }
            }
          
            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            
            //Márgenes (1cm aprox.)

            oDoc.PageSetup.LeftMargin = 40;
            oDoc.PageSetup.RightMargin = 40;

            object fileName = "C:\\Temp\\SeguimientoAuditorías.doc";
            oDoc.SaveAs(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            Close();
        }

        public void ExportInformeDiscrepancias(AuditoriaPrint auditoria, InformeDiscrepancia informe)
        {
            Word.Document oDoc = NewDocument();
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            Word.Paragraph oParaAux;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oParaAux = oDoc.Content.Paragraphs.Add(ref oRng);
            oParaAux.Range.Text = string.Empty;
            oParaAux.Range.InsertParagraph();
            oParaAux.Range.InsertParagraph();

            //Texto cabecera informe
            Word.Paragraph oTexto;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTexto = oDoc.Content.Paragraphs.Add(ref oRng);
            oTexto.Range.Text = "Cada discrepancia debería ser registrada, se haya rectificado o no, por medio de una referencia, que será la misma que la indicada en el apartado correspondiente de número. Todas las discrepancias no rectificadas deberían remitirse al departamento auditado por medio del presente parte, requiriendo las acciones correctoras.";
            oTexto.Range.Font.Size = 10;
            oTexto.Range.Font.Name = "Arial";
            oTexto.Range.Font.Bold = 0;
            oTexto.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Tabla datos
            Word.Table oTableDatos;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableDatos = oDoc.Tables.Add(wrdRng, 2, 6, ref oMissing, ref oMissing);
            oTableDatos.Range.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            oTableDatos.Range.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            oTableDatos.Columns[1].Width = 80F;
            oTableDatos.Columns[2].Width = 170F;
            oTableDatos.Columns[3].Width = 60F;
            oTableDatos.Columns[4].Width = 60F;
            oTableDatos.Columns[5].Width = 60F;
            oTableDatos.Columns[6].Width = 70F;

            oTableDatos.Range.ParagraphFormat.SpaceAfter = 6;
            oTableDatos.Range.ParagraphFormat.SpaceBefore = 6;

            oTableDatos.Borders.Enable = 1;
            oTableDatos.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            oTableDatos.Cell(1, 5).Merge(oTableDatos.Cell(1, 6));
            oTableDatos.Cell(1, 4).Merge(oTableDatos.Cell(1, 5));

            oTableDatos.Cell(1, 1).Merge(oTableDatos.Cell(2, 1));
            oTableDatos.Cell(1, 2).Merge(oTableDatos.Cell(2, 2));
            oTableDatos.Cell(1, 3).Merge(oTableDatos.Cell(2, 3));

            oTableDatos.Cell(1, 1).Range.Text = Environment.NewLine + "NÚMERO" +
                Environment.NewLine;
            oTableDatos.Cell(1, 1).Range.Font.Size = 14;
            oTableDatos.Cell(1, 1).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(1, 1).Range.Font.Bold = 1;
            oTableDatos.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(1, 2).Range.Text = Environment.NewLine + "DISCREPANCIA" +
                Environment.NewLine;
            oTableDatos.Cell(1, 2).Range.Font.Size = 14;
            oTableDatos.Cell(1, 2).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(1, 2).Range.Font.Bold = 1;
            oTableDatos.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Cell(1, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(1, 3).Range.Text = Environment.NewLine + "NIVEL" +
                Environment.NewLine;
            oTableDatos.Cell(1, 3).Range.Font.Size = 14;
            oTableDatos.Cell(1, 3).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(1, 3).Range.Font.Bold = 1;
            oTableDatos.Cell(1, 3).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Cell(1, 3).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(1, 4).Range.Text = Environment.NewLine + "ACCIÓN CORRECTORA" +
                Environment.NewLine;
            oTableDatos.Cell(1, 4).Range.Font.Size = 14;
            oTableDatos.Cell(1, 4).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(1, 4).Range.Font.Bold = 1;
            oTableDatos.Cell(1, 4).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Cell(1, 4).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(2, 4).Range.Text = "FECHA" 
                + Environment.NewLine + "DEBIDA";
            oTableDatos.Cell(2, 4).Range.Font.Size = 12;
            oTableDatos.Cell(2, 4).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(2, 4).Range.Font.Bold = 1;
            oTableDatos.Cell(2, 4).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Cell(2, 4).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(2, 5).Range.Text = "FECHA"
                + Environment.NewLine + "CIERRE";
            oTableDatos.Cell(2, 5).Range.Font.Size = 12;
            oTableDatos.Cell(2, 5).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(2, 5).Range.Font.Bold = 1;
            oTableDatos.Cell(2, 5).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Cell(2, 5).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(2, 6).Range.Text = "REFER."
                + Environment.NewLine + "INFORME";
            oTableDatos.Cell(2, 6).Range.Font.Size = 12;
            oTableDatos.Cell(2, 6).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(2, 6).Range.Font.Bold = 1;
            oTableDatos.Cell(2, 6).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Cell(2, 6).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            int fila = 3;
            
            foreach (Discrepancia disc in informe.Discrepancias)
            {
                if (!disc.EsDiscrepancia) continue;

                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTableDatos.Rows.Add(ref oRng);

                oTableDatos.Cell(fila, 1).Range.Text = Environment.NewLine + disc.Numero.ToString() + Environment.NewLine;
                oTableDatos.Cell(fila, 1).Range.Font.Size = 12;
                oTableDatos.Cell(fila, 1).Range.Font.Name = "Times New Roman";
                oTableDatos.Cell(fila, 1).Range.Font.Bold = 1;
                oTableDatos.Cell(fila, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTableDatos.Cell(fila, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                oTableDatos.Cell(fila, 2).Range.Text = disc.Texto;
                oTableDatos.Cell(fila, 2).Range.Font.Size = 10;
                oTableDatos.Cell(fila, 2).Range.Font.Name = "Times New Roman";
                oTableDatos.Cell(fila, 2).Range.Font.Bold = 0;
                oTableDatos.Cell(fila, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oTableDatos.Cell(fila, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                oTableDatos.Cell(fila, 3).Range.Text = Environment.NewLine + disc.Nivel.ToString() + Environment.NewLine;
                oTableDatos.Cell(fila, 3).Range.Font.Size = 12;
                oTableDatos.Cell(fila, 3).Range.Font.Name = "Times New Roman";
                oTableDatos.Cell(fila, 3).Range.Font.Bold = 1;
                oTableDatos.Cell(fila, 3).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTableDatos.Cell(fila, 3).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                oTableDatos.Cell(fila, 4).Range.Text = Environment.NewLine 
                    + disc.FechaDebida.ToShortDateString() + Environment.NewLine;
                oTableDatos.Cell(fila, 4).Range.Font.Size = 11;
                oTableDatos.Cell(fila, 4).Range.Font.Name = "Times New Roman";
                oTableDatos.Cell(fila, 4).Range.Font.Bold = 1;
                oTableDatos.Cell(fila, 4).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTableDatos.Cell(fila, 4).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                foreach(InformeCorrector informe_corrector in informe.Correctores)
                {
                    bool accion_encontrada = false;
                    foreach (AccionCorrectora accion in informe_corrector.Acciones)
                    {
                        if (accion.OidDiscrepancia == disc.Oid)
                        {
                            oTableDatos.Cell(fila, 5).Range.Text = Environment.NewLine
                                + disc.FechaCierre.ToShortDateString() + Environment.NewLine;
                            oTableDatos.Cell(fila, 5).Range.Font.Size = 11;
                            oTableDatos.Cell(fila, 5).Range.Font.Name = "Times New Roman";
                            oTableDatos.Cell(fila, 5).Range.Font.Bold = 1;
                            oTableDatos.Cell(fila, 5).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            oTableDatos.Cell(fila, 5).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                            oTableDatos.Cell(fila, 6).Range.Text = Environment.NewLine
                                + informe_corrector.Numero.ToString() + Environment.NewLine;
                            oTableDatos.Cell(fila, 6).Range.Font.Size = 12;
                            oTableDatos.Cell(fila, 6).Range.Font.Name = "Times New Roman";
                            oTableDatos.Cell(fila, 6).Range.Font.Bold = 1;
                            oTableDatos.Cell(fila, 6).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                            oTableDatos.Cell(fila, 6).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                            accion_encontrada = true;
                            break;
                        }
                    }
                    if (accion_encontrada) break;
                }

                fila++;
            }

            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableDatos.Rows.Add(ref oRng);

            oTableDatos.Cell(fila, 5).Merge(oTableDatos.Cell(fila, 6));
            oTableDatos.Cell(fila, 4).Merge(oTableDatos.Cell(fila, 5));
            oTableDatos.Cell(fila, 3).Merge(oTableDatos.Cell(fila, 4));

            oTableDatos.Cell(fila, 3).Range.Text = "Gerente Responsable (Nombre, fecha y firma):" +
                Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                "Responsable Departamento (Nombre, fecha y firma):" +
                Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            oTableDatos.Cell(fila, 3).Range.Font.Size = 12;
            oTableDatos.Cell(fila, 3).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(fila, 3).Range.Font.Bold = 1;
            oTableDatos.Cell(fila, 3).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTableDatos.Cell(fila, 3).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(fila, 1).Merge(oTableDatos.Cell(fila, 2));

            oTableDatos.Cell(fila, 1).Range.Text = "Responsable de Calidad (Nombre, fecha y firma):" +
                Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                "Auditor Responsable (Nombre, fecha y firma):" +
                Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            oTableDatos.Cell(fila, 1).Range.Font.Size = 12;
            oTableDatos.Cell(fila, 1).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(fila, 1).Range.Font.Bold = 1;
            oTableDatos.Cell(fila, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTableDatos.Cell(fila, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Encabezado y pie de página
            foreach (Word.Section wordSection in oDoc.Sections)
            {
                oDoc.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;

                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Text = auditoria.TextoPie;
                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Font.Size = 10;
                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Borders.DistanceFromTop = 10;

                wordSection.Range.ParagraphFormat.SpaceAfter = 0;
                wordSection.Range.ParagraphFormat.SpaceBefore = 0;

                wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Borders.DistanceFromTop = 10;
                wordSection.Headers[
                    Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.ShowFirstPageNumber = true;
                wordSection.Range.ParagraphFormat.SpaceAfter = 0;
                wordSection.Range.ParagraphFormat.SpaceBefore = 0;


                //Tabla de encabezado
                Word.Table oTable;

                Word.Range headerRng = wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;

                if (wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Tables.Count == 0)
                {
                    oTable = wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Tables.Add(headerRng, 1, 1, ref oMissing, ref oMissing);

                    oTable.Range.ParagraphFormat.SpaceAfter = 6;
                    oTable.Range.ParagraphFormat.SpaceBefore = 6;

                    oTable.Borders.Enable = 1;

                    oTable.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

                    oTable.Columns[1].Width = 100F;

                    oTable.Cell(1, 1).Range.Font.Bold = 0;
                    oTable.Cell(1, 1).Range.Font.Size = 12;
                    oTable.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    oTable.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    oDoc.ActiveWindow.Selection.TypeText("Página ");
                    Object CurrentPage = Word.WdFieldType.wdFieldPage;
                    oDoc.ActiveWindow.Selection.Fields.Add(oDoc.ActiveWindow.Selection.Range, ref CurrentPage, ref oMissing, ref oMissing);
                    oDoc.ActiveWindow.Selection.TypeText(" de ");
                    Object total_paginas = Word.WdFieldType.wdFieldNumPages;
                    oDoc.ActiveWindow.Selection.Fields.Add(oDoc.ActiveWindow.Selection.Range, ref total_paginas, ref oMissing, ref oMissing);

                    object celda = oTable.Cell(1, 1).Range;
                    oTable.Range.Cells.Add(ref celda);
                    oTable.Range.Cells.Add(ref celda);

                    oTable.Columns[2].Width = 300F;
                    oTable.Columns[1].Width = 100F;


                    oTable.Cell(1, 2).Range.Text = "INFORME DE DISCREPANCIAS" +
                        Environment.NewLine +
                        "Nº. " + auditoria.Referencia + ", (" +
                        auditoria.CodigoTipoAuditoria + ") " +
                        auditoria.NombreTipoAuditoria; ;
                    oTable.Cell(1, 2).Range.Font.Bold = 1;
                    oTable.Cell(1, 2).Range.Font.Size = 14;
                    oTable.Cell(1, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    oTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    string logo = CompanyInfo.GetLogoPath(AppContext.ActiveSchema.Oid);
                    if (!File.Exists(logo)) MessageBox.Show("No se ha encontrado la imagen: " + logo);
                    else oTable.Cell(1, 1).Range.InlineShapes.AddPicture(logo, ref oMissing, ref oMissing, ref oMissing);
                    oTable.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    oTable.Borders.InsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;
                    oTable.Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;

                    //SETTING FOCUS BACK TO DOCUMENT
                    oDoc.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
                }

            }

            //Márgenes (1cm aprox.)

            oDoc.PageSetup.LeftMargin = 50;
            oDoc.PageSetup.RightMargin = 50;

            object fileName = "C:\\Temp\\InformeDiscrepancias_" + informe.Codigo.Replace('/','-') + ".doc";
            oDoc.SaveAs(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            Close();
        }

        public void ExportInformeCorrector(AuditoriaPrint auditoria, InformeCorrector informe)
        {
            Word.Document oDoc = NewDocument();
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            Word.Paragraph oParaAux;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oParaAux = oDoc.Content.Paragraphs.Add(ref oRng);
            oParaAux.Range.Text = string.Empty;
            oParaAux.Range.InsertParagraph();
            oParaAux.Range.InsertParagraph();

            InformeDiscrepanciaInfo informe_discrepancia = auditoria.Informes.GetItem(informe.OidInformeDiscrepancia);

            //Tabla
            Word.Table oTableCabecera;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableCabecera = oDoc.Tables.Add(wrdRng, 3, 1, ref oMissing, ref oMissing);
            oTableCabecera.Range.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;
            oTableCabecera.Range.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;

            oTableCabecera.Columns[1].Width = 200F;
            oTableCabecera.Rows.Height = 30F;
            oTableCabecera.Columns[1].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableCabecera.Range.ParagraphFormat.SpaceAfter = 6;
            oTableCabecera.Range.ParagraphFormat.SpaceBefore = 6;

            //oTableCabecera.Borders.Enable = 1;
            oTableCabecera.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTableCabecera.Rows.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
            oTableCabecera.Range.Font.Size = 12;
            oTableCabecera.Range.Font.Name = "Arial";
            oTableCabecera.Range.Font.Bold = 1;

            oTableCabecera.Cell(1, 1).Range.Text = "Nº de Informe: " + informe.Numero;
            oTableCabecera.Cell(2, 1).Range.Text = "Fecha: " + informe.Fecha.ToShortDateString();
            oTableCabecera.Cell(3, 1).Range.Text = "Realizado por: " + auditoria.Responsable;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Texto cabecera informe
            Word.Paragraph oTexto;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTexto = oDoc.Content.Paragraphs.Add(ref oRng);
            oTexto.Range.Text = "En el siguiente informe se detalla el plan de acción para las acciones correctoras tomadas por el RESPONSABLE DEL DEPARTAMENTO AUDITADO para resolver las discrepancias emitidas por el Departamento de Calidad a fecha de " + informe_discrepancia.Fecha.ToShortDateString() + " con referencia de auditoría " + auditoria.Referencia + " " + auditoria.NombreTipoAuditoria + ".";
            oTexto.Range.Font.Size = 10;
            oTexto.Range.Font.Name = "Arial";
            oTexto.Range.Font.Bold = 0;
            oTexto.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Tabla datos
            Word.Table oTableDatos;
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableDatos = oDoc.Tables.Add(wrdRng, 1, 4, ref oMissing, ref oMissing);
            oTableDatos.Range.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            oTableDatos.Range.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            oTableDatos.Columns[1].Width = 60F;
            oTableDatos.Columns[2].Width = 190F;
            oTableDatos.Columns[3].Width = 60F;
            oTableDatos.Columns[4].Width = 190F;

            oTableDatos.Range.ParagraphFormat.SpaceAfter = 6;
            oTableDatos.Range.ParagraphFormat.SpaceBefore = 6;

            oTableDatos.Borders.Enable = 1;
            oTableDatos.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            oTableDatos.Cell(1, 1).Range.Text = Environment.NewLine + "NÚMERO" +
                Environment.NewLine;
            oTableDatos.Cell(1, 1).Range.Font.Size = 10;
            oTableDatos.Cell(1, 1).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(1, 1).Range.Font.Bold = 1;
            oTableDatos.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(1, 2).Range.Text = Environment.NewLine + "DISCREPANCIA" +
                Environment.NewLine;
            oTableDatos.Cell(1, 2).Range.Font.Size = 12;
            oTableDatos.Cell(1, 2).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(1, 2).Range.Font.Bold = 1;
            oTableDatos.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Cell(1, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(1, 3).Range.Text = Environment.NewLine + "NIVEL" +
                Environment.NewLine;
            oTableDatos.Cell(1, 3).Range.Font.Size = 12;
            oTableDatos.Cell(1, 3).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(1, 3).Range.Font.Bold = 1;
            oTableDatos.Cell(1, 3).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Cell(1, 3).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTableDatos.Cell(1, 4).Range.Text = Environment.NewLine + "PLAN DE ACCIÓN" +
                Environment.NewLine;
            oTableDatos.Cell(1, 4).Range.Font.Size = 12;
            oTableDatos.Cell(1, 4).Range.Font.Name = "Times New Roman";
            oTableDatos.Cell(1, 4).Range.Font.Bold = 1;
            oTableDatos.Cell(1, 4).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Cell(1, 4).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            int fila = 2;

            foreach (AccionCorrectora accion in informe.Acciones)
            {
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTableDatos.Rows.Add(ref oRng);

                oTableDatos.Cell(fila, 1).Range.Text = Environment.NewLine + accion.Numero.ToString() + Environment.NewLine;
                oTableDatos.Cell(fila, 1).Range.Font.Size = 12;
                oTableDatos.Cell(fila, 1).Range.Font.Name = "Times New Roman";
                oTableDatos.Cell(fila, 1).Range.Font.Bold = 1;
                oTableDatos.Cell(fila, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTableDatos.Cell(fila, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                DiscrepanciaInfo disc = informe_discrepancia.Discrepancias.GetItem(accion.OidDiscrepancia);

                oTableDatos.Cell(fila, 2).Range.Text = disc.Texto;
                oTableDatos.Cell(fila, 2).Range.Font.Size = 10;
                oTableDatos.Cell(fila, 2).Range.Font.Name = "Times New Roman";
                oTableDatos.Cell(fila, 2).Range.Font.Bold = 0;
                oTableDatos.Cell(fila, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oTableDatos.Cell(fila, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                oTableDatos.Cell(fila, 3).Range.Text = Environment.NewLine + disc.Nivel.ToString() + Environment.NewLine;
                oTableDatos.Cell(fila, 3).Range.Font.Size = 12;
                oTableDatos.Cell(fila, 3).Range.Font.Name = "Times New Roman";
                oTableDatos.Cell(fila, 3).Range.Font.Bold = 1;
                oTableDatos.Cell(fila, 3).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTableDatos.Cell(fila, 3).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                oTableDatos.Cell(fila, 4).Range.Text = accion.Texto;
                oTableDatos.Cell(fila, 4).Range.Font.Size = 11;
                oTableDatos.Cell(fila, 4).Range.Font.Name = "Times New Roman";
                oTableDatos.Cell(fila, 4).Range.Font.Bold = 1;
                oTableDatos.Cell(fila, 4).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oTableDatos.Cell(fila, 4).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                fila++;
            }

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);
            
            //Firma Responsable
            Word.Paragraph oFirma;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oFirma = oDoc.Content.Paragraphs.Add(ref oRng);
            oFirma.Range.Text = "Responsable del Departamento (Nombre, fecha y firma):";
            oFirma.Range.Font.Size = 12;
            oFirma.Range.Font.Name = "Arial";
            oFirma.Range.Font.Bold = 1;
            oFirma.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);


            //Nombre Responsable
            Word.Paragraph oNombre;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oNombre = oDoc.Content.Paragraphs.Add(ref oRng);
            oNombre.Range.Text = auditoria.Responsable;
            oNombre.Range.Font.Size = 12;
            oNombre.Range.Font.Name = "Arial";
            oNombre.Range.Font.Bold = 1;
            oNombre.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oDoc.Paragraphs.Add(ref oMissing);
            oDoc.Paragraphs.Add(ref oMissing);

            //Encabezado y pie de página
            foreach (Word.Section wordSection in oDoc.Sections)
            {
                oDoc.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;

                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Text = auditoria.TextoPie;
                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Font.Size = 10;
                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Borders.DistanceFromTop = 10;

                wordSection.Range.ParagraphFormat.SpaceAfter = 0;
                wordSection.Range.ParagraphFormat.SpaceBefore = 0;

                wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
              .Range.Borders.DistanceFromTop = 10;
                wordSection.Headers[
                    Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.ShowFirstPageNumber = true;
                wordSection.Range.ParagraphFormat.SpaceAfter = 0;
                wordSection.Range.ParagraphFormat.SpaceBefore = 0;


                //Tabla de encabezado
                Word.Table oTable;

                Word.Range headerRng = wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;

                if (wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Tables.Count == 0)
                {
                    oTable = wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Tables.Add(headerRng, 1, 1, ref oMissing, ref oMissing);

                    oTable.Range.ParagraphFormat.SpaceAfter = 6;
                    oTable.Range.ParagraphFormat.SpaceBefore = 6;

                    oTable.Borders.Enable = 1;

                    oTable.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

                    oTable.Columns[1].Width = 100F;

                    oTable.Cell(1, 1).Range.Font.Bold = 0;
                    oTable.Cell(1, 1).Range.Font.Size = 12;
                    oTable.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    oTable.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    oDoc.ActiveWindow.Selection.TypeText("Página ");
                    Object CurrentPage = Word.WdFieldType.wdFieldPage;
                    oDoc.ActiveWindow.Selection.Fields.Add(oDoc.ActiveWindow.Selection.Range, ref CurrentPage, ref oMissing, ref oMissing);
                    oDoc.ActiveWindow.Selection.TypeText(" de ");
                    Object total_paginas = Word.WdFieldType.wdFieldNumPages;
                    oDoc.ActiveWindow.Selection.Fields.Add(oDoc.ActiveWindow.Selection.Range, ref total_paginas, ref oMissing, ref oMissing);

                    object celda = oTable.Cell(1, 1).Range;
                    oTable.Range.Cells.Add(ref celda);
                    oTable.Range.Cells.Add(ref celda);

                    oTable.Columns[2].Width = 300F;
                    oTable.Columns[1].Width = 100F;


                    oTable.Cell(1, 2).Range.Text = "INFORME DE ACCIONES CORRECTORAS" +
                        Environment.NewLine +
                        "Nº. " + auditoria.Referencia;
                    oTable.Cell(1, 2).Range.Font.Bold = 1;
                    oTable.Cell(1, 2).Range.Font.Size = 14;
                    oTable.Cell(1, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    oTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    string logo = CompanyInfo.GetLogoPath(AppContext.ActiveSchema.Oid);
                    if (!File.Exists(logo)) MessageBox.Show("No se ha encontrado la imagen: " + logo);
                    else oTable.Cell(1, 1).Range.InlineShapes.AddPicture(logo, ref oMissing, ref oMissing, ref oMissing);
                    oTable.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    oTable.Borders.InsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;
                    oTable.Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;

                    //SETTING FOCUS BACK TO DOCUMENT
                    oDoc.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
                }

            }

            //Márgenes (1cm aprox.)

            oDoc.PageSetup.LeftMargin = 50;
            oDoc.PageSetup.RightMargin = 50;

            object fileName = "C:\\Temp\\InformeAccionesCorrectoras_" + informe.Codigo.Replace('/','-') + ".doc";
            oDoc.SaveAs(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            Close();
        }

        public void ExportInformePlanAnual(PlanAnualInfo plan)
        {
            Word.Document oDoc = NewDocument();
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Márgenes (1cm aprox.)
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            oDoc.PageSetup.LeftMargin = 50;
            oDoc.PageSetup.RightMargin = 50;

            //Tabla encabezado
            Word.Table oTableEncabezado; 
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableEncabezado = oDoc.Tables.Add(wrdRng, 1, 2, ref oMissing, ref oMissing);

            oTableEncabezado.Range.ParagraphFormat.SpaceAfter = 0;
            oTableEncabezado.Range.ParagraphFormat.SpaceBefore = 0;

            oTableEncabezado.Borders.Enable = 0;

            oTableEncabezado.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            oTableEncabezado.Columns[1].Width = 100F;
            oTableEncabezado.Columns[2].Width = 600F;

            oTableEncabezado.Range.Font.Bold = 1;
            oTableEncabezado.Range.Font.Size = 14;
            oTableEncabezado.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            oTableEncabezado.Cell(1, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            //oTableEncabezado.Cell(1, 2).Range.Paragraphs.Add(ref oMissing);
            oTableEncabezado.Cell(1, 2).Range.Paragraphs.Last.Range.Text = "PLAN ANUAL DE AUDITORÍAS";
            oTableEncabezado.Cell(1, 2).Range.Paragraphs.Last.Range.Font.Size = 12;
            oTableEncabezado.Cell(1, 2).Range.Paragraphs.Last.Range.Font.Bold = 1;
            oTableEncabezado.Cell(1, 2).Range.Paragraphs.Last.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            oTableEncabezado.Cell(1, 2).Range.Paragraphs.Add(ref oMissing);

            oTableEncabezado.Cell(1, 2).Range.Paragraphs.Add(ref oMissing);
            oTableEncabezado.Cell(1, 2).Range.Paragraphs.Last.Range.Text = "SISTEMA DE CALIDAD";
            oTableEncabezado.Cell(1, 2).Range.Paragraphs.Last.Range.Font.Size = 11;
            oTableEncabezado.Cell(1, 2).Range.Paragraphs.Last.Range.Font.Bold = 1;
            oTableEncabezado.Cell(1, 2).Range.Paragraphs.Last.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            string logo = CompanyInfo.GetLogoPath(AppContext.ActiveSchema.Oid);
            if (!File.Exists(logo)) MessageBox.Show("No se ha encontrado la imagen: " + logo);
            else oTableEncabezado.Cell(1, 1).Range.InlineShapes.AddPicture(logo, ref oMissing, ref oMissing, ref oMissing);
            oTableEncabezado.Rows.Height = 50F;

            oDoc.Paragraphs.Add(ref oMissing);

            //Tabla informativa
            Word.Table oTable;
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 2, 2, ref oMissing, ref oMissing);

            oTable.Range.ParagraphFormat.SpaceAfter = 1;
            oTable.Range.ParagraphFormat.SpaceBefore = 1;

            oTable.Borders.Enable = 1;

            oTable.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            oTable.Columns[1].Width = 500F;
            oTable.Columns[2].Width = 200F;

            oTable.Range.Font.Bold = 1;
            oTable.Range.Font.Size = 8;
            oTable.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(1, 1).Range.Text = "Auditorías";
            oTable.Cell(1, 2).Range.Text = "SISTEMA DE CALIDAD PARTE 66-147";
            oTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTable.Cell(2, 1).Range.Text = plan.Nombre;

            oDoc.Paragraphs.Add(ref oMissing);

            AreaList areas = AreaList.GetList(false);

            int n_columnas = 16 + areas.Count;

            //Tabla de datos
            Word.Table oTableDatos;
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTableDatos = oDoc.Tables.Add(wrdRng, 2, n_columnas, ref oMissing, ref oMissing);

            oTableDatos.Range.ParagraphFormat.SpaceAfter = 1;
            oTableDatos.Range.ParagraphFormat.SpaceBefore = 1;

            int indice_columna = 0;
            for (int ic = 5; ic <= n_columnas; ic++)
                oTableDatos.Columns[ic].Width = 15F;

            oTableDatos.Columns[1].Width = 50F;
            oTableDatos.Columns[2].Width = 50F;
            oTableDatos.Columns[3].Width = 100F;

            oTableDatos.Columns[4].Width = 500 - (12 + areas.Count) * 15;

            oTableDatos.Borders.Enable = 1;
            oTableDatos.Range.Bold = 1;
            oTableDatos.Range.Font.Size = 8;

            oTableDatos.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;
            oTableDatos.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTableDatos.Rows[2].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            for (int i = 1; i < 4; i++)
                oTableDatos.Cell(1, 1).Merge(oTableDatos.Cell(1, 2));

            for (int i = 1; i < areas.Count; i++)
                oTableDatos.Cell(1, 2).Merge(oTableDatos.Cell(1, 3));

            for (int i = 1; i < 12; i++)
                oTableDatos.Cell(1, 3).Merge(oTableDatos.Cell(1, 4));

            oTableDatos.Cell(1, 2).Range.Text = "ÁREAS";
            oTableDatos.Cell(1, 3).Range.Text = "AUDITORÍAS / SEGUIMIENTO";

            oTableDatos.Cell(2, 1).Range.Text = "TIPO";
            oTableDatos.Cell(2, 2).Range.Text = "NÚMERO";
            oTableDatos.Cell(2, 3).Range.Text = "CLASE";
            oTableDatos.Cell(2, 4).Range.Text = "NOMBRE DE AUDITORÍA";

            int column_index, j;
            for (column_index = 5, j = 0; j < areas.Count; column_index++, j++)
            {
                oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
                oTableDatos.Cell(2, column_index).Range.Text = areas[j].Nombre.ToUpper();
            }

            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "ENERO";
            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "FEBRERO";
            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "MARZO";
            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "ABRIL";
            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "MAYO";
            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "JUNIO";
            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "JULIO";
            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "AGOSTO";
            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "SEPTIEMBRE";
            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "OCTUBRE";
            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "NOVIEMBRE";
            oTableDatos.Cell(2, column_index).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            oTableDatos.Cell(2, column_index++).Range.Text = "DICIEMBRE";

            TipoAuditoriaList tipos = TipoAuditoriaList.GetList();
            ClaseAuditoriaList clases = ClaseAuditoriaList.GetList(false);

            //Me tengo que traer la lista de PlanesTipos ordenada por número de Tipo de Auditoría 
            //y quitando los repetidos

            Plan_TipoList planes = Plan_TipoList.GetPlanAnualList(plan.Oid);
            int indice = 0;
            long oid_clase = 0;
            int indice_clase = 2;

            foreach (Plan_TipoInfo plan_tipo in planes)
            {
                object oRng;

                TipoAuditoriaInfo tipo = tipos.GetItem(plan_tipo.OidTipo);
                ClaseAuditoriaInfo clase = clases.GetItem(tipo.OidClaseAuditoria);

                if (indice != 0)
                {
                    if (plan_tipo.OidTipo == planes[indice - 1].OidTipo)
                        continue;
                    if (oid_clase != 0 && oid_clase != clase.Oid)
                    {
                        oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        //object last = oTableCuestiones.Rows.Last.Range;
                        oTableDatos.Rows.Add(ref oRng);

                        for (int k = 1; k <= n_columnas; k++)
                            oTableDatos.Cell(oTableDatos.Rows.Count, k).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorBlack;
                    }
                }

                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                //object last = oTableCuestiones.Rows.Last.Range;
                oTableDatos.Rows.Add(ref oRng);

                int indice_fila = oTableDatos.Rows.Count;

                for (int k = 1; k <= n_columnas; k++)
                    oTableDatos.Cell(indice_fila, k).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorAutomatic;

                if (indice == 0 || oid_clase != clase.Oid)
                {
                    indice_clase = indice_fila;
                    oTableDatos.Cell(indice_fila, 1).Range.Text = clase.Tipo;
                    oTableDatos.Cell(indice_fila, 2).Range.Text = clase.Numero.ToString();
                    oTableDatos.Cell(indice_fila, 3).Range.Text = clase.Nombre;
                    oTableDatos.Cell(indice_fila, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    oTableDatos.Cell(indice_fila, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    oTableDatos.Cell(indice_fila, 3).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                }
                else
                {
                    oTableDatos.Cell(indice_fila, 1).Merge(oTableDatos.Cell(indice_clase, 1));
                    oTableDatos.Cell(indice_fila, 2).Merge(oTableDatos.Cell(indice_clase, 2));
                    oTableDatos.Cell(indice_fila, 3).Merge(oTableDatos.Cell(indice_clase, 3));
                }
                oTableDatos.Cell(indice_fila, 4).Range.Text = tipo.Numero + " " + tipo.Nombre;
                oTableDatos.Cell(indice_fila, 4).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

                for (int i = 0; i < areas.Count; i++)
                {
                    foreach (Auditoria_AreaInfo item in tipo.Areas)
                    {
                        if (item.OidArea == areas[i].Oid)
                        {
                            oTableDatos.Cell(indice_fila, 5 + i).Range.Text = "X";
                            oTableDatos.Cell(indice_fila, 5 + i).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                            break;
                        }
                    }
                }

                indice_columna = n_columnas - 12 + 1;

                if (plan_tipo.Enero)
                    oTableDatos.Cell(indice_fila, indice_columna).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                if (plan_tipo.Febrero)
                    oTableDatos.Cell(indice_fila, indice_columna + 1).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna + 1).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                if (plan_tipo.Marzo)
                    oTableDatos.Cell(indice_fila, indice_columna + 2).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna + 2).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                if (plan_tipo.Abril)
                    oTableDatos.Cell(indice_fila, indice_columna + 3).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna + 3).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                if (plan_tipo.Mayo)
                    oTableDatos.Cell(indice_fila, indice_columna + 4).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna + 4).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                if (plan_tipo.Junio)
                    oTableDatos.Cell(indice_fila, indice_columna + 5).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna + 5).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                if (plan_tipo.Julio)
                    oTableDatos.Cell(indice_fila, indice_columna + 6).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna + 6).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                if (plan_tipo.Agosto)
                    oTableDatos.Cell(indice_fila, indice_columna + 7).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna + 7).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                if (plan_tipo.Septiembre)
                    oTableDatos.Cell(indice_fila, indice_columna + 8).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna + 8).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                if (plan_tipo.Octubre)
                    oTableDatos.Cell(indice_fila, indice_columna + 9).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna + 9).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                if (plan_tipo.Noviembre)
                    oTableDatos.Cell(indice_fila, indice_columna + 10).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna + 10).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                if (plan_tipo.Diciembre)
                    oTableDatos.Cell(indice_fila, indice_columna + 11).Range.Text = "X";
                oTableDatos.Cell(indice_fila, indice_columna + 11).Range.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;

                indice++;
                oid_clase = clase.Oid;

            }
            oTableDatos.Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightExactly;
            oTableDatos.Cell(2, n_columnas).Height = 120F;

            for (int k = 1; k <= oTableDatos.Rows.Count; k++)
            {
                try
                {
                    if (oTableDatos.Cell(k, n_columnas).Range.Shading.BackgroundPatternColor == Word.WdColor.wdColorBlack)
                        oTableDatos.Cell(k, n_columnas).Height = 2F;
                }
                catch { continue; }
            }

            oDoc.Paragraphs.Add(ref oMissing);

            //Tabla pie
            Word.Table oTablePie;
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTablePie = oDoc.Tables.Add(wrdRng, 2, 2, ref oMissing, ref oMissing);

            oTablePie.Range.ParagraphFormat.SpaceAfter = 1;
            oTablePie.Range.ParagraphFormat.SpaceBefore = 1;

            oTablePie.Borders.Enable = 1;

            oTablePie.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            oTablePie.Columns[1].Width = 500F;
            oTablePie.Columns[2].Width = 200F;

            oTablePie.Cell(2, 1).Merge(oTablePie.Cell(2, 2));

            oTablePie.Range.Font.Bold = 1;
            oTablePie.Range.Font.Size = 8;
            oTablePie.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTablePie.Cell(1, 1).Range.Text = "GERENTE RESPONSABLE (NOMBRE, FIRMA Y FECHA):";
            oTablePie.Cell(1, 2).Range.Text = "EDIC: " + plan.Edicion + " REV: " + plan.Revision + "FECHA: " + plan.Fecha.ToShortDateString();
            oTablePie.Cell(2, 1).Range.Text = "RESPONSABLE DE CALIDAD (NOMBRE, FIRMA Y FECHA):";

            object fileName = "C:\\Temp\\PlanAnual_" + plan.Ano.ToString() + ".doc";
            oDoc.SaveAs(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            Close();
        }

        public void ExportActaComite(ActaComiteInfo acta)
        {
            Word.Document oDoc = NewDocument();
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Márgenes (1cm aprox.)
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
            oDoc.PageSetup.LeftMargin = 50;
            oDoc.PageSetup.RightMargin = 50;

            //Tabla encabezado
            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 6, 2, ref oMissing, ref oMissing);

            oTable.Range.ParagraphFormat.SpaceAfter = 0;
            oTable.Range.ParagraphFormat.SpaceBefore = 0;

            oTable.Borders.Enable = 1;

            oTable.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            oTable.Columns[1].Width = 200F;
            oTable.Columns[2].Width = 200F;

            oTable.Range.Font.Bold = 1;
            oTable.Range.Font.Size = 14;
            oTable.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            oTable.Rows[1].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTable.Cell(1, 1).Range.Text = "Nº DE REVISIÓN:";
            oTable.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTable.Cell(1, 2).Range.Text = acta.Revision.ToString();
            oTable.Cell(1, 2).Range.Bold = 0;
            oTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Rows[2].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTable.Cell(2, 1).Range.Text = "MOTIVO:";
            oTable.Cell(2, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTable.Cell(2, 2).Range.Text = acta.Motivo;
            oTable.Cell(2, 2).Range.Bold = 0;
            oTable.Cell(2, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Rows[3].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTable.Cell(3, 1).Range.Text = "FECHA:";
            oTable.Cell(3, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTable.Cell(3, 2).Range.Text = acta.Fecha.ToShortDateString();
            oTable.Cell(3, 2).Range.Bold = 0;
            oTable.Cell(3, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(4, 1).Merge(oTable.Cell(4, 2));
            oTable.Cell(4, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oTable.Cell(4, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oTable.Cell(4, 1).Range.Bold = 0;

            oTable.Cell(4, 1).Range.Text = string.Empty;

            foreach (PuntoActaInfo punto in acta.PuntosActas)
                oTable.Cell(4, 1).Range.Text += punto.Numero.ToString() + ". " 
                    + punto.Texto + Environment.NewLine;

            oTable.Rows[5].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            oTable.Cell(5, 1).Range.Text = "FIRMA RESPONSABLE DE CALIDAD";
            oTable.Cell(5, 2).Range.Text = "FIRMA GERENTE RESPONSABLE";

            oTable.Rows[6].Height = 100F;

            object fileName = "C:\\Temp\\ActaComite_" + acta.Codigo + ".doc";
            oDoc.SaveAs(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            Close();
        }

        public void Cerrar()
        {
            Close();
        }

        #endregion

        #region Business Methods Informe Precios

        private Excel.Range GetRange(Excel.Worksheet sheet, char start, int index, int count, bool porFilas)
        {
            char c = start.ToString().ToUpper()[0];
            string init, final;
            init = c.ToString() + index.ToString();

            if (!porFilas)
            {
                int aux = count == 0 ? 0 : count - 1;
                c = (char)((int)c + aux);
                final = c.ToString() + index.ToString();
            }
            else
            {
                int aux = index + count;
                final = c.ToString() + aux.ToString();
            }

            return sheet.get_Range(init, final);
        }

        public void ExportInformePrecios(DataTable datos, string tipo)
        {
            /*Excel.Workbook theWorkbook = null;

            try
            {
                theWorkbook = (Excel.Workbook)(OfficeExporter.__excel_obj.Workbooks.Add(Missing.Value));
            }
            catch (Exception ex)
            {
                _excel_obj.Workbooks.Close();
                Cerrar();
                throw new Exception(ex.Message);
            }*/

            Excel.Workbook theWorkbook = ExcelExporter.NewWorkbook();
            Excel.Worksheet sheet = (Excel.Worksheet)theWorkbook.ActiveSheet;
            Excel.Range rango = null;
            string nombre = string.Empty;

            int fila_inicial = 8;


            //foreach (DataColumn dc in datos.Columns)
            //{
            //    sheet.Cells[fila_inicial, i] = dc.ColumnName.ToUpper();
            //}

            sheet.Cells[2, 1] = "INFORME DE PRECIOS";
            sheet.Cells[4, 1] = "TIPO: " + tipo.ToUpper();
            sheet.Cells[4, datos.Columns.Count] = "FECHA: " + DateTime.Today.ToShortDateString();

            //Dar formato a las cabeceras mediante rangos -> negrita, alineación central, ajustar, sombrado y bordes
            rango = GetRange(sheet, 'A', 2, datos.Columns.Count, false);
            rango.MergeCells = true;
            rango.Font.Bold = true;
            rango.Font.Size = 14;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.Borders.Weight = Excel.XlBorderWeight.xlThin;

            string[] cabeceras = new string[datos.Columns.Count];
            double[] precios_productos = new double[datos.Columns.Count - 1];

            string max = string.Empty;
            {
                int i, j;
                if (datos.Columns[0].ColumnName.Contains("Cliente"))
                {
                    cabeceras[0] = "(Numero) Nombre";
                    i = j = 2;
                }
                else
                {
                    cabeceras[0] = "Nombre";
                    i = j = 1;
                }

                for (; i < datos.Columns.Count; i++)
                {
                    string cName = datos.Columns[i].ColumnName;
                    cabeceras[i] = cName;
                    if (max.Length < cName.Length)
                        max = cName;
                    precios_productos[i - j] = Convert.ToDouble(cName.Substring(cName.IndexOf("\n") + 1));
                }
            }

            //Dar formato a las cabeceras mediante rangos -> negrita, alineación central, ajustar, sombrado y bordes
            rango = GetRange(sheet, 'A', fila_inicial, datos.Columns.Count, false);
            int h = TextRenderer.MeasureText(max, new Font(rango.Font.Name.ToString(), (float)9)).Height;
            int n = 0;
            for (int i = 0; i < max.Length; i++)
            {
                if (max[i] == ' ' || max[i] == '\n')
                    n++;
            }
            rango.RowHeight = h * (n - 2);
            rango.Font.Bold = true;
            rango.Font.Size = 9;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.WrapText = true;
            rango.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
            rango.Borders.Weight = Excel.XlBorderWeight.xlThin;
            rango.Value2 = cabeceras;
            rango.ColumnWidth = 30;

            int indice = fila_inicial + 1;

            foreach (DataRow row in datos.Rows)
            {
                string[] sTextos = new string[1];
                sTextos[0] = row[0].ToString();

                rango = GetRange(sheet, 'A', indice, 1, false);
                rango.Value2 = sTextos;
                rango.ColumnWidth = 30;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                double[] valores = new double[datos.Columns.Count - 1];
                for (int i = 1; i < datos.Columns.Count; i++)
                {
                    try
                    {
                        double d = Double.Parse(row[i].ToString());
                        valores[i - 1] = d;
                    }
                    catch
                    {
                    }
                }

                rango = GetRange(sheet, 'B', indice, datos.Columns.Count - 1, false);
                rango.Value2 = valores;
                rango.ColumnWidth = 30;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                for (int i = 1; i < datos.Columns.Count; i++)
                {
                    if (row[i].ToString().Equals("-"))
                    {
                        sheet.Cells[indice, i + 1] = "No Asignado";
                        continue;
                    }
                    if (precios_productos[i - 1] > valores[i - 1])
                    {
                        rango = GetRange(sheet, (char)((int)'B' + (i - 1)), indice, 1, false);
                        rango.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Red);
                        //((Excel.Range)rango.Cells[indice, i + 1]).Interior.Color =
                        //    System.Drawing.ColorTranslator.ToOle(Color.Red);
                    }

                }
                indice++;
            }

            //Hacemos visible Excel y damos el control al usuario
            /*_excel_obj.Visible = true;
            _excel_obj.UserControl = true;

            // Se necesita para limpiar todas las refrencias del Excel
            /*theWorkbook.Close(
            _excel_obj.Workbooks.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(theWorkbook);
            worksheet = null;
            theWorkbook = null;/**/
        }

        #endregion

        #region Factory Methods

        public WordExporter()
        {
            InitWordExporter();
        }

        #endregion

    }
}
