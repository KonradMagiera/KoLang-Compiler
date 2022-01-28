using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(args[0]);
            ICharStream stream = CharStreams.fromString(input);
            ITokenSource lexer = new KoLangLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            KoLangParser parser = new KoLangParser(tokens)
            {
                BuildParseTree = true
            };
            parser.RemoveErrorListeners();
            parser.AddErrorListener(KoLangException._instance);
            IParseTree tree;
            try
            {
                tree = parser.program();
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
            ParseTreeWalker.Default.Walk(new LLVMActions(), tree);
            //Console.WriteLine($"\n{tree.ToStringTree(parser)}");
        }
    }
}
