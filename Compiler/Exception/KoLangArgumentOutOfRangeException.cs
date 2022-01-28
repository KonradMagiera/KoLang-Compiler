using System;

namespace Compiler
{
    class KoLangArgumentOutOfRangeException : FormatException
    {
        public KoLangArgumentOutOfRangeException(string msg) : base(msg) { }
    }
}
