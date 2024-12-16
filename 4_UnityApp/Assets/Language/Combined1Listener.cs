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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="Combined1Parser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface ICombined1Listener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>constExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstExpression([NotNull] Combined1Parser.ConstExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>constExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstExpression([NotNull] Combined1Parser.ConstExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>varExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVarExpression([NotNull] Combined1Parser.VarExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>varExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVarExpression([NotNull] Combined1Parser.VarExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>listExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterListExpression([NotNull] Combined1Parser.ListExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>listExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitListExpression([NotNull] Combined1Parser.ListExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>funcCallExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncCallExpression([NotNull] Combined1Parser.FuncCallExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>funcCallExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncCallExpression([NotNull] Combined1Parser.FuncCallExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>parentExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParentExpression([NotNull] Combined1Parser.ParentExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parentExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParentExpression([NotNull] Combined1Parser.ParentExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>notExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNotExpression([NotNull] Combined1Parser.NotExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>notExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNotExpression([NotNull] Combined1Parser.NotExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>absExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAbsExpression([NotNull] Combined1Parser.AbsExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>absExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAbsExpression([NotNull] Combined1Parser.AbsExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>multExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultExpression([NotNull] Combined1Parser.MultExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>multExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultExpression([NotNull] Combined1Parser.MultExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>addExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddExpression([NotNull] Combined1Parser.AddExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>addExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddExpression([NotNull] Combined1Parser.AddExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>compExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompExpression([NotNull] Combined1Parser.CompExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>compExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompExpression([NotNull] Combined1Parser.CompExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>boolExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolExpression([NotNull] Combined1Parser.BoolExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>boolExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolExpression([NotNull] Combined1Parser.BoolExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>negExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNegExpression([NotNull] Combined1Parser.NegExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>negExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNegExpression([NotNull] Combined1Parser.NegExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>inputExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInputExpression([NotNull] Combined1Parser.InputExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>inputExpression</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInputExpression([NotNull] Combined1Parser.InputExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>turnStagesExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTurnStagesExp([NotNull] Combined1Parser.TurnStagesExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>turnStagesExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTurnStagesExp([NotNull] Combined1Parser.TurnStagesExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>pMoveTypeExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPMoveTypeExp([NotNull] Combined1Parser.PMoveTypeExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>pMoveTypeExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPMoveTypeExp([NotNull] Combined1Parser.PMoveTypeExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>neighborsExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNeighborsExp([NotNull] Combined1Parser.NeighborsExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>neighborsExp</c>
	/// labeled alternative in <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNeighborsExp([NotNull] Combined1Parser.NeighborsExpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] Combined1Parser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] Combined1Parser.ProgramContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.comment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComment([NotNull] Combined1Parser.CommentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.comment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComment([NotNull] Combined1Parser.CommentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLine([NotNull] Combined1Parser.LineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLine([NotNull] Combined1Parser.LineContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] Combined1Parser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] Combined1Parser.BlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.logStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogStatement([NotNull] Combined1Parser.LogStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.logStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogStatement([NotNull] Combined1Parser.LogStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.phase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPhase([NotNull] Combined1Parser.PhaseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.phase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPhase([NotNull] Combined1Parser.PhaseContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.ifBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfBlock([NotNull] Combined1Parser.IfBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.ifBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfBlock([NotNull] Combined1Parser.IfBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.elseifBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElseifBlock([NotNull] Combined1Parser.ElseifBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.elseifBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElseifBlock([NotNull] Combined1Parser.ElseifBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.repeatUntil"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRepeatUntil([NotNull] Combined1Parser.RepeatUntilContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.repeatUntil"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRepeatUntil([NotNull] Combined1Parser.RepeatUntilContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] Combined1Parser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] Combined1Parser.StatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaration([NotNull] Combined1Parser.DeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaration([NotNull] Combined1Parser.DeclarationContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] Combined1Parser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] Combined1Parser.AssignmentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.stop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStop([NotNull] Combined1Parser.StopContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.stop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStop([NotNull] Combined1Parser.StopContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.cancel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCancel([NotNull] Combined1Parser.CancelContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.cancel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCancel([NotNull] Combined1Parser.CancelContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariable([NotNull] Combined1Parser.VariableContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariable([NotNull] Combined1Parser.VariableContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.pieceType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPieceType([NotNull] Combined1Parser.PieceTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.pieceType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPieceType([NotNull] Combined1Parser.PieceTypeContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameterList([NotNull] Combined1Parser.ParameterListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameterList([NotNull] Combined1Parser.ParameterListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterType([NotNull] Combined1Parser.TypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitType([NotNull] Combined1Parser.TypeContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.member"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMember([NotNull] Combined1Parser.MemberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.member"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMember([NotNull] Combined1Parser.MemberContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterField([NotNull] Combined1Parser.FieldContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitField([NotNull] Combined1Parser.FieldContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.tile"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTile([NotNull] Combined1Parser.TileContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.tile"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTile([NotNull] Combined1Parser.TileContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.collection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCollection([NotNull] Combined1Parser.CollectionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.collection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCollection([NotNull] Combined1Parser.CollectionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterList([NotNull] Combined1Parser.ListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitList([NotNull] Combined1Parser.ListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElement([NotNull] Combined1Parser.ElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElement([NotNull] Combined1Parser.ElementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.functionBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionBody([NotNull] Combined1Parser.FunctionBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.functionBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionBody([NotNull] Combined1Parser.FunctionBodyContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.functionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionBlock([NotNull] Combined1Parser.FunctionBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.functionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionBlock([NotNull] Combined1Parser.FunctionBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionCall([NotNull] Combined1Parser.FunctionCallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionCall([NotNull] Combined1Parser.FunctionCallContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.functionName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionName([NotNull] Combined1Parser.FunctionNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.functionName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionName([NotNull] Combined1Parser.FunctionNameContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] Combined1Parser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] Combined1Parser.ExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.turnStages"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTurnStages([NotNull] Combined1Parser.TurnStagesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.turnStages"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTurnStages([NotNull] Combined1Parser.TurnStagesContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.input"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInput([NotNull] Combined1Parser.InputContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.input"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInput([NotNull] Combined1Parser.InputContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.inputTypes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInputTypes([NotNull] Combined1Parser.InputTypesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.inputTypes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInputTypes([NotNull] Combined1Parser.InputTypesContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.pieceMoveTypes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPieceMoveTypes([NotNull] Combined1Parser.PieceMoveTypesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.pieceMoveTypes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPieceMoveTypes([NotNull] Combined1Parser.PieceMoveTypesContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.neighbors"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNeighbors([NotNull] Combined1Parser.NeighborsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.neighbors"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNeighbors([NotNull] Combined1Parser.NeighborsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.multOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultOp([NotNull] Combined1Parser.MultOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.multOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultOp([NotNull] Combined1Parser.MultOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.addOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddOp([NotNull] Combined1Parser.AddOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.addOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddOp([NotNull] Combined1Parser.AddOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.compareOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompareOp([NotNull] Combined1Parser.CompareOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.compareOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompareOp([NotNull] Combined1Parser.CompareOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.boolOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolOp([NotNull] Combined1Parser.BoolOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.boolOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolOp([NotNull] Combined1Parser.BoolOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstant([NotNull] Combined1Parser.ConstantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstant([NotNull] Combined1Parser.ConstantContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Combined1Parser.color"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterColor([NotNull] Combined1Parser.ColorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Combined1Parser.color"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitColor([NotNull] Combined1Parser.ColorContext context);
}
} // namespace Language