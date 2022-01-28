//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from KoLang.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="KoLangParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface IKoLangListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] KoLangParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] KoLangParser.ProgramContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>print</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrint([NotNull] KoLangParser.PrintContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>print</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrint([NotNull] KoLangParser.PrintContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>printArrayItem</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrintArrayItem([NotNull] KoLangParser.PrintArrayItemContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>printArrayItem</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrintArrayItem([NotNull] KoLangParser.PrintArrayItemContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>read</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRead([NotNull] KoLangParser.ReadContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>read</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRead([NotNull] KoLangParser.ReadContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>assign</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssign([NotNull] KoLangParser.AssignContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>assign</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssign([NotNull] KoLangParser.AssignContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>assignArrayItemToID</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignArrayItemToID([NotNull] KoLangParser.AssignArrayItemToIDContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>assignArrayItemToID</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignArrayItemToID([NotNull] KoLangParser.AssignArrayItemToIDContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>changeArrayItemValue</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChangeArrayItemValue([NotNull] KoLangParser.ChangeArrayItemValueContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>changeArrayItemValue</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChangeArrayItemValue([NotNull] KoLangParser.ChangeArrayItemValueContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>assignArray</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignArray([NotNull] KoLangParser.AssignArrayContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>assignArray</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignArray([NotNull] KoLangParser.AssignArrayContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>ifStatement</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfStatement([NotNull] KoLangParser.IfStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ifStatement</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfStatement([NotNull] KoLangParser.IfStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>while</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhile([NotNull] KoLangParser.WhileContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>while</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhile([NotNull] KoLangParser.WhileContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>function</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunction([NotNull] KoLangParser.FunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>function</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunction([NotNull] KoLangParser.FunctionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>invokeFunction</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInvokeFunction([NotNull] KoLangParser.InvokeFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>invokeFunction</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInvokeFunction([NotNull] KoLangParser.InvokeFunctionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>assignFunction</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignFunction([NotNull] KoLangParser.AssignFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>assignFunction</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignFunction([NotNull] KoLangParser.AssignFunctionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValue([NotNull] KoLangParser.ValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValue([NotNull] KoLangParser.ValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.arrayAssignItem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayAssignItem([NotNull] KoLangParser.ArrayAssignItemContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.arrayAssignItem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayAssignItem([NotNull] KoLangParser.ArrayAssignItemContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>single</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSingle([NotNull] KoLangParser.SingleContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>single</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSingle([NotNull] KoLangParser.SingleContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>add</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAdd([NotNull] KoLangParser.AddContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>add</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAdd([NotNull] KoLangParser.AddContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>parent</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParent([NotNull] KoLangParser.ParentContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parent</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParent([NotNull] KoLangParser.ParentContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>multiply</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultiply([NotNull] KoLangParser.MultiplyContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>multiply</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultiply([NotNull] KoLangParser.MultiplyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumber([NotNull] KoLangParser.NumberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumber([NotNull] KoLangParser.NumberContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.stringConcat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStringConcat([NotNull] KoLangParser.StringConcatContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.stringConcat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStringConcat([NotNull] KoLangParser.StringConcatContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.concatVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConcatVal([NotNull] KoLangParser.ConcatValContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.concatVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConcatVal([NotNull] KoLangParser.ConcatValContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.arrayVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayVal([NotNull] KoLangParser.ArrayValContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.arrayVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayVal([NotNull] KoLangParser.ArrayValContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.whileComp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileComp([NotNull] KoLangParser.WhileCompContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.whileComp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileComp([NotNull] KoLangParser.WhileCompContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.elseifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElseifStatement([NotNull] KoLangParser.ElseifStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.elseifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElseifStatement([NotNull] KoLangParser.ElseifStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.elseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElseStatement([NotNull] KoLangParser.ElseStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.elseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElseStatement([NotNull] KoLangParser.ElseStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.comparision"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComparision([NotNull] KoLangParser.ComparisionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.comparision"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComparision([NotNull] KoLangParser.ComparisionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.compValueFirst"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompValueFirst([NotNull] KoLangParser.CompValueFirstContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.compValueFirst"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompValueFirst([NotNull] KoLangParser.CompValueFirstContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.compValueSecond"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompValueSecond([NotNull] KoLangParser.CompValueSecondContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.compValueSecond"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompValueSecond([NotNull] KoLangParser.CompValueSecondContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.callFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCallFunction([NotNull] KoLangParser.CallFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.callFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCallFunction([NotNull] KoLangParser.CallFunctionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.functionArguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionArguments([NotNull] KoLangParser.FunctionArgumentsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.functionArguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionArguments([NotNull] KoLangParser.FunctionArgumentsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.functionArg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionArg([NotNull] KoLangParser.FunctionArgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.functionArg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionArg([NotNull] KoLangParser.FunctionArgContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.givenFunctionArguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGivenFunctionArguments([NotNull] KoLangParser.GivenFunctionArgumentsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.givenFunctionArguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGivenFunctionArguments([NotNull] KoLangParser.GivenFunctionArgumentsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.givenFunctionArg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGivenFunctionArg([NotNull] KoLangParser.GivenFunctionArgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.givenFunctionArg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGivenFunctionArg([NotNull] KoLangParser.GivenFunctionArgContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.functionArgType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionArgType([NotNull] KoLangParser.FunctionArgTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.functionArgType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionArgType([NotNull] KoLangParser.FunctionArgTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.functionReturnType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionReturnType([NotNull] KoLangParser.FunctionReturnTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.functionReturnType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionReturnType([NotNull] KoLangParser.FunctionReturnTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.operatorOne"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperatorOne([NotNull] KoLangParser.OperatorOneContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.operatorOne"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperatorOne([NotNull] KoLangParser.OperatorOneContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.operatorTwo"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperatorTwo([NotNull] KoLangParser.OperatorTwoContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.operatorTwo"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperatorTwo([NotNull] KoLangParser.OperatorTwoContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.compareOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompareOperator([NotNull] KoLangParser.CompareOperatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.compareOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompareOperator([NotNull] KoLangParser.CompareOperatorContext context);
}
