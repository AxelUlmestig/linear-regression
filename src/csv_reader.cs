using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

static class CSVReader
{
        public static double[][] read(string path)
        {
                var reader = new StreamReader(File.OpenRead(path));
                List<double> columnX = new List<double>();
                List<double> columnY = new List<double>();
                while (!reader.EndOfStream)
                {
                        var line = reader.ReadLine();
                        var valueStrings = line.Split(',');
                        var values = valueStrings.Select(Convert.ToDouble).ToArray(); 

                        columnX.Add(values[0]);
                        columnY.Add(values[1]);
                }
                List<double[]> fileContentList = new List<double[]>();
                fileContentList.Add(columnX.ToArray());
                fileContentList.Add(columnY.ToArray());
                double[][] fileContent = fileContentList.ToArray();
                return fileContent;
        }

        public static double[,] read2D(string path)
        {
                double[][] jagged = read(path);
                double[,] output = new double[jagged.Length, jagged.Max(x => x.Length)];
                for(int i = 0; i < jagged.Length; i++)
                {
                        for(int j = 0; j < jagged[i].Length; j++)
                        {
                                output[i, j] = jagged[i][j];
                        }
                }
                return output;
        }
}
