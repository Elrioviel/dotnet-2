using NUnit.Framework;
using System.Collections.Generic;
using Vector;

namespace VectorTests
{
    [TestFixture]
    public class Vector3DTests
    {
        [TestCaseSource("VectorValuesTestCase")]
        public void TestVector3D_Vector_Equals(double vectorX, double vectorY, double vectorZ)
        {
            var vector = new Vector3D(vectorX, vectorY, vectorZ);
            Assert.AreEqual(vector.X, vectorX);
            Assert.AreEqual(vector.Y, vectorY);
            Assert.AreEqual(vector.Z, vectorZ);
        }
        static object[] VectorValuesTestCase =
        {
            new object[] { 3, 2, 1 },
            new object[] { 3.556525, 2.02, 1.75 },
            new object[] { -3.556525, -2.02, -1.75 },
            new object[] { 2154563, 0, 30154478 }
        };

        [TestCaseSource("BothVectorsValuesTestCase")]
        public Vector3D TestOperatorPlus_LeftVectorPlusRightVector(Vector3D leftVector, Vector3D rightVector) => leftVector + rightVector;

        public static IEnumerable<TestCaseData> BothVectorsValuesTestCase()
        {
            yield return new TestCaseData(new Vector3D(3, 3, 3), new Vector3D(3, 3, 3)).Returns(new Vector3D(6, 6, 6));
            yield return new TestCaseData(new Vector3D(-123.00, 0, 0), new Vector3D(0, -5, 12)).Returns(new Vector3D(-123.00, -5, 12));
            yield return new TestCaseData(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0)).Returns(new Vector3D(0, 0, 0));
        }

        [Test]
        public void TestOperatorPlus_VectorsNull_Failure()
        {
            Vector3D leftVector = null;
            Vector3D rightVector = new Vector3D(3.025, 0, 566);
            Assert.That(() => leftVector + rightVector, Throws.ArgumentNullException);
        }

        [TestCaseSource("VectorsToSubstractTestCase")]
        public Vector3D TestOperatorMinus_LeftVectorMinusRightVector(Vector3D leftVector, Vector3D rightVector) => leftVector - rightVector;

        public static IEnumerable<TestCaseData> VectorsToSubstractTestCase()
        {
            yield return new TestCaseData(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0)).Returns(new Vector3D(0, 0, 0));
            yield return new TestCaseData(new Vector3D(23, 5, 57), new Vector3D(2, 0, 20)).Returns(new Vector3D(21, 5, 37));
            yield return new TestCaseData(new Vector3D(-15, -26, -23), new Vector3D(6, 2, 3)).Returns(new Vector3D(-21, -28, -26));
            yield return new TestCaseData(new Vector3D(10, 10, 10), new Vector3D(10, 10, 10)).Returns(new Vector3D(0, 0, 0));
        }

        [Test]
        public void TestOperatorMinus_VectorNull_Failure()
        {
            Vector3D leftVector = null;
            Vector3D rightVector = new Vector3D(3.025, 0, 566);
            Assert.That(() => leftVector - rightVector, Throws.ArgumentNullException);
        }

        [TestCaseSource("VectorsToCompareTestCase")]
        public bool TestEquals_LeftVectorEqualsRightVector(Vector3D leftVector, Vector3D rightVector) => leftVector.Equals(rightVector);

        public static IEnumerable<TestCaseData> VectorsToCompareTestCase()
        {
            yield return new TestCaseData(new Vector3D(12, 5, 35), new Vector3D(12, 4, 35)).Returns(false);
            yield return new TestCaseData(new Vector3D(10, 56, 55), new Vector3D(10, 56, 55)).Returns(true);
            yield return new TestCaseData(new Vector3D(-10, -15, -10), new Vector3D(-10, -15, -10)).Returns(true);
            yield return new TestCaseData(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0)).Returns(true);
        }

        [TestCaseSource("VectorsToGetHashCodeTestCase")]
        public bool TestGetHashCode_HashCodeEquals(Vector3D leftVector, Vector3D rightVector) => leftVector.GetHashCode() == rightVector.GetHashCode();

        public static IEnumerable<TestCaseData> VectorsToGetHashCodeTestCase()
        {
            yield return new TestCaseData(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0)).Returns(true);
            yield return new TestCaseData(new Vector3D(-9, -1, 0), new Vector3D(-9, -1, 9)).Returns(false);
            yield return new TestCaseData(new Vector3D(-9, -1, 1), new Vector3D(-9, 0, 9)).Returns(false);
            yield return new TestCaseData(new Vector3D(-9, 0, 1), new Vector3D(-9, 9, 1)).Returns(false);
            yield return new TestCaseData(new Vector3D(-1, 0, 9), new Vector3D(-1, 0, 1)).Returns(false);
            yield return new TestCaseData(new Vector3D(-1, 9, 1), new Vector3D(0, 9, 1)).Returns(false);
            yield return new TestCaseData(new Vector3D(9, 9, 9), new Vector3D(9, 9, 9)).Returns(true);
            yield return new TestCaseData(new Vector3D(-9, -9, -9), new Vector3D(-9, -9, -9)).Returns(true);
        }

        [TestCaseSource("VectorsValuesInequalityTestCase")]
        public bool TestOperatorInequal_leftVectorInequalRightVector(Vector3D leftVector, Vector3D rightVector) => leftVector != rightVector;

        public static IEnumerable<TestCaseData> VectorsValuesInequalityTestCase()
        {
            yield return new TestCaseData(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0)).Returns(false);
            yield return new TestCaseData(new Vector3D(15, 10, 15), new Vector3D(10, 15, 15)).Returns(true);
            yield return new TestCaseData(new Vector3D(-9, -1, -9), new Vector3D(-9, -1, -9)).Returns(false);
        }

        [TestCaseSource("VectorToMultiplyByNumberTestCase")]
        public Vector3D TestOperatorMultiply_VectorMultipliedByNumber(Vector3D vector, double number) => vector * number;

        public static IEnumerable<TestCaseData> VectorToMultiplyByNumberTestCase()
        {
            yield return new TestCaseData(new Vector3D(5, 10, 6), 3).Returns(new Vector3D(15, 30, 18));
            yield return new TestCaseData(new Vector3D(9, 10, 14), 0.5).Returns(new Vector3D(4.5, 5, 7));
            yield return new TestCaseData(new Vector3D(9, 1, 0), -1).Returns(new Vector3D(-9, -1, 0));
        }

        [Test]
        public void TestOperatorMultiply_VectorNull_Failure()
        {
            Vector3D vector = null;
            double number = 5;
            Assert.That(() => vector * number, Throws.ArgumentNullException);
        }

        [TestCaseSource("VectorToMultiplyByVectorTestCase")]
        public Vector3D TestOperatorMultiply_MultiplyTwoVectors(Vector3D firstVector, Vector3D secondVector) => firstVector * secondVector;

        public static IEnumerable<TestCaseData> VectorToMultiplyByVectorTestCase()
        {
            yield return new TestCaseData(new Vector3D(10, 5, 8), new Vector3D(2, 3, 2)).Returns(new Vector3D(20, 15, 16));
            yield return new TestCaseData(new Vector3D(50, 50, 50), new Vector3D(0.5, 0.5, 0.5)).Returns(new Vector3D(25, 25, 25));
            yield return new TestCaseData(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0)).Returns(new Vector3D(0, 0, 0));
        }

        [Test]
        public void TestOperatorMultiply_VectorsNull_Failure()
        {
            Vector3D firstVector = null;
            Vector3D secondVector = null;
            Assert.That(() => firstVector * secondVector, Throws.ArgumentNullException);
        }

        [TestCaseSource("VectorsToCrossTestCase")]
        public Vector3D TestCross_FirstVectorAndSecondVectorCrossed(Vector3D firstVector, Vector3D secondVector) => Vector3D.Cross(firstVector, secondVector);

        public static IEnumerable<TestCaseData> VectorsToCrossTestCase()
        {
            yield return new TestCaseData(new Vector3D(15, 26, 13), new Vector3D(11, 7, 18)).Returns(new Vector3D(377, -127, -181));
            yield return new TestCaseData(new Vector3D(0.5, 0.5, 0.5), new Vector3D(0.5, 0.5, 0.5)).Returns(new Vector3D(0, 0, 0));
        }

        [Test]
        public void TestCross_VectorsNull_Failure()
        {
            Vector3D firstVector = null;
            Vector3D secondVector = null;
            Assert.That(() => Vector3D.Cross(firstVector, secondVector), Throws.ArgumentNullException);
        }

        [TestCaseSource("VectorsToStringTestCase")]
        public string TestToString_VectorToString(Vector3D vector) => vector.ToString();
        
        public static IEnumerable<TestCaseData> VectorsToStringTestCase()
        {
            yield return new TestCaseData(new Vector3D(0, 0, 0)).Returns("<0, 0, 0>");
            yield return new TestCaseData(new Vector3D(20, -65, -6)).Returns("<20, -65, -6>");
        }
    }
}
