using NUnit.Framework;
using GCD;

namespace GCDFTests
{
    [TestFixture]
    public class GCDFinderTests
    {
        [Test]
        public void TestCalculateEuclideanGCD_ATenBTen_Success()
        {
            int a = 10;
            int b = 10;

            int expected = 10;
            int actual = GCDFinder.CalculateEuclideanGCD(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateBinaryEuclideanGCD_ATenBTen_Success()
        {
            int a = 10;
            int b = 10;

            int expected = 10;
            int actual = GCDFinder.CalculateBinaryEuclideanGCD(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateEuclideanGCD_AFifteenBThirty_Success()
        {
            int a = 15;
            int b = 30;

            int expected = 15;
            int actual = GCDFinder.CalculateEuclideanGCD(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateBinaryEuclideanGCD_AFifteenBThirty_Success()
        {
            int a = 15;
            int b = 30;

            int expected = 15;
            int actual = GCDFinder.CalculateBinaryEuclideanGCD(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateEuclideanGCD_AEightyBThirtyFive_Success()
        {
            int a = 80;
            int b = 35;

            int expected = 5;
            int actual = GCDFinder.CalculateEuclideanGCD(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateBinaryEuclideanGCD_AEightyBThirtyFive_Success()
        {
            int a = 80;
            int b = 35;

            int expected = 5;
            int actual = GCDFinder.CalculateBinaryEuclideanGCD(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateEuclideanGCD_AZeroBZero_Success()
        {
            int a = 0;
            int b = 0;

            int expected = 0;
            int actual = GCDFinder.CalculateEuclideanGCD(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateBinaryEuclideanGCD_AZeroBZero_Success()
        {
            int a = 0;
            int b = 0;

            int expected = 0;
            int actual = GCDFinder.CalculateBinaryEuclideanGCD(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateEuclideanGCD_AThreeBFiveCSeven_Success()
        {
            int a = 3;
            int b = 5;
            int c = 7;

            int expected = 1;
            int actual = GCDFinder.CalculateEuclideanGCD(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateBinaryEuclideanGCD_AThreeBFiveCSeven_Success()
        {
            int a = 3;
            int b = 5;
            int c = 7;

            int expected = 1;
            int actual = GCDFinder.CalculateBinaryEuclideanGCD(a, b, c);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestCalculateEuclideanGCD_ATenBTwelveCTwentyTwo_Success()
        {
            int a = 10;
            int b = 12;
            int c = 22;

            int expected = 2;
            int actual = GCDFinder.CalculateEuclideanGCD(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateBinaryEuclideanGCD_ATenBTwelveCTwentyTwo_Success()
        {
            int a = 10;
            int b = 12;
            int c = 22;

            int expected = 2;
            int actual = GCDFinder.CalculateBinaryEuclideanGCD(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateEuclideanGCD_ATwoBThreeCFourDFiveESix_Success()
        {
            int a = 2;
            int b = 3;
            int c = 4;
            int d = 5;
            int e = 6;

            int expected = 1;
            int actual = GCDFinder.CalculateEuclideanGCD(a, b, c, d, e);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateBinaryEuclideanGCD_ATwoBThreeCFourDFiveESix_Success()
        {
            int a = 2;
            int b = 3;
            int c = 4;
            int d = 5;
            int e = 6;

            int expected = 1;
            int actual = GCDFinder.CalculateBinaryEuclideanGCD(a, b, c, d, e);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateEuclideanGCD_AFifteenBThirtyCFourtyFiveDFifty_Success()
        {
            int a = 15;
            int b = 30;
            int c = 45;
            int d = 50;

            int expected = 5;
            int actual = GCDFinder.CalculateEuclideanGCD(a, b, c, d);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateBinaryEuclideanGCD_AFifteenBThirtyCFourtyFiveDFifty_Success()
        {
            int a = 15;
            int b = 30;
            int c = 45;
            int d = 50;

            int expected = 5;
            int actual = GCDFinder.CalculateBinaryEuclideanGCD(a, b, c, d);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateEuclideanGCDMaster_FifteenNumbers_Success()
        {
            int[] numbersArray = new int[15] { 125, 860, 994, 526, 654, 579, 542, 964, 1254, 254, 687, 168, 712, 364, 845 };

            int expected = 1;
            int actual = GCDFinder.CalculateEuclideanGCDMaster(numbersArray);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateBinaryEuclideanGCDMaster_FifteenNumbers_Success()
        {
            int[] numbersArray = new int[15] { 125, 860, 994, 526, 654, 579, 542, 964, 1254, 254, 687, 168, 712, 364, 845 };

            int expected = 1;
            int actual = GCDFinder.CalculateBinaryEuclideanGCDMaster(numbersArray);

            Assert.AreEqual(expected, actual);
        }
    }
}
