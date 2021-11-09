using System;
using System.IO.Compression;
using System.IO;

class Archiver
{  
    public static void doArchive(string sourceFolder, string zipFolder)
    {
 
        zipFolder = zipFolder.Insert(zipFolder.Length, @"\" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToFileTimeUtc() + ".zip");          
        DirectoryInfo dirInfo = new DirectoryInfo(sourceFolder);
        if (dirInfo.Exists)
        {
            try 
            { 
                ZipFile.CreateFromDirectory(sourceFolder, zipFolder); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                
        }
        else Console.WriteLine("Папка для архивации не найдена");          
    }
}

