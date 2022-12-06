using System;
using System.Text;

namespace Matrixes
{
    public class Matrix
    {
        private double[,] _matrixArray;

        public Matrix(int matrixNumberOfRows, int matrixNumberOfColumns)
        {
            if (matrixNumberOfRows < 1 || matrixNumberOfColumns < 1)
            {
                throw new MatrixException($"Cannot create matrix, number of rows and columns must be greater than 1. Current number of rows = {matrixNumberOfRows}, columns = {matrixNumberOfColumns}");
            }
            _matrixArray = new double[matrixNumberOfRows, matrixNumberOfColumns];
        }

        public Matrix(double[,] matrixArray)
        {
            if (matrixArray is null)
            {
                throw new MatrixException($"Cannot create matrix, number of rows and columns must be greater than 1. Current number of rows = {matrixArray.GetLength(0)}, columns = {matrixArray.GetLength(1)}");
            }
            _matrixArray = (double[,])matrixArray.Clone();
        }

        public double this[int matrixNumberOfRows, int matrixNumberOfColumns]
        {
            get
            {
                return _matrixArray[matrixNumberOfRows, matrixNumberOfColumns];
            }
            set
            {
                _matrixArray[matrixNumberOfRows, matrixNumberOfColumns] = value;
            }
        }

        public static void CheckMatrixIfNull(Matrix leftMatrix, Matrix rightMatrix)
        {
            if (leftMatrix is null)
            {
                throw new ArgumentNullException(nameof(leftMatrix));
            }
            if (rightMatrix is null)
            {
                throw new ArgumentNullException(nameof(rightMatrix));
            }
        }

        public static Matrix operator -(Matrix matrix)
        {
            for (int i = 0; i < NumberOfRows(matrix); i++)
            {
                for (int j = 0; j < NumberOfColumns(matrix); j++)
                {
                    matrix._matrixArray[i, j] = -matrix._matrixArray[i, j];
                }
            }
            return new Matrix(matrix._matrixArray);
        }

        public double[,] Add(Matrix other)
        {
            if (_matrixArray.GetLength(0) != NumberOfRows(other))
            {
                throw new MatrixException($"Cannot perform addition/substraction. The number of rows of the first matrix must be equal to the number of rows and columns in the second matrix. First matrix's rows = {_matrixArray.GetLength(0)} , second matrix's rows = {NumberOfRows(other)}");
            }
            if (_matrixArray.GetLength(1) != NumberOfColumns(other))
            {
                throw new MatrixException($"Cannot perform addition/substraction. The number of columns of the first matrix must be equal to the number of columns and columns in the second matrix. First matrix's columns = {_matrixArray.GetLength(1)} , second matrix's columns = {NumberOfColumns(other)}");
            }
            for (int i = 0; i < _matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < _matrixArray.GetLength(1); j++)
                {
                    _matrixArray[i, j] += other._matrixArray[i, j];
                }
            }
            return _matrixArray;
        }

        public static Matrix operator +(Matrix leftMatrix, Matrix rightMatrix)
        {
            CheckMatrixIfNull(leftMatrix, rightMatrix);
            return new Matrix(leftMatrix.Add(rightMatrix));
        }

        public static Matrix operator -(Matrix leftMatrix, Matrix rightMatrix)
        {
            CheckMatrixIfNull(leftMatrix, rightMatrix);
            return leftMatrix + (-rightMatrix);
        }

        public static Matrix operator *(Matrix leftMatrix, Matrix rightMatrix)
        {
            CheckMatrixIfNull(leftMatrix, rightMatrix);
            if (NumberOfColumns(leftMatrix) != NumberOfRows(rightMatrix))
            {
                throw new MatrixException($"Matrixes can not be multiplied. The number of columns in the first matrix must be equal to the number of rows in the second matrix. The number of columns of the first matrix = {NumberOfColumns(leftMatrix)}, the number of rows of the second matrix = {NumberOfRows(rightMatrix)}");
            }
            double[,] resultMatrixArray = new double[NumberOfRows(leftMatrix), NumberOfColumns(rightMatrix)];
            for (int i = 0; i < NumberOfRows(leftMatrix); i++)
            {
                for (int j = 0; j < NumberOfColumns(rightMatrix); j++)
                {
                    for (int k = 0; k < NumberOfColumns(leftMatrix); k++)
                    {
                        resultMatrixArray[i, j] += leftMatrix[i, k] * rightMatrix[k, j];
                    }
                }
            }
            return new Matrix(resultMatrixArray);
        }

        public static Matrix operator *(Matrix matrix, double number)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
            double[,] resultMatrixArray = new double[NumberOfRows(matrix), NumberOfColumns(matrix)];
            for (int i = 0; i < NumberOfRows(matrix); i++)
            {
                for (int j = 0; j < NumberOfColumns(matrix); j++)
                {
                    resultMatrixArray[i, j] = matrix[i, j] * number;
                }
            }
            return new Matrix(resultMatrixArray);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Rows = " + _matrixArray.GetLength(0).ToString() + ", Columns = " + _matrixArray.GetLength(1).ToString() + ", Values = ");
            for (int i = 0; i < _matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < _matrixArray.GetLength(1); j++)
                {
                    sb.AppendFormat("{0:G17}", _matrixArray[i, j] + " ");
                    sb.Append("| ");
                }
            }
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 17;
            for (int i = 0; i < _matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < _matrixArray.GetLength(1); j++)
                {
                    hash = (int)(hash * 31 + _matrixArray[i, j]);
                }
            }
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            Matrix other = (Matrix)obj;
            if (_matrixArray.GetLength(1) != NumberOfColumns(other) && _matrixArray.GetLength(0) != NumberOfRows(other))
            {
                return false;
            }
            for (int i = 0; i < _matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < _matrixArray.GetLength(1); j++)
                {
                    if (_matrixArray[i, j] != other._matrixArray[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator ==(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (ReferenceEquals(firstMatrix, secondMatrix))
            {
                return true;
            }
            if (ReferenceEquals(firstMatrix, null))
            {
                return false;
            }
            return firstMatrix.Equals(secondMatrix);
        }

        public static bool operator !=(Matrix firstMatrix, Matrix secondMatrix) => !(firstMatrix == secondMatrix);

        public static int NumberOfRows(Matrix matrix) => matrix._matrixArray.GetLength(0);

        public static int NumberOfColumns(Matrix matrix) => matrix._matrixArray.GetLength(1);
    }
}
