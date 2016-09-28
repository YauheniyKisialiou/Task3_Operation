using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class FileWorker
    {
        string folderPath = @"d:\";
        string folderName;
        string fileName = "Result.txt";
        string separator = @"\";
        string copiedFilePath = @"d:\CopiedFile.txt";
        List<string> tempList;

        public void CreateFolder()
        {
            Console.WriteLine("Enter folder name");

            while (true)
            {
                folderName = Console.ReadLine();


                if (Directory.Exists(folderPath + folderName))
                {
                    Console.WriteLine("This folder exist. Enter another folder name");
                    continue;
                }
                else
                {
                    Directory.CreateDirectory($@"d:\{folderName}");
                    break;
                }
            }
        }

        public void CreateFile()
        {
            File.Create(folderPath + folderName + separator + fileName).Close();
            
        }

        public void CopyFile()
        {
            tempList = File.ReadLines(copiedFilePath).Take(20).ToList();
            File.WriteAllLines(folderPath + folderName + separator + fileName, tempList);
        }
    }
}
