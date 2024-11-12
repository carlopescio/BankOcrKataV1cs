namespace BankOcrV1
{
    internal class BinaryImage(string[] Rows)
    {
        internal byte GlyphSlice(int row, int glyphIndex)
        {
            string textChunk = Rows[row].Substring(glyphIndex * Digits.ColumnsPerGlyph, Digits.ColumnsPerGlyph);
            string binaryPattern = textChunk.Replace(' ', '0').Replace('|', '1').Replace('_', '1');
            return Convert.ToByte(binaryPattern, 2);
        }
    }
}
