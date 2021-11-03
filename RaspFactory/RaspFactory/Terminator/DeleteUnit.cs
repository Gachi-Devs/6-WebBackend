using System;
using System.IO;

class DeleteUnit
{
    public static void deleteFile(string path)
    {
        FileInfo fileInfo = new FileInfo(path);
        if (fileInfo.Exists) fileInfo.Delete();
        else Console.WriteLine("Файл не найден");
    }

    public static void deleteFiles(string path)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(path);
        if (dirInfo.Exists)
        {
            foreach (FileInfo file in dirInfo.GetFiles()) file.Delete();
        }
        else Console.WriteLine("Папка не найдена");
    }
}

