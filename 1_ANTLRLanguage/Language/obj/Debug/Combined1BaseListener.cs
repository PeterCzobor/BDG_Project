﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\czobo\Documents\GitHub\BDG\BDG_Language\Language\Combined1.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Language {

using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ICombined1Listener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class Combined1BaseListener : ICombined1Listener {
	/// <summary>
	/// Enter a parse tree produced by the <c>constExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConstExpression([NotNull] Combined1Parser.ConstExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>constExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConstExpression([NotNull] Combined1Parser.ConstExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>varExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVarExpression([NotNull] Combined1Parser.VarExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>varExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVarExpression([NotNull] Combined1Parser.VarExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>listExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterListExpression([NotNull] Combined1Parser.ListExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>listExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitListExpression([NotNull] Combined1Parser.ListExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>funcCallExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFuncCallExpression([NotNull] Combined1Parser.FuncCallExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>funcCallExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFuncCallExpression([NotNull] Combined1Parser.FuncCallExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>parentExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParentExpression([NotNull] Combined1Parser.ParentExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>parentExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParentExpression([NotNull] Combined1Parser.ParentExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>notExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNotExpression([NotNull] Combined1Parser.NotExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>notExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNotExpression([NotNull] Combined1Parser.NotExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>absExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAbsExpression([NotNull] Combined1Parser.AbsExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>absExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAbsExpression([NotNull] Combined1Parser.AbsExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>multExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultExpression([NotNull] Combined1Parser.MultExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>multExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultExpression([NotNull] Combined1Parser.MultExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>addExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAddExpression([NotNull] Combined1Parser.AddExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>addExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAddExpression([NotNull] Combined1Parser.AddExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>compExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCompExpression([NotNull] Combined1Parser.CompExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>compExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCompExpression([NotNull] Combined1Parser.CompExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>boolExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolExpression([NotNull] Combined1Parser.BoolExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>boolExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolExpression([NotNull] Combined1Parser.BoolExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>negExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNegExpression([NotNull] Combined1Parser.NegExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>negExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNegExpression([NotNull] Combined1Parser.NegExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>inputExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInputExpression([NotNull] Combined1Parser.InputExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>inputExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInputExpression([NotNull] Combined1Parser.InputExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>turnStagesExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTurnStagesExp([NotNull] Combined1Parser.TurnStagesExpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>turnStagesExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTurnStagesExp([NotNull] Combined1Parser.TurnStagesExpContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>pMoveTypeExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPMoveTypeExp([NotNull] Combined1Parser.PMoveTypeExpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>pMoveTypeExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPMoveTypeExp([NotNull] Combined1Parser.PMoveTypeExpContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>neighborsExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNeighborsExp([NotNull] Combined1Parser.NeighborsExpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>neighborsExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNeighborsExp([NotNull] Combined1Parser.NeighborsExpContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProgram([NotNull] Combined1Parser.ProgramContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProgram([NotNull] Combined1Parser.ProgramContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.comment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterComment([NotNull] Combined1Parser.CommentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.comment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitComment([NotNull] Combined1Parser.CommentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLine([NotNull] Combined1Parser.LineContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLine([NotNull] Combined1Parser.LineContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBlock([NotNull] Combined1Parser.BlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBlock([NotNull] Combined1Parser.BlockContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.logStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLogStatement([NotNull] Combined1Parser.LogStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.logStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLogStatement([NotNull] Combined1Parser.LogStatementContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.phase"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPhase([NotNull] Combined1Parser.PhaseContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.phase"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPhase([NotNull] Combined1Parser.PhaseContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.ifBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIfBlock([NotNull] Combined1Parser.IfBlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.ifBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIfBlock([NotNull] Combined1Parser.IfBlockContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.elseifBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterElseifBlock([NotNull] Combined1Parser.ElseifBlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.elseifBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitElseifBlock([NotNull] Combined1Parser.ElseifBlockContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.repeatUntil"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRepeatUntil([NotNull] Combined1Parser.RepeatUntilContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.repeatUntil"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRepeatUntil([NotNull] Combined1Parser.RepeatUntilContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatement([NotNull] Combined1Parser.StatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatement([NotNull] Combined1Parser.StatementContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.declaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDeclaration([NotNull] Combined1Parser.DeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.declaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDeclaration([NotNull] Combined1Parser.DeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignment([NotNull] Combined1Parser.AssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignment([NotNull] Combined1Parser.AssignmentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.stop"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStop([NotNull] Combined1Parser.StopContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.stop"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStop([NotNull] Combined1Parser.StopContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.cancel"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCancel([NotNull] Combined1Parser.CancelContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.cancel"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCancel([NotNull] Combined1Parser.CancelContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.variable"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVariable([NotNull] Combined1Parser.VariableContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.variable"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVariable([NotNull] Combined1Parser.VariableContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.pieceType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPieceType([NotNull] Combined1Parser.PieceTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.pieceType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPieceType([NotNull] Combined1Parser.PieceTypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.parameterList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParameterList([NotNull] Combined1Parser.ParameterListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.parameterList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParameterList([NotNull] Combined1Parser.ParameterListContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterType([NotNull] Combined1Parser.TypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitType([NotNull] Combined1Parser.TypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.member"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMember([NotNull] Combined1Parser.MemberContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.member"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMember([NotNull] Combined1Parser.MemberContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.field"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterField([NotNull] Combined1Parser.FieldContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.field"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitField([NotNull] Combined1Parser.FieldContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.tile"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTile([NotNull] Combined1Parser.TileContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.tile"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTile([NotNull] Combined1Parser.TileContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.collection"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCollection([NotNull] Combined1Parser.CollectionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.collection"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCollection([NotNull] Combined1Parser.CollectionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterList([NotNull] Combined1Parser.ListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitList([NotNull] Combined1Parser.ListContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.element"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterElement([NotNull] Combined1Parser.ElementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.element"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitElement([NotNull] Combined1Parser.ElementContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.functionBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionBody([NotNull] Combined1Parser.FunctionBodyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.functionBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionBody([NotNull] Combined1Parser.FunctionBodyContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.functionBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionBlock([NotNull] Combined1Parser.FunctionBlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.functionBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionBlock([NotNull] Combined1Parser.FunctionBlockContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.functionCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionCall([NotNull] Combined1Parser.FunctionCallContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.functionCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionCall([NotNull] Combined1Parser.FunctionCallContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.functionName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionName([NotNull] Combined1Parser.FunctionNameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.functionName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionName([NotNull] Combined1Parser.FunctionNameContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpression([NotNull] Combined1Parser.ExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpression([NotNull] Combined1Parser.ExpressionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.turnStages"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTurnStages([NotNull] Combined1Parser.TurnStagesContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.turnStages"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTurnStages([NotNull] Combined1Parser.TurnStagesContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.input"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInput([NotNull] Combined1Parser.InputContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.input"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInput([NotNull] Combined1Parser.InputContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.inputTypes"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInputTypes([NotNull] Combined1Parser.InputTypesContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.inputTypes"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInputTypes([NotNull] Combined1Parser.InputTypesContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.pieceMoveTypes"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPieceMoveTypes([NotNull] Combined1Parser.PieceMoveTypesContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.pieceMoveTypes"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPieceMoveTypes([NotNull] Combined1Parser.PieceMoveTypesContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.neighbors"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNeighbors([NotNull] Combined1Parser.NeighborsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.neighbors"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNeighbors([NotNull] Combined1Parser.NeighborsContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.multOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultOp([NotNull] Combined1Parser.MultOpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.multOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultOp([NotNull] Combined1Parser.MultOpContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.addOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAddOp([NotNull] Combined1Parser.AddOpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.addOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAddOp([NotNull] Combined1Parser.AddOpContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.compareOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCompareOp([NotNull] Combined1Parser.CompareOpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.compareOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCompareOp([NotNull] Combined1Parser.CompareOpContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.boolOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolOp([NotNull] Combined1Parser.BoolOpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.boolOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolOp([NotNull] Combined1Parser.BoolOpContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.constant"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConstant([NotNull] Combined1Parser.ConstantContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.constant"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConstant([NotNull] Combined1Parser.ConstantContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.color"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterColor([NotNull] Combined1Parser.ColorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.color"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitColor([NotNull] Combined1Parser.ColorContext context) { }

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
} // namespace Language
