using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Globalization;

namespace LibForTask4_2
{
    public static class Matrix
    {
        static double[,] firstMatrix;
        static double[,] SecondMatrix;


        static void ReadFile()
        {
            List<string> listOfMatrix;
            List<string> firstMatrixToList = new List<string>();
            List<string> SecondMatrixToList = new List<string>();
            var config = ConfigurationManager.AppSettings["config"];

            listOfMatrix = File.ReadAllLines(config).ToList();
            var FirstMatrixSize = listOfMatrix[0].Split();
            var SecondMatrixSize = listOfMatrix[int.Parse(FirstMatrixSize[0]) + 1].Split();

            for (int i = 1; i < listOfMatrix.Count; i++)
            {
                if (i < (int.Parse(FirstMatrixSize[0]) +2))
                {
                    firstMatrixToList.Add(listOfMatrix[i]);
                }
                else
                {
                    SecondMatrixToList.Add(listOfMatrix[i]);
                }
            }
            firstMatrix = ConvertMatrixToDouble(firstMatrixToList, FirstMatrixSize);
            SecondMatrix =  ConvertMatrixToDouble(SecondMatrixToList, SecondMatrixSize);
        }

        public static double[,] MultiplicationOfMatrix()
        {
            ReadFile();
            if (firstMatrix.GetLength(1) != SecondMatrix.GetLength(0))
            {
                Console.WriteLine("Multiplication is impossible. Invalid sizes");
                return null;
            }
            else
            {
                double[,] r = new double[firstMatrix.GetLength(0), SecondMatrix.GetLength(1)];
                for (int i = 0; i < firstMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < SecondMatrix.GetLength(1); j++)
                    {
                        for (int k = 0; k < SecondMatrix.GetLength(0); k++)
                        {
                            r[i, j] += firstMatrix[i, k] * SecondMatrix[k, j];
                        }
                    }
                }
                return r;
            }
            
        }

        static double[,] ConvertMatrixToDouble(List<string> listOfMatrix, string[] matrixSize)
        {
            int size1 = int.Parse(matrixSize[0]);
            int size2 = int.Parse(matrixSize[1]);
            double[,] matrix = new double[size1,size2];
                for (int m = 0; m < size1; m++)
                {
                    string[] tempArray;
                    tempArray = listOfMatrix[m].Split();
                    for (int n = 0; n < size2; n++)
                    {
                        matrix[m, n] = double.Parse(tempArray[n]);
                    }
                }
            return matrix;
        }

        public static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j].ToString("F", CultureInfo.InvariantCulture).PadLeft(10) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
