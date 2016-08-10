using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

class Program
{
        static void Main(string[] args)
        {
                if(args.Length < 1)
                {
                        Console.WriteLine("usage: linear_regression.exe <data> [<degree>]");
                        System.Environment.Exit(-1);
                }
                string path = args[0];
                //string path = "./data.csv";
                int degree = 1;
                if(args.Length > 1)
                {
                        degree = Int32.Parse(args[1]);
                }

                double[][] fileContent = CSVReader.read(path);
                Vector<double> x = Vector<double>.Build.Dense(fileContent[0]);
                Vector<double> y = Vector<double>.Build.Dense(fileContent[1]);
                Vector<double> beta = LinearRegression.calculate(x, y, degree);
                Console.WriteLine(beta);
                /*
                Matrix<double> matrix = DelimitedReader.Read<double>(path, false, ",");
                Console.WriteLine(matrix);
                */
        }
}
