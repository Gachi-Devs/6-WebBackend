using RaspFactory.Parser;
using System;
using System.Collections.Generic;

namespace RaspFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] xlsDirs = Converter.GetDirs.GetAllDirs(@"P:\ITheM\Documents\TESTJSON\Conv\xlsInput");
            for (int i = 0; i < xlsDirs.Length; i++)
            {
                Converter.Converter.GetXmlFromXls(xlsDirs[i], @"P:\ITheM\Documents\TESTJSON\Conv\xlsxInput\" + i+".xlsx");
                Parser.Parser.Pars(Converter.Converter.GetXmlFromXls(xlsDirs[i], @"P:\ITheM\Documents\TESTJSON\Conv\xlsxInput\" + i + ".xlsx"), @"P:\ITheM\Documents\TESTJSON\Conv\jsonOutput");
            }
            
            /* var p = new Parser.Parser();
             p.Pars();*/

            




          



        }
    }
}
