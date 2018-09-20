using System;
using System.IO;
namespace Backend
{
    public class LogGenerater
    {
        StreamWriter writer;
        /*
         * This method generates the log file on the basis of the Data passed.
         * @param:Data.
         * @returns:Nothing.
         */ 
        public void GenerateLog(string data)
        {
            try
            {
                writer = new StreamWriter("C:\\Users\\Raju Methwani\\Desktop\\log.txt");
                writer.WriteLine(data);
            }
            catch (Exception e)
            {
                writer.WriteLine("Error" + e);
            }
        }
    }
}