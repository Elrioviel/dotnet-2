using System;

namespace Matrixes
{
    public class MatrixException : ArgumentException
    {
        public MatrixException(string message) : base(message)
        {
        }
    }
}
