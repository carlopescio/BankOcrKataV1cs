using System.Text;

namespace BankOcrV1
{
    public class AccountNumber
    {
        internal AccountNumber(Glyph[] figures)
        {
            this.figures = figures;
            invalidDigits = figures.Any(f => !f.IsDigit);
        }

        public void Validate()
        {
            long checksum = 0;
            for(int i = 0; i < figures.Length; ++i)
                checksum += figures[i].Value * (figures.Length - i);
            invalidChecksum = checksum % 11 != 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendJoin("",figures.Select(g => g.IsDigit ? g.Value.ToString() : "?"));
            if(invalidDigits)
                sb.Append(" ILL");
            else if(invalidChecksum)
                sb.Append(" ERR");
            return sb.ToString();
        }

        private readonly bool invalidDigits;
        private bool invalidChecksum;
        private readonly Glyph[] figures;
    }
}
