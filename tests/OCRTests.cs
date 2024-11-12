namespace BankOcrV1.tests
{
    [TestClass]
    public class OCRTests
    {
        [TestMethod]
        public void Recognize123456789()
        {
            string row1 = "    _  _     _  _  _  _  _ ";
            string row2 = "  | _| _||_||_ |_   ||_||_|";
            string row3 = "  ||_  _|  | _||_|  ||_| _|";

            OCR o = new();
            AccountNumber an = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("123456789", an.ToString());

            an.Validate();
            Assert.AreEqual("123456789", an.ToString());
        }

        [TestMethod]
        public void Recognize000000051()
        {
            string row1 = " _  _  _  _  _  _  _  _    ";
            string row2 = "| || || || || || || ||_   |";
            string row3 = "|_||_||_||_||_||_||_| _|  |";

            OCR o = new();
            AccountNumber an = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("000000051", an.ToString());

            an.Validate();
            Assert.AreEqual("000000051", an.ToString());
        }

        [TestMethod]
        public void Recognize444444444()
        {
            string row1 = "                           ";
            string row2 = "|_||_||_||_||_||_||_||_||_|";
            string row3 = "  |  |  |  |  |  |  |  |  |";

            OCR o = new();
            AccountNumber an = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("444444444", an.ToString());

            an.Validate();
            Assert.AreEqual("444444444 ERR", an.ToString());
        }

        [TestMethod]
        public void InvalidPattern1()
        {
            string row1 = "    _  _  _  _  _  _     _ ";
            string row2 = "|_||_|| || ||_   |  |  | _ ";
            string row3 = "  | _||_||_||_|  |  |  | _|";

            OCR o = new();
            AccountNumber an = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("49006771? ILL", an.ToString());

            an.Validate();
            Assert.AreEqual("49006771? ILL", an.ToString());
        }


        [TestMethod]
        public void InvalidPattern2()
        {
            string row1 = "    _  _     _  _  _  _  _ ";
            string row2 = "  | _| _||_| _ |_   ||_||_|";
            string row3 = "  ||_  _|  | _||_|  ||_| _ ";

            OCR o = new();
            AccountNumber an = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("1234?678? ILL", an.ToString());
        }
    }
}