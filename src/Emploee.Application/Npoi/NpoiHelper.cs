using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Text.RegularExpressions;
 
using System.Web;
using Abp.UI;
 

namespace Emploee.Npoi
{
    public class NpoiHelper
    {
        private readonly ISqlExecuter _sqlExecuter;
         

        public NpoiHelper(ISqlExecuter sqlExecuter )
        {
            _sqlExecuter = sqlExecuter;
            
        }






        /// <summary>
        /// 将excel导入到datatable
        /// </summary>
        /// <param name="filePath">excel路径</param>
        /// <param name="isColumnName">第一行是否是列名</param>
        /// <returns>返回datatable</returns>
        public static DataTable ExcelToDataTable(string filePath, bool isColumnName)
        {

            DataTable dataTable = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 7;
            try
            {
                using (fs = File.OpenRead(filePath))
                {
                    // 2007版本
                    if (filePath.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本
                    else if (filePath.IndexOf(".xls") > 0)
                        workbook = new HSSFWorkbook(fs);

                    if (workbook != null)
                    {
                        int sheetTotalNumber = workbook.NumberOfSheets - 2;
                        for (int sheetT = 0; sheetT <= sheetTotalNumber; sheetT++)
                        {

                            sheet = workbook.GetSheetAt(sheetT);//读取第一个sheet，当然也可以   

                            dataTable = new DataTable();
                            if (sheet != null)
                            {

                                int rowCount = sheet.LastRowNum;//总行数
                                if (rowCount > 0)
                                {
                                    IRow firstRow = sheet.GetRow(0);//第一行

                                    int cellCount = firstRow.LastCellNum;//列数

                                    //构建datatable的列
                                    if (isColumnName)
                                    {
                                        startRow = 7;//如果第一行是列名，则从第二行开始读取
                                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                        {
                                            cell = firstRow.GetCell(i);
                                            if (cell != null)
                                            {
                                                if (cell.StringCellValue != null)
                                                {
                                                    column = new DataColumn(cell.StringCellValue);
                                                    dataTable.Columns.Add(column);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                        {
                                            column = new DataColumn("column" + (i + 1));
                                            dataTable.Columns.Add(column);
                                        }
                                    }

                                    //填充行
                                    for (int i = startRow; i <= rowCount; ++i)
                                    {
                                        row = sheet.GetRow(i);
                                        if (row == null) continue;

                                        dataRow = dataTable.NewRow();
                                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                                        {
                                            cell = row.GetCell(j);
                                            if (cell == null)
                                            {
                                                dataRow[j] = "";
                                            }
                                            else
                                            {
                                                //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)
                                                switch (cell.CellType)
                                                {
                                                    case CellType.Blank:
                                                        dataRow[j] = "";
                                                        break;
                                                    case CellType.Numeric:
                                                        short format = cell.CellStyle.DataFormat;
                                                        //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                                        if (format == 14 || format == 31 || format == 57 || format == 58)
                                                            dataRow[j] = cell.DateCellValue;
                                                        else
                                                            dataRow[j] = cell.NumericCellValue;
                                                        break;
                                                    case CellType.String:
                                                        dataRow[j] = cell.StringCellValue;
                                                        break;
                                                }
                                            }
                                        }
                                        dataTable.Rows.Add(dataRow);
                                    }
                                }
                            }
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return null;
            }
        }

        public static List<T> ExcelToList<T>(Type instanceType, string strFileName, int sheetIndex = 0, bool haveTitles = false, Dictionary<string, string> titleDic = null) where T : class, new()
        {
            PropertyInfo[] myPropertyInfo = instanceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);  //获取所有属性
            List<T> tList = new List<T>();
            var propertys = typeof(T).GetProperties();
            HSSFWorkbook hssfworkbook = null;
            XSSFWorkbook xssfworkbook = null;
            strFileName = HttpContext.Current.Server.MapPath(strFileName);

            string fileExt = Path.GetExtension(strFileName);    //获取文件的后缀名
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                if (fileExt == ".xls")
                    hssfworkbook = new HSSFWorkbook(file);
                else if (fileExt == ".xlsx")
                    xssfworkbook = new XSSFWorkbook(file);     //初始化太慢了，不知道这是什么bug
            }
            if (hssfworkbook != null)
            {
                HSSFSheet sheet = (HSSFSheet)hssfworkbook.GetSheetAt(sheetIndex);
                if (sheet != null)
                {
                    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                    if (haveTitles)
                    {
                        HSSFRow headerRow = (HSSFRow)sheet.GetRow(0);
                        int cellCount = headerRow.LastCellNum;
                        for (int j = 0; j < cellCount; j++)
                        {
                            HSSFCell cell = (HSSFCell)headerRow.GetCell(j);   //获取Excel标题
                        }
                    }
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                        HSSFRow row = (HSSFRow)sheet.GetRow(i);

                        var obj = new T();
                        for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                        {
                            string cellValue = "";
                            if (row.GetCell(j) != null)
                            {
                                cellValue = row.GetCell(j).ToString();
                                string dkey = titleDic.Keys.ToArray()[j];
                                string dataType = (myPropertyInfo[j].PropertyType).FullName;  //获取数据类型
                                foreach (var p in propertys)
                                {
                                    string name = p.Name;
                                    if (name == dkey)
                                    {
                                        if (dataType == "System.String")
                                        {
                                            p.SetValue(obj, cellValue, null);
                                        }
                                        else if (dataType == "System.DateTime")
                                        {
                                            DateTime pdt = Convert.ToDateTime(cellValue);
                                            p.SetValue(obj, pdt, null);
                                        }
                                        else if (dataType == "System.Boolean")
                                        {
                                            bool pb = Convert.ToBoolean(cellValue);
                                            p.SetValue(obj, pb, null);
                                        }
                                        else if (dataType == "System.Int16")
                                        {
                                            Int16 pi16 = Convert.ToInt16(cellValue);
                                            p.SetValue(obj, pi16, null);
                                        }
                                        else if (dataType == "System.Int32")
                                        {
                                            Int32 pi32 = Convert.ToInt32(cellValue);
                                            p.SetValue(obj, pi32, null);
                                        }
                                        else if (dataType == "System.Int64")
                                        {
                                            Int64 pi64 = Convert.ToInt64(cellValue);
                                            p.SetValue(obj, pi64, null);
                                        }
                                        else if (dataType == "System.Byte")
                                        {
                                            Byte pb = Convert.ToByte(cellValue);
                                            p.SetValue(obj, pb, null);
                                        }
                                        else if (dataType == "System.Decimal")
                                        {
                                            System.Decimal pd = Convert.ToDecimal(cellValue);
                                            p.SetValue(obj, pd, null);
                                        }
                                        else if (dataType == "System.Double")
                                        {
                                            double pd = Convert.ToDouble(cellValue);
                                            p.SetValue(obj, pd, null);
                                        }
                                        else
                                        {
                                            p.SetValue(obj, null, null);
                                        }
                                    }
                                }
                            }
                        }
                        tList.Add(obj);
                    }
                }
            }
            else if (xssfworkbook != null)
            {
                XSSFSheet xSheet = (XSSFSheet)xssfworkbook.GetSheetAt(sheetIndex);
                if (xSheet != null)
                {
                    System.Collections.IEnumerator rows = xSheet.GetRowEnumerator();
                    if (haveTitles)
                    {
                        XSSFRow headerRow = (XSSFRow)xSheet.GetRow(0);
                        int cellCount = headerRow.LastCellNum;
                        for (int j = 0; j < cellCount; j++)
                        {
                            XSSFCell cell = (XSSFCell)headerRow.GetCell(j);   //获取Excel标题
                        }
                    }
                    for (int i = (xSheet.FirstRowNum + 1); i <= xSheet.LastRowNum; i++)
                    {
                        XSSFRow row = (XSSFRow)xSheet.GetRow(i);

                        var obj = new T();
                        for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                        {
                            string value = "";
                            if (row.GetCell(j) != null)
                            {
                                value = row.GetCell(j).ToString();
                                string dkey = titleDic.Keys.ToArray()[j];
                                string dvalue = titleDic.Values.ToArray()[j];
                                string str = (myPropertyInfo[j].PropertyType).FullName;  //获取数据类型
                                foreach (var p in propertys)
                                {
                                    string name = p.Name;
                                    if (name == dkey)
                                    {
                                        if (str == "System.String")
                                        {
                                            p.SetValue(obj, value, null);
                                        }
                                        else if (str == "System.DateTime")
                                        {
                                            //var datevalue= row.GetCell(j).DateCellValue;
                                            // DateTime pdt = Convert.ToDateTime(datevalue);
                                            DateTime pdt = row.GetCell(j).DateCellValue;
                                            p.SetValue(obj, pdt, null);
                                        }
                                        else if (str == "System.Boolean")
                                        {
                                            bool pb = Convert.ToBoolean(value);
                                            p.SetValue(obj, pb, null);
                                        }
                                        else if (str == "System.Int16")
                                        {
                                            Int16 pi16 = Convert.ToInt16(value);
                                            p.SetValue(obj, pi16, null);
                                        }
                                        else if (str == "System.Int32")
                                        {
                                            Int32 pi32 = Convert.ToInt32(value);
                                            p.SetValue(obj, pi32, null);
                                        }
                                        else if (str == "System.Int64")
                                        {
                                            Int64 pi64 = Convert.ToInt64(value);
                                            p.SetValue(obj, pi64, null);
                                        }
                                        else if (str == "System.Byte")
                                        {
                                            Byte pb = Convert.ToByte(value);
                                            p.SetValue(obj, pb, null);
                                        }
                                        else if (str == "System.Decimal")
                                        {
                                            System.Decimal pd = Convert.ToDecimal(value);
                                            p.SetValue(obj, pd, null);
                                        }
                                        else if (str == "System.Double")
                                        {
                                            double pd = Convert.ToDouble(value);
                                            p.SetValue(obj, pd, null);
                                        }
                                        else
                                        {
                                            p.SetValue(obj, null, null);
                                        }
                                    }
                                }
                            }
                        }
                        tList.Add(obj);
                    }
                }
            }
            return tList;
        }




        /// <summary>
        /// 将excel导入到datatable
        /// </summary>
        /// <param name="filePath">excel路径</param>
        /// <param name="isColumnName">第一行是否是列名</param>
        /// <returns>返回datatable</returns>
         
        public class ExcelUtility
        {


            /// <summary>  
            /// 将excel中的数据导入到DataTable中  
            /// </summary>  
            /// <param name="fileName">execl文件路径名称</param>  
            /// <param name="sheetName">excel工作薄sheet的名称</param>  
            /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>  
            /// <returns>返回的DataTable</returns>  
            public static DataTable ExcelToDataTableNew(string fileName, bool isFirstRowColumn)
            {
                IWorkbook workbook = null;

                fileName = HttpContext.Current.Server.MapPath(fileName);

                var data = new DataTable();
                try
                {
                    var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    // 2007版本  
                    if (fileName != null && fileName.IndexOf(".xlsx") > 0)
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    // 2003版本  
                    else if (fileName != null && fileName.IndexOf(".xls") > 0)
                    {
                        workbook = new HSSFWorkbook(fs);
                    }

                    var sheet = workbook.GetSheetAt(0);

                    if (sheet == null) return data;

                    var firstRow = sheet.GetRow(0);
                    //一行最后一个cell的编号 即总的列数  
                    int cellCount = firstRow.LastCellNum;
                    var startRow = 0;

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            var column = new DataColumn(firstRow.GetCell(i).StringCellValue);
                            data.Columns.Add(column);
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号  
                    var rowCount = sheet.LastRowNum;
                    for (var i = startRow; i <= rowCount; ++i)
                    {
                        var row = sheet.GetRow(i);
                        //没有数据的行默认是null  
                        if (row == null) continue;

                        var dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            //同理，没有数据的单元格都默认是null  
                            if (row.GetCell(j) != null)
                            {
                                dataRow[j] = row.GetCell(j).ToString();
                            }
                        }
                        data.Rows.Add(dataRow);
                    }
                    return data;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            /// <summary>
            /// 将excel导入到datatable
            /// </summary>
            /// <param name="filePath">excel路径</param>
            /// <param name="isColumnName">第一行是否是列名</param>
            /// <returns>返回datatable</returns>
            public static DataTable ExcelToDataTable(string filePath, bool isColumnName)
            {

                DataTable dataTable = null;
                FileStream fs = null;
                DataColumn column = null;
                DataRow dataRow = null;
                IWorkbook workbook = null;
                ISheet sheet = null;
                IRow row = null;
                ICell cell = null;
                int startRow = 2;
                filePath = HttpContext.Current.Server.MapPath(filePath);

                try
                {
                    using (fs = File.OpenRead(filePath))
                    {
                        // 2007版本
                        if (filePath.IndexOf(".xlsx") > 0)
                            workbook = new XSSFWorkbook(fs);
                        // 2003版本
                        else if (filePath.IndexOf(".xls") > 0)
                            workbook = new HSSFWorkbook(fs);

                        if (workbook != null)
                        {
                            int sheetTotalNumber = workbook.NumberOfSheets;
                            for (int sheetT = 0; sheetT <= sheetTotalNumber; sheetT++)
                            {

                                sheet = workbook.GetSheetAt(sheetT);//读取第一个sheet，当然也可以   

                                dataTable = new DataTable();
                                if (sheet != null)
                                {

                                    int rowCount = sheet.LastRowNum;//总行数
                                    if (rowCount > 0)
                                    {
                                        IRow firstRow = sheet.GetRow(0);//第一行

                                        int cellCount = firstRow.LastCellNum;//列数

                                        //构建datatable的列
                                        if (isColumnName)
                                        {
                                            startRow = 2;//如果第一行是列名，则从第二行开始读取
                                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                            {
                                                cell = firstRow.GetCell(i);
                                                if (cell != null)
                                                {
                                                    if (cell.StringCellValue != null)
                                                    {
                                                        column = new DataColumn(cell.StringCellValue);
                                                        dataTable.Columns.Add(column);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                            {
                                                column = new DataColumn("column" + (i + 1));
                                                dataTable.Columns.Add(column);
                                            }
                                        }

                                        //填充行
                                        for (int i = startRow; i <= rowCount; ++i)
                                        {
                                            row = sheet.GetRow(i);
                                            if (row == null) continue;

                                            dataRow = dataTable.NewRow();
                                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                                            {
                                                cell = row.GetCell(j);
                                                if (cell == null)
                                                {
                                                    dataRow[j] = "";
                                                }
                                                else
                                                {
                                                    //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)
                                                    switch (cell.CellType)
                                                    {
                                                        case CellType.Blank:
                                                            dataRow[j] = "";
                                                            break;
                                                        case CellType.Numeric:
                                                            short format = cell.CellStyle.DataFormat;
                                                            //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                                            if (format == 14 || format == 31 || format == 57 || format == 58)
                                                                dataRow[j] = cell.DateCellValue;
                                                            else
                                                                dataRow[j] = cell.NumericCellValue;
                                                            break;
                                                        case CellType.String:
                                                            dataRow[j] = cell.StringCellValue;
                                                            break;
                                                    }
                                                }
                                            }
                                            dataTable.Rows.Add(dataRow);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return dataTable;
                }
                catch (Exception ex)
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                    return null;
                }
            }

            public static List<T> ExcelToList<T>(Type instanceType, string strFileName, int sheetIndex = 0, bool haveTitles = false, Dictionary<string, string> titleDic = null) where T : class, new()
            {
                PropertyInfo[] myPropertyInfo = instanceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);  //获取所有属性
                List<T> tList = new List<T>();
                var propertys = typeof(T).GetProperties();
                HSSFWorkbook hssfworkbook = null;
                XSSFWorkbook xssfworkbook = null;
                strFileName = HttpContext.Current.Server.MapPath(strFileName);
                string fileExt = Path.GetExtension(strFileName);    //获取文件的后缀名
                using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    if (fileExt == ".xls")
                        hssfworkbook = new HSSFWorkbook(file);
                    else if (fileExt == ".xlsx")
                        xssfworkbook = new XSSFWorkbook(file);     //初始化太慢了，不知道这是什么bug
                }
                if (hssfworkbook != null)
                {
                    HSSFSheet sheet = (HSSFSheet)hssfworkbook.GetSheetAt(sheetIndex);
                    if (sheet != null)
                    {
                        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                        if (haveTitles)
                        {
                            HSSFRow headerRow = (HSSFRow)sheet.GetRow(0);
                            int cellCount = headerRow.LastCellNum;
                            for (int j = 0; j < cellCount; j++)
                            {
                                HSSFCell cell = (HSSFCell)headerRow.GetCell(j);   //获取Excel标题
                            }
                        }
                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            HSSFRow row = (HSSFRow)sheet.GetRow(i);

                            var obj = new T();
                            for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                            {
                                string cellValue = "";
                                if (row.GetCell(j) != null)
                                {
                                    cellValue = row.GetCell(j).ToString();
                                    string dkey = titleDic.Keys.ToArray()[j];
                                    string dataType = (myPropertyInfo[j].PropertyType).FullName;  //获取数据类型
                                    foreach (var p in propertys)
                                    {
                                        string name = p.Name;
                                        if (name == dkey)
                                        {
                                            if (dataType == "System.String")
                                            {
                                                p.SetValue(obj, cellValue, null);
                                            }
                                            else if (dataType == "System.DateTime")
                                            {
                                                DateTime pdt = Convert.ToDateTime(cellValue);
                                                p.SetValue(obj, pdt, null);
                                            }
                                            else if (dataType == "System.Boolean")
                                            {
                                                bool pb = Convert.ToBoolean(cellValue);
                                                p.SetValue(obj, pb, null);
                                            }
                                            else if (dataType == "System.Int16")
                                            {
                                                Int16 pi16 = Convert.ToInt16(cellValue);
                                                p.SetValue(obj, pi16, null);
                                            }
                                            else if (dataType == "System.Int32")
                                            {
                                                Int32 pi32 = Convert.ToInt32(cellValue);
                                                p.SetValue(obj, pi32, null);
                                            }
                                            else if (dataType == "System.Int64")
                                            {
                                                Int64 pi64 = Convert.ToInt64(cellValue);
                                                p.SetValue(obj, pi64, null);
                                            }
                                            else if (dataType == "System.Byte")
                                            {
                                                Byte pb = Convert.ToByte(cellValue);
                                                p.SetValue(obj, pb, null);
                                            }
                                            else if (dataType == "System.Decimal")
                                            {
                                                System.Decimal pd = Convert.ToDecimal(cellValue);
                                                p.SetValue(obj, pd, null);
                                            }
                                            else if (dataType == "System.Double")
                                            {
                                                double pd = Convert.ToDouble(cellValue);
                                                p.SetValue(obj, pd, null);
                                            }
                                            else
                                            {
                                                p.SetValue(obj, null, null);
                                            }
                                        }
                                    }
                                }
                            }
                            tList.Add(obj);
                        }
                    }
                }
                else if (xssfworkbook != null)
                {
                    XSSFSheet xSheet = (XSSFSheet)xssfworkbook.GetSheetAt(sheetIndex);
                    if (xSheet != null)
                    {
                        System.Collections.IEnumerator rows = xSheet.GetRowEnumerator();
                        if (haveTitles)
                        {
                            XSSFRow headerRow = (XSSFRow)xSheet.GetRow(0);
                            int cellCount = headerRow.LastCellNum;
                            for (int j = 0; j < cellCount; j++)
                            {
                                XSSFCell cell = (XSSFCell)headerRow.GetCell(j);   //获取Excel标题
                            }
                        }
                        for (int i = (xSheet.FirstRowNum + 1); i <= xSheet.LastRowNum; i++)
                        {
                            XSSFRow row = (XSSFRow)xSheet.GetRow(i);

                            var obj = new T();
                            for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                            {
                                string value = "";
                                if (row.GetCell(j) != null)
                                {
                                    value = row.GetCell(j).ToString();
                                    string dkey = titleDic.Keys.ToArray()[j];
                                    string dvalue = titleDic.Values.ToArray()[j];
                                    string str = (myPropertyInfo[j].PropertyType).FullName;  //获取数据类型
                                    foreach (var p in propertys)
                                    {
                                        string name = p.Name;
                                        if (name == dkey)
                                        {
                                            if (str == "System.String")
                                            {
                                                p.SetValue(obj, value, null);
                                            }
                                            else if (str == "System.DateTime")
                                            {
                                                if (!string.IsNullOrEmpty(value))
                                                {
                                                    DateTime pdt = Convert.ToDateTime(value);
                                                    p.SetValue(obj, pdt, null);
                                                }
                                            }
                                            else if (str == "System.Boolean")
                                            {
                                                bool pb = Convert.ToBoolean(value);
                                                p.SetValue(obj, pb, null);
                                            }
                                            else if (str == "System.Int16")
                                            {
                                                Int16 pi16 = Convert.ToInt16(value);
                                                p.SetValue(obj, pi16, null);
                                            }
                                            else if (str == "System.Int32")
                                            {
                                                if (!string.IsNullOrEmpty(value))
                                                {
                                                    Int32 pi32 = Convert.ToInt32(value);
                                                    p.SetValue(obj, pi32, null);
                                                }
                                            }
                                            else if (str == "System.Int64")
                                            {
                                                Int64 pi64 = Convert.ToInt64(value);
                                                p.SetValue(obj, pi64, null);
                                            }
                                            else if (str == "System.Byte")
                                            {
                                                Byte pb = Convert.ToByte(value);
                                                p.SetValue(obj, pb, null);
                                            }
                                            else if (str == "System.Decimal")
                                            {
                                                System.Decimal pd = Convert.ToDecimal(value);
                                                p.SetValue(obj, pd, null);
                                            }
                                            else if (str == "System.Double")
                                            {
                                                double pd = Convert.ToDouble(value);
                                                p.SetValue(obj, pd, null);
                                            }
                                            else if (str == "System.Single")
                                            {
                                                float pd = Convert.ToSingle(value);
                                                p.SetValue(obj, pd, null);
                                            }
                                            else
                                            {
                                                p.SetValue(obj, null, null);
                                            }
                                        }
                                    }
                                }
                            }
                            tList.Add(obj);
                        }
                    }
                }
                return tList;
            }

        }
    }
    
}
