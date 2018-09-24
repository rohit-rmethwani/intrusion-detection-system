using System;
using System.IO;
namespace Backend
{
    public class LogGenerater
    {
        /*
         * This method generates the log file on the basis of the Data passed.
         * @param:Data.
         * @returns:Nothing.
         */ 
        public void GenerateLog(string data)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\Raju Methwani\\Desktop\\log.txt", true))
            {
                try
                {
                    writer.WriteLine(data);
                    Console.WriteLine("From LogGenerater:" + data);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    writer.WriteLine("Error" + e);
                }
            }
        }
    }
}