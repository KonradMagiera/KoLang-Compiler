using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compiler
{
    class KoLangException : BaseErrorListener
    {
        public static readonly KoLangException _instance = new KoLangException();
        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            throw new KoLangFormatException($"line {line}:{charPositionInLine} {msg}");
            //base.SyntaxError(output, recognizer, offendingSymbol, line, charPositionInLine, msg, e);
        }
    }
}
