using System.Collections.Generic;
using System.Linq;

namespace Vino.Server.Services.Helper
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source is null || !source.Any();
        }

    }
}