using Antlr4.Runtime.Misc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Compiler
{
    public class LLVMActions : KoLangBaseListener
    {

        private readonly LLVMGenerator generator;
        private readonly Dictionary<string, FunctionData> functions;
        private readonly Stack<string> numbers; // math values(INT/REAL/%expr1/%x.1)
        private readonly Stack<bool[]> isElse;
        private readonly List<string> functionArguments;
        private readonly string[] compareValues; // compVal1, varType1, compVal2, varType2
        private string value;
        private string varType;
        private string functionName;
        private bool shouldChangeValue;

        public LLVMActions()
        {
            generator = new LLVMGenerator();
            functionName = "main";
            functions = new Dictionary<string, FunctionData>
            {
                [functionName] = new FunctionData("i32", "0")
            };
            numbers = new Stack<string>();
            isElse = new Stack<bool[]>();
            functionArguments = new List<string>();
            compareValues = new string[4] { "", "", "", "" };
            shouldChangeValue = false;
        }

        public override void ExitAssign([NotNull] KoLangParser.AssignContext ctx)
        {
            if(ctx.ID() != null)
            {
                string id= ctx.ID().GetText();
                id = $"{functionName}.{id}";
                bool changeValue = false;
                Dictionary<string, VariableData> variables = functions[functionName].Variables;
                Dictionary<string, VariableData> arguments = functions[functionName].Arguments;
                if(arguments.ContainsKey(id))
                {
                    throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Variable {id} is function argument!");
                }
                else if (!variables.ContainsKey(id))
                {
                    variables[id] = new VariableData(0, varType);
                }
                else if (variables[id].VarType == varType && (varType == "i32" || varType == "double"))
                {
                    changeValue = true;
                }
                else
                {
                    variables[id].Id++;
                    variables[id].VarType = varType;
                }

                if (numbers.Count > 0)
                {
                    string num = numbers.Pop();
                    value = num;
                }
                bool varTypeIsID = variables[id].VarType == "ID";
                string tmpVarType = "";
                if (varTypeIsID && variables.ContainsKey(value))
                {
                    tmpVarType = variables[value].VarType;
                    value = $"{value}.{variables[value].Id} {variables[value].VarType}";
                } else if (varTypeIsID && arguments.ContainsKey(value))
                {
                    tmpVarType = arguments[value].VarType;
                    value = $"{value}.{arguments[value].Id} {arguments[value].VarType}";
                }

                if (changeValue)
                {
                    generator.ChangeValue(id, variables[id].Id, variables[id].VarType, value);
                }
                else
                {
                    generator.DeclareVar(id, variables[id].Id, variables[id].VarType, value);
                }

                if (varTypeIsID)
                    variables[id].VarType = tmpVarType;
            }
        }

        public override void ExitAssignArray([NotNull] KoLangParser.AssignArrayContext ctx)
        {
            if (ctx.ID() != null)
            {
                string[] array = numbers.ToArray();
                string id = ctx.ID().GetText();
                id = $"{functionName}.{id}";
                numbers.Clear();
                if (ctx.INT() != null)
                {
                    string size = ctx.INT().GetText();
                    if (size != array.Length.ToString())
                        throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Array {id} is declared with size {size} but got {array.Length} elements!");
                }

                string arrayType = varType[6..];
                value = "[";
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if(arrayType == "double" && !array[i].Contains('.'))
                    {
                        array[i] += ".0";
                    }
                    if (i > 0)
                    {
                        value += $"{arrayType} {array[i]}, ";
                    }
                    else
                    {
                        value += $"{arrayType} {array[i]}]";
                    }
                }
                Dictionary<string, VariableData> variables = functions[functionName].Variables;
                Dictionary<string, VariableData> arguments = functions[functionName].Arguments;
                if (arguments.ContainsKey(id))
                {
                    throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Variable {id} is function argument!");
                }
                else if (!variables.ContainsKey(id))
                {
                    variables[id] = new VariableData(0, varType);
                }
                else
                {
                    variables[id].Id++;
                    variables[id].VarType = varType;
                }

                varType = $"[{array.Length} x {arrayType}]";
                generator.DeclareArray(id, variables[id].Id, varType, value);
            }
        }

        public override void ExitAssignArrayItemToID([NotNull] KoLangParser.AssignArrayItemToIDContext ctx)
        {
            string id = ctx.ID().GetText();
            id = $"{functionName}.{id}";
            bool changeValue = false;
            Dictionary<string, VariableData> variables = functions[functionName].Variables;
            Dictionary<string, VariableData> arguments = functions[functionName].Arguments;
            if (arguments.ContainsKey(id))
            {
                throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Variable {id} is function argument!");
            }
            else if (!variables.ContainsKey(id))
            {
                variables[id] = new VariableData(0, varType);
            }
            else if (variables[id].VarType == varType && (varType == "i32" || varType == "double"))
            {
                changeValue = true;
            }
            else
            {
                variables[id].Id++;
                variables[id].VarType = varType;
            }
            generator.DeclareVarFromArrayItem(id, variables[id].Id, variables[id].VarType, value, changeValue);
        }

        public override void ExitChangeArrayItemValue([NotNull] KoLangParser.ChangeArrayItemValueContext ctx)
        {
            if(ctx.ID() != null && ctx.INT() != null)
            {
                string id = ctx.ID().GetText();
                id = $"{functionName}.{id}";
                string elementId = ctx.INT().GetText();
                Dictionary<string, VariableData> variables = functions[functionName].Variables;
                if (numbers.Count != 1)
                    throw new KoLangMathException($"Error at line: {ctx.Start.Line}. Something went wrong in math module!");
                if (!variables.ContainsKey(id))
                    throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Array {id} is not declared!");
                if (variables[id].VarType.IndexOf("array") < 0)
                    throw new KoLangDataTypeException($"Error at line: {ctx.Start.Line}. Variable {id} is not an array!");

                string num = numbers.Pop();
                int element = int.Parse(elementId);
                if (element < 0)
                    throw new KoLangArgumentOutOfRangeException($"Error at line: {ctx.Start.Line}. Bad array index!");

                generator.ChangeArrayItemValue($"@{id}.{variables[id].Id}", element, variables[id].VarType[6..], varType, num);
            }
        }

        public override void ExitPrint([NotNull] KoLangParser.PrintContext ctx)
        {
            Dictionary<string, VariableData> variables = functions[functionName].Variables;
            Dictionary<string, VariableData> arguments = functions[functionName].Arguments;
            if (varType == "ID") 
            {
                if (!variables.ContainsKey(value) && !arguments.ContainsKey(value))
                    throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Variable {value} was not declared!");
                if(variables.ContainsKey(value))
                {
                    generator.Print(value, variables[value].Id, varType, variables[value].VarType);
                }
                else
                {
                    generator.Print(value, arguments[value].Id, varType, arguments[value].VarType);
                }
                
            }
            else if(varType == "array i32" || varType == "array double") // printf whole array
            {
                if (!variables.ContainsKey(value))
                    throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Variable {value} was not declared!");

                generator.PrintArray(value, variables[value].Id, null);
            }
            else
            {
                if (numbers.Count > 0)
                {
                    string num = numbers.Pop();
                    value = num;
                }
                generator.Print(value, -1, varType, "");
            }
        }

        public override void ExitPrintArrayItem([NotNull] KoLangParser.PrintArrayItemContext ctx)
        {
            string id = ctx.ID().GetText();
            id = $"{functionName}.{id}";
            Dictionary<string, VariableData> variables = functions[functionName].Variables;
            if (!variables.ContainsKey(id))
                throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Variable {value} was not declared!");

            generator.PrintArray(id, variables[id].Id, int.Parse(ctx.INT().GetText()), false);
        }

        public override void ExitRead([NotNull] KoLangParser.ReadContext ctx)
        {
            if(ctx.ID() != null)
            {
                string id = ctx.ID().GetText();
                id = $"{functionName}.{id}";
                bool changeValue = false;
                Dictionary<string, VariableData> variables = functions[functionName].Variables;
                Dictionary<string, VariableData> arguments = functions[functionName].Arguments;
                if(arguments.ContainsKey(id))
                {
                    throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Variable {id} is function argument!");
                }
                else if (!variables.ContainsKey(id))
                {
                    variables[id] = new VariableData(0, "double");
                }
                else if(variables[id].VarType == "double")
                {
                    changeValue = true;
                }
                else
                {
                    variables[id].Id++;
                    variables[id].VarType = "double";
                }
                generator.Scan(id, variables[id].Id, changeValue);
            }
        }

        public override void ExitAdd([NotNull] KoLangParser.AddContext ctx)
        {
            if (numbers.Count < 2)
                throw new KoLangMathException($"Error at line: {ctx.Start.Line}. Something went wrong in math module!");
            string operation = "add";
            if (ctx.operatorOne() != null && ctx.operatorOne().GetText() == "-") 
                operation = "sub";
            string var = generator.Calculate(numbers.Pop(), numbers.Pop(), varType, operation);
            numbers.Push(var);
        }

        public override void ExitMultiply([NotNull] KoLangParser.MultiplyContext ctx)
        {
            if (numbers.Count < 2)
                throw new KoLangMathException($"Error at line: {ctx.Start.Line}. Something went wrong in math module!");
            string operation = "mul";
            if (ctx.operatorTwo() != null && ctx.operatorTwo().GetText() == "/")
                operation = "div";
            string var = generator.Calculate(numbers.Pop(), numbers.Pop(), varType, operation);
            numbers.Push(var);
        }

        #region IfMethods
        public override void EnterIfStatement([NotNull] KoLangParser.IfStatementContext ctx)
        {
            isElse.Push(new bool[] { ctx.elseifStatement() != null, ctx.elseStatement() != null });
            generator.AddIfToStack();
        }

        public override void ExitIfStatement([NotNull] KoLangParser.IfStatementContext ctx)
        {
            bool[] checkElse = isElse.Pop();
            generator.EndIf(checkElse[0] || checkElse[1]);
        }

        public override void EnterElseifStatement([NotNull] KoLangParser.ElseifStatementContext ctx)
        {
            bool[] checkElse = isElse.Pop();
            checkElse[0] = ctx.elseifStatement() != null;
            isElse.Push(checkElse);
            generator.EnterElse();
        }

        public override void EnterElseStatement([NotNull] KoLangParser.ElseStatementContext ctx)
        {
            generator.EnterElse();
        }

        public override void ExitElseStatement([NotNull] KoLangParser.ElseStatementContext ctx)
        {
            generator.ExitElse();
        }
        
        public override void EnterComparision([NotNull] KoLangParser.ComparisionContext ctx)
        {
            varType = "";
        }

        public override void ExitComparision([NotNull] KoLangParser.ComparisionContext ctx)
        {
            if(compareValues[0] == "" || compareValues[1] == "" || compareValues[2] == "" || compareValues[3] == "")
                throw new KoLangMathException($"Error at line: {ctx.Start.Line}. Compare operation is broken!");
            bool[] checkElse = isElse.Pop();
            generator.IfComparision(compareValues, ctx.compareOperator().GetText(), checkElse[0] || checkElse[1]);
            isElse.Push(checkElse);

            for(int i = 0; i < compareValues.Length; i++)
                compareValues[i] = "";
        }
        #endregion

        #region WhileMethods
        public override void EnterWhile([NotNull] KoLangParser.WhileContext ctx)
        {
            generator.AddWhileToStack();
        }

        public override void ExitWhile([NotNull] KoLangParser.WhileContext ctx)
        {
            generator.EndWhile();
        }

        public override void EnterWhileComp([NotNull] KoLangParser.WhileCompContext ctx)
        {
            varType = "";
        }

        public override void ExitWhileComp([NotNull] KoLangParser.WhileCompContext ctx)
        {
            if (compareValues[0] == "" || compareValues[1] == "" || compareValues[2] == "" || compareValues[3] == "")
                throw new KoLangMathException($"Error at line: {ctx.Start.Line}. Compare operation is broken!");
            generator.WhileComparision(compareValues, ctx.compareOperator().GetText());

            for (int i = 0; i < compareValues.Length; i++)
                compareValues[i] = "";
        }
        #endregion

        #region Comparision
        public override void EnterCompValueFirst([NotNull] KoLangParser.CompValueFirstContext ctx)
        {
            varType = "";
        }

        public override void ExitCompValueFirst([NotNull] KoLangParser.CompValueFirstContext ctx)
        {
            if(numbers.Count != 1)
                throw new KoLangMathException($"Error at line: {ctx.Start.Line}. Something went wrong in math module for comparision!");
            compareValues[0] = numbers.Pop();
            compareValues[1] = varType;

        }

        public override void EnterCompValueSecond([NotNull] KoLangParser.CompValueSecondContext ctx)
        {
            varType = "";
        }

        public override void ExitCompValueSecond([NotNull] KoLangParser.CompValueSecondContext ctx)
        {
            if (numbers.Count != 1)
                throw new KoLangMathException($"Error at line: {ctx.Start.Line}. Something went wrong in math module for comparision!");
            compareValues[2] = numbers.Pop();
            compareValues[3] = varType;
        }
        #endregion

        #region FunctionMethods
        public override void EnterFunction([NotNull] KoLangParser.FunctionContext ctx)
        {
            if (!generator.IsMain)
                throw new KoLangFunctionException($"Error at line: {ctx.Start.Line}. Can't define function inside another function!");
            generator.IsMain = false;
            functionName = ctx.ID().GetText();
            string returnType = "i32";
            string returnValue = "0";
            switch(ctx.functionReturnType().GetText())
            {
                case "void":
                    returnType = "void";
                    returnValue = "";
                    break;
                case "int":
                    returnType = "i32";
                    returnValue = "0";
                    break;
                case "double":
                    returnType = "double";
                    returnValue = "0.0";
                    break;
            }
            if (functions.ContainsKey(functionName))
                throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Function {functionName} already exists!");

            functions[functionName] = new FunctionData(returnType, returnValue);

            if(ctx.functionArguments() == null)
                generator.EnterFunction(functionName, functions[functionName]);
        }

        public override void ExitFunction([NotNull] KoLangParser.FunctionContext ctx)
        {
            if (ctx.math() != null) // has return value
            {
                if (functions[functionName].ReturnType == "void")
                    throw new KoLangFunctionException($"Error at line: {ctx.Start.Line}. Function {functionName} has return type \"void\"!");
                string value = numbers.Pop();
                
                
                if(value.Contains($"%{functionName}.")) // load value from ID
                {
                    value = generator.LoadAllocaToReturn(value, varType);
                }
                if(varType != functions[functionName].ReturnType) // cast to ReturnType
                {
                    value = generator.CastReturnValue(value, functions[functionName].ReturnType);
                }
                functions[functionName].ReturnValue = value;
                varType = "";

            }

            generator.ExitFunction(functions[functionName].ReturnType, functions[functionName].ReturnValue);
            generator.IsMain = true;
            functionName = "main";
        }

        public override void ExitFunctionArguments([NotNull] KoLangParser.FunctionArgumentsContext ctx)
        {
            generator.EnterFunction(functionName, functions[functionName]);
        }

        public override void ExitFunctionArg([NotNull] KoLangParser.FunctionArgContext ctx)
        {
            string argType = ctx.functionArgType().GetText() switch
            {
                "int" => "i32",
                "double" => "double",
                _ => "i32",
            };
            string id = ctx.ID().GetText();
            id = $"{functionName}.{id}";
            if (functions[functionName].Arguments.ContainsKey(id))
                throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Argument named {id} was already used!");

            functions[functionName].Arguments[id] = new VariableData(0, argType);
        }

        public override void EnterAssignFunction([NotNull] KoLangParser.AssignFunctionContext ctx)
        {
            if (ctx.ID() != null)
            {
                string id = ctx.ID().GetText();
                id = $"{functionName}.{id}";
                string function = ctx.callFunction().ID().GetText();
                if (!functions.ContainsKey(function))
                    throw new KoLangFunctionException($"Error at line: {ctx.Start.Line}. Function {function} does not exist!");
                string functionReturnType = functions[function].ReturnType;
                

                Console.WriteLine(functionReturnType);
                Dictionary<string, VariableData> variables = functions[functionName].Variables;
                Dictionary<string, VariableData> arguments = functions[functionName].Arguments;
                if (arguments.ContainsKey(id))
                {
                    throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Variable {id} is function argument!");
                }
                else if (!variables.ContainsKey(id))
                {
                    variables[id] = new VariableData(0, functionReturnType);
                }
                else if (variables[id].VarType == functionReturnType && (functionReturnType == "i32" || functionReturnType == "double"))
                {
                    shouldChangeValue = true;
                }
                else
                {
                    variables[id].Id++;
                    variables[id].VarType = functionReturnType;
                }
                value = generator.GetReturnValue();
            }
        }

        public override void ExitAssignFunction([NotNull] KoLangParser.AssignFunctionContext ctx)
        {
            string id = ctx.ID().GetText();
            id = $"{functionName}.{id}";
            Dictionary<string, VariableData> variables = functions[functionName].Variables;
            if (shouldChangeValue)
            {
                generator.ChangeValue(id, variables[id].Id, variables[id].VarType, value);
            }
            else
            {
                generator.DeclareVar(id, variables[id].Id, variables[id].VarType, value);
            }
            shouldChangeValue = false;
            varType = "";
            value = "";
        }

        public override void ExitCallFunction([NotNull] KoLangParser.CallFunctionContext ctx)
        {
            string functionName = ctx.ID().GetText();

            if (!functions.ContainsKey(functionName))
                throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Function {functionName} is not defined!");

            generator.CallFunction(functionName, functions[functionName], functionArguments);
            functionArguments.Clear();
        }

        public override void ExitGivenFunctionArg([NotNull] KoLangParser.GivenFunctionArgContext ctx)
        {
            string id = ctx.ID().GetText();
            id = $"{functionName}.{id}";
            Dictionary<string, VariableData> arguments = functions[functionName].Arguments;
            Dictionary<string, VariableData> variables = functions[functionName].Variables;

            if(!variables.ContainsKey(id) && !arguments.ContainsKey(id))
                throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Variable {id} not declared!");

            if (variables.ContainsKey(id))
            { 
                id = $"{id}.{variables[id].Id}";
            } else if (arguments.ContainsKey(id))
            {
                id = $"{id}.{arguments[id].Id}";
            }

            functionArguments.Add(id);
        }
        #endregion

        public override void EnterValue([NotNull] KoLangParser.ValueContext ctx)
        {
            value = "";
            varType = "";
        }

        public override void EnterAssignArray([NotNull] KoLangParser.AssignArrayContext ctx)
        {
            varType = "";
            numbers.Clear();
        }

        public override void EnterArrayAssignItem([NotNull] KoLangParser.ArrayAssignItemContext ctx)
        {
            varType = "";
            value = "";
        }

        public override void ExitConcatVal([NotNull] KoLangParser.ConcatValContext ctx)
        {
            if (ctx.STRING() != null)
            {
                string tmp = ctx.STRING().GetText();
                value += tmp[1..^1];
                varType = "string";
            }
            if (ctx.INT() != null)
            {
                string tmp = ctx.INT().GetText().Replace("+", "");
                value += tmp;
                varType = "string";
            }
            if (ctx.REAL() != null)
            {
                string tmp = ctx.REAL().GetText().Replace("+", "");
                value += tmp;
                varType = "string";
            }
        }

        public override void ExitValue([NotNull] KoLangParser.ValueContext ctx)
        {
            if(ctx.ID() != null)
            {
                value = ctx.ID().GetText();
                value = $"{functionName}.{value}";
                Dictionary<string, VariableData> variables = functions[functionName].Variables;
                if (variables.ContainsKey(value) && variables[value].VarType.IndexOf("array") != -1)
                {
                    varType = variables[value].VarType;
                }
                else
                {
                    varType = "ID";
                }
                
            }
        }

        public override void ExitNumber([NotNull] KoLangParser.NumberContext ctx)
        {
            if (ctx.INT() != null)
            {
                string tmp = ctx.INT().GetText().Replace("+", "");
                numbers.Push(tmp);
                value = tmp;
                varType = varType != "double" ? "i32" : "double";
            }
            if (ctx.REAL() != null)
            {
                string tmp = ctx.REAL().GetText().Replace("+", "");
                numbers.Push(tmp);
                value = tmp;
                varType = "double";
            }
            if (ctx.ID() != null)
            {
                string id = ctx.ID().GetText();
                id = $"{functionName}.{id}";
                Dictionary<string, VariableData> arguments = functions[functionName].Arguments;
                Dictionary<string, VariableData> variables = functions[functionName].Variables;
                if (!variables.ContainsKey(id) && !arguments.ContainsKey(id))
                    throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Variable {id} not declared!");
                string tmp;
                string tmpVarType;
                if(variables.ContainsKey(id))
                {
                    tmp = $"%{id}.{variables[id].Id}";
                    tmpVarType = variables[id].VarType;
                }
                else
                {
                    tmp = $"%{id}.{arguments[id].Id}";
                    tmpVarType = arguments[id].VarType;
                }
                numbers.Push(tmp);
                value = tmp;
                if ((variables.ContainsKey(id) && variables[id].VarType == "string")
                    || (arguments.ContainsKey(id) && arguments[id].VarType == "string"))
                    throw new KoLangDataTypeException($"Error at line: {ctx.Start.Line}. Variable {id} is of type string, expected i32 or double");
                varType = varType != "double" ? tmpVarType : "double";
            }
        }

        public override void ExitArrayVal([NotNull] KoLangParser.ArrayValContext ctx)
        {
            if (ctx.INT() != null)
            {
                numbers.Push(ctx.INT().GetText());
                varType = varType != "array double" ? "array i32" : "array double";
            }
            if (ctx.REAL() != null)
            {
                numbers.Push(ctx.REAL().GetText());
                varType = "array double";
            }
        }

        public override void ExitArrayAssignItem([NotNull] KoLangParser.ArrayAssignItemContext ctx)
        {
            if (ctx.ID() != null && ctx.INT() != null)
            {
                string id = ctx.ID().GetText();
                id = $"{functionName}.{id}";
                Dictionary<string, VariableData> variables = functions[functionName].Variables;
                if (!variables.ContainsKey(id))
                    throw new KoLangDeclarationException($"Error at line: {ctx.Start.Line}. Array {id} is not declared!");

                int number = int.Parse(ctx.INT().GetText());
                if (number < 0)
                    throw new KoLangArgumentOutOfRangeException($"Error at line: {ctx.Start.Line}. Bad array index!");
                if (!variables[id].VarType.Contains("array"))
                    throw new KoLangDataTypeException($"Error at line: {ctx.Start.Line}. {id} is not an array!");
                value = $"{id}.{variables[id].Id} {ctx.INT().GetText()}";
                varType = variables[id].VarType[6..];
            }
        }

        public override void ExitProgram([NotNull] KoLangParser.ProgramContext ctx)
        {
            string generated = generator.Generate();
            File.WriteAllText("KoLang.ll", generated);
            Console.WriteLine($"{generated}");

            Process p = Process.Start("wsl", "clang KoLang.ll");
            p.WaitForExit();
        }
    }
}