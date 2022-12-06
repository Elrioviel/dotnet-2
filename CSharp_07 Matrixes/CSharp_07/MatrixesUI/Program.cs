using System;
using Matrixes;

namespace MatrixesUI
{
    class Program
    {
        const string invalidInput = "Invalid input";
        public static int InputInt(string displayMessage)
        {
            int intValue;
            Console.WriteLine(displayMessage);
            while (!int.TryParse(Console.ReadLine(), out intValue))
            {
                Console.WriteLine(invalidInput);
            }
            return intValue;
        }

        public static double InputDouble(string displayMessage)
        {
            double doubleValue;
            Console.WriteLine(displayMessage);
            while (!double.TryParse(Console.ReadLine(), out doubleValue))
            {
                Console.WriteLine(invalidInput);
            }
            return doubleValue;
        }

        public static double[,] FillMatrixArray()
        {
            double[,] matrixArray = new double[InputInt("Enter the number of rows:"), InputInt("Enter the number of columns:")];
            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    matrixArray[i, j] = InputDouble($"Enter a value for row {i} column {j}");
                }
            }
            return matrixArray;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Creating first matrix:");
            Matrix matrix = new Matrix(FillMatrixArray());
            Console.WriteLine("Creating second matrix");
            Matrix anotherMatrix = new Matrix(FillMatrixArray());
            try
            {
                Console.WriteLine($"Result of addition: {(matrix + anotherMatrix).ToString()}");
                Console.WriteLine($"Result of substraction: {(matrix - anotherMatrix).ToString()}");
            }
            catch (MatrixException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Console.WriteLine($"Result of multiplication: {(matrix * anotherMatrix).ToString()}");
            }
            catch (MatrixException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"First matrix multiplied by 15: {(matrix * 15).ToString()}");
            Console.WriteLine($"Second matrix multiplied by -29: {(anotherMatrix * -29)}");
            Console.WriteLine($"First matrix' hash code: {matrix.GetHashCode()}");
            Console.WriteLine($"Second matrix' hash code: {anotherMatrix.GetHashCode()}");
            Console.WriteLine($"Comparing both matrixes: Equals = {matrix == anotherMatrix} Inequal = {matrix != anotherMatrix}");
        }
    }
}
