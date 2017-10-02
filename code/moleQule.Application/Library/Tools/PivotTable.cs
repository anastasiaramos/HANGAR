using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace moleQule.Library.Application.Tools
{
    public static class PivotTable
    {
        public static DataTable GetClientDataTable(DataTable table)
        {
            return GetInversedDataTable(table, "NombreProducto", "NombreCliente", "PrecioCliente", true);
        }

        public static DataTable GetProvDataTable(DataTable table)
        {
            return GetInversedDataTable(table, "NombreProducto", "NombreProveedor", "PrecioProveedor", false);
        }

        /// <summary>
        /// Gets a Inverted DataTable
        /// </summary>
        /// <param name="table">Provided DataTable</param>
        /// <param name="columnX">X Axis Column</param>
        /// <param name="columnY">Y Axis Column</param>
        /// <param name="columnZ">Z Axis Column (values)</param>
        /// <param name="columnsToIgnore">Whether to ignore some column, it must be 
        /// provided here</param>
        /// <param name="nullValue">null Values to be filled</param> 
        /// <returns>C# Pivot Table Method  - Felipe Sabino</returns>
        private static DataTable GetInversedDataTable(DataTable table, string columnX,
             string columnY, string columnZ, bool isClient)
        {
            //Create a DataTable to Return
            DataTable returnTable = new DataTable();

            if (columnX == "")
                columnX = table.Columns[0].ColumnName;

            if (isClient)
                returnTable.Columns.Add("NumeroCliente");
            //Add a Column at the beginning of the table
            returnTable.Columns.Add(columnY);


            //Read all DISTINCT values from columnX Column in the provided DataTale
            List<string> columnXValues = new List<string>();

            foreach (DataRow dr in table.Rows)
            {

                string columnXTemp = dr[columnX].ToString();
                if (!columnXValues.Contains(columnXTemp))
                {
                    //Read each row value, if it's different from others provided, add to 
                    //the list of values and creates a new Column with its value.
                    columnXValues.Add(columnXTemp);
                    decimal d = Convert.ToDecimal(dr["PrecioProducto"]);
                    returnTable.Columns.Add(columnXTemp + "\n" + d.ToString("#######0.,######"));
                }
            }

            //Verify if Y and Z Axis columns re provided
            if (columnY != "" && columnZ != "")
            {
                //Read DISTINCT Values for Y Axis Column
                List<string> columnYValues = new List<string>();

                foreach (DataRow dr in table.Rows)
                {
                    if (!columnYValues.Contains(dr[columnY].ToString()))
                    {
                        columnYValues.Add(dr[columnY].ToString());
                    }
                }

                //Loop all Column Y Distinct Value
                foreach (string columnYValue in columnYValues)
                {
                    //Creates a new Row
                    DataRow drReturn = returnTable.NewRow();
                    //foreach column Y value, The rows are selected distincted
                    DataRow[] rows = table.Select(columnY + "='" + columnYValue + "'");

                    //Read each row to fill the DataTable
                    foreach (DataRow dr in rows)
                    {

                        if (isClient)
                        {
                            drReturn[0] = dr["NumeroCliente"];
                            drReturn[1] = columnYValue;
                        }
                        else
                            drReturn[0] = columnYValue;

                        string rowColumnTitle = dr[columnX].ToString();

                        decimal d = Convert.ToDecimal(dr["PrecioProducto"]);
                        rowColumnTitle += "\n" + d.ToString("#######0.,######");

                        //Read each column to fill the DataTable
                        foreach (DataColumn dc in returnTable.Columns)
                        {
                            if (dc.ColumnName == rowColumnTitle)
                            {
                                d = Convert.ToDecimal(dr[columnZ]);
                                drReturn[rowColumnTitle] = d.ToString("#######0.,######");
                            }
                        }
                    }

                    returnTable.Rows.Add(drReturn);
                }

            }
            else
            {
                throw new Exception("The columns to perform inversion are not provided");
            }

            foreach (DataRow dr in returnTable.Rows)
            {
                foreach (DataColumn dc in returnTable.Columns)
                {
                    if (dr[dc.ColumnName].ToString() == "")
                        dr[dc.ColumnName] = "-";
                }
            }

            return returnTable;
        }

    }
}
