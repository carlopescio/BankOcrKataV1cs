namespace BankOcrV1.tests
{
    [TestClass]
    public class BinaryImageTests
    {
        [TestMethod]
        public void DigitSplits()
        {
            string row1 = "    _  _     _  _  _  _  _ ";
            string row2 = "  | _| _||_||_ |_   ||_||_|";
            string row3 = "  ||_  _|  | _||_|  ||_| _|";

            BinaryImage bin = new([row1, row2, row3]);
            Assert.AreEqual(0b000, bin.GlyphSlice(0, 0));
            Assert.AreEqual(0b111, bin.GlyphSlice(1, 3));
            Assert.AreEqual(0b011, bin.GlyphSlice(2, 8));
        }
    }
}