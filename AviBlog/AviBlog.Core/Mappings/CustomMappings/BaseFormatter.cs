using System;
using AutoMapper;

namespace AviBlog.Core.Mappings.CustomMappings
{
    public abstract class BaseFormatter<T> : IValueFormatter
    {
        #region IValueFormatter Members

        public string FormatValue(ResolutionContext context)
        {
            if (context.SourceValue == null)
                return null;

            if (!(context.SourceValue is T))
                return context.SourceValue ==
                       null
                           ? String.Empty
                           : context.SourceValue.ToString();

            return FormatValueCore((T) context.SourceValue);
        }

        #endregion

        protected abstract string FormatValueCore(T value);
    }
}