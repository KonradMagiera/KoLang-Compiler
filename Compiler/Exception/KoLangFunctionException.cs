using System;

namespace Compiler
{
    class KoLangFunctionException : FormatException
    {
        public KoLangFunctionException(string msg) : base(msg) { }
    }
}
