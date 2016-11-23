using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace BTL_QUANLYSINHVIEN
{
    public class Report
    {
        public void CreateExcelDoc(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Test Sheet" };

                sheets.Append(sheet);

                workbookPart.Workbook.Save();
            }

        }
        public int report_LHP(string fileName,DataTable dt,string nameClass,string classCode,string subject,string nameTeacher,string year)
        {
            string currenPath = "";
            // Lấy file template đã tạo sẵn
            string tempFile = currenPath + "C:/data/hoc tap/SQL/luyentap/BTL_QUANLYSINHVIEN/templatefile/PhieuDiemLHP.xlsx";
            // File sau khi được tạo ra lưu tại đây
            string tempOutFile = currenPath + "C:/data/hoc tap/SQL/luyentap/BTL_QUANLYSINHVIEN/downloadfile/PhieuDiemLHP_{%code%}.xlsx";
            // Thông tin cần lấy ra được lưu ở file .xml
            string fileConfig = currenPath + "C:/data/hoc tap/SQL/luyentap/BTL_QUANLYSINHVIEN/templatefile/PhieuDiemLHP.xml";
            //
            tempOutFile = tempOutFile.Replace("{%code%}", classCode);
            fileName = tempOutFile;
            //prepare file name
            File.Copy(tempFile, fileName, true);
            SpreadsheetDocument spreadSheet = null;
            WorkbookPart workbookPart = null;
            WorksheetPart worksheetPart = null;
            DataSet dsSource = new DataSet();
            dsSource.Tables.Add(dt.Copy());
         //   dsSource.Tables[0].TableName = tablename;
            if (openFile(fileName, out spreadSheet, out workbookPart, out worksheetPart) != 0)
            {
                return -5;
            }
            DataSet ds = loadConfig(fileConfig);
            //update mã lhp, tên mh, tên giáo viên, năm hoc
              updateCell(workbookPart, worksheetPart, ds, "topvalue", "classtitle", nameClass);
              updateCell(workbookPart, worksheetPart, ds, "topvalue", "subject", subject);
              updateCell(workbookPart, worksheetPart, ds, "topvalue", "teacher", nameTeacher);
              updateCell(workbookPart, worksheetPart, ds, "topvalue", "gradeyear",year);
            DataRow drLoop = getDataRow(ds.Tables["loop"], "allstudents");
            int countStaff = 0;
            string tableName = drLoop["name"].ToString();
            string loopType = drLoop["looptype"].ToString();
            int rowLoop = Convert.ToInt32(drLoop["row"].ToString());
            InsertDataTable2WorkSheet(dsSource.Tables["allstudents"], worksheetPart, ds.Tables[tableName], rowLoop);

            closeFile(spreadSheet, workbookPart, worksheetPart);
            return 0;
        }
        public int report_Lop(string fileName, DataTable dt, string nameClass,string year)
        {
            string currenPath = "";
            // Lấy file template đã tạo sẵn
            string tempFile = currenPath + "C:/data/hoc tap/SQL/luyentap/BTL_QUANLYSINHVIEN/templatefile/PhieuDiemLop.xlsx";
            // File sau khi được tạo ra lưu tại đây
            string tempOutFile = currenPath + "C:/data/hoc tap/SQL/luyentap/BTL_QUANLYSINHVIEN/downloadfile/PhieuDiemLop_{%code%}_{%year%}.xlsx";
            // Thông tin cần lấy ra được lưu ở file .xml
            string fileConfig = currenPath + "C:/data/hoc tap/SQL/luyentap/BTL_QUANLYSINHVIEN/templatefile/PhieuDiemLop.xml";
            //
            tempOutFile = tempOutFile.Replace("{%code%}", nameClass);
            tempOutFile = tempOutFile.Replace("{%year%}", year);
            fileName = tempOutFile;
            //prepare file name
            File.Copy(tempFile, fileName, true);
            SpreadsheetDocument spreadSheet = null;
            WorkbookPart workbookPart = null;
            WorksheetPart worksheetPart = null;
            DataSet dsSource = new DataSet();
            dsSource.Tables.Add(dt.Copy());
            //   dsSource.Tables[0].TableName = tablename;
            if (openFile(fileName, out spreadSheet, out workbookPart, out worksheetPart) != 0)
            {
                return -5;
            }
            DataSet ds = loadConfig(fileConfig);
            //update mã lhp, tên mh, tên giáo viên, năm hoc
            updateCell(workbookPart, worksheetPart, ds, "topvalue", "classtitle", nameClass);
            updateCell(workbookPart, worksheetPart, ds, "topvalue", "gradeyear", year);
            DataRow drLoop = getDataRow(ds.Tables["loop"], "allstudents");
            int countStaff = 0;
            string tableName = drLoop["name"].ToString();
            string loopType = drLoop["looptype"].ToString();
            int rowLoop = Convert.ToInt32(drLoop["row"].ToString());
            InsertDataTable2WorkSheet(dsSource.Tables["allstudents"], worksheetPart, ds.Tables[tableName], rowLoop);

            closeFile(spreadSheet, workbookPart, worksheetPart);
            return 0;
        }
        private void InsertDataTable2WorkSheet(DataTable dt, WorksheetPart worksheetPart, DataTable xmldt, int startrow)
        {
            int count = dt.Rows.Count;
            if (count == 0)
                return;
            int iend = int.MaxValue;
            Row rr = GetRow(worksheetPart.Worksheet, (uint)startrow);
            List<Row> li = new List<Row>();//all row will be add
            string valuetype = "";
            int i = 0;
            Row rAdd;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                rAdd = (Row)rr.Clone();
                foreach (DataRow xmlRow in xmldt.Rows)
                {
                    valuetype = xmlRow["valuetype"].ToString();
                    if (valuetype == "table")
                    {
                        //process based on value
                        updateCell(rAdd, xmlRow, dt.Rows[i]);
                    }
                }
                updateCell(rAdd, getDataRow(xmldt, "order"), (i + 1).ToString());
                updateReferenceCells(rAdd, i);
                li.Add(rAdd);
            }

            //update for all 
            SheetData sd = worksheetPart.Worksheet.GetFirstChild<SheetData>();

            //upate all row 
            //Move forward countStaff rows (without copying the format)
            foreach (Row updateLink in sd.Elements<Row>())
            {
                if (updateLink.RowIndex > startrow && updateLink.RowIndex <= iend)
                {
                    updateReferenceCells(updateLink, count - 1);
                }
            }
            // insert all list
            //rr = GetRow(worksheetPart.Worksheet, (uint)startrow);
            //for (i = 0; i < count;i++ )
            //{
            //    sd.InsertAt(li[i], i + startrow);
            //}

            // insert all list
            for (i = li.Count - 1; i >= 0; i--)
            {
                sd.InsertAfter(li[i], rr);
            }

        }
        protected int updateReferenceCells(Row r, string newIndex)
        {
            if (r == null)
                return -1;
            uint current = r.RowIndex;
            string currentIndex = current.ToString();
            foreach (Cell cell1 in r.Elements<Cell>())
            {
                string cellReference = cell1.CellReference.Value;
                cell1.CellReference = cellReference.Replace(currentIndex, newIndex);

            }
            uint ii;
            uint.TryParse(newIndex, out ii);
            r.RowIndex.Value = ii;
            return 0;
        }
        protected int updateReferenceCells(Row r, int distance)
        {
            if (r == null)
                return -1;
            uint current = r.RowIndex;
            string currentIndex = current.ToString();
            string newIndex = (current + distance).ToString();
            foreach (Cell cell1 in r.Elements<Cell>())
            {
                string cellReference = cell1.CellReference.Value;
                cell1.CellReference = cellReference.Replace(currentIndex, newIndex);

            }
            r.RowIndex = current + (uint)distance;
            return 0;
        }
        protected int updateCell(WorkbookPart wb, WorksheetPart ws, DataSet xmlDs, string xmlTableName, string xmlId, params object[] para)
        {
            if (!xmlDs.Tables.Contains(xmlTableName))
            {
                return -1;
            }
            DataRow dr = getDataRow(xmlDs.Tables[xmlTableName], xmlId);
            if (dr == null)
            {
                return -2;
            }
            int rowindex =Convert.ToInt32(dr["row"].ToString());
            string columnName = dr["col"].ToString();
            string source = dr["source"].ToString();
            string celltype = dr["type"].ToString();
            Cell c = GetCell(ws, (uint)rowindex, columnName);
            SharedStringItem sharedo = null;
            string value = "";
            SharedStringTablePart stringTable = null;
            int cal = 0;
            if (c.DataType.Value == CellValues.SharedString)
            {
                stringTable = wb.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                if (stringTable != null)
                {
                    //value = stringTable.SharedStringTable.
                    //  ElementAt(int.Parse(c.CellValue.InnerText)).InnerText;
                    //value = stringTable.SharedStringTable.
                    //  ElementAt(int.Parse(c.CellValue.InnerText)).InnerText;
                    sharedo = (SharedStringItem)stringTable.SharedStringTable.ElementAt(int.Parse(c.CellValue.InnerText)).Clone();
                    if (sharedo != null && sharedo.HasChildren && sharedo.ChildElements.Count > 1)
                    {
                        cal = 1;
                    }
                }
                if (cal == 0)
                {
                    sharedo = null;//set null to cal on value
                    value = stringTable.SharedStringTable.ElementAt(int.Parse(c.CellValue.InnerText)).InnerText;
                }

            }
            else
            {
                //cvlo = (CellValue) c.CellValue.Clone();
                value = c.CellValue.InnerText;
            }
            string[] replaceformat = source.Split('|');
            int cr = Math.Min(replaceformat.Length, para.Length);
            int k = 0;
            for (int i = 0; i < cr; i++)
            {
                if (sharedo != null)
                {
                    for (k = 0; k < sharedo.ChildElements.Count; k++)
                    {
                        sharedo.ChildElements[k].InnerXml = sharedo.ChildElements[k].InnerXml.Replace(replaceformat[i], para[i].ToString());
                        //                        cvlo.ChildElements[k].InnerText = cvlo.ChildElements[k].InnerText.Replace(replaceformat[i], para[i].ToString());
                    }
                }
                else
                {
                    value = value.Replace(replaceformat[i], para[i].ToString());
                }
            }
            //            CellValue cvl = new CellValue(value);
            if (sharedo == null)
            {
                c.CellValue = new CellValue(value);//cvlo;// 
                c.DataType = convertType(celltype);
            }
            else
            {
                stringTable.SharedStringTable.AppendChild(sharedo);
                c.DataType = CellValues.SharedString;
                stringTable.SharedStringTable.Save();
                c.CellValue = new CellValue((stringTable.SharedStringTable.ChildElements.Count - 1).ToString());
            }
            return 0;
        }
        protected Cell GetCell(WorksheetPart ws, uint rowindex, string columnName)
        {
            Row r = GetRow(ws.Worksheet, rowindex);
            return GetCell(r, columnName);

        }
        protected int updateCell(Row exelRow, WorkbookPart wb, DataSet xmlDs, string xmlTableName, string xmlId, params object[] para)
        {
            if (!xmlDs.Tables.Contains(xmlTableName))
            {
                return -1;
            }
            DataRow dr = getDataRow(xmlDs.Tables[xmlTableName], xmlId);
            if (dr == null)
            {
                return -2;
            }
            int rowindex = 0;
            string columnName = "col";
            string source = "source";
            string celltype = "celltype";
            Cell c = GetCell(exelRow, (uint)rowindex, columnName);
            SharedStringItem sharedo = null;
            string value = "";
            SharedStringTablePart stringTable = null;
            int cal = 0;
            if (c.DataType.Value == CellValues.SharedString)
            {
                stringTable = wb.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                if (stringTable != null)
                {
                    //value = stringTable.SharedStringTable.
                    //  ElementAt(int.Parse(c.CellValue.InnerText)).InnerText;
                    //value = stringTable.SharedStringTable.
                    //  ElementAt(int.Parse(c.CellValue.InnerText)).InnerText;
                    sharedo = (SharedStringItem)stringTable.SharedStringTable.ElementAt(int.Parse(c.CellValue.InnerText)).Clone();
                    if (sharedo != null && sharedo.HasChildren && sharedo.ChildElements.Count > 1)
                    {
                        cal = 1;
                    }
                }
                if (cal == 0)
                {
                    sharedo = null;//set null to cal on value
                    value = stringTable.SharedStringTable.ElementAt(int.Parse(c.CellValue.InnerText)).InnerText;
                }

            }
            else
            {
                //cvlo = (CellValue) c.CellValue.Clone();
                value = c.CellValue.InnerText;
            }
            string[] replaceformat = source.Split('|');
            int cr = Math.Min(replaceformat.Length, para.Length);
            int k = 0;
            for (int i = 0; i < cr; i++)
            {
                if (sharedo != null)
                {
                    for (k = 0; k < sharedo.ChildElements.Count; k++)
                    {
                        sharedo.ChildElements[k].InnerXml = sharedo.ChildElements[k].InnerXml.Replace(replaceformat[i], para[i].ToString());
                        //                        cvlo.ChildElements[k].InnerText = cvlo.ChildElements[k].InnerText.Replace(replaceformat[i], para[i].ToString());
                    }
                }
                else
                {
                    value = value.Replace(replaceformat[i], para[i].ToString());
                }
            }
            //            CellValue cvl = new CellValue(value);
            if (sharedo == null)
            {
                c.CellValue = new CellValue(value);//cvlo;// 
                c.DataType = convertType(celltype);
            }
            else
            {
                stringTable.SharedStringTable.AppendChild(sharedo);
                c.DataType = CellValues.SharedString;
                stringTable.SharedStringTable.Save();
                c.CellValue = new CellValue((stringTable.SharedStringTable.ChildElements.Count - 1).ToString());
            }
            return 0;
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
        protected int closeFile(SpreadsheetDocument spreadSheet, WorkbookPart workbookPart, WorksheetPart worksheetPart)
        {
            int ret = 0;
            worksheetPart.Worksheet.Save();
            workbookPart.Workbook.Save();
            spreadSheet.Close();
            return ret;
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
        protected DataRow getDataRow(DataTable dt, string filterValue)
        {
            if (dt == null)
            {
                return null;
            }
            filterValue = filterValue.Replace("'", "''");

            DataRow[] row = dt.Select(string.Format("id='{0}'", filterValue));
            if (row.Length < 1)
            {
                return null;
            }
            return row[0];
        }
        protected int updateCell(WorksheetPart ws, DataSet xmlDs, string xmlTableName, string xmlId, string value)
        {
            if (!xmlDs.Tables.Contains(xmlTableName))
            {
                return -1;
            }
            DataRow dr = getDataRow(xmlDs.Tables[xmlTableName], xmlId);
            if (dr == null)
            {
                return -2;
            }
            return updateCell(ws, dr, value);
        }
        protected int updateCell(WorksheetPart ws, DataSet xmlDs, string xmlTableName, string xmlId, DataRow sourceRow)
        {
            if (!xmlDs.Tables.Contains(xmlTableName))
            {
                return -1;
            }
            DataRow dr = getDataRow(xmlDs.Tables[xmlTableName], xmlId);
            if (dr == null)
            {
                return -2;
            }
            return updateCell(ws, dr, sourceRow);
        }
        protected int updateCell(WorksheetPart ws, DataRow dtrow, DataRow sourceRow)
        {
            int row = 1;
            Row r = GetRow(ws.Worksheet, (uint)row);
            return updateCell(r, dtrow, sourceRow);

        }
        protected int updateCell(Row r, DataRow dtrow, DataRow sourceRow)
        {
            string col = dtrow["col"].ToString();
            string celltype = dtrow["type"].ToString();
            //string defaultValue = dtrow["default"].ToString();
                    string defaultValue = "";
            string source = dtrow["source"].ToString();
            //string format = dtrow["format"].ToString(); ;
            string format = "";
            DateTime dt = new DateTime();

            string value = "";
            switch (celltype.ToUpper())
            {
                case "STRING":
                    value = sourceRow[source].ToString();
                    break;
                case "NUMBER2STRING":
                    value = sourceRow[source].ToString();
                    break;
                case "NUMBER":
                    if (format != "" && format.ToUpper() != "NONE")
                    {
                        value =sourceRow[source].ToString();
                    }
                    else
                    {
                        value = sourceRow[source].ToString();
                    }
                    break;
                case "DATE":
                    dt = DateTime.Parse(sourceRow[source].ToString());
                    if (dt != DateTime.MinValue)
                    {

                        value = dt.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        value = "";
                        celltype = "string";
                    }
                    break;
                case "DATESTRING":
                    dt = DateTime.Parse(sourceRow[source].ToString());
                    if (dt != DateTime.MinValue)
                    {

                        value = dt.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        value = "";
                    }
                    break;
            }
            Cell cellme = GetCell(r, col);
            cellme.CellValue = new CellValue(value);
            cellme.DataType = convertType("string");
            return 0;
        }
        protected int updateCell(WorksheetPart ws, DataRow xmldtrow, string value)
        {
            int row = 1;
            Row r = GetRow(ws.Worksheet, (uint)row);
            return updateCell(r, xmldtrow, value);
        }
        protected int updateCell(Row r, DataRow dtrow, string value)
        {
            string col = dtrow["col"].ToString();
            string celltype = dtrow["type"].ToString();
            string defaultValue = "defaultValue";
            Cell cellme = GetCell(r, col);
            cellme.CellValue = new CellValue(value);
            cellme.DataType = convertType("string");
            return 0;
        }
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
        protected CellFormat GetCellFormat(WorkbookPart workbookPart, uint styleIndex)
        {
            return workbookPart.WorkbookStylesPart.Stylesheet.Elements<CellFormats>().First().Elements<CellFormat>().ElementAt((int)styleIndex);
        }
        private Cell GetCell(Row row, uint rowIndex, string columnName)
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
        protected Row GetRow(Worksheet worksheet, uint rowIndex)
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
    }
}
