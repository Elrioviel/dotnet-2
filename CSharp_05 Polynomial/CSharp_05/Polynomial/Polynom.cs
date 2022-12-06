using System;
using System.Linq;
using System.Text;

namespace Polynomial
{
    public class Polynom
    {
        private readonly int[] _coefficients;
        public int Degree
        {
            get
            {
                for (int i = _coefficients.Length - 1; i >= 0; i--)
                {
                    if (_coefficients[i] != 0)
                    {
                        return i;
                    }
                }
                return 0;
            }
        }

        public Polynom(params int[] coefficients)
        {
            if (coefficients is null)
            {
                throw new ArgumentNullException(nameof(coefficients));
            }
            _coefficients = new int[coefficients.Length];
            coefficients.CopyTo(_coefficients, 0);
        }

        public Polynom(Polynom polynom)
        {
            if (polynom is null)
            {
                throw new ArgumentNullException(nameof(polynom));
            }
            _coefficients = new int[polynom.Length];
            for (int i = 0; i < polynom.Length; i++)
            {
                _coefficients[i] = polynom[i];
            }
        }

        public int this[int n]
        {
            get
            {
                return _coefficients[n];
            }
        }

        internal int Length
        {
            get
            {
                return _coefficients.Length;
            }
        }

        public override int GetHashCode() => _coefficients.GetHashCode();

        public static Polynom operator -(Polynom polynom)
        {
            for (int i = 0; i < polynom.Length; i++)
            {
                polynom._coefficients[i] = -polynom._coefficients[i];
            }
            return polynom;
        }

        public static int[] Add(Polynom firstPolynomial, Polynom secondPolynomial)
        {
            int itemsCount = Math.Max(firstPolynomial._coefficients.Length, secondPolynomial._coefficients.Length);
            int[] resultCoefficients = new int[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                int a = 0;
                int b = 0;
                if (i < firstPolynomial._coefficients.Length)
                {
                    a = firstPolynomial[i];
                }
                if (i < secondPolynomial._coefficients.Length)
                {
                    b = secondPolynomial[i];
                }
                resultCoefficients[i] = a + b;
            }
            return resultCoefficients;
        }

        public static Polynom operator +(Polynom firstPolynomial, Polynom secondPolynomial)
        {
            if (firstPolynomial is null)
            {
                throw new ArgumentNullException(nameof(firstPolynomial));
            }
            if (secondPolynomial is null)
            {
                throw new ArgumentNullException(nameof(secondPolynomial));
            }
            return new Polynom(Add(firstPolynomial, secondPolynomial));
        }

        public static Polynom operator -(Polynom firstPolynomial, Polynom secondPolynomial)
        {
            if (firstPolynomial is null)
            {
                throw new ArgumentNullException(nameof(firstPolynomial));
            }
            if (secondPolynomial is null)
            {
                throw new ArgumentNullException(nameof(secondPolynomial));
            }
            return firstPolynomial + (-secondPolynomial);
        }

        public static Polynom operator *(Polynom firstPolynomial, Polynom secondPolynomial)
        {
            if (firstPolynomial is null)
            {
                throw new ArgumentNullException(nameof(firstPolynomial));
            }
            if (secondPolynomial is null)
            {
                throw new ArgumentNullException(nameof(secondPolynomial));
            }
            int[] resultCoefficients = new int[firstPolynomial._coefficients.Length + secondPolynomial._coefficients.Length - 1];
            for (int i = 0; i < firstPolynomial._coefficients.Length; i++)
            {
                for (int j = 0; j < secondPolynomial._coefficients.Length; j++)
                {
                    resultCoefficients[i + j] += firstPolynomial._coefficients[i] * secondPolynomial._coefficients[j];
                }
            }
            return new Polynom(resultCoefficients);
        }

        public static Polynom operator *(Polynom polynomial, int number)
        {
            if (polynomial is null)
            {
                throw new ArgumentNullException(nameof(polynomial));
            }
            int[] resultCoefficients = new int[polynomial._coefficients.Length];
            for (int i = 0; i < polynomial._coefficients.Length; i++)
            {
                resultCoefficients[i] = polynomial._coefficients[i] * number;
            }
            return new Polynom(resultCoefficients);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            Polynom other = (Polynom)obj;
            if (Degree != other.Degree)
            {
                return false;
            }
            for (int i = 0; i <= Degree; i++)
            {
                if (other[i] != this[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator ==(Polynom firstPolynomial, Polynom secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, secondPolynomial))
            {
                return true;
            }
            if (ReferenceEquals(firstPolynomial, null))
            {
                return false;
            }
            return firstPolynomial.Equals(secondPolynomial);
        }

        public static bool operator !=(Polynom firstPolynomial, Polynom secondPolynomial)
        {
            return !(firstPolynomial == secondPolynomial);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < _coefficients.Length; i++)
            {
                sb.Append(_coefficients[i]);
                switch (i)
                {
                    case 0:
                        sb.Append(" + ");
                        break;
                    case 1:
                        sb.Append("x + ");
                        break;
                    default:
                        sb.Append("x^" + i + ((i == _coefficients.Length - 1) ? "" : " + "));
                        break;
                }
            }
            return sb.ToString();
        }

        public static string NormalizePolynomial(Polynom polynomial)
        {
            if (polynomial is null)
            {
                throw new ArgumentNullException(nameof(polynomial));
            }
            if (polynomial._coefficients.All(o => o == 0))
            {
                return "0";
            }
            else
            {
                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < polynomial._coefficients.Length; i++)
                {
                    int value = polynomial._coefficients[i];
                    switch (i)
                    {
                        case 0:
                            sb.Append(value != 0 ? polynomial._coefficients[i].ToString() : "");
                            break;
                        case 1:
                            if (value == 0)
                            {
                                sb.Append("");
                            }
                            else
                            {
                                sb.Append(sb.Length > 1 ? " + " : "");
                                sb.Append(polynomial._coefficients[i].ToString() + "x");
                            }
                            break;
                        default:
                            if (value == 0)
                            {
                                sb.Append("");
                            }
                            else
                            {
                                sb.Append(sb.Length > 1 ? " + " : "");
                                sb.Append(polynomial._coefficients[i].ToString() + "x^" + i);
                            }
                            break;
                    }
                }
                return sb.ToString();
            }
        }
    }
}

