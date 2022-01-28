using System;

namespace Compiler
{
    class KoLangFormatException : FormatException
    {
        public KoLangFormatException(string msg) : base(msg) { }
    }
}
