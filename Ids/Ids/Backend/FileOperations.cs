using System;
using System.IO;
namespace Backend
{
    public class FileOperations
    {
        public static string[] GetAllFiles(string path)
        {
            return Directory.GetFiles(path);

        }

        public static string[] GetAllDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }

        public static void CreateSelectedFileCopy(string selection)
        {
            Console.WriteLine("From FOM"+selection);
            Console.WriteLine(Path.GetFileNameWithoutExtension(selection));
            Console.WriteLine(Path.GetDirectoryName(selection));
            using (StreamWriter fs = new StreamWriter(Path.GetDirectoryName(selection)+"\\"+Path.GetFileNameWithoutExtension(selection) + "copy" + Path.GetExtension(selection), true))
            {
                fs.WriteLine(File.ReadAllText(selection));
                fs.Close();
            }
        }

        public static void SaveFile(string file)
        {
            string changedData = File.ReadAllText(Path.GetFileNameWithoutExtension(file)+"copy"+Path.GetExtension(file));
            File.AppendAllText(file,changedData);
        }

        public static void DeleteFile(string file)
        {
            File.Delete(file);
        }
        
    }
}