using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaspFactory.Converter
{
    public class XlsToXlsx
    {

        public void ConvertToXlsxFile(string xlsPath, string destPath)
        {


            Workbook workbook = new Workbook();
            workbook.LoadFromFile(xlsPath);
            workbook.SaveToFile(destPath, ExcelVersion.Version2013);



        }


    }
}