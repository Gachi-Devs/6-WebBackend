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
}

