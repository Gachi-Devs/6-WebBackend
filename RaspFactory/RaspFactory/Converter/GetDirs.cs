using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspFactory.Converter
{
    public class GetDirs
    {
        public static String[] GetAllDirs(String dirPath)
        {

            string[] files = System.IO.Directory.GetFiles(dirPath);

            return files;

        }







    }

}