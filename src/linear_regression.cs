using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

class LinearRegression
{
        public static Vector<double> calculate(Vector<double> xRaw, Vector<double> y, int degree = 1)
        {
                Matrix<double> x = generateX(xRaw, degree);
                Vector<double> beta = getBeta(x, y);
                return beta;
        }

        private static Matrix<double> generateX(Vector<double> xRaw, int degree)
        {
                double[,] x = new double[xRaw.Count, degree + 1];
                //double[,] x = new double[xRaw.Count, degree];
                for(int i = 0; i < xRaw.Count; i++)
                {
                        double xBase = xRaw[i];
                        for(int j = 0; j <= degree; j++)
                        //for(int j = 0; j < degree; j++)
                        {
                                x[i, j] = Math.Pow(xBase, j);
                                //x[i, j] = Math.Pow(xBase, j + 1);
                        }
                }
                return Matrix<double>.Build.DenseOfArray(x);
        }

        private static Vector<double> getBeta(Matrix<double> x, Vector<double> y)
        {
                var beta = (x.Transpose() * x).Inverse() * (x.Transpose() * y);
                return beta;
        }
}
