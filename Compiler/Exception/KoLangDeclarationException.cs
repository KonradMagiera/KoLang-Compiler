using System;

namespace Compiler
{
    class KoLangDeclarationException : FormatException
    {
        public KoLangDeclarationException(string msg) : base(msg) { }
    }
}
