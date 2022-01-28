using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler
{
    public class FunctionData
    {
        public string ReturnType { get; set; }
        public string ReturnValue { get; set; }
        public Dictionary<string, VariableData> Arguments { get; set; }
        public Dictionary<string, VariableData> Variables { get; set; }  // var, {Id, VarType}

        public FunctionData(string returnType, string returnValue)
        {
            ReturnType = returnType;
            ReturnValue = returnValue;
            Arguments = new Dictionary<string, VariableData>();
            Variables = new Dictionary<string, VariableData>();
        }
    }
}
