using System;
using Backend;
    public class MainClass
    {
        public static void Main()
        {
            Watcher obj = new Watcher();
            //obj.InitializePath();
            //obj.InitializeEvents();
            obj.StartWatcher();
            while (Console.ReadLine() != "q") ;
            obj.Log.GenerateLog("Exiting the application by:"+Environment.UserName+" on "+DateTime.Now);
        }
    }
