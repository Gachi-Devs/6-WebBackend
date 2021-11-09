using RaspFactory.Parser;
using System;
using System.Collections.Generic;
using System.IO;

namespace RaspFactory
{
    class Program
    {
        static void Main(string[] args)
        {

            AppDomain domain = AppDomain.CurrentDomain;
            string pathOfProject = domain.BaseDirectory;

            string[] xlsDirs = Converter.GetDirs.GetAllDirs(Path.Combine(domain.BaseDirectory, "xlsInput"));
            for (int i = 0; i < xlsDirs.Length; i++)
            {
                Converter.Converter.GetXmlFromXls(xlsDirs[i], pathOfProject + "\\xlsxInput\\" + i+".xlsx");
                Parser.Parser.Pars(Converter.Converter.GetXmlFromXls(xlsDirs[i], pathOfProject + "\\xlsxInput\\" + i + ".xlsx"), pathOfProject + "\\jsonOutput");
            }
            Archiver.doArchive(pathOfProject + "\\xlsInput");
           // DeleteUnit.deleteFiles(@"P:\ITheM\Documents\TESTJSON\Conv\xlsInput");
            /* var p = new Parser.Parser();
             p.Pars();*/










        }
    }
}
