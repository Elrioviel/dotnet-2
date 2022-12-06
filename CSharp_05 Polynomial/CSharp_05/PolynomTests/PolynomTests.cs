using NUnit.Framework;
using System.Collections.Generic;
using Polynomial;

namespace PolynomTests
{
    [TestFixture]
    public class PolynomTests
    {
        [TestCaseSource("ActualAndExpectedPolynomialsTestCase")]
        public bool TestPolynom_Polynom_Equals(Polynom actual, Polynom expected)
        {
            return actual.Equals(expected);
        }
        public static IEnumerable<TestCaseData> ActualAndExpectedPolynomialsTestCase()
        {
            yield return new TestCaseData(new Polynom(5, 2, 9), new Polynom(5, 2, 9)).Returns(true);
            yield return new TestCaseData(new Polynom(-5, -2, -9), new Polynom(-5, -2, -9)).Returns(true);
            yield return new TestCaseData(new Polynom(0, 0, 0, 0), new Polynom(0, 0, 0, 0)).Returns(true);
        }

        [TestCaseSource("PolynomialDegreeTestCase")]
        public int TestPolynom_PolynomialDegree(Polynom polynomial)
        {
            return polynomial.Degree;
        }
        public static IEnumerable<TestCaseData> PolynomialDegreeTestCase()
        {
            yield return new TestCaseData(new Polynom(0, 5, 6, 0, 8)).Returns(4);
            yield return new TestCaseData(new Polynom(0, 0, 0)).Returns(0);
            yield return new TestCaseData(new Polynom(-6, -8, -9)).Returns(2);
            yield return new TestCaseData(new Polynom(0, 0, 0, 0)).Returns(0);
        }

        [TestCaseSource("PolynomialsHashCodeTestCase")]
        public bool TestGetHashCode_HashCodeEquals(Polynom firstPolynomial, Polynom secondPolynomial) => firstPolynomial.GetHashCode().Equals(secondPolynomial.GetHashCode());
        public static IEnumerable<TestCaseData> PolynomialsHashCodeTestCase()
        {
            yield return new TestCaseData(new Polynom(-9, -1, 0), new Polynom(-9, -1, 9)).Returns(false);
            yield return new TestCaseData(new Polynom(-9, -1, 1), new Polynom(-9, 0, 9)).Returns(false);
            yield return new TestCaseData(new Polynom(-9, 0, 1), new Polynom(-9, 9, 1)).Returns(false);
            yield return new TestCaseData(new Polynom(-1, 0, 9), new Polynom(-1, 0, 1)).Returns(false);
            yield return new TestCaseData(new Polynom(-1, 9, 1), new Polynom(0, 9, 1)).Returns(false);
        }

        [TestCaseSource("PolynomialsStringTestCase")]
        public string TestGetString_PolynomialGetString(Polynom polynomial) => polynomial.ToString();
        public static IEnumerable<TestCaseData> PolynomialsStringTestCase()
        {
            yield return new TestCaseData(new Polynom(1, 0, 4, 10)).Returns("1 + 0x + 4x^2 + 10x^3");
            yield return new TestCaseData(new Polynom(5, -3, 6)).Returns("5 + -3x + 6x^2");
            yield return new TestCaseData(new Polynom(-10, -6, -78, -5, -1)).Returns("-10 + -6x + -78x^2 + -5x^3 + -1x^4");
            yield return new TestCaseData(new Polynom(0, 0, 0, 0)).Returns("0 + 0x + 0x^2 + 0x^3");
        }

        [TestCaseSource("PolynomialsToCompareTestCase")]
        public bool TestEquals_LeftPolynomialrEqualsRightPolynomial(Polynom firstPolynomial, Polynom secondPolynomial) => firstPolynomial == (secondPolynomial);
        public static IEnumerable<TestCaseData> PolynomialsToCompareTestCase()
        {
            yield return new TestCaseData(new Polynom(12, 5, 35), new Polynom(12, 4, 35)).Returns(false);
            yield return new TestCaseData(new Polynom(10, 56, 55), new Polynom(10, 56, 55)).Returns(true);
            yield return new TestCaseData(new Polynom(-10, -15, -10), new Polynom(-10, -15, -10)).Returns(true);
            yield return new TestCaseData(new Polynom(0, 0, 0), new Polynom(0, 0, 0, 0)).Returns(true);
        }

        [TestCaseSource("PolynomialsInequalityTestCase")]
        public bool TestOperatorInequal_firstPolynomialInequalSecondPolynomial(Polynom firstPolynomial, Polynom secondPolynomial) => firstPolynomial != secondPolynomial;
        public static IEnumerable<TestCaseData> PolynomialsInequalityTestCase()
        {
            yield return new TestCaseData(new Polynom(0, 0, 0), new Polynom(0, 0, 0, 0)).Returns(false);
            yield return new TestCaseData(new Polynom(15, 10, 15), new Polynom(10, 15, 15)).Returns(true);
            yield return new TestCaseData(new Polynom(-9, -1, -9), new Polynom(-9, -1, -9)).Returns(false);
        }

        [TestCaseSource("PolynomialNormalizingTestCase")]
        public string TestNormalizePolynomial_PolynomialNormalized(Polynom polynomial) => Polynom.NormalizePolynomial(polynomial);
        public static IEnumerable<TestCaseData> PolynomialNormalizingTestCase()
        {
            yield return new TestCaseData(new Polynom(0, 0, 3, 0, 0, 7, 0)).Returns("3x^2 + 7x^5");
            yield return new TestCaseData(new Polynom(0)).Returns("0");
            yield return new TestCaseData(new Polynom(-0)).Returns("0");
            yield return new TestCaseData(new Polynom(-0, 0)).Returns("0");
            yield return new TestCaseData(new Polynom(0, 1)).Returns("1x");
            yield return new TestCaseData(new Polynom(0, -1)).Returns("-1x");
            yield return new TestCaseData(new Polynom(-1, -1)).Returns("-1 + -1x");
            yield return new TestCaseData(new Polynom(0, 31, 21)).Returns("31x + 21x^2");
            yield return new TestCaseData(new Polynom(-0, 1, 0)).Returns("1x");
            yield return new TestCaseData(new Polynom(0, -0, -0)).Returns("0");
            yield return new TestCaseData(new Polynom(0, -0, -0, -10)).Returns("-10x^3");
            yield return new TestCaseData(new Polynom(-15, 0, -0, -0)).Returns("-15");
            yield return new TestCaseData(new Polynom(-10, 0, -0, -13)).Returns("-10 + -13x^3");
            yield return new TestCaseData(new Polynom(10, 11, 12, 13, 14, 15)).Returns("10 + 11x + 12x^2 + 13x^3 + 14x^4 + 15x^5");
            yield return new TestCaseData(new Polynom(-10, -11, -12, -13, -14, -15)).Returns("-10 + -11x + -12x^2 + -13x^3 + -14x^4 + -15x^5");
        }

        [Test]
        public void TestOperatorPlus_PolynomialNull_Failure()
        {
            Polynom leftPolynomial = null;
            Polynom rightPolynomial = new Polynom(10, 0, 15, 3, 6);
            Assert.That(() => leftPolynomial + rightPolynomial, Throws.ArgumentNullException);
        }

        [Test]
        public void TestOperatorMinus_PolynomialNull_Failure()
        {
            Polynom leftPolynomial = null;
            Polynom rightPolynomial = new Polynom(10, 0, 15, 3, 6);
            Assert.That(() => rightPolynomial + leftPolynomial, Throws.ArgumentNullException);
        }

        [Test]
        public void TestOperatorMultiply_PolynomialsBothNull_Failure()
        {
            Polynom leftPolynomial = null;
            Polynom rightPolynomial = null;
            Assert.That(() => leftPolynomial * rightPolynomial, Throws.ArgumentNullException);
        }

        [Test]
        public void TestOperatorMultiply_PolynomialNull_Failure()
        {
            Polynom leftPolynomial = null;
            int number = 15;
            Assert.That(() => leftPolynomial * number, Throws.ArgumentNullException);
        }

        [Test]
        public void TestOperatorNormalizePolynomial_PolynomialNull_Failure()
        {
            Polynom polynomial = null;
            Assert.That(() => Polynom.NormalizePolynomial(polynomial), Throws.ArgumentNullException);
        }
    }
}
