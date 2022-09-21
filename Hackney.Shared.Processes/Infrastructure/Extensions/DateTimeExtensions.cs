using System;
using System.Globalization;

namespace Hackney.Shared.Processes.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToIsoString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.FFF", CultureInfo.InvariantCulture) + "Z";
        }
    }
}
