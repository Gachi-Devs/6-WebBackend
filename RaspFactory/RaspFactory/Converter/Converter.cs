using System;
using System.IO;
using System.Xml;
using Aspose.Cells;
using Newtonsoft.Json;



namespace RaspFactory.Converter
{
   public class Converter
    {
       

        public static String GetXmlFromXls(String xlsPath, String xlsxPath)
        {

            XlsxToXml convertXML = new XlsxToXml();

            XlsToXlsx convertXlsx = new XlsToXlsx();

            convertXlsx.ConvertToXlsxFile(xlsPath, xlsxPath);

            string exelSTR = convertXML.ConvertByFile(xlsxPath);


            return exelSTR;


        }




      public static String GetXmlFromXlsx(String xlsxPath)
      {



            XlsxToXml convertXML = new XlsxToXml();

            string exelSTR = convertXML.ConvertByFile(xlsxPath);


            return exelSTR;
      }






    }





















}






