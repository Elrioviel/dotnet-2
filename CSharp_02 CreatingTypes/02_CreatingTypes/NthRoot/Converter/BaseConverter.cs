using System;
using System.Text;
using System.Numerics;

namespace Converter
{
    public class BaseConverter
    {
        const string DefaultDigitSet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/";
        public enum BaseSystem
        {
            Bin = 2,
            Oct = 8,
            Hex = 16,
            Base32 = 32,
            Base64 = 64
        }
        public static string ToBin(int value)
        {
            return ToBase(value, BaseSystem.Bin);
        }
        public static string ToOct(int value)
        {
            return ToBase(value, BaseSystem.Oct);
        }
        public static string ToHex(int value)
        {
            return ToBase(value, BaseSystem.Hex);
        }
        public static string ToBase32(int value)
        {
            return ToBase(value, BaseSystem.Base32);
        }
        public static string ToBase64(int value)
        {
            return ToBase(value, BaseSystem.Base64);
        }
        public static string ToBinStandard(int value)
        {
            return Convert.ToString(value, 2);
        }
        public static string ToOctStandard(int value)
        {
            return Convert.ToString(value, 8);
        }
        public static string ToHexStandard(int value)
        {
            return Convert.ToString(value, 16);
        }
        public static string ToBase64Standard(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
        public static string ToBase(int value, BaseSystem radix)
        {
            if (((int)radix > DefaultDigitSet.Length) || ((int)radix < 2))
            {
                throw new ArgumentOutOfRangeException("radix", radix, string.Format("Radix has to be within range <2, {0}>;", DefaultDigitSet.Length));
            }
            StringBuilder result = new StringBuilder();
            while (value > 0)
            {
                value = Math.DivRem(value, (int)radix, out int remainder);
                result.Insert(0, DefaultDigitSet[remainder]);
            }
            return result.ToString();
        }
    }
}
