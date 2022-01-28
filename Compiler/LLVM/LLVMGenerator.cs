using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler
{
    public class LLVMGenerator
    {
        private string header_text;
        private int str_i;
        private int current_if;
        private int currentWhile;

        public LLVMGenerator()
        {
            MainText = new StringBuilder();
            FunctionText = new StringBuilder();
            RuntimeExpressions = new StringBuilder();
            DeclaredFunctions = new StringBuilder();
            IsMain = true;
            header_text = "";
            str_i = current_if = currentWhile = 0;
            IfIterators = new Stack<IfIteratorData>();
            WhileIterators = new Stack<int>();
        }

        private StringBuilder MainText { get; set; }
        private StringBuilder FunctionText { get; set; }
        private StringBuilder RuntimeExpressions { get; set; }
        private StringBuilder DeclaredFunctions { get; set; }
        public bool IsMain { get; set; }
        private Stack<IfIteratorData> IfIterators { get; set; }
        private Stack<int> WhileIterators { get; set; }

        public void DeclareVar(string var, int id, string varType, string value)
        {
            if (varType == "string")
            {
                header_text += $"@{var}.{id} = private constant [{value.Length+2} x i8] c\"{value}\\0A\\00\"\n";
            } 
            else if (varType == "i32" || varType == "double")
            {
                AddCode($"  %{var}.{id} = alloca {varType}\n");
                AddCode($"  store {varType} {value}, {varType}* %{var}.{id}\n");
            }
            else if (varType == "ID")
            {
                int index = value.IndexOf(' ');
                string varId = value.Substring(0, index);
                string valueType = value[(index + 1)..];

                if(valueType == "string")
                {
                    varId = $"@{varId}";
                    string seek = $"{varId} = private constant [";
                    index = header_text.IndexOf(seek);
                    if (index < 0)
                        throw new KoLangDeclarationException($"Variable: {varId[1..]} is not declared!");
                    index += seek.Length;
                    seek = header_text[index..];
                    int index2 = seek.IndexOf(' ');

                    string stringSize = seek.Substring(0, index2);
                    valueType = $"[{stringSize} x i8]";
                    index = seek.IndexOf("c\"", index2);
                    index2 = seek.IndexOf("\n", index2);
                    value = seek[index..index2];

                    header_text += $"@{var}.{id} = private constant {valueType} {value}\n";
                } 
                else
                {
                    varId = $"%{varId}";
                    string seek = $"{varId} = alloca";
                    index = GetCurrentScope().IndexOf(seek);
                    //if (index < 0)
                    //    throw new KoLangDeclarationException($"Variable: {varId[1..]} is not declared!");

                    AddCode($"  %{var}.{id} = alloca {valueType}\n");
                    if(varId.Contains('%') && varId.Contains('.'))
                    {
                        string tmp = $"%expr{str_i++}";
                        AddCode($"  {tmp} = load {valueType}, {valueType}* {varId}\n");
                        varId = tmp;
                    }
                    AddCode($"  store {valueType} {varId}, {valueType}* %{var}.{id}\n");
                }
            }
        }

        public void ChangeValue(string var, int id, string varType, string value)
        {
            AddCode($"  store {varType} {value}, {varType}* %{var}.{id}\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="var">name of variable to declare</param>
        /// <param name="id">id of variable to declare</param>
        /// <param name="varType"></param>
        /// <param name="value">string "arrayName itemNumber"</id></param>
        public void DeclareVarFromArrayItem(string var, int id, string varType, string value, bool changeValue = false)
        {
            string varId = $"%{var}.{id}";
            int index = value.IndexOf(' ');
            string arrayName =  value.Substring(0, index);
            string arrayElementId = value[(index + 1)..];

            string seek = $"@{arrayName} = global [";
            index = header_text.IndexOf(seek);

            if(index < 0)
                throw new KoLangDeclarationException($"Variable {arrayName} is not recognized as array or is not declared!");

            index += seek.Length;
            int index2 = header_text.IndexOf(' ', index);
            seek = header_text[index..index2];

            int givenIndex = int.Parse(arrayElementId);
            int arraySize = int.Parse(seek);
            if (arraySize - 1 < givenIndex)
                throw new KoLangArgumentOutOfRangeException($"Size of array is {arraySize}!");

            string arrayType = $"[{arraySize} x {varType}]";

            AddCode($"  %expr{str_i++} = getelementptr inbounds {arrayType}, {arrayType}* @{arrayName}, i32 0, i32 {givenIndex}\n");
            AddCode($"  %expr{str_i} = load {varType}, {varType}* %expr{str_i - 1}\n");
            if (!changeValue)
                AddCode($"  {varId} = alloca {varType}\n");

            AddCode($"  store {varType} %expr{str_i++}, {varType}* {varId}\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="var">name of variable</param>
        /// <param name="id">new id of variable</param>
        /// <param name="arrayType">dataType of items in array</param>
        /// <param name="value">all array items in llvm</param>
        public void DeclareArray(string var, int id, string arrayType, string value)
        {
            header_text += $"@{var}.{id} = global {arrayType} {value}\n";
        }

        public void ChangeArrayItemValue(string arrayId, int elementId, string arrayType, string valueType, string value)
        {
            string seek = $"{arrayId} = global [";
            int index = header_text.IndexOf(seek);
            if (index < 0)
                throw new KoLangDeclarationException($"Something went wrong! Array was not declared but is in memory!");
            
            index += seek.Length;
            int index2 = header_text.IndexOf(' ', index);
            int arraySize = int.Parse(header_text[index..index2]);
            
            if (arraySize - 1 < elementId)
                throw new KoLangArgumentOutOfRangeException($"Size of array is {arraySize}!");

            if (arrayType != valueType) // cast value to arrayType
            {
                if (value.Contains('%') && value.Contains('.'))
                {
                    AddCode($"  %expr{str_i} = load {valueType}, {valueType}* {value}\n");
                    value = $"%expr{str_i++}";
                }
                string newValue = $"%expr{str_i++}";
                string operation = arrayType == "i32" ? "fptosi" : "sitofp";
                AddCode($"  {newValue} = {operation} {valueType} {value} to {arrayType}\n");
                value = newValue;
            }

            string pointer = $"%expr{str_i++}";
            AddCode($"  {pointer} = getelementptr inbounds [{arraySize} x {arrayType}], " +
                $"[{arraySize} x {arrayType}]* {arrayId}, i32 0, i32 {elementId}\n");

            if (value.Contains('%') && value.Contains('.'))
            {
                AddCode($"  %expr{str_i} = load {arrayType}, {arrayType}* {value}\n");
                value = $"%expr{str_i++}";
            }
                

            AddCode($"  store {arrayType} {value}, {arrayType}* {pointer}\n");
        }

        public void Print(string value, int id, string varType, string idVarType)
        {
            if (varType == "ID")
            {
                string seek = $"@{value}.{id} = private constant ";
                int index = header_text.IndexOf(seek);
                index += seek.Length;
                string substring;
                if (header_text.Length > index && header_text[index] == '[')
                {
                    int index2 = header_text.IndexOf("]", index);
                    substring = header_text.Substring(index, index2 - index + 1);
                    AddCode($"  %expr{str_i} = getelementptr inbounds {substring}, {substring}* @{value}.{id}, i32 0, i32 0\n");
                    AddCode($"  call i32 (i8*, ...) @printf(i8* %expr{str_i++})\n");

                } else // i32 / double 
                {
                    int sizeOfType;
                    string pattern;
                    if (idVarType == "double")
                    {
                        sizeOfType = 5;
                        pattern = "%lf";
                    }
                    else
                    {
                        sizeOfType = 4;
                        pattern = "%d";
                    }

                    AddCode($"  %expr{str_i++} = getelementptr inbounds [{sizeOfType} x i8], [{sizeOfType} x i8]* @.{idVarType}, i32 0, i32 0\n");
                    AddCode($"  %expr{str_i} = load {idVarType}, {idVarType}* %{value}.{id}\n");
                    AddCode($"  call i32 (i8*, ...) @printf(i8* %expr{str_i-1}, {idVarType} %expr{str_i++})\n");

                    BuilderContains(RuntimeExpressions, $"@.{idVarType} =", 
                        $"@.{idVarType} = private unnamed_addr constant [{sizeOfType} x i8] c\"{pattern}\\0A\\00\"\n");
                }
            }
            else if(varType == "string")
            {
                header_text += $"@val.{str_i} = private constant [{value.Length + 2} x i8] c\"{value}\\0A\\00\"\n";
                AddCode($"  %expr{str_i} = getelementptr inbounds [{value.Length + 2} x i8], [{value.Length + 2} x i8]* @val.{str_i}, i32 0, i32 0\n");
                AddCode($"  call i32 (i8*, ...) @printf(i8* %expr{str_i++})\n");
            }
            else
            {
                int sizeOfType = varType == "i32" ? 4 : 5;
                AddCode($"  %expr{str_i} = getelementptr inbounds [{sizeOfType} x i8], [{sizeOfType} x i8]* @.{varType}, i32 0, i32 0\n");
                AddCode($"  call i32 (i8*, ...) @printf(i8* %expr{str_i++}, {varType} {value})\n");

                string pattern = varType == "i32" ? "%d" : "%lf";
                BuilderContains(RuntimeExpressions, $"@.{varType} =",
                        $"@.{varType} = private unnamed_addr constant [{sizeOfType} x i8] c\"{pattern}\\0A\\00\"\n");
            }

            BuilderContains(DeclaredFunctions, "declare i32 @printf", "declare i32 @printf(i8*, ...)\n");
        }

        public void PrintArray(string var, int id, int? elementId, bool printAll = true)
        {
            string seek = $"@{var}.{id} = global [";
            int index = header_text.IndexOf(seek);
            if (index < 0)
                throw new KoLangDeclarationException($"Array {var} not declared!");

            index += seek.Length;
            int index2 = header_text.IndexOf(' ', index);
            seek = header_text[index..index2];
            
            int arraySize = int.Parse(seek);
            index = header_text.IndexOf(']', index2);
            index2 += 3;
            string arrayType = header_text[index2..index];

            if (elementId == null) // print all items
            {
                AddCode($"  %expr{str_i} = getelementptr inbounds [3 x i8], [3 x i8]* @.arrayopen, i32 0, i32 0\n");
                AddCode($"  call i32 (i8*, ...) @printf(i8* %expr{str_i++})\n");
                for (int i = 0; i < arraySize; i++)
                {
                    PrintArray(var, id, i);
                    if(i + 1 != arraySize)
                    {
                        AddCode($"  %expr{str_i} = getelementptr inbounds [3 x i8], [3 x i8]* @.commaseparator, i32 0, i32 0\n");
                        AddCode($"  call i32 (i8*, ...) @printf(i8* %expr{str_i++})\n");
                    }
                }
                AddCode($"  %expr{str_i} = getelementptr inbounds [4 x i8], [4 x i8]* @.arrayclose, i32 0, i32 0\n");
                AddCode($"  call i32 (i8*, ...) @printf(i8* %expr{str_i++})\n");

                BuilderContains(RuntimeExpressions, "@.arrayopen", 
                    "@.arrayopen = private unnamed_addr constant [3 x i8] c\"[ \\00\"\n");
                BuilderContains(RuntimeExpressions, "@.arrayclose",
                    "@.arrayclose = private unnamed_addr constant [4 x i8] c\" ]\\0A\\00\"\n");
                BuilderContains(RuntimeExpressions, "@.commaseparator",
                    "@.commaseparator = private unnamed_addr constant [3 x i8] c\", \\00\"\n");

                int size = arrayType == "i32" ? 3 : 4;
                string pattern = arrayType == "i32" ? "%d" : "%lf";
                BuilderContains(RuntimeExpressions, $"@.{arrayType}scanf =",
                    $"@.{arrayType}scanf = private unnamed_addr constant [{size} x i8] c\"{pattern}\\00\"\n");
                
            }
            else // print chosen item
            {
                if (arraySize <= elementId || elementId < 0)
                    throw new KoLangArgumentOutOfRangeException($"Attempted to access {var}[{elementId}], but array length is {arraySize}!");

                string expr = $"%expr{str_i++}";
                string scanf = printAll == true ? "scanf" : "";
                int printSize = arrayType == "i32" ? 3 : 4;
                if (!printAll)
                {
                    printSize++;
                }

                AddCode($"  {expr} = getelementptr inbounds [{arraySize} x {arrayType}], " +
                    $"[{arraySize} x {arrayType}]* @{var}.{id}, i32 0, i32 {elementId}\n");

                AddCode($"  %expr{str_i++} = load {arrayType}, {arrayType}* {expr}\n");

                AddCode($"  %expr{str_i} = getelementptr inbounds [{printSize} x i8], [{printSize} x i8]* " +
                    $"@.{arrayType}{scanf}, i32 0, i32 0\n");

                AddCode($"  call i32 (i8*, ...) @printf(i8* %expr{str_i}, {arrayType} %expr{str_i - 1})\n");
                str_i++;

                if(!printAll)
                {
                    string printType = printSize == 4 ? "%d" : "%lf";
                    BuilderContains(RuntimeExpressions, $"@.{arrayType} =",
                    $"@.{arrayType} = private unnamed_addr constant [{printSize} x i8] c\"{printType}\\0A\\00\"\n");
                }
            }

            BuilderContains(DeclaredFunctions, "declare i32 @printf", "declare i32 @printf(i8*, ...)\n");
        }

        /// <summary>
        /// Scan works for i32 and double values
        /// </summary>
        /// <param name="var"></param>
        /// <param name="id"></param>
        public void Scan(string var, int id, bool changeValue = false)
        {
            string dataType = "double";
            if (!changeValue)
                AddCode($"  %{var}.{id} = alloca {dataType}\n");
            AddCode($"  %expr{str_i} = getelementptr inbounds [4 x i8], [4 x i8]* @.{dataType}scanf, i32 0, i32 0\n");
            AddCode($"  call i32 (i8*, ...) @scanf(i8* %expr{str_i++}, {dataType}* %{var}.{id})\n");

            BuilderContains(RuntimeExpressions, "@.doublescanf", 
                "@.doublescanf = private unnamed_addr constant [4 x i8] c\"%lf\\00\"\n");
            BuilderContains(DeclaredFunctions, "declare i32 @scanf", "declare i32 @scanf(i8*, ...)\n");
        }

        public string Calculate(string valOne, string valTwo, string varType, string operation)
        {
            string isDouble = "";
            if (varType == "double")
            {
                isDouble = "f";
                if (!valOne.Contains('%') && !valOne.Contains('.')) valOne += ".0";
                if (!valTwo.Contains('%') && !valTwo.Contains('.')) valTwo += ".0";

                CastToDouble(ref valOne);
                CastToDouble(ref valTwo);  
            }

            if (operation == "div")
                isDouble = isDouble == "f" ? isDouble : "s";

            if(valOne.Contains('%') && valOne.Contains('.'))
            {
                string tmp = $"%expr{str_i++}";
                AddCode($"  {tmp} = load {varType}, {varType}* {valOne}\n");
                valOne = tmp;
            }
            if (valTwo.Contains('%') && valTwo.Contains('.'))
            {
                string tmp = $"%expr{str_i++}";
                AddCode($"  {tmp} = load {varType}, {varType}* {valTwo}\n");
                valTwo = tmp;
            }

            string var = $"%expr{str_i++}";
            AddCode($"  {var} = {isDouble}{operation} {varType} {valTwo}, {valOne}\n");
            return var;
        }

        #region IfMethods
        public void AddIfToStack()
        {
            IfIterators.Push(new IfIteratorData(current_if++));
        }

        public void IfComparision(string[] comparators, string compOperation, bool isElse)
        {
            // make compare values the same type i32 or double
            CompareHelper(ref comparators, ref compOperation);

            IfIteratorData data = IfIterators.Pop();

            string cmpType = comparators[1] == "i32" ? "i" : "f";
            AddCode($"  %ifcomp{data.IfIterator}.{data.SubIfIterator} = {cmpType}cmp {compOperation} {comparators[1]} {comparators[0]}, {comparators[2]}\n");
            if (isElse)
            {
                AddCode($"  br i1 %ifcomp{data.IfIterator}.{data.SubIfIterator}, label %if{data.IfIterator}.{data.SubIfIterator}, label %if{data.IfIterator}.{data.SubIfIterator + 1}\n");
            }
            else
            {
                AddCode($"  br i1 %ifcomp{data.IfIterator}.{data.SubIfIterator}, label %if{data.IfIterator}.{data.SubIfIterator}, label %endif{data.IfIterator}\n");
            }
            
            AddCode($"if{data.IfIterator}.{data.SubIfIterator++}:\n");
            IfIterators.Push(data);
        }

        public void EndIf(bool isElse = false)
        {
            IfIteratorData data = IfIterators.Pop();
            if (!isElse)
            {
                AddCode($"  br label %endif{data.IfIterator}\n");
                AddCode($"endif{data.IfIterator}:\n");
            }
        }

        public void EnterElse()
        {
            IfIteratorData data = IfIterators.Pop();
            AddCode($"  br label %endif{data.IfIterator}\n");
            AddCode($"if{data.IfIterator}.{data.SubIfIterator++}:\n");
            IfIterators.Push(data);
        }

        public void ExitElse(bool isNested = false)
        {
            IfIteratorData data = IfIterators.Pop();
            AddCode($"  br label %endif{data.IfIterator}\n");
            AddCode($"endif{data.IfIterator}:\n");
            IfIterators.Push(data);
        }
        #endregion

        #region WhileMethods
        public void AddWhileToStack()
        {
            WhileIterators.Push(currentWhile++);
        }

        public void WhileComparision(string[] comparators, string compOperation)
        {
            // make compare values the same type i32 or double
            CompareHelper(ref comparators, ref compOperation, false);
            string cmpType = comparators[1] == "i32" ? "i" : "f";
            int currentWhile = WhileIterators.Pop();
            AddCode($"  br label %condwhile{currentWhile}\n");
            AddCode($"condwhile{currentWhile}:\n");

            LoadVarValue(ref comparators, true);
            AddCode($"  %whilecomp{currentWhile} = {cmpType}cmp {compOperation} {comparators[1]} {comparators[0]}, {comparators[2]}\n");
            AddCode($"  br i1 %whilecomp{currentWhile}, label %while{currentWhile}, label %endwhile{currentWhile}\n");
            AddCode($"while{currentWhile}:\n");
            WhileIterators.Push(currentWhile);


        }

        public void EndWhile()
        {
            int currentWhile = WhileIterators.Pop();
            AddCode($"  br label %condwhile{currentWhile}\n");
            AddCode($"endwhile{currentWhile}:\n");
        }
        #endregion

        #region FunctionMethods
        public void EnterFunction(string id, FunctionData data)
        {
            AddCode($"\ndefine {data.ReturnType} @{id}(");
            int i = 0;
            foreach(var arg in data.Arguments)
            {
                AddCode($"{arg.Value.VarType}* %{arg.Key}.0");
                if (i+1 != data.Arguments.Count)
                    FunctionText.Append($", ");
                i++;
            }
            AddCode(") nounwind {\n");
        }

        public void ExitFunction(string returnType, string returnValue)
        {
            AddCode($"  ret {returnType} {returnValue}\n"); // TODO better return handling
            AddCode("}\n");
        }

        public string LoadAllocaToReturn(string var, string varType)
        {
            string newValue = $"%expr{str_i++}";
            AddCode($"  {newValue} = load {varType}, {varType}* {var}\n");
            return newValue;
        }

        public string CastReturnValue(string value, string returnType)
        {
            string newValue = $"%expr{str_i++}";
            if (returnType == "double")
            {
                AddCode($"  {newValue} = sitofp i32 {value} to double\n");
            } 
            else if (returnType == "i32")
            {
                AddCode($"  {newValue} = fptosi double {value} to i32\n");
            }
            return newValue;
        }

        public void CallFunction(string functionName, FunctionData data, List<string> functionArguments)
        {
            AddCode($"  call {data.ReturnType} (");
            int i = 0;
            foreach (var arg in data.Arguments)
            {
                if (functionArguments.Count <= i)
                {
                    throw new KoLangDeclarationException($"Missing argument(s) in function call!");
                }
                AddCode($"{arg.Value.VarType}*");
                if (i + 1 != data.Arguments.Count)
                    AddCode($", ");
                i++;
            }
            AddCode($") @{functionName}(");
            i = 0;
            foreach (var arg in data.Arguments)
            {
                if(functionArguments.Count <= i)
                {
                    throw new KoLangDeclarationException($"Missing argument(s) in function call!");
                }
                AddCode($"{arg.Value.VarType}* %{functionArguments[i]}");
                if (i + 1 != data.Arguments.Count)
                    AddCode($", ");
                i++;
            }

            AddCode($")\n");
        }

        public string GetReturnValue()
        {
            string val = $"%expr{str_i++}";
            AddCode($"  {val} = ");
            return val;
        }
        #endregion

        public string Generate()
        {
            StringBuilder llvmText = new StringBuilder("target triple = \"x86_64-pc-linux-gnu\"\n\n");
            llvmText.Append(RuntimeExpressions);
            llvmText.Append("\n");
            llvmText.Append(header_text);
            llvmText.Append(FunctionText);
            llvmText.Append("\ndefine i32 @main() nounwind {\n");
            llvmText.Append("entry:\n");
            llvmText.Append(MainText);
            llvmText.Append("  ret i32 0\n");
            llvmText.Append("}\n\n");
            llvmText.Append(DeclaredFunctions);

            return llvmText.ToString();
        }

        private void CastToDouble(ref string val)
        {
            if (val.Contains('%'))
            {
                string seek = $"{val} = alloca ";
                int index = GetCurrentScope().IndexOf(seek);

                if (index < 0) // seek is in expr, in some cases need to cast i32 to double
                {
                    seek = $"{val} = sub ";
                    index = GetCurrentScope().IndexOf(seek); 
                }
                if (index < 0)
                {
                    seek = $"{val} = add ";
                    index = GetCurrentScope().IndexOf(seek);
                }
                if (!IsMain && index < 0) // look in function arguments
                {
                    seek = $"* {val}";
                    index = GetCurrentScope().IndexOf(seek) - 3 - seek.Length;
                }

                if (index >= 0)
                {
                    index += seek.Length;
                    string tmp = GetCurrentScope().Substring(index, 3);
                    if (tmp == "i32")
                    {
                        if(val.Contains('.'))
                        {
                            tmp = $"%expr{str_i++}";
                            AddCode($"  {tmp} = load i32, i32* {val}\n");
                            val = tmp;
                        }
                        tmp = $"%expr{str_i++}";
                        AddCode($"  {tmp} = sitofp i32 {val} to double\n");
                        val = tmp;
                    }
                }
            }
        }

        private void CompareHelper(ref string[] comparators, ref string compOperation, bool isIf = true)
        {
            if (comparators[1] != comparators[3])
            {
                if (comparators[1] == "double")
                {
                    
                    if (!comparators[2].Contains('%')) comparators[2] += ".0";
                    CastToDouble(ref comparators[2]);
                    comparators[3] = "double";
                }
                else
                {
                    if (!comparators[0].Contains('%')) comparators[0] += ".0";
                    CastToDouble(ref comparators[0]);
                    comparators[1] = "double";
                }
            }
            LoadVarValue(ref comparators, isIf);

            
            // choose llvm operation
            switch (compOperation)
            {
                case "<":
                    compOperation = comparators[1] == "i32" ? "slt" : "olt";
                    break;
                case ">":
                    compOperation = comparators[1] == "i32" ? "sgt" : "ogt";
                    break;
                case "<=":
                    compOperation = comparators[1] == "i32" ? "sle" : "ole";
                    break;
                case ">=":
                    compOperation = comparators[1] == "i32" ? "sge" : "oge";
                    break;
                case "==":
                    compOperation = comparators[1] == "i32" ? "eq" : "oeq";
                    break;
                case "!=":
                    compOperation = comparators[1] == "i32" ? "ne" : "one";
                    break;
            }
        }

        private void LoadVarValue(ref string[] comparators, bool isIf = true)
        {
            if (isIf && comparators[0].Contains('%') && comparators[0].Contains('.'))
            {
                string tmp = $"%expr{str_i++}";
                AddCode($"  {tmp} = load {comparators[1]}, {comparators[1]}* {comparators[0]}\n");
                comparators[0] = tmp;
            }
            if (isIf && comparators[2].Contains('%') && comparators[2].Contains('.'))
            {
                string tmp = $"%expr{str_i++}";
                AddCode($"  {tmp} = load {comparators[3]}, {comparators[3]}* {comparators[2]}\n");
                comparators[2] = tmp;
            }
        }

        private void AddCode(string code)
        {
            if (IsMain)
            {
                MainText.Append(code);
            }
            else
            {
                FunctionText.Append(code);
            }
        }

        private string GetCurrentScope()
        {
            if (IsMain) return MainText.ToString();
            return FunctionText.ToString();
        }
        
        private void BuilderContains(StringBuilder sb, string contain, string insert)
        {
            if (!sb.ToString().Contains(contain))
                sb.Append(insert);
        }

        public void TempHelper(string moreInfo = "")
        {
            AddCode($"{moreInfo}\n");
        }
    }
}