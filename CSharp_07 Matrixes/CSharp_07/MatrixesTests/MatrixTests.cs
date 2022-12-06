using NUnit.Framework;
using System.Collections.Generic;
using Matrixes;

namespace MatrixesTests
{
    [TestFixture]
    public class Tests
    {
        [TestCaseSource("ActualEqualsExpectedMatrixTestCase")]
        public bool TestEquals_ActualMatrixEqualsExpected(double[,] actualArray, double[,] expectedArray)
        {
            Matrix actual = new Matrix(actualArray);
            Matrix expected = new Matrix(expectedArray);
            return actual.Equals(expected);
        }
        public static IEnumerable<TestCaseData> ActualEqualsExpectedMatrixTestCase()
        {
            yield return new TestCaseData(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }, new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }).Returns(true);
            yield return new TestCaseData(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } }, new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } }).Returns(true);
            yield return new TestCaseData(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } }, new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } }).Returns(true);
            yield return new TestCaseData(new double[,] { { -1, -2 }, { -3, -4 }, { -5, -6 }, { -7, -8 } }, new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }).Returns(false);
        }

        [Test]
        public void TestCheckMatrixIfNull_BothMatrixesAreNull_Failure()
        {
            Matrix firstMatrix = null;
            Matrix secondMatrix = null;
            Assert.That(() => Matrix.CheckMatrixIfNull(firstMatrix, secondMatrix), Throws.ArgumentNullException);
        }

        [Test]
        public void TestCheckMatrixIfNull_OneMatrixIsNull_Failure()
        {
            Matrix firstMatrix = new Matrix(3, 2);
            Matrix secondMatrix = null;
            Assert.That(() => Matrix.CheckMatrixIfNull(firstMatrix, secondMatrix), Throws.ArgumentNullException);
        }

        [TestCaseSource("AddingTwoMatrixesTestCase")]
        public double[,] TestAdd_AddSecondMatrixToFirstMatrix(double[,] firstMatrixArray, double[,] secondMatrixArray)
        {
            Matrix firstMatrix = new Matrix(firstMatrixArray);
            Matrix secondMatrix = new Matrix(secondMatrixArray);
            return firstMatrix.Add(secondMatrix);
        }
        public static IEnumerable<TestCaseData> AddingTwoMatrixesTestCase()
        {
            yield return new TestCaseData(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }, new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }).Returns(new double[,] { { 2, 4 }, { 6, 8 }, { 10, 12 }, { 14, 16 } });
            yield return new TestCaseData(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } }, new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } }).Returns(new double[,] { { 2.04, 4.04 }, { 4.66, 11.92 }, { 12.2508, 11324 } });
            yield return new TestCaseData(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } }, new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } }).Returns(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } });
        }

        [TestCaseSource("AddingTwoDifferentMatrixesTestCase")]
        public void TestAdd_MatrixesAreNotEqualSized_Failure(double[,] firstMatrixArray, double[,] secondMatrixArray)
        {
            Matrix firstMatrix = new Matrix(firstMatrixArray);
            Matrix secondMatrix = new Matrix(secondMatrixArray);
            Assert.That(() => firstMatrix.Add(secondMatrix), Throws.Exception);
        }
        public static IEnumerable<TestCaseData> AddingTwoDifferentMatrixesTestCase()
        {
            yield return new TestCaseData(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }, new double[,] { { 3, 4 }, { 5, 6 }, { 7, 8 } });
            yield return new TestCaseData(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } }, new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 } });
            yield return new TestCaseData(new double[,] { { 0, 0 }, { 1, 0 } }, new double[,] { { 0, 1 }, { 0, 0 }, { 0, 1 } });
        }

        [TestCaseSource("OperatorAddingTwoMatrixesTestCase")]
        public Matrix TestOperatorPlus_AddFirstAndSecondMatrix(Matrix firstMatrix, Matrix secondMatrix)
        {
            return firstMatrix + secondMatrix;
        }
        public static IEnumerable<TestCaseData> OperatorAddingTwoMatrixesTestCase()
        {
            yield return new TestCaseData(new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }), new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } })).Returns(new Matrix(new double[,] { { 2, 4 }, { 6, 8 }, { 10, 12 }, { 14, 16 } }));
            yield return new TestCaseData(new Matrix(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } }), new Matrix(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } })).Returns(new Matrix(new double[,] { { 2.04, 4.04 }, { 4.66, 11.92 }, { 12.2508, 11324 } }));
            yield return new TestCaseData(new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } }), new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } })).Returns(new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } }));
        }

        [Test]
        public void TestOperatorPlus_OneMatrixIsNull_Failure()
        {
            Matrix firstMatrix = new Matrix(3, 2);
            Matrix secondMatrix = null;
            Assert.That(() => firstMatrix + secondMatrix, Throws.ArgumentNullException);
        }

        [TestCaseSource("OperatorMinusTwoMatrixesTestCase")]
        public Matrix TestOperatorMinus_SubstractSecondMatrixFromFirstMatrix(Matrix firstMatrix, Matrix secondMatrix) => firstMatrix - secondMatrix;
        public static IEnumerable<TestCaseData> OperatorMinusTwoMatrixesTestCase()
        {
            yield return new TestCaseData(new Matrix(new double[,] { { 10, 12 }, { 33, 41 }, { 15, 56 }, { 87, 89 } }), new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } })).Returns(new Matrix(new double[,] { { 9, 10 }, { 30, 37 }, { 10, 50 }, { 80, 81 } }));
            yield return new TestCaseData(new Matrix(new double[,] { { -10, 12 }, { -33, 41 }, { -15, 56 }, { -87, 89 } }), new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } })).Returns(new Matrix(new double[,] { { -11, 10 }, { -36, 37 }, { -20, 50 }, { -94, 81 } }));
            yield return new TestCaseData(new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } }), new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } })).Returns(new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } }));
        }

        [TestCaseSource("OperatorMinusMatrixTestCase")]
        public Matrix TestOperatorMinus_UnaryMinusMatrix(Matrix matrix) => -matrix;
        public static IEnumerable<TestCaseData> OperatorMinusMatrixTestCase()
        {
            yield return new TestCaseData(new Matrix(new double[,] { { 10, 12 }, { 33, 41 }, { 15, 56 }, { 87, 89 } })).Returns(new Matrix(new double[,] { { -10, -12 }, { -33, -41 }, { -15, -56 }, { -87, -89 } }));
            yield return new TestCaseData(new Matrix(new double[,] { { -10, 12 }, { -33, 41 }, { -15, 56 }, { -87, 89 } })).Returns(new Matrix(new double[,] { { 10, -12 }, { 33, -41 }, { 15, -56 }, { 87, -89 } }));
            yield return new TestCaseData(new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } })).Returns(new Matrix(new double[,] { { -0, -0 }, { -0, -0 }, { -0, -0 }, { -0, -0 } }));
        }

        [Test]
        public void TestOperatorMinus_OneMatrixIsNull_Failure()
        {
            Matrix firstMatrix = new Matrix(3, 2);
            Matrix secondMatrix = null;
            Assert.That(() => firstMatrix - secondMatrix, Throws.ArgumentNullException);
        }

        [TestCaseSource("OperatorMultiplyTwoMatrixesTestCase")]
        public Matrix TestOperatorMultiply_MultiplyFirstMatrixBySecondMatrix(Matrix firstMatrix, Matrix secondMatrix) => firstMatrix * secondMatrix;
        public static IEnumerable<TestCaseData> OperatorMultiplyTwoMatrixesTestCase()
        {
            yield return new TestCaseData(new Matrix(new double[,] { { 10, 11 }, { 11, 12 }, { 13, 10 }, { 10, 11 }, { 11, 12 }, { 13, 10 } }), new Matrix(new double[,] { { 1, 1 }, { 16, 1 } })).Returns(new Matrix(new double[,] { { 186, 21 }, { 203, 23 }, { 173, 23 }, { 186, 21 }, { 203, 23 }, { 173, 23 } }));
            yield return new TestCaseData(new Matrix(new double[,] { { 108, 23, 12, 2 }, { 76, 12, 20, 65 }, { 86, 13, 56, 5 } }), new Matrix(new double[,] { { 18, 16 }, { 10, 10 }, { 81, 23 }, { 23, 61 } })).Returns(new Matrix(new double[,] { { 3192, 2356 }, { 4603, 5761 }, { 6329, 3099 } }));
        }

        [TestCaseSource("MultiplyingTwoDifferentSizedMatrixesTestCase")]
        public void TestOperatorMultiply_MatrixesAreNotEqualSized_Failure(double[,] firstMatrixArray, double[,] secondMatrixArray)
        {
            Matrix firstMatrix = new Matrix(firstMatrixArray);
            Matrix secondMatrix = new Matrix(secondMatrixArray);
            Assert.That(() => firstMatrix * secondMatrix, Throws.Exception);
        }
        public static IEnumerable<TestCaseData> MultiplyingTwoDifferentSizedMatrixesTestCase()
        {
            yield return new TestCaseData(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }, new double[,] { { 3, 4 }, { 5, 6 }, { 7, 8 } });
            yield return new TestCaseData(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } }, new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 }, { 6.1254, 5662 }, { 6.1254, 5662 } });
            yield return new TestCaseData(new double[,] { { 0, 0 }, { 1, 0 } }, new double[,] { { 0, 1 }, { 0, 0 }, { 0, 1 } });
        }

        [Test]
        public void TestOperatorMultiply_MatrixesAreNull_Failure()
        {
            Matrix firstMatrix = null;
            Matrix secondMatrix = null;
            Assert.That(() => firstMatrix * secondMatrix, Throws.ArgumentNullException);
        }

        [TestCaseSource("OperatorMultiplyMatrixByNumberTestCase")]
        public Matrix TestOperatorMultiply_MultiplyMatrixByNumber(Matrix firstMatrix, double number) => firstMatrix * number;
        public static IEnumerable<TestCaseData> OperatorMultiplyMatrixByNumberTestCase()
        {
            yield return new TestCaseData(new Matrix(new double[,] { { 10, 11 }, { 11, 12 }, { 13, 10 }, { 10, 11 }, { 11, 12 }, { 13, 10 } }), 2).Returns(new Matrix(new double[,] { { 20, 22 }, { 22, 24 }, { 26, 20 }, { 20, 22 }, { 22, 24 }, { 26, 20 } }));
            yield return new TestCaseData(new Matrix(new double[,] { { 108, 23, 12, 2 }, { 76, 12, 20, 65 }, { 86, 13, 56, 5 } }), 1).Returns(new Matrix(new double[,] { { 108, 23, 12, 2 }, { 76, 12, 20, 65 }, { 86, 13, 56, 5 } }));
        }

        [Test]
        public void TestOperatorMultiply_MultiplyNullMatrixByDouble_Failure()
        {
            Matrix firstMatrix = null;
            double number = 13;
            Assert.That(() => firstMatrix * number, Throws.ArgumentNullException);
        }

        [TestCaseSource("MatrixToStringTestCase")]
        public string TestToString_MatrixToString(Matrix matrix) => matrix.ToString();
        public static IEnumerable<TestCaseData> MatrixToStringTestCase()
        {
            yield return new TestCaseData(new Matrix(new double[,] { { 23, 26 }, { 18, 26 }, { 102, 26 }, { 33, 5 }, { 11, 105 } })).Returns("Rows = 5, Columns = 2, Values = 23 | 26 | 18 | 26 | 102 | 26 | 33 | 5 | 11 | 105 | ");
            yield return new TestCaseData(new Matrix(new double[,] { { 12, 13, 6 }, { 16, 95, 20 }, { 16, 10, 75 } })).Returns("Rows = 3, Columns = 3, Values = 12 | 13 | 6 | 16 | 95 | 20 | 16 | 10 | 75 | ");
        }

        [TestCaseSource("MatrixesHashCodeTestCase")]
        public bool TestGetHashCode_HashCodeEquals(Matrix firstMatrix, Matrix secondMatrix) => firstMatrix.GetHashCode().Equals(secondMatrix.GetHashCode());
        public static IEnumerable<TestCaseData> MatrixesHashCodeTestCase()
        {
            yield return new TestCaseData(new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }), new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } })).Returns(true);
            yield return new TestCaseData(new Matrix(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } }), new Matrix(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } })).Returns(true);
            yield return new TestCaseData(new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } }), new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } })).Returns(true);
            yield return new TestCaseData(new Matrix(new double[,] { { -1, -2 }, { -3, -4 }, { -5, -6 }, { -7, -8 } }), new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } })).Returns(false);
        }

        [TestCaseSource("MatrixesToCompareTestCase")]
        public bool TestEquals_LeftMatrixEqualsRightMatrix(Matrix leftMatrix, Matrix rightMatrix) => leftMatrix == (rightMatrix);
        public static IEnumerable<TestCaseData> MatrixesToCompareTestCase()
        {
            yield return new TestCaseData(new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }), new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } })).Returns(true);
            yield return new TestCaseData(new Matrix(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } }), new Matrix(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } })).Returns(true);
            yield return new TestCaseData(new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } }), new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } })).Returns(true);
            yield return new TestCaseData(new Matrix(new double[,] { { -1, -2 }, { -3, -4 }, { -5, -6 }, { -7, -8 } }), new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } })).Returns(false);
        }

        [TestCaseSource("MatrixesInequalityTestCase")]
        public bool TestOperatorInequal_firstMatrixInequalSecondMatrix(Matrix leftMatrix, Matrix rightMatrix) => leftMatrix != rightMatrix;
        public static IEnumerable<TestCaseData> MatrixesInequalityTestCase()
        {
            yield return new TestCaseData(new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }), new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } })).Returns(false);
            yield return new TestCaseData(new Matrix(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } }), new Matrix(new double[,] { { 1.02, 2.02 }, { 2.33, 5.96 }, { 6.1254, 5662 } })).Returns(false);
            yield return new TestCaseData(new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } }), new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } })).Returns(false);
            yield return new TestCaseData(new Matrix(new double[,] { { -1, -2 }, { -3, -4 }, { -5, -6 }, { -7, -8 } }), new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } })).Returns(true);
        }

        [TestCaseSource("GetNumberOfRowsTestCase")]
        public int TestNumberOfRows_MatrixNumberOfRows(Matrix matrix) => Matrix.NumberOfRows(matrix);
        public static IEnumerable<TestCaseData> GetNumberOfRowsTestCase()
        {
            yield return new TestCaseData(new Matrix(new double[,] { { 108, 23, 12, 2 }, { 76, 12, 20, 65 }, { 86, 13, 56, 5 } })).Returns(3);
            yield return new TestCaseData(new Matrix(new double[,] { { 26, 20, 15, 16 }, { 96, 45, 32, 78 } })).Returns(2);
            yield return new TestCaseData(new Matrix(new double[,] { { 562, 78, 65, 325, 45, 5 }, { 655, 218, 654, 965, 32, 57 }, { 325, 456, 965, 23, 5, 5 }, { 665, -55, -666, -32, 65, -20 }, { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 } })).Returns(6);
        }

        [TestCaseSource("GetNumberOfColumnsTestCase")]
        public int TestNumberOfColumns_MatrixNumberOfColumns(Matrix matrix) => Matrix.NumberOfColumns(matrix);
        public static IEnumerable<TestCaseData> GetNumberOfColumnsTestCase()
        {
            yield return new TestCaseData(new Matrix(new double[,] { { 108, 23, 12, 2 }, { 76, 12, 20, 65 }, { 86, 13, 56, 5 } })).Returns(4);
            yield return new TestCaseData(new Matrix(new double[,] { { 26, 20, 15, 16 }, { 96, 45, 32, 78 } })).Returns(4);
            yield return new TestCaseData(new Matrix(new double[,] { { 562, 78, 65, 325, 45, 5 }, { 655, 218, 654, 965, 32, 57 }, { 325, 456, 965, 23, 5, 5 }, { 665, -55, -666, -32, 65, -20 }, { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 } })).Returns(6);
        }
    }
}