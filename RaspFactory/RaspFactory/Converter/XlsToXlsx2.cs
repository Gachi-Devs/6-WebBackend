using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaspFactory.Converter
{
    public class XlsToXlsx2
    {

        public void ConvertToXlsxFile(string xlsPath, string destPath)
        {


            String dirPath = @"C:\Users\Win10_Game_OS\OneDrive\Рабочий стол\ffff\fff.xls";
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(xlsPath);
            workbook.SaveToFile(destPath, ExcelVersion.Version2013);



        }


    }
}
