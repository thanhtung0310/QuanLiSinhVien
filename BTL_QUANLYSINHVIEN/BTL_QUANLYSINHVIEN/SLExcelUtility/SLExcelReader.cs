using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.Data;
using System.IO;

namespace BTL_QUANLYSINHVIEN.SLExcelUtility
{
    public class SLExcelReader
    {
        protected string currenPath = "";
        public SLExcelReader(string serverPath)
        {
            currenPath = serverPath;
        }
        protected DataSet loadConfig(string fileName)
        {
            DataSet ds;
            ds = new DataSet();
            try
            {
                ds.ReadXml(fileName);
                return ds;
            }
            catch
            {
                return null;
            }
        }

         private string GetColumnName(string cellReference)
        {
            var regex = new Regex("[A-Za-z]+");
            var match = regex.Match(cellReference);

            return match.Value;
        }

        private int ConvertColumnNameToNumber(string columnName)
        {
            var alpha = new Regex("^[A-Z]+$");
            if (!alpha.IsMatch(columnName)) throw new ArgumentException();

            char[] colLetters = columnName.ToCharArray();
            Array.Reverse(colLetters);

            var convertedValue = 0;
            for (int i = 0; i < colLetters.Length; i++)
            {
                char letter = colLetters[i];
                int current = i == 0 ? letter - 65 : letter - 64; // ASCII 'A' = 65
                convertedValue += current * (int)Math.Pow(26, i);
            }

            return convertedValue;
        }

        private IEnumerator<Cell> GetExcelCellEnumerator(Row row)
        {
            int currentCount = 0;
            foreach (Cell cell in row.Descendants<Cell>())
            {
                string columnName = GetColumnName(cell.CellReference);

                int currentColumnIndex = ConvertColumnNameToNumber(columnName);

                for (; currentCount < currentColumnIndex; currentCount++)
                {
                    var emptycell = new Cell() { DataType = null, CellValue = new CellValue(string.Empty) };
                    yield return emptycell;
                }

                yield return cell;
                currentCount++;
            }
        }

        private string ReadExcelCell(Cell cell, WorkbookPart workbookPart)
        {
            var cellValue = cell.CellValue;
            var text = (cellValue == null) ? cell.InnerText : cellValue.Text;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                text = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(
                        Convert.ToInt32(cell.CellValue.Text)).InnerText;
            }

            return (text ?? string.Empty).Trim();
        }
        public SLExcelData ReadExcel(string fileName)
        {
            var data = new SLExcelData();

            //HttpPostedFile file = new HttpPostedFile();
            //System.IO.StreamReader r = new System.IO.StreamReader(fileName);

            //// Check if the file is excel
            //if (file.ContentLength <= 0)
            //{
            //    data.Status.Message = "You uploaded an empty file";
            //    return data;
            //}

            //if (file.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            //{
            //    data.Status.Message = "Please upload a valid excel file of version 2007 and above";
            //    return data;
            //}

            // Open the excel document
            WorkbookPart workbookPart; List<Row> rows;
            try
            {
                var document = SpreadsheetDocument.Open(fileName, false);
                workbookPart = document.WorkbookPart;

                var sheets = workbookPart.Workbook.Descendants<Sheet>();
                var sheet = sheets.First();
                data.SheetName = sheet.Name;

                var workSheet = ((WorksheetPart)workbookPart.GetPartById(sheet.Id)).Worksheet;
                var columns = workSheet.Descendants<Columns>().FirstOrDefault();
                data.ColumnConfigurations = columns;

                var sheetData = workSheet.Elements<SheetData>().First();
                rows = sheetData.Elements<Row>().ToList();
            }
            catch (Exception e)
            {
                data.Status.Message = "Unable to open the file";
                return data;
            }

            // Read the header
            if (rows.Count > 0)
            {
                var row = rows[0];
                var cellEnumerator = GetExcelCellEnumerator(row);
                while (cellEnumerator.MoveNext())
                {
                    var cell = cellEnumerator.Current;
                    var text = ReadExcelCell(cell, workbookPart).Trim();
                    data.Headers.Add(text);
                }
            }

            // Read the sheet data
            if (rows.Count > 1)
            {
                for (var i = 1; i < rows.Count; i++)
                {
                    var dataRow = new List<string>();
                    data.DataRows.Add(dataRow);
                    var row = rows[i];
                    var cellEnumerator = GetExcelCellEnumerator(row);
                    while (cellEnumerator.MoveNext())
                    {
                        var cell = cellEnumerator.Current;
                        var text = ReadExcelCell(cell, workbookPart).Trim();
                        dataRow.Add(text);
                    }
                }
            }

            return data;
        }
        //public SLExcelData ReadExcel(HttpPostedFileBase file)
        //{
        //    var data = new SLExcelData();

        //    // Check if the file is excel
        //    if (file.ContentLength <= 0)
        //    {
        //        data.Status.Message = "You uploaded an empty file";
        //        return data;
        //    }

        //    if (file.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        //    {
        //        data.Status.Message = "Please upload a valid excel file of version 2007 and above";
        //        return data;
        //    }

        //    // Open the excel document
        //    WorkbookPart workbookPart; List<Row> rows;
        //    try
        //    {
        //        var document = SpreadsheetDocument.Open(file.InputStream, false);
        //        workbookPart = document.WorkbookPart;

        //        var sheets = workbookPart.Workbook.Descendants<Sheet>();
        //        var sheet = sheets.First();
        //        data.SheetName = sheet.Name;

        //        var workSheet = ((WorksheetPart)workbookPart.GetPartById(sheet.Id)).Worksheet;
        //        var columns = workSheet.Descendants<Columns>().FirstOrDefault();
        //        data.ColumnConfigurations = columns;

        //        var sheetData = workSheet.Elements<SheetData>().First();
        //        rows = sheetData.Elements<Row>().ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        data.Status.Message = "Unable to open the file";
        //        return data;
        //    }

        //    // Read the header
        //    if (rows.Count > 0)
        //    {
        //        var row = rows[0];
        //        var cellEnumerator = GetExcelCellEnumerator(row);
        //        while (cellEnumerator.MoveNext())
        //        {
        //            var cell = cellEnumerator.Current;
        //            var text = ReadExcelCell(cell, workbookPart).Trim();
        //            data.Headers.Add(text);
        //        }
        //    }

        //    // Read the sheet data
        //    if (rows.Count > 1)
        //    {
        //        for (var i = 1; i < rows.Count; i++)
        //        {
        //            var dataRow = new List<string>();
        //            data.DataRows.Add(dataRow);
        //            var row = rows[i];
        //            var cellEnumerator = GetExcelCellEnumerator(row);
        //            while (cellEnumerator.MoveNext())
        //            {
        //                var cell = cellEnumerator.Current;
        //                var text = ReadExcelCell(cell, workbookPart).Trim();
        //                dataRow.Add(text);
        //            }
        //        }
        //    }

        //    return data;
        //}
                protected  Row GetRow(Worksheet worksheet, uint rowIndex)
        {
            try
            {
                return worksheet.GetFirstChild<SheetData>().
                  Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
                protected int openFile(string fileName, out SpreadsheetDocument doc, out WorkbookPart wb, out WorksheetPart ws)
                {
                    int ret = 0;
                    doc = null;
                    wb = null;
                    ws = null;
                    SpreadsheetDocument spreadSheet = null;
                    WorkbookPart workbookPart = null;
                    WorksheetPart worksheetPart = null;
                    try
                    {
                        spreadSheet = SpreadsheetDocument.Open(fileName, true);
                    }
                    catch (Exception ex)
                    {
                        return -1;
                    }
                    try
                    {
                        workbookPart = spreadSheet.WorkbookPart;
                    }
                    catch (Exception ex)
                    {
                        return -2;
                    }

                    try
                    {
                        var sheets = workbookPart.Workbook.Descendants<Sheet>();
                        var sheet = sheets.First();
                        worksheetPart = ((WorksheetPart)workbookPart.GetPartById(sheet.Id));
                    }
                    catch (Exception ex)
                    {
                        return -3;
                    }
                    doc = spreadSheet;
                    wb = workbookPart;
                    ws = worksheetPart;
                    return ret;
                }
        //private Cell GetCell(Row row, string columnName)
        //{
        //    if (row == null)
        //        return null;
        //    string add = columnName + row.RowIndex.ToString();
        //    Cell a;
        //    try
        //    {
        //        a = row.Elements<Cell>().Where(c => string.Compare(c.CellReference.Value, add, true) == 0).First();
        //        return a;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        /// <summary>
        /// Get cell base on identified row and the column name (A, AZ)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        protected Cell GetCell(Row row, string columnName)
        {
            if (row == null)
                return null;
            uint rowIndex = row.RowIndex;
            return GetCell(row, rowIndex, columnName);
            //int columnIndex=0;
            //columnName = columnName.ToUpper();
            //switch (columnName.Length)
            //{
            //    case 1:
            //        columnIndex=(int)(columnName[0]-'A');
            //        break;
            //    case 2:
            //        columnIndex = (int)(  Math.Pow(('Z' - 'A'),(columnName[0] - 'A')+1) + (columnName[1] - 'A'));
            //        break;
            //    default:
            //        columnIndex = int.MaxValue;
            //        break;
            //}
            //if (columnIndex >= row.ChildElements.Count)
            //{
            //    return null;//over index
            //}
            //Cell a=null;
            //try
            //{
            //    a = (Cell)row.ChildElements[columnIndex];
            //    return a;
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
        }
        /// <summary>
        /// get cell based on rowindex and clumn
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="rowindex"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        protected Cell GetCell(WorksheetPart ws, uint rowindex, string columnName)
        {
            Row r=GetRow(ws.Worksheet, rowindex);
            return GetCell(r, columnName);

        }
        /// <summary>
        /// get datarow based on filter id
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filterValue"></param>
        /// <returns></returns>
        protected DataRow getDataRow(DataTable dt, string filterValue)
        {
            if(dt==null)
            {
                return null;
            }
            filterValue = filterValue.Replace("'", "''");

            DataRow[] row = dt.Select(string.Format("id='{0}'",filterValue));
            if (row.Length < 1)
            {
                return null;
            }
            return row[0];
        }

        private  Cell GetCell(Row row, uint rowIndex, string columnName)
        {
            if (row == null)
                return null;
            
            string add = columnName + rowIndex.ToString();
            Cell a;
            try
            {
                a = row.Elements<Cell>().Where(c => string.Compare(c.CellReference.Value, add, true) == 0).First();
                return a;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
            //foreach (Cell cell in row.Elements<Cell>())
            //{
            //    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
            //    {
            //        refCell = cell;
            //        break;
            //    }
            //}
        }
        /// <summary>
        /// convert type in text to cell type
        /// </summary>
        /// <param name="type">string name: number, string, date, boolean</param>
        /// <returns>cell type </returns>
        protected EnumValue<CellValues> convertType(string type)
        {
            type = type.ToUpper();
            switch (type)
            {
                case "NUMBER":
                    return new EnumValue<CellValues>(CellValues.Number);
                case "DATESTRING":
                case "NUMBER2STRING":
                case "STRING":
                    return new EnumValue<CellValues>(CellValues.String);
                case "DATE":
                    return new EnumValue<CellValues>(CellValues.Date);
                case "BOOLEAN":
                    return new EnumValue<CellValues>(CellValues.Boolean);
                default:
                    return new EnumValue<CellValues>(CellValues.String);
            }
        }
        protected string getFileName(string filenameTemplate)
        {
            int c = 0;
            string currentFile = filenameTemplate.Replace("{%COUNT%}", c.ToString());
            while (File.Exists(currentFile))
            {
                c++;
                currentFile = filenameTemplate.Replace("{%COUNT%}", c.ToString());
            }
            return currentFile;
        }


        //public int ModifyExcel(string fileConfig, string fileName)
        //{
        //    DataSet ds = loadConfig(fileConfig);
        //    if (ds == null)
        //    {
        //        return -1;
        //    }
        //    SpreadsheetDocument spreadSheet = null;
        //    try
        //    {
        //        spreadSheet = SpreadsheetDocument.Open(fileName, true);
        //    }
        //    catch (Exception ex)
        //    {
        //        return -2;
        //    }
        //    WorkbookPart workbookPart;
        //    workbookPart = spreadSheet.WorkbookPart;
        //    var sheets = workbookPart.Workbook.Descendants<Sheet>();
        //    var sheet = sheets.First();
        //    WorksheetPart worksheetPart = ((WorksheetPart)workbookPart.GetPartById(sheet.Id));
        //    //end load file
        //    //update all header
        //    updateCell(worksheetPart, ds, "topvalue", "uniname", "Đại học nào đó");
        //    updateCell(workbookPart, worksheetPart, ds, "topvalue", "title", "1", "2013", "2014");
        //    //if (ds.Tables.Contains("topvalue"))
        //    //{
        //    //    DataTable dt =ds.Tables["topvalue"];
        //    //    DataRow dtrow = null;
        //    //    //uniname
        //    //    dtrow=getDataRow(dt, "uniname");
        //    //    string col = com.string4Row(dtrow, "col", "");
        //    //    int row = com.int4Row(dtrow, "row", -1);
        //    //    string celltype = com.string4Row(dtrow, "type", "string");
        //    //    string defaultValue = com.string4Row(dtrow, "default", "string");

        //    //}


        //    if (worksheetPart != null)
        //    {
        //        Row r = GetRow(worksheetPart.Worksheet, 6);//row 1 in detail
        //        int aaaa = r.ChildElements.Count;
        //        Cell cellme = GetCell(r, "A");//(Cell)r.ChildElements[1];
        //        cellme.CellValue = new CellValue("100");
        //        cellme.DataType = convertType("number");
        //        Row b = (Row)r.Clone();//add new row with the same format
        //        //                Row b = new Row();

        //        //                Cell cell = GetCell(r, 6,"A");

        //        //                cell.CellValue=new CellValue("khong");
        //        //                cell.DataType = new DocumentFormat.OpenXml.EnumValue<CellValues>(CellValues.String);

        //        //replace all referece in sheet
        //        //update for new row
        //        b.RowIndex = 7;

        //        foreach (Cell cell1 in b.Elements<Cell>())
        //        {
        //            string cellReference = cell1.CellReference.Value;
        //            cell1.CellReference = cellReference.Replace("6", "7");

        //        }

        //        //update for all row after new row
        //        foreach (Row rr in worksheetPart.Worksheet.GetFirstChild<SheetData>().Elements<Row>())
        //        {
        //            if (rr.RowIndex > 6)
        //            {
        //                rr.RowIndex = rr.RowIndex + 1;
        //                foreach (Cell cell2 in rr.Elements<Cell>())
        //                {
        //                    // Update the references for the rows cells.
        //                    cell2.CellReference = cell2.CellReference.Value.Replace((rr.RowIndex - 1).ToString(), rr.RowIndex);
        //                }

        //                // Update the row index.


        //            }
        //        }
        //        //                Row r1 = GetRow(worksheetPart.Worksheet, 7);
        //        //                r1.Remove();
        //        try
        //        {
        //            SheetData sd = worksheetPart.Worksheet.GetFirstChild<SheetData>();
        //            sd.InsertAfter(b, r);
        //        }
        //        catch (Exception ex)
        //        {
        //            int kk = 0;
        //        }
        //        //                worksheetPart.Worksheet.RemoveChild(r);
        //        // Save the worksheet.
        //        worksheetPart.Worksheet.Save();
        //        workbookPart.Workbook.Save();

        //    }
        //    spreadSheet.Close();


        //    return 0;
        //}
        public uint GetRowIndex(string cellReference)
        {
            // Create a regular expression to match the row index portion the cell name.
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(cellReference);

            return uint.Parse(match.Value);
        }
        /// <summary>
        /// copy all Row to list of Rows; and then sort increasely on rowindex
        /// </summary>
        /// <param name="ws"></param>
        /// <returns></returns>
        protected List<Row> backupRow(Worksheet ws)
        {
            List<Row> li = new List<Row>();
            foreach (Row r in ws.GetFirstChild<SheetData>().Elements<Row>())
            {
                Row newrow = (Row)r.Clone();
                li.Add(newrow);
            }
            Row temp;
            int ii;
            int jj;
            int vt;
            for (ii = 0; ii < li.Count; ii++)
            {
                vt = ii;
                for (jj = ii + 1; jj < li.Count; jj++)
                {
                    if (li[vt].RowIndex > li[jj].RowIndex)
                    {
                        vt = jj;
                    }
                }
                if (vt != ii)
                {
                    temp = li[vt];
                    li[vt] = li[ii];
                    li[ii] = temp;
                }
            }
            return li;
        }
        //protected List<string> backupMergecell(Worksheet ws)
        //{
        //    List<string> mergList = new List<string>();
        //    MergeCells mergeCells;
        //    mergeCells = ws.Elements<MergeCells>().First();
        //    foreach (MergeCell mec in mergeCells.ChildElements)
        //    {
        //        mergList.Add(mec.Reference.Value.ToString());
        //    }
        //    int ii;
        //    int jj;
        //    int vt;
        //    string stemp;
        //    for (ii = 0; ii < mergList.Count; ii++)
        //    {
        //        vt = ii;
        //        for (jj = ii + 1; jj < mergList.Count; jj++)
        //        {
        //            if (rowIndexFirst(mergList[vt]) > rowIndexFirst(mergList[jj]))
        //            {
        //                vt = jj;
        //            }
        //        }
        //        if (vt != ii)
        //        {
        //            stemp = mergList[vt];
        //            mergList[vt] = mergList[ii];
        //            mergList[ii] = stemp;
        //        }
        //    }
        //    return mergList;
        //}
        #region cell format
        protected List<uint> createRowClearFormat(WorkbookPart workbookPart, WorksheetPart workSheetPart, Row BaseOn)
        {

            List<uint> styleIndex = new List<uint>();
            foreach (Cell cell in BaseOn.Elements<Cell>())
            {
                CellFormat cellFormat = cell.StyleIndex != null ? GetCellFormat(workbookPart, cell.StyleIndex).CloneNode(true) as CellFormat : new CellFormat();
                uint borderID = InsertBorder(workbookPart, generateClearRowBorder());
                cellFormat.BorderId = borderID;
                uint si = InsertCellFormat(workbookPart, cellFormat);
                styleIndex.Add(si);
            }
            return styleIndex;
        }
        /// <summary>
        /// create a cell format based on the BaseOn format
        /// </summary>
        /// <param name="workbookPart"></param>
        /// <param name="workSheetPart"></param>
        /// <param name="BaseOn">cell format</param>
        /// <returns></returns>
        protected List<uint> createRowFormat(WorkbookPart workbookPart, WorksheetPart workSheetPart, Row BaseOn)
        {
            List<uint> styleIndex = new List<uint>();
            foreach (Cell cell in BaseOn.Elements<Cell>())
            {
                CellFormat cellFormat = cell.StyleIndex != null ? GetCellFormat(workbookPart, cell.StyleIndex).CloneNode(true) as CellFormat : new CellFormat();
                uint borderID = InsertBorder(workbookPart, generaRowBorder());
                cellFormat.BorderId = borderID;
                uint si = InsertCellFormat(workbookPart, cellFormat);
                styleIndex.Add(si);
            }
            return styleIndex;
        }
        /// Cập nhật lại một cell khi biết số hàng, cột và giá trị mới cần cập nhật
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="rownumber"></param>
        /// <param name="columnname"></param>
        /// <param name="newvalue"></param>
        /// <returns></returns>
        protected int updateCell(ref WorksheetPart ws, uint rownumber, string columnname, string newvalue)
        {
            Cell cell = GetCell(ws, rownumber, columnname);
            cell.CellValue = new CellValue(newvalue);
            cell.DataType = new EnumValue<CellValues>(CellValues.String);
            ws.Worksheet.Save();
            return 1;
        }

        /// <summary>
        /// create a cell format based on the BaseOn format
        /// </summary>
        /// <param name="workbookPart"></param>
        /// <param name="workSheetPart"></param>
        /// <param name="BaseOn">cell format</param>
        /// <returns></returns>
        protected List<uint> createRowFormatLast(WorkbookPart workbookPart, WorksheetPart workSheetPart, Row BaseOn)
        {
            List<uint> styleIndex = new List<uint>();
            foreach (Cell cell in BaseOn.Elements<Cell>())
            {
                CellFormat cellFormat = cell.StyleIndex != null ? GetCellFormat(workbookPart, cell.StyleIndex).CloneNode(true) as CellFormat : new CellFormat();
                uint borderID = InsertBorder(workbookPart, generaLastRowBorder());
                cellFormat.BorderId = borderID;
                uint si = InsertCellFormat(workbookPart, cellFormat);
                styleIndex.Add(si);
            }
            return styleIndex;
        }

        protected int rowFormat(WorkbookPart workbookPart, WorksheetPart workSheetPart, Row r, List<uint> styleIndex)
        {
            int i = 0;
            foreach (Cell cell in r.Elements<Cell>())
            {
                cell.StyleIndex = styleIndex[i];
                i++;
            }
            return 0;
        }

        /// <summary>
        /// Get cell format
        /// </summary>
        /// <param name="workbookPart"></param>
        /// <param name="styleIndex"></param>
        /// <returns></returns>
        protected CellFormat GetCellFormat(WorkbookPart workbookPart, uint styleIndex)
        {
            return workbookPart.WorkbookStylesPart.Stylesheet.Elements<CellFormats>().First().Elements<CellFormat>().ElementAt((int)styleIndex);
        }
        /// <summary>
        /// Insert cellformats to the list
        /// </summary>
        /// <param name="workbookPart"></param>
        /// <param name="cellFormat"></param>
        /// <returns></returns>
        protected uint InsertCellFormat(WorkbookPart workbookPart, CellFormat cellFormat)
        {
            CellFormats cellFormats = workbookPart.WorkbookStylesPart.Stylesheet.Elements<CellFormats>().First();
            cellFormats.Append(cellFormat);
            return (uint)cellFormats.Count++;
        }
        /// <summary>
        /// insert boder to list of border in file
        /// </summary>
        /// <param name="workbookPart"></param>
        /// <param name="border"></param>
        /// <returns></returns>
        protected uint InsertBorder(WorkbookPart workbookPart, Border border)
        {
            Borders borders = workbookPart.WorkbookStylesPart.Stylesheet.Elements<Borders>().First();
            borders.Append(border);
            return (uint)borders.Count++;
        }

        /// <summary>
        /// Set border for a cell
        /// </summary>
        /// <param name="workbookPart"></param>
        /// <param name="workSheetPart"></param>
        protected void SetBorderAndFill(WorkbookPart workbookPart, WorksheetPart workSheetPart, Cell cell)
        {

            CellFormat cellFormat = cell.StyleIndex != null ? GetCellFormat(workbookPart, cell.StyleIndex).CloneNode(true) as CellFormat : new CellFormat();
            uint borderID = InsertBorder(workbookPart, generaRowBorder());
            cellFormat.BorderId = borderID;
            uint styleIndex = InsertCellFormat(workbookPart, cellFormat);
            cell.StyleIndex = styleIndex;
        }
        /// <summary>
        /// Set border for a cell at last row
        /// </summary>
        /// <param name="workbookPart"></param>
        /// <param name="workSheetPart"></param>
        protected void SetBorderAndFillLast(WorkbookPart workbookPart, WorksheetPart workSheetPart, Cell cell)
        {

            CellFormat cellFormat = cell.StyleIndex != null ? GetCellFormat(workbookPart, cell.StyleIndex).CloneNode(true) as CellFormat : new CellFormat();
            uint borderID = InsertBorder(workbookPart, generaLastRowBorder());
            cellFormat.BorderId = borderID;
            uint styleIndex = InsertCellFormat(workbookPart, cellFormat);
            cell.StyleIndex = styleIndex;
        }
        /// <summary>
        /// generate border for the row
        /// </summary>
        /// <returns></returns>
        protected Border generaRowBorder()
        {
            Border border2 = new Border();

            LeftBorder leftBorder2 = new LeftBorder() { Style = BorderStyleValues.Thin };
            Color color1 = new Color() { Indexed = (UInt32Value)64U };

            leftBorder2.Append(color1);

            RightBorder rightBorder2 = new RightBorder() { Style = BorderStyleValues.Thin };
            Color color2 = new Color() { Indexed = (UInt32Value)64U };

            rightBorder2.Append(color2);

            TopBorder topBorder2 = new TopBorder() { Style = BorderStyleValues.Dotted | BorderStyleValues.Hair };
            Color color3 = new Color() { Indexed = (UInt32Value)64U };

            topBorder2.Append(color3);

            BottomBorder bottomBorder2 = new BottomBorder() { Style = BorderStyleValues.Dotted | BorderStyleValues.Hair };
            Color color4 = new Color() { Indexed = (UInt32Value)64U };

            bottomBorder2.Append(color4);
            DiagonalBorder diagonalBorder2 = new DiagonalBorder();

            border2.Append(leftBorder2);
            border2.Append(rightBorder2);
            border2.Append(topBorder2);
            border2.Append(bottomBorder2);
            border2.Append(diagonalBorder2);

            return border2;
        }
        protected Border generateClearRowBorder()
        {
            Border border2 = new Border();

            LeftBorder leftBorder2 = new LeftBorder() { Style = BorderStyleValues.None };
            //            Color color1 = new Color() { Indexed = (UInt32Value)64U };

            //            leftBorder2.Append(color1);

            RightBorder rightBorder2 = new RightBorder() { Style = BorderStyleValues.None };
            //Color color2 = new Color() { Indexed = (UInt32Value)64U };

            //rightBorder2.Append(color2);

            TopBorder topBorder2 = new TopBorder() { Style = BorderStyleValues.None };
            //Color color3 = new Color() { Indexed = (UInt32Value)64U };

            //topBorder2.Append(color3);

            BottomBorder bottomBorder2 = new BottomBorder() { Style = BorderStyleValues.None };
            //Color color4 = new Color() { Indexed = (UInt32Value)64U };

            //bottomBorder2.Append(color4);
            DiagonalBorder diagonalBorder2 = new DiagonalBorder();

            border2.Append(leftBorder2);
            border2.Append(rightBorder2);
            border2.Append(topBorder2);
            border2.Append(bottomBorder2);
            border2.Append(diagonalBorder2);

            return border2;
        }
        /// <summary>
        /// generate border for the row
        /// </summary>
        /// <returns></returns>
        protected Border generaLastRowBorder()
        {
            Border border2 = new Border();

            LeftBorder leftBorder2 = new LeftBorder() { Style = BorderStyleValues.Thin };
            Color color1 = new Color() { Indexed = (UInt32Value)64U };

            leftBorder2.Append(color1);

            RightBorder rightBorder2 = new RightBorder() { Style = BorderStyleValues.Thin };
            Color color2 = new Color() { Indexed = (UInt32Value)64U };

            rightBorder2.Append(color2);

            TopBorder topBorder2 = new TopBorder() { Style = BorderStyleValues.Dotted | BorderStyleValues.Hair };
            Color color3 = new Color() { Indexed = (UInt32Value)64U };

            topBorder2.Append(color3);

            BottomBorder bottomBorder2 = new BottomBorder() { Style = BorderStyleValues.Thin };
            Color color4 = new Color() { Indexed = (UInt32Value)64U };

            bottomBorder2.Append(color4);
            DiagonalBorder diagonalBorder2 = new DiagonalBorder();

            border2.Append(leftBorder2);
            border2.Append(rightBorder2);
            border2.Append(topBorder2);
            border2.Append(bottomBorder2);
            border2.Append(diagonalBorder2);

            return border2;
        }
        #endregion
        //private static string GetColumnName(string cellName)
        //{
        //    // Create a regular expression to match the column name portion of the cell name.
        //    Regex regex = new Regex("[A-Za-z]+");
        //    Match match = regex.Match(cellName);

        //    return match.Value;
        //}
        //public  string IncrementCellReference(string reference, CellReferencePartEnum cellRefPart)
        //{
        //    string newReference = reference;

        //    if (cellRefPart != CellReferencePartEnum.None && !String.IsNullOrEmpty(reference))
        //    {
        //        string[] parts = Regex.Split(reference, "([A-Z]+)");

        //        if (cellRefPart == CellReferencePartEnum.Column || cellRefPart == CellReferencePartEnum.Both)
        //        {
        //            List<char> col = parts[1].ToCharArray().ToList();
        //            bool needsIncrement = true;
        //            int index = col.Count - 1;

        //            do
        //            {
        //                // increment the last letter
        //                col[index] = Letters[Letters.IndexOf(col[index]) + 1];

        //                // if it is the last letter, then we need to roll it over to 'A'
        //                if (col[index] == Letters[Letters.Count - 1])
        //                {
        //                    col[index] = Letters[0];
        //                }
        //                else
        //                {
        //                    needsIncrement = false;
        //                }

        //            } while (needsIncrement && --index >= 0);

        //            // If true, then we need to add another letter to the mix. Initial value was something like "ZZ"
        //            if (needsIncrement)
        //            {
        //                col.Add(Letters[0]);
        //            }

        //            parts[1] = new String(col.ToArray());
        //        }

        //        if (cellRefPart == CellReferencePartEnum.Row || cellRefPart == CellReferencePartEnum.Both)
        //        {
        //            // Increment the row number. A reference is invalid without this componenet, so we assume it will always be present.
        //            parts[2] = (int.Parse(parts[2]) + 1).ToString();
        //        }

        //        newReference = parts[1] + parts[2];
        //    }

        //    return newReference;
        //}
        //private  void UpdateMergedCellReferences(WorksheetPart worksheetPart, uint rowIndex, bool isDeletedRow)
        //{
    }
}
