using System;
using System.IO;
using System.Xml;
using Aspose.Cells;
using Newtonsoft.Json;



namespace RaspFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            String destPath = @"C:\Users\Win10_Game_OS\OneDrive\Рабочий стол\ffff\ddd.xlsx";
            String dirPath = @"C:\Users\Win10_Game_OS\OneDrive\Рабочий стол\ffff\fff.xls";
              XlsToXlsx2 testXlsx = new XlsToXlsx2();
            testXlsx.ConvertToXlsxFile(dirPath, destPath);


              


            XlsToXml test2XML = new XlsToXml();
            

            XlsxToXml testXML = new XlsxToXml();
            testXML.ConvertByFile(destPath);


               
            

            String exelSTR = testXML.ConvertByFile(destPath);


            var book = new Workbook(destPath);
            book.Save(@"C:\Users\Win10_Game_OS\OneDrive\Рабочий стол\ffff\Test2.xml", Aspose.Cells.SaveFormat.Auto);



            





            try
            {
               
                StreamWriter sw = new StreamWriter(@"C:\Users\Win10_Game_OS\OneDrive\Рабочий стол\ffff\Test.xml");
               
                sw.WriteLine(exelSTR);
                
                
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(exelSTR);
            string jsonText = JsonConvert.SerializeXmlNode(doc);


            try
            {

                StreamWriter sw = new StreamWriter(@"C:\Users\Win10_Game_OS\OneDrive\Рабочий стол\ffff\Test.json");

                sw.WriteLine(jsonText);


                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }




            // To convert JSON text contained in string json into an XML node






        }
    }
}
