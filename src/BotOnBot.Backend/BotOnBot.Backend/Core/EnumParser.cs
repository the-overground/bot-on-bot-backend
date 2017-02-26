using System;

namespace BotOnBot.Backend.Core
{
    internal static class EnumParser
    {
        internal static TEnum Parse<TEnum>(string member) where TEnum : struct, IComparable
        {
            if (Enum.TryParse(member, true, out TEnum result))
                return result;

            return default(TEnum);
        }
    }
}
