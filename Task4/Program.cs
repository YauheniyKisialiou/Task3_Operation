using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWorker fw = new FileWorker();
            fw.CreateFolder();
            fw.CreateFile();
            fw.CopyFile();
            Console.ReadLine();
        }

        
    }
}
