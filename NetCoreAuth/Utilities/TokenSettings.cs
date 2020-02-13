using System.Text;

namespace NetCoreAuth.Utilities
{
    public static class TokenSettings
    {
        public const int ExpireHour = 4;
        public static readonly byte[] SecurityKey = Encoding.ASCII.GetBytes("NWhhZGZvcnQ0cyNDb250cmFjdDFuZHVjdGlvbg==");
    }
}
