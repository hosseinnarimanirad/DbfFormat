// besmellahe rahmane rahim
// Allahomma ajjel le-valiyek al-faraj

using System;
//using IRI.Ham.Algebra;
using System.Text;
using System.Collections.Generic;

namespace IRI.Ket.IO
{
    public class TextStream
    {
        //Exceptions has not been handeled
        //Has not been tested
        //public static double[,] ReadValues(string path, char seprator)
        //{
        //    System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //    List<List<double>> values = new List<List<double>>();

        //    int counter = 0;

        //    while (!reader.EndOfStream)
        //    {
        //        values.Add(new List<double>());

        //        string[] temp = reader.ReadLine().Split(new Char[] { seprator }, StringSplitOptions.RemoveEmptyEntries);

        //        for (int i = 0; i < temp.Length - 1; i++)
        //        {
        //            values[counter].Add(double.Parse(temp[i]));
        //        }

        //        counter++;
        //    }

        //    reader.Close();

        //    int numberOfColumns = values[0].Count;

        //    int numberOfRows = values.Count;

        //    double[,] result = new double[numberOfRows, numberOfColumns];

        //    for (int i = 0; i < numberOfRows; i++)
        //    {
        //        for (int j = 0; j < numberOfColumns; j++)
        //        {
        //            result[i, j] = values[i][j];
        //        }
        //    }

        //    return result;
        //}

        public static double[][] ReadValues(string path, char seprator)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(path);

            List<List<double>> values = new List<List<double>>();

            int counter = 0;

            while (!reader.EndOfStream)
            {
                values.Add(new List<double>());

                string[] temp = reader.ReadLine().Split(new Char[] { seprator }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < temp.Length; i++)
                {
                    values[counter].Add(double.Parse(temp[i]));
                }

                counter++;
            }

            reader.Close();

            int numberOfColumns = values[0].Count;

            int numberOfRows = values.Count;

            double[][] result = new double[numberOfColumns][];

            for (int i = 0; i < numberOfColumns; i++)
            {
                result[i] = new double[numberOfRows];

                for (int j = 0; j < numberOfRows; j++)
                {
                    result[i][j] = values[j][i];
                }
            }

            return result;
        }

        public static void WriteValues(double[,] values, string path, char seprator)
        {
            throw new NotImplementedException();
        }
    }
}
