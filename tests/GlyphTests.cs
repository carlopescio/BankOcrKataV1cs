namespace BankOcrV1.tests
{
    [TestClass]
    public class GlyphTests
    {
        [TestMethod]
        public void Recognize0()
        {
            Glyph zero = new();
            zero.AddSlice(0, 0b010);
            zero.AddSlice(1, 0b101);
            zero.AddSlice(2, 0b111);

            zero.Recognize();
            Assert.AreEqual(0, zero.Value);
        }

        [TestMethod]
        public void Recognize5()
        {
            Glyph five = new();
            five.AddSlice(0, 0b010);
            five.AddSlice(1, 0b110);
            five.AddSlice(2, 0b011);

            five.Recognize();
            Assert.AreEqual(5, five.Value);
        }

        [TestMethod]
        public void Recognize9()
        {
            Glyph nine = new();
            nine.AddSlice(0, 0b010);
            nine.AddSlice(1, 0b111);
            nine.AddSlice(2, 0b011);

            nine.Recognize();
            Assert.AreEqual(9, nine.Value);
        }

        [TestMethod]
        public void InvalidPatternInRow()
        {
            Glyph inv = new();
            inv.AddSlice(0, 0b110);
            inv.AddSlice(1, 0b111);
            inv.AddSlice(2, 0b011);

            inv.Recognize();
            Assert.IsFalse(inv.IsDigit);
        }

        [TestMethod]
        public void InvalidRowCombination()
        {
            Glyph inv = new();
            inv.AddSlice(0, 0b000);
            inv.AddSlice(1, 0b111);
            inv.AddSlice(2, 0b111);

            inv.Recognize();
            Assert.IsFalse(inv.IsDigit);
        }
    }
}