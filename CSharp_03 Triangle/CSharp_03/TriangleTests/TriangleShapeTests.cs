using NUnit.Framework;
using System;
using Triangle;

namespace TriangleTests
{
    [TestFixture]
    public class TriangleShapeTests
    {
        [Test]
        public void TestTriangleShape_AFiveBFiveCFive_Success()
        {
            var triangle = TriangleShape.Create(5, 5, 5);

            Assert.AreEqual(5, triangle.A);
            Assert.AreEqual(5, triangle.B);
            Assert.AreEqual(5, triangle.C);
        }

        [Test]
        public void TestCheckSidesValues_AZeroBZeroCZero_Failure()
        {
            double a = 0;
            double b = 0;
            double c = 0;

            bool triangleIsLegit = TriangleShape.CheckSidesValues(a, b, c);

            Assert.IsFalse(triangleIsLegit);
        }

        [Test]
        public void TestCalculateTriangleArea_AFiveBFiveCFive_Success()
        {
            var triangle = TriangleShape.Create(5, 5, 5);

            double expected = 10.825317547305483;
            double actual = triangle.CalculateTriangleArea(triangle);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateTrianglePerimeter_AFiveBFiveCFive_Success()
        {
            var triangle = TriangleShape.Create(5, 5, 5);

            double expected = 15;
            double actual = triangle.CalculateTrianglePerimeter(triangle);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCreate_AOneBOneCTen_Failure()
        {
            Assert.Throws<ArgumentException>(() => TriangleShape.Create(1, 1, 10));
        }
    }
}
