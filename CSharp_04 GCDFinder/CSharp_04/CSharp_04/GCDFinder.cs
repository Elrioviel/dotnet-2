using System.Diagnostics;

namespace GCD
{
    public class GCDFinder
    {
        public static int CalculateEuclideanGCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }
            return a == 0 ? b : a;
        }

        public static int CalculateEuclideanGCDMaster(params int[] InputNumbers)
        {
            if (InputNumbers == null || InputNumbers.Length == 0)
            {
                return 0;
            }
            var result = InputNumbers[0];
            for (int i = 1; i < InputNumbers.Length; i++)
            {
                result = CalculateEuclideanGCD(result, InputNumbers[i]);
            }
            return result;
        }

        public static int CalculateEuclideanGCD(out long timeSpent, params int[] InputNumbers)
        {
            var watch = Stopwatch.StartNew();
            var result = CalculateEuclideanGCDMaster(InputNumbers);
            watch.Stop();
            timeSpent = watch.ElapsedMilliseconds;
            return result;
        }

        public static int CalculateEuclideanGCD(int a, int b, int c)
        {
            return CalculateEuclideanGCDMaster(a, b, c);
        }

        public static int CalculateEuclideanGCD(int a, int b, int c, int d)
        {
            return CalculateEuclideanGCDMaster(a, b, c, d);
        }

        public static int CalculateEuclideanGCD(int a, int b, int c, int d, int e)
        {
            return CalculateEuclideanGCDMaster(a, b, c, d, e);
        }

        public static int CalculateBinaryEuclideanGCD(int a, int b)
        {
            int k = 1;
            while ((a != 0) && (b != 0))
            {
                while ((a % 2 == 0) && (b % 2 == 0))
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }
                while (a % 2 == 0) a /= 2;
                while (b % 2 == 0) b /= 2;
                if (a >= b) a -= b; else b -= a;
            }
            return b * k;
        }

        public static int CalculateBinaryEuclideanGCDMaster(params int[] InputNumbers)
        {
            if (InputNumbers == null || InputNumbers.Length == 0)
            {
                return 0;
            }
            var result = InputNumbers[0];
            for (int i = 1; i < InputNumbers.Length; i++)
            {
                result = CalculateBinaryEuclideanGCD(result, InputNumbers[i]);
            }
            return result;
        }

        public static int CalculateBinaryEuclideanGCD(out long timeSpent, params int[] InputNumbers)
        {
            var watch = Stopwatch.StartNew();
            var result = CalculateBinaryEuclideanGCDMaster(InputNumbers);
            watch.Stop();
            timeSpent = watch.ElapsedMilliseconds;
            return result;
        }

        public static int CalculateBinaryEuclideanGCD(int a, int b, int c)
        {
            return CalculateBinaryEuclideanGCDMaster(a, b, c);
        }

        public static int CalculateBinaryEuclideanGCD(int a, int b, int c, int d)
        {
            return CalculateBinaryEuclideanGCDMaster(a, b, c, d);
        }

        public static int CalculateBinaryEuclideanGCD(int a, int b, int c, int d, int e)
        {
            return CalculateBinaryEuclideanGCDMaster(a, b, c, d, e);
        }
    }
}
