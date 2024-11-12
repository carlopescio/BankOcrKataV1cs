using System.Numerics;

namespace BankOcrV1
{
    internal class Glyph
    {
        internal Glyph()
        {
            Value = NotADigit;
            and = 0b1111111111111111;
        }

        internal void AddSlice(int row, byte pattern)
        {
            and &= Digits.Candidates(row, pattern);
        }

        internal void Recognize()
        {
            if(BitOperations.IsPow2(and))
                Value = (byte)(BitOperations.TrailingZeroCount(and));
        }

        internal byte Value
        {
            get; private set;
        }

        internal bool IsDigit
        {
            get
            {
                return Value != NotADigit;
            }
        }

        private ushort and;
        private static readonly byte NotADigit = 0b10000000;
    }
}
