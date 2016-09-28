using LibForTask4_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Equation equation = new Equation();
            //equation.ChoseEquation();
            //Console.ReadLine();

            try
            {
                Matrix.PrintMatrix(Matrix.MultiplicationOfMatrix());
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid data in file");
            }
            
            Console.ReadLine();
        }
    }
}
