using System;

namespace NthRoot
{
    public class NthRootCalculator
    {
        private double number;
        private int rootDegree;
        private double accuracy;
        public NthRootCalculator(double number, int rootDegree, double accuracy)
        {
            this.number = number;
            this.rootDegree = rootDegree;
            this.accuracy = accuracy;
        }
        private double UpdatePrediction(double predictionToUpdate, double number, double rootDegree)
        {
            return (1.0 / rootDegree) * ((rootDegree - 1) * predictionToUpdate + number / (Math.Pow(predictionToUpdate, rootDegree - 1)));
        }
        private bool IsPrecisionMatched(double prediction, double number, double rootDegree, double accuracy)
        {
            return Math.Abs(number - Math.Pow(prediction, rootDegree)) <= accuracy;
        }
        public double CalculateNewtonNthRoot(NthRootCalculator nthRoot)
        {
            double prediction = 1;
            while (!IsPrecisionMatched(prediction, nthRoot.number, nthRoot.rootDegree, nthRoot.accuracy))
            {
                prediction = UpdatePrediction(prediction, nthRoot.number, nthRoot.rootDegree);
            }
            return prediction;
        }
        public double CalculateNthRoot(NthRootCalculator nthRoot)
        {
            return Math.Pow(nthRoot.number, 1.0 / nthRoot.rootDegree);
        }
    }
}
