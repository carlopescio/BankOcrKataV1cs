
namespace BankOcrV1
{
    public class OCR
    {
        public OCR()
        {
            figures = new Glyph[GlyphsPerRow];
            for(int g = 0; g < GlyphsPerRow; ++g)
            {
                figures[g] = new();
            }
        }

        public AccountNumber Recognize(string[] rows)
        {
            ExtractGlyphSlices(rows);
            RecognizeDigits();
            return DigitsToAccountNumber();
        }

        private AccountNumber DigitsToAccountNumber()
        {
            return new AccountNumber(figures);
        }

        private void RecognizeDigits()
        {
            foreach(Glyph g in figures)
                g.Recognize();
        }

        private void ExtractGlyphSlices(string[] rows)
        {
            BinaryImage img = new(rows);
            for(int r = 0; r < rows.Length; ++r)
            {
                for(int g = 0; g < GlyphsPerRow; ++g)
                {
                    byte b = img.GlyphSlice(r, g);
                    figures[g].AddSlice(r, b);
                }
            }
        }

        private readonly Glyph[] figures;
        private static readonly int GlyphsPerRow = 9;
    }
}
