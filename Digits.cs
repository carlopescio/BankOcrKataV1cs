namespace BankOcrV1
{
    internal static class Digits
    {
        internal static readonly ushort Invalid = 0b10000000000;

        static Digits()
        {
            patternToDigits = new ushort[RowsPerGlyph, patternsPerRow];
            InitWithInvalid();
            SetValidPatterns();
        }

        private static void SetValidPatterns()
        {
            patternToDigits[0, 0b000] = 0b0000010010;
            patternToDigits[0, 0b010] = 0b1111101101;

            patternToDigits[1, 0b101] = 0b0000000001;
            patternToDigits[1, 0b001] = 0b0010000010;
            patternToDigits[1, 0b011] = 0b0000001100;
            patternToDigits[1, 0b111] = 0b1100010000;
            patternToDigits[1, 0b110] = 0b0001100000;

            patternToDigits[2, 0b001] = 0b0010010010;
            patternToDigits[2, 0b110] = 0b0000000100;
            patternToDigits[2, 0b011] = 0b1000101000;
            patternToDigits[2, 0b111] = 0b0101000001;
        }

        private static void InitWithInvalid()
        {
            for(int r = 0; r < RowsPerGlyph; ++r)
                for(int p = 0; p < patternsPerRow; ++p)
                    patternToDigits[r, p] = Invalid;
        }

        internal static ushort Candidates(int row, byte pattern)
        {
            return patternToDigits[row, pattern];
        }

        internal static readonly int ColumnsPerGlyph = 3;

        private static readonly int RowsPerGlyph = 3;

        private static readonly int patternsPerRow = (1 << ColumnsPerGlyph);
        private static readonly ushort[,] patternToDigits;

    }
}
