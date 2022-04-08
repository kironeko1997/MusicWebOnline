using System;

namespace MusicWebOnline
{
    public class DAL
    {
        public static object ToDBNull(object value)
        {
            if (value != null)
                return value;
            return DBNull.Value;
        }

        public static object ToDBNull(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return value;
            return "";
        }

        public static object ToDBNull(int value)
        {
            if (value > 0)
                return value;
            return DBNull.Value;
        }
    }
}