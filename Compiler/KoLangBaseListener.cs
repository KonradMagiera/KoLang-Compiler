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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IKoLangListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class KoLangBaseListener : IKoLangListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProgram([NotNull] KoLangParser.ProgramContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProgram([NotNull] KoLangParser.ProgramContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>print</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPrint([NotNull] KoLangParser.PrintContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>print</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPrint([NotNull] KoLangParser.PrintContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>printArrayItem</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPrintArrayItem([NotNull] KoLangParser.PrintArrayItemContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>printArrayItem</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPrintArrayItem([NotNull] KoLangParser.PrintArrayItemContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>read</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRead([NotNull] KoLangParser.ReadContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>read</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRead([NotNull] KoLangParser.ReadContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>assign</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssign([NotNull] KoLangParser.AssignContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>assign</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssign([NotNull] KoLangParser.AssignContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>assignArrayItemToID</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignArrayItemToID([NotNull] KoLangParser.AssignArrayItemToIDContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>assignArrayItemToID</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignArrayItemToID([NotNull] KoLangParser.AssignArrayItemToIDContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>changeArrayItemValue</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterChangeArrayItemValue([NotNull] KoLangParser.ChangeArrayItemValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>changeArrayItemValue</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitChangeArrayItemValue([NotNull] KoLangParser.ChangeArrayItemValueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>assignArray</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignArray([NotNull] KoLangParser.AssignArrayContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>assignArray</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignArray([NotNull] KoLangParser.AssignArrayContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>ifStatement</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIfStatement([NotNull] KoLangParser.IfStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>ifStatement</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIfStatement([NotNull] KoLangParser.IfStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>while</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterWhile([NotNull] KoLangParser.WhileContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>while</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitWhile([NotNull] KoLangParser.WhileContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>function</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunction([NotNull] KoLangParser.FunctionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>function</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunction([NotNull] KoLangParser.FunctionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>invokeFunction</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInvokeFunction([NotNull] KoLangParser.InvokeFunctionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>invokeFunction</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInvokeFunction([NotNull] KoLangParser.InvokeFunctionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>assignFunction</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignFunction([NotNull] KoLangParser.AssignFunctionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>assignFunction</c>
	/// labeled alternative in <see cref="KoLangParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignFunction([NotNull] KoLangParser.AssignFunctionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterValue([NotNull] KoLangParser.ValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitValue([NotNull] KoLangParser.ValueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.arrayAssignItem"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArrayAssignItem([NotNull] KoLangParser.ArrayAssignItemContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.arrayAssignItem"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArrayAssignItem([NotNull] KoLangParser.ArrayAssignItemContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>single</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSingle([NotNull] KoLangParser.SingleContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>single</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSingle([NotNull] KoLangParser.SingleContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>add</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAdd([NotNull] KoLangParser.AddContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>add</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAdd([NotNull] KoLangParser.AddContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>parent</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParent([NotNull] KoLangParser.ParentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>parent</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParent([NotNull] KoLangParser.ParentContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>multiply</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultiply([NotNull] KoLangParser.MultiplyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>multiply</c>
	/// labeled alternative in <see cref="KoLangParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultiply([NotNull] KoLangParser.MultiplyContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.number"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNumber([NotNull] KoLangParser.NumberContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.number"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNumber([NotNull] KoLangParser.NumberContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.stringConcat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStringConcat([NotNull] KoLangParser.StringConcatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.stringConcat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStringConcat([NotNull] KoLangParser.StringConcatContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.concatVal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConcatVal([NotNull] KoLangParser.ConcatValContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.concatVal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConcatVal([NotNull] KoLangParser.ConcatValContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.arrayVal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArrayVal([NotNull] KoLangParser.ArrayValContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.arrayVal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArrayVal([NotNull] KoLangParser.ArrayValContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.whileComp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterWhileComp([NotNull] KoLangParser.WhileCompContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.whileComp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitWhileComp([NotNull] KoLangParser.WhileCompContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.elseifStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterElseifStatement([NotNull] KoLangParser.ElseifStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.elseifStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitElseifStatement([NotNull] KoLangParser.ElseifStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.elseStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterElseStatement([NotNull] KoLangParser.ElseStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.elseStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitElseStatement([NotNull] KoLangParser.ElseStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.comparision"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterComparision([NotNull] KoLangParser.ComparisionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.comparision"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitComparision([NotNull] KoLangParser.ComparisionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.compValueFirst"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCompValueFirst([NotNull] KoLangParser.CompValueFirstContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.compValueFirst"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCompValueFirst([NotNull] KoLangParser.CompValueFirstContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.compValueSecond"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCompValueSecond([NotNull] KoLangParser.CompValueSecondContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.compValueSecond"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCompValueSecond([NotNull] KoLangParser.CompValueSecondContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.callFunction"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCallFunction([NotNull] KoLangParser.CallFunctionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.callFunction"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCallFunction([NotNull] KoLangParser.CallFunctionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.functionArguments"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionArguments([NotNull] KoLangParser.FunctionArgumentsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.functionArguments"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionArguments([NotNull] KoLangParser.FunctionArgumentsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.functionArg"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionArg([NotNull] KoLangParser.FunctionArgContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.functionArg"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionArg([NotNull] KoLangParser.FunctionArgContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.givenFunctionArguments"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterGivenFunctionArguments([NotNull] KoLangParser.GivenFunctionArgumentsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.givenFunctionArguments"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitGivenFunctionArguments([NotNull] KoLangParser.GivenFunctionArgumentsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.givenFunctionArg"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterGivenFunctionArg([NotNull] KoLangParser.GivenFunctionArgContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.givenFunctionArg"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitGivenFunctionArg([NotNull] KoLangParser.GivenFunctionArgContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.functionArgType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionArgType([NotNull] KoLangParser.FunctionArgTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.functionArgType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionArgType([NotNull] KoLangParser.FunctionArgTypeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.functionReturnType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionReturnType([NotNull] KoLangParser.FunctionReturnTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.functionReturnType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionReturnType([NotNull] KoLangParser.FunctionReturnTypeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.operatorOne"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOperatorOne([NotNull] KoLangParser.OperatorOneContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.operatorOne"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOperatorOne([NotNull] KoLangParser.OperatorOneContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.operatorTwo"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOperatorTwo([NotNull] KoLangParser.OperatorTwoContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.operatorTwo"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOperatorTwo([NotNull] KoLangParser.OperatorTwoContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoLangParser.compareOperator"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCompareOperator([NotNull] KoLangParser.CompareOperatorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoLangParser.compareOperator"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCompareOperator([NotNull] KoLangParser.CompareOperatorContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
