using System;
using System.Text;
using System.Globalization;

namespace Vector
{
    public class Vector3D
    {
        public double X;
        public double Y;
        public double Z;

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3D operator +(Vector3D firstVector, Vector3D secondVector)
        {
            if (firstVector is null)
            {
                throw new ArgumentNullException(nameof(firstVector));
            }
            if (secondVector is null)
            {
                throw new ArgumentNullException(nameof(secondVector));
            }
            return new Vector3D(firstVector.X + secondVector.X, firstVector.Y + secondVector.Y, firstVector.Z + secondVector.Z);
        }

        public static Vector3D operator -(Vector3D vector, Vector3D vectorToSubstract)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector));
            }
            if (vectorToSubstract is null)
            {
                throw new ArgumentNullException(nameof(vectorToSubstract));
            }
            return new Vector3D(vector.X - vectorToSubstract.X, vector.Y - vectorToSubstract.Y, vector.Z - vectorToSubstract.Z);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            Vector3D other = (Vector3D)obj;
            return (other.X == X && other.Y == Y && other.Z == Z);
        }

        public static bool operator ==(Vector3D firstVector, Vector3D secondVector)
        {
            if (ReferenceEquals(firstVector, secondVector))
            {
                return true;
            }
            if (ReferenceEquals(firstVector, null))
            {
                return false;
            }
            return firstVector.Equals(secondVector);
        }

        public static bool operator !=(Vector3D firstVector, Vector3D secondVector) => !(firstVector == secondVector);

        public static Vector3D operator *(Vector3D firstVector, Vector3D secondVector)
        {
            if (firstVector is null)
            {
                throw new ArgumentNullException(nameof(firstVector));
            }
            if (secondVector is null)
            {
                throw new ArgumentNullException(nameof(secondVector));
            }
            return new Vector3D(firstVector.X * secondVector.X, firstVector.Y * secondVector.Y, firstVector.Z * secondVector.Z);
        }

        public static Vector3D operator *(Vector3D vector, double number)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector));
            }
            return new Vector3D(vector.X * number, vector.Y * number, vector.Z * number);
        }

        public static Vector3D Cross(Vector3D firstVector, Vector3D secondVector)
        {
            if (firstVector is null)
            {
                throw new ArgumentNullException(nameof(firstVector));
            }
            if (secondVector is null)
            {
                throw new ArgumentNullException(nameof(secondVector));
            }
            return new Vector3D(
                (firstVector.Y * secondVector.Z) - (firstVector.Z * secondVector.Y),
                (firstVector.Z * secondVector.X) - (firstVector.X * secondVector.Z),
                (firstVector.X * secondVector.Y) - (firstVector.Y * secondVector.X)
            );
        }

        public override int GetHashCode() => HashCode.Combine(this.X, this.Y, this.Z);

        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder sb = new StringBuilder();
            string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
            sb.Append('<');
            sb.Append(X.ToString(format, formatProvider));
            sb.Append(separator);
            sb.Append(' ');
            sb.Append(Y.ToString(format, formatProvider));
            sb.Append(separator);
            sb.Append(' ');
            sb.Append(Z.ToString(format, formatProvider));
            sb.Append('>');
            return sb.ToString();
        }
    }
}
