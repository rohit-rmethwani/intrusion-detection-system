using System;
using Backend;
using System.IO;
public class MainClass
{
    public static void Main()
    {
        int i = 0;
        Watcher obj = new Watcher();
        Console.WriteLine("Path:" + Directory.GetCurrentDirectory());
        obj.Log.GenerateLog("Application started by:"+Environment.UserName+" on "+DateTime.Now);
        obj.StartWatcher();
        string curpath = Directory.GetCurrentDirectory();
        string[] files = Directory.GetFiles(curpath + "\\Test");
        if (files.Length!=0)
        {
            foreach (string name in files)
            {
                Console.WriteLine(i + name);
                i++;
            }
            Console.WriteLine("Enter the file number which you want to see:");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine(files[choice]);
            obj.Log.GenerateLog("Exiting the application by:" + Environment.UserName + " on " + DateTime.Now);
            FileOperations.SaveFile(files[choice]);
        }
        else
        {
            Console.WriteLine("Directory has no files");
        }
    }
}
