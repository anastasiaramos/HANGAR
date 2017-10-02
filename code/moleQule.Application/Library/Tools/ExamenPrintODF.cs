using System;
using NUnit.Framework;
using System.Xml;
using AODL.Document.SpreadsheetDocuments;
using AODL.Document.Content.Tables;
using AODL.Document.Content.Text;
using AODL.Document.Styles;
using AODL.Document.TextDocuments;

namespace Hangar.Library
{
    public class ExamenPrintODF
    {
        /// <summary>
        /// Creates the new document 
        /// </summary>
        public static void CreateNewDocument()
        {
            //some text e.g read from a TextBox
            string someText = "";

            //Create new TextDocument
            TextDocument document = new TextDocument();
            document.New();

            Table oTable = TableBuilder.CreateTextDocumentTable(
                document,
                "ctable",
                "ctable",
                0,
                0,
                16.99,
                false,
                false);
            
            //Create a standard paragraph
            Paragraph paragraph = ParagraphBuilder.CreateStandardTextParagraph(document);
            //Add some simple text
            paragraph.TextContent.Add(new SimpleText(document, "Some cell text"));
            ColumnStyle estilo = new ColumnStyle(document);

            Column columna = new Column(oTable, estilo.StyleName);
            Cell celda = oTable.CreateCell();
            columna.Table.Rows.Add(new Row(oTable));
            columna.Table.Rows[oTable.Rows.Count - 1].Cells.Add(celda);
            columna.Table.Rows[oTable.Rows.Count - 1].Cells[0].Content.Add(paragraph);
            oTable.ColumnCollection.Add(columna);


            //    //Tabla de encabezado
            //    Word.Table oTable;
            //    Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //    oTable = oDoc.Tables.Add(wrdRng, 6, 4, ref oMissing, ref oMissing);

            //    oTable.Range.ParagraphFormat.SpaceAfter = 6;
            //    oTable.Range.ParagraphFormat.SpaceBefore = 6;

            //    oTable.Columns[1].Cells.Merge();
            //    oTable.Borders.Enable = 1;
            //    oTable.Borders.InsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;
            //    oTable.Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;

            //    oTable.Columns[2].Cells[1].Merge(oTable.Columns[2].Cells[2]);
            //    oTable.Columns[2].Cells[2].Merge(oTable.Columns[2].Cells[3]);

            //    oTable.Columns[3].Cells[2].Merge(oTable.Columns[3].Cells[3]);
            //    oTable.Columns[3].Cells[3].Merge(oTable.Columns[3].Cells[4]);

            //    oTable.Columns[4].Cells[2].Merge(oTable.Columns[4].Cells[3]);
            //    oTable.Columns[4].Cells[3].Merge(oTable.Columns[4].Cells[4]);

            //    oTable.Columns[1].Width = 108.44F;
            //    oTable.Columns[3].Width = 81.33F;
            //    oTable.Columns[4].Width = 81.33F;
            //    oTable.Columns[2].Width = 271.1F;

            //    oTable.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

            //    string logo = EmpresaInfo.GetLogoPath(AppContext.ActiveSchema.Oid);
            //    oTable.Cell(1, 1).Range.InlineShapes.AddPicture(logo, ref oMissing, ref oMissing, ref oMissing);
            //    oTable.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            
            //Create a table for a text document using the TableBuilder
            //Table table = TableBuilder.CreateTextDocumentTable(
            //    document,
            //    "table1",
            //    "table1",
            //    3,
            //    3,
            //    16.99,
            //    false,
            //    false);
            
            ////Insert paragraph into the first cell
            //table.Rows[0].Cells[0].Content.Add(paragraph);
            //Add table to the document
            document.Content.Add(oTable);
            //document.Content.Add(table);
            //Save the document
            document.SaveTo("C:\\Users\\Anastasia\\Desktop\\simpleTable.odt");
        }


        //private void GeneraWord()
        //{
        //    object oMissing = System.Reflection.Missing.Value;
        //    object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

        //    //Start Word and create a new document.
        //    Word._Application oWord;
        //    Word._Document oDoc;
        //    oWord = new Word.Application();
        //    oWord.Visible = true;
        //    oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
        //        ref oMissing, ref oMissing);

        //    foreach (Word.Section wordSection in oDoc.Sections)
        //    {
        //        wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
        //      .Range.Text = "MT Roalmed S.L.";
        //        wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.ShowFirstPageNumber = true;
        //        wordSection.Range.ParagraphFormat.SpaceAfter = 0;
        //        wordSection.Range.ParagraphFormat.SpaceBefore = 0;
        //    }

        //    //Márgenes (1cm aprox.)
        //    oDoc.PageSetup.TopMargin = 15;
        //    oDoc.PageSetup.BottomMargin = 0;
        //    oDoc.PageSetup.LeftMargin = 30;
        //    oDoc.PageSetup.RightMargin = 30;

        //    //Tabla de encabezado
        //    Word.Table oTable;
        //    Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //    oTable = oDoc.Tables.Add(wrdRng, 6, 4, ref oMissing, ref oMissing);

        //    oTable.Range.ParagraphFormat.SpaceAfter = 6;
        //    oTable.Range.ParagraphFormat.SpaceBefore = 6;

        //    oTable.Columns[1].Cells.Merge();
        //    oTable.Borders.Enable = 1;
        //    oTable.Borders.InsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;
        //    oTable.Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;

        //    oTable.Columns[2].Cells[1].Merge(oTable.Columns[2].Cells[2]);
        //    oTable.Columns[2].Cells[2].Merge(oTable.Columns[2].Cells[3]);

        //    oTable.Columns[3].Cells[2].Merge(oTable.Columns[3].Cells[3]);
        //    oTable.Columns[3].Cells[3].Merge(oTable.Columns[3].Cells[4]);

        //    oTable.Columns[4].Cells[2].Merge(oTable.Columns[4].Cells[3]);
        //    oTable.Columns[4].Cells[3].Merge(oTable.Columns[4].Cells[4]);

        //    oTable.Columns[1].Width = 108.44F;
        //    oTable.Columns[3].Width = 81.33F;
        //    oTable.Columns[4].Width = 81.33F;
        //    oTable.Columns[2].Width = 271.1F;

        //    oTable.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

        //    string logo = EmpresaInfo.GetLogoPath(AppContext.ActiveSchema.Oid);
        //    oTable.Cell(1, 1).Range.InlineShapes.AddPicture(logo, ref oMissing, ref oMissing, ref oMissing);
        //    oTable.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

        //    ExamenPrint examen = Entity.GetPrintObject(EmpresaInfo.Get(AppContext.ActiveSchema.Oid, false));

        //    oTable.Cell(1, 2).Range.Text = "HOJA DE PREGUNTAS";
        //    oTable.Cell(1, 2).Range.Font.Bold = 1;
        //    oTable.Cell(1, 2).Range.Font.Size = 16;
        //    oTable.Cell(1, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[2].Cells[1].Range.Font.Name = "Arial";

        //    oTable.Columns[2].Cells[2].Range.Text = examen.Modulo;
        //    oTable.Columns[2].Cells[2].Range.Font.Bold = 1;
        //    oTable.Columns[2].Cells[2].Range.Font.Size = 11;
        //    oTable.Columns[2].Cells[2].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Columns[2].Cells[2].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[2].Cells[2].Range.Font.Name = "Arial";

        //    oTable.Columns[2].Cells[3].Range.Text = "PROMOCIÓN : " + examen.Promocion;
        //    oTable.Columns[2].Cells[3].Range.Font.Bold = 1;
        //    oTable.Columns[2].Cells[3].Range.Font.Size = 11;
        //    oTable.Columns[2].Cells[3].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Columns[2].Cells[3].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[2].Cells[3].Range.Font.Name = "Arial";

        //    oTable.Columns[2].Cells[4].Range.Text = "Deberá responder a las preguntas del examen a continuación de las mismas.";
        //    oTable.Columns[2].Cells[4].Range.Font.Size = 11;
        //    oTable.Columns[2].Cells[4].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Columns[2].Cells[4].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[2].Cells[4].Range.Font.Name = "Arial";

        //    oTable.Columns[3].Cells[1].Range.Text = "FECHA";
        //    oTable.Columns[3].Cells[1].Range.Font.Bold = 1;
        //    oTable.Columns[3].Cells[1].Range.Font.Size = 11;
        //    oTable.Columns[3].Cells[1].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Columns[3].Cells[1].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[3].Cells[1].Range.Font.Name = "Arial";

        //    oTable.Columns[3].Cells[2].Range.Text = "TIPO EXAMEN";
        //    oTable.Columns[3].Cells[2].Range.Font.Bold = 1;
        //    oTable.Columns[3].Cells[2].Range.Font.Size = 11;
        //    oTable.Columns[3].Cells[2].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Columns[3].Cells[2].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[3].Cells[2].Range.Font.Name = "Arial";

        //    oTable.Columns[3].Cells[3].Range.Text = "Nº PREGUNTAS";
        //    oTable.Columns[3].Cells[3].Range.Font.Bold = 1;
        //    oTable.Columns[3].Cells[3].Range.Font.Size = 11;
        //    oTable.Columns[3].Cells[3].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Columns[3].Cells[3].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[3].Cells[3].Range.Font.Name = "Arial";

        //    oTable.Columns[3].Cells[4].Range.Text = "TIEMPO";
        //    oTable.Columns[3].Cells[4].Range.Font.Bold = 1;
        //    oTable.Columns[3].Cells[4].Range.Font.Size = 11;
        //    oTable.Columns[3].Cells[4].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Columns[3].Cells[4].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[3].Cells[4].Range.Font.Name = "Arial";

        //    oTable.Columns[4].Cells[1].Range.Text = examen.FechaExamen.ToShortDateString();
        //    oTable.Columns[4].Cells[1].Range.Font.Size = 11;
        //    oTable.Columns[4].Cells[1].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Columns[4].Cells[1].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[4].Cells[1].Range.Font.Name = "Arial";

        //    oTable.Columns[4].Cells[2].Range.Text = examen.Tipo;
        //    oTable.Columns[4].Cells[2].Range.Font.Size = 11;
        //    oTable.Columns[4].Cells[2].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Columns[4].Cells[2].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[4].Cells[2].Range.Font.Name = "Arial";

        //    oTable.Columns[4].Cells[3].Range.Text = examen.NPreguntas.ToString();
        //    oTable.Columns[4].Cells[3].Range.Font.Size = 11;
        //    oTable.Columns[4].Cells[3].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Columns[4].Cells[3].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[4].Cells[3].Range.Font.Name = "Arial";

        //    oTable.Columns[4].Cells[4].Range.Text = examen.Duracion.ToShortTimeString();
        //    oTable.Columns[4].Cells[4].Range.Font.Size = 11;
        //    oTable.Columns[4].Cells[4].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    oTable.Columns[4].Cells[4].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //    oTable.Columns[4].Cells[4].Range.Font.Name = "Arial";

        //    oTable.Range.InsertParagraphAfter();

        //    ////Add some text after the table.
        //    Word.Paragraph oParaAux;
        //    object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //    oParaAux = oDoc.Content.Paragraphs.Add(ref oRng);
        //    oParaAux.Range.Text = string.Empty;
        //    oParaAux.Range.InsertParagraph();

        //    //Nombre y apellidos
        //    Word.Paragraph oPara1;
        //    oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
        //    oPara1.Range.Text = "NOMBRE Y APELLIDOS:";
        //    oPara1.Range.Font.Size = 12;
        //    oPara1.Range.Font.Name = "Arial";
        //    oPara1.Range.InsertParagraphAfter();
        //    oPara1.Range.InsertParagraphBefore();

        //    //DNI/NIE, FIRMA
        //    Word.Paragraph oPara2;
        //    oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
        //    oPara2.Range.Text = "DNI/NIE:                                                           FIRMA:";
        //    oPara2.Range.Font.Size = 12;
        //    oPara2.Range.Font.Name = "Arial";
        //    oPara2.Range.InsertParagraphAfter();
        //    oPara2.Range.InsertParagraphBefore();

        //    if (_preguntas_examen != null)
        //    {
        //        int i = 1;

        //        foreach (Pregunta_Examen preg in _preguntas_examen)
        //        {
        //            Pregunta item = _preguntas.GetItem(preg.OidPregunta);

        //            //Para cada pregunta se inserta una tabla
        //            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            Word.Range newRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            int paginas_antes = (int)(oTable.Range.get_Information(Word.WdInformation.wdNumberOfPagesInDocument));
        //            oTable = oDoc.Tables.Add(wrdRng, 2, 3, ref oMissing, ref oMissing);

        //            oTable.Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightAuto;

        //            oTable.Columns[1].Width = 30;
        //            oTable.Cell(1, 1).Range.Text = i.ToString();
        //            oTable.Cell(1, 1).Range.Font.Size = 10;
        //            oTable.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //            oTable.Cell(1, 1).Range.Font.Bold = 1;
        //            oTable.Cell(1, 1).Range.Font.Name = "Arial";

        //            oTable.Cell(1, 2).Merge(oTable.Columns[3].Cells[1]);
        //            oTable.Cell(1, 2).Width = 510;
        //            oTable.Cell(1, 2).Range.Text = item.Texto;
        //            oTable.Cell(1, 2).Range.Font.Size = 10;
        //            oTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
        //            oTable.Cell(1, 2).Range.Font.Bold = 1;
        //            oTable.Cell(1, 2).Range.Font.Name = "Arial";

        //            oTable.Cell(2, 2).Merge(oTable.Cell(2, 3));
        //            oTable.Cell(2, 1).Merge(oTable.Cell(2, 2));
        //            oTable.Cell(2, 1).Width = 540;

        //            if (item.Imagen != string.Empty)
        //            {
        //                string path = Images.GetRootPath() + PreguntaInfo.GetImagenesPath() + item.Imagen;
        //                if (File.Exists(path))
        //                {
        //                    oTable.Cell(2, 1).Range.InlineShapes.AddPictureBullet(path, ref oMissing);
        //                    oTable.Cell(2, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    oTable.Cell(2, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //                }
        //                else
        //                    oTable.Rows[2].Delete();
        //            }
        //            else
        //                oTable.Rows[2].Delete();

        //            ////Add some text after the table.
        //            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            oParaAux = oDoc.Content.Paragraphs.Add(ref oRng);
        //            oParaAux.Range.Text = string.Empty;
        //            oParaAux.Range.InsertParagraph();

        //            int paginas_despues = (int)(oParaAux.Range.get_Information(Word.WdInformation.wdNumberOfPagesInDocument));
        //            if (paginas_antes < paginas_despues)
        //                newRng.InsertBreak(ref oMissing);

        //            i++;
        //        }
        //    }
        //    else
        //    {
        //        foreach (PreguntaExamenInfo item in Entity.PreguntaExamens)
        //        {
        //            //Para cada pregunta se inserta una tabla
        //            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            Word.Range newRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            int paginas_antes = (int)(oTable.Range.get_Information(Word.WdInformation.wdNumberOfPagesInDocument));
        //            oTable = oDoc.Tables.Add(wrdRng, 2, 3, ref oMissing, ref oMissing);

        //            oTable.Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightAuto;

        //            oTable.Columns[1].Width = 30;
        //            oTable.Cell(1, 1).Range.Text = item.Orden.ToString();
        //            oTable.Cell(1, 1).Range.Font.Size = 10;
        //            oTable.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //            oTable.Cell(1, 1).Range.Font.Bold = 1;
        //            oTable.Cell(1, 1).Range.Font.Name = "Arial";

        //            oTable.Cell(1, 2).Merge(oTable.Columns[3].Cells[1]);
        //            oTable.Cell(1, 2).Width = 510;
        //            oTable.Cell(1, 2).Range.Text = item.Texto;
        //            oTable.Cell(1, 2).Range.Font.Size = 10;
        //            oTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
        //            oTable.Cell(1, 2).Range.Font.Bold = 1;
        //            oTable.Cell(1, 2).Range.Font.Name = "Arial";

        //            oTable.Cell(2, 2).Merge(oTable.Cell(2, 3));
        //            oTable.Cell(2, 1).Merge(oTable.Cell(2, 2));
        //            oTable.Cell(2, 1).Width = 540;

        //            if (item.Imagen != string.Empty)
        //            {
        //                string path = Images.GetRootPath() + PreguntaExamenInfo.GetImagenesPath() +
        //                    item.OidExamen.ToString("00000") + "\\" + item.Imagen;
        //                if (File.Exists(path))
        //                {
        //                    oTable.Cell(2, 1).Range.InlineShapes.AddPictureBullet(path, ref oMissing);
        //                    oTable.Cell(2, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    oTable.Cell(2, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //                }
        //                else
        //                    oTable.Rows[2].Delete();
        //            }
        //            else
        //                oTable.Rows[2].Delete();

        //            ////Add some text after the table.
        //            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            oParaAux = oDoc.Content.Paragraphs.Add(ref oRng);
        //            oParaAux.Range.Text = string.Empty;
        //            oParaAux.Range.InsertParagraph();

        //            int paginas_despues = (int)(oParaAux.Range.get_Information(Word.WdInformation.wdNumberOfPagesInDocument));
        //            if (paginas_antes < paginas_despues)
        //                newRng.InsertBreak(ref oMissing);
        //        }
        //    }
        //}
    }
}


