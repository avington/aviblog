using System;

namespace AviBlog.Core.Mappings.CustomMappings
{
    public class DateNonNullStringFormatter : BaseFormatter<DateTime>
    {
        protected override string FormatValueCore(DateTime value)
        {
            return value.ToShortDateString();
        }
    }
}