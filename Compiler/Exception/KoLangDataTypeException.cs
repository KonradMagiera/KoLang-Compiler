using System;

namespace Compiler
{
    class KoLangDataTypeException : FormatException
    {
        public KoLangDataTypeException(string msg) : base(msg) { }
    }
}
