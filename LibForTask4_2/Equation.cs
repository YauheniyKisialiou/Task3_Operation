using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibForTask4_2
{
    public class Equation
    {
        List<string> logList = new List<string>();

        public void ChoseEquation()
        {
            string line;
            Console.WriteLine("Chose equation to solve: 1 - QuadraticEquation, 2 - LinearEquation");
            while (!(line = Console.ReadLine()).Equals("1") && !line.Equals("2"))
            {
                Console.WriteLine("Invalid enter");
                Console.WriteLine("Chose equation to solve: 1 - QuadraticEquation, 2 - LinearEquation");
            }
            
            switch (line)
            {
                case "1":
                    logList.Add("QuadraticEquation" + "\n");
                    SolveQuadraticEquation();
                    WriteInFile();
                    break;
                case "2":
                    logList.Add("LinearEquation" + "\n");
                    SolveLinearEquation();
                    WriteInFile();
                    break;
            }

        }

        public List<double> CheckСoefficient(int numberOfCoef)
        {
            List<string> list = new List<string>() { "Enter coef 'a'", "Enter coef 'b'", "Enter coef 'c'" };
            List<double> listOfCoef = new List<double>();
            string line;
            double coef;
            for (int i = 0; i < numberOfCoef; i++)
            {
                Console.WriteLine(list[i]);
                while (true)
                {
                    if (double.TryParse(line = Console.ReadLine(), out coef))
                    {
                        listOfCoef.Add(coef);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid enter");
                        Console.WriteLine(list[i]);
                        logList.Add($"Invalid enter '{line}'" + "\n");
                    }

                }
            }
            return listOfCoef;

        }

        public void SolveQuadraticEquation()
        {
            List<double> listOfCoef = CheckСoefficient(3);

            if (listOfCoef[0]==0)
            {
                double x;

                if (listOfCoef[1] == 0)
                {
                    logList.Add("Equation dosen't have roots" + "\n");
                }
                if (listOfCoef[1] == 0 && listOfCoef[2] == 0)
                {
                    logList.Add("Equation has infinity set of roots" + "\n");
                }
                if (listOfCoef[1] != 0)
                {
                    x = -listOfCoef[2] / listOfCoef[1];
                    logList.Add($"x = {x.ToString("F", CultureInfo.InvariantCulture)}" + "\n");
                }
            }
            else
            {
                double x1;
                double x2;
                double discriminant;
                discriminant = Math.Pow(listOfCoef[1], 2) - 4 * listOfCoef[0] * listOfCoef[2];

                if (discriminant > 0)
                {
                    x1 = (-listOfCoef[1] + Math.Sqrt(discriminant)) / (2 * listOfCoef[0]);
                    x2 = (-listOfCoef[1] - Math.Sqrt(discriminant)) / (2 * listOfCoef[0]);
                    logList.Add($"x1 = {x1.ToString("F", CultureInfo.InvariantCulture)}" + "\n");
                    logList.Add($"x2 = {x2.ToString("F", CultureInfo.InvariantCulture)}" + "\n");
                }
                if (discriminant == 0)
                {
                    x1 = (-listOfCoef[1]) / (2 * listOfCoef[0]);
                    x2 = x1;
                    logList.Add($"x1 = x2 = {x2.ToString("F", CultureInfo.InvariantCulture)}" + "\n");
                }
                if (discriminant < 0)
                {
                    logList.Add("Equation dosen't have roots" + "\n");
                }
            }
            
        }

        public void SolveLinearEquation()
        {
            List<double> listOfCoef = CheckСoefficient(2);
            double x;

            if (listOfCoef[0] == 0)
            {
                logList.Add("Equation dosen't have roots" + "\n");
            }
            if (listOfCoef[0]==0 && listOfCoef[1]==0)
            {
                logList.Add("Equation has infinity set of roots" + "\n");
            }
            if (listOfCoef[0]!=0)
            {
                x = -listOfCoef[1] / listOfCoef[0];
                logList.Add($"x = {x.ToString("F", CultureInfo.InvariantCulture)}" + "\n");
            }

        }

        public void WriteInFile()
        {
            string path = @"d:\result.txt";
            File.WriteAllLines(path, logList);
        }

    }
}
