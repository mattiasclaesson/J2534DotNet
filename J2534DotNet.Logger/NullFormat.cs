﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J2534DotNet.Logger
{
    public class NullFormat: IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
            {
                return "*NULL*";
            }

            var formattable = arg as IFormattable;
            return formattable != null ? formattable.ToString(format, formatProvider) : arg.ToString();
        }
    }
}
