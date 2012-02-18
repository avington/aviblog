using System;

namespace AviBlog.Core.Mappings.CustomMappings
{
    public class DateStringFormatter : BaseFormatter<DateTime?>
    {
        protected override string FormatValueCore(DateTime? value)
        {
            return value.HasValue ? value.Value.ToShortDateString() : string.Empty;
        }
    }
}