// Generated from c:/Users/czobo/source/repos/Language/Language/Combined1.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link Combined1Parser}.
 */
public interface Combined1Listener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(Combined1Parser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(Combined1Parser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#comment}.
	 * @param ctx the parse tree
	 */
	void enterComment(Combined1Parser.CommentContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#comment}.
	 * @param ctx the parse tree
	 */
	void exitComment(Combined1Parser.CommentContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#block}.
	 * @param ctx the parse tree
	 */
	void enterBlock(Combined1Parser.BlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#block}.
	 * @param ctx the parse tree
	 */
	void exitBlock(Combined1Parser.BlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#line}.
	 * @param ctx the parse tree
	 */
	void enterLine(Combined1Parser.LineContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#line}.
	 * @param ctx the parse tree
	 */
	void exitLine(Combined1Parser.LineContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#phase}.
	 * @param ctx the parse tree
	 */
	void enterPhase(Combined1Parser.PhaseContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#phase}.
	 * @param ctx the parse tree
	 */
	void exitPhase(Combined1Parser.PhaseContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(Combined1Parser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(Combined1Parser.StatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#ifBlock}.
	 * @param ctx the parse tree
	 */
	void enterIfBlock(Combined1Parser.IfBlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#ifBlock}.
	 * @param ctx the parse tree
	 */
	void exitIfBlock(Combined1Parser.IfBlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#repeatUntil}.
	 * @param ctx the parse tree
	 */
	void enterRepeatUntil(Combined1Parser.RepeatUntilContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#repeatUntil}.
	 * @param ctx the parse tree
	 */
	void exitRepeatUntil(Combined1Parser.RepeatUntilContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#stop}.
	 * @param ctx the parse tree
	 */
	void enterStop(Combined1Parser.StopContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#stop}.
	 * @param ctx the parse tree
	 */
	void exitStop(Combined1Parser.StopContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#cancel}.
	 * @param ctx the parse tree
	 */
	void enterCancel(Combined1Parser.CancelContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#cancel}.
	 * @param ctx the parse tree
	 */
	void exitCancel(Combined1Parser.CancelContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#elseifBlock}.
	 * @param ctx the parse tree
	 */
	void enterElseifBlock(Combined1Parser.ElseifBlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#elseifBlock}.
	 * @param ctx the parse tree
	 */
	void exitElseifBlock(Combined1Parser.ElseifBlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#collection}.
	 * @param ctx the parse tree
	 */
	void enterCollection(Combined1Parser.CollectionContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#collection}.
	 * @param ctx the parse tree
	 */
	void exitCollection(Combined1Parser.CollectionContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#list}.
	 * @param ctx the parse tree
	 */
	void enterList(Combined1Parser.ListContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#list}.
	 * @param ctx the parse tree
	 */
	void exitList(Combined1Parser.ListContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#element}.
	 * @param ctx the parse tree
	 */
	void enterElement(Combined1Parser.ElementContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#element}.
	 * @param ctx the parse tree
	 */
	void exitElement(Combined1Parser.ElementContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#tile}.
	 * @param ctx the parse tree
	 */
	void enterTile(Combined1Parser.TileContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#tile}.
	 * @param ctx the parse tree
	 */
	void exitTile(Combined1Parser.TileContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#variable}.
	 * @param ctx the parse tree
	 */
	void enterVariable(Combined1Parser.VariableContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#variable}.
	 * @param ctx the parse tree
	 */
	void exitVariable(Combined1Parser.VariableContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#declaration}.
	 * @param ctx the parse tree
	 */
	void enterDeclaration(Combined1Parser.DeclarationContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#declaration}.
	 * @param ctx the parse tree
	 */
	void exitDeclaration(Combined1Parser.DeclarationContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#pieceType}.
	 * @param ctx the parse tree
	 */
	void enterPieceType(Combined1Parser.PieceTypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#pieceType}.
	 * @param ctx the parse tree
	 */
	void exitPieceType(Combined1Parser.PieceTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#parameterList}.
	 * @param ctx the parse tree
	 */
	void enterParameterList(Combined1Parser.ParameterListContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#parameterList}.
	 * @param ctx the parse tree
	 */
	void exitParameterList(Combined1Parser.ParameterListContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#assignment}.
	 * @param ctx the parse tree
	 */
	void enterAssignment(Combined1Parser.AssignmentContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#assignment}.
	 * @param ctx the parse tree
	 */
	void exitAssignment(Combined1Parser.AssignmentContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#functionBody}.
	 * @param ctx the parse tree
	 */
	void enterFunctionBody(Combined1Parser.FunctionBodyContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#functionBody}.
	 * @param ctx the parse tree
	 */
	void exitFunctionBody(Combined1Parser.FunctionBodyContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#functionBlock}.
	 * @param ctx the parse tree
	 */
	void enterFunctionBlock(Combined1Parser.FunctionBlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#functionBlock}.
	 * @param ctx the parse tree
	 */
	void exitFunctionBlock(Combined1Parser.FunctionBlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#functionCall}.
	 * @param ctx the parse tree
	 */
	void enterFunctionCall(Combined1Parser.FunctionCallContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#functionCall}.
	 * @param ctx the parse tree
	 */
	void exitFunctionCall(Combined1Parser.FunctionCallContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#functionName}.
	 * @param ctx the parse tree
	 */
	void enterFunctionName(Combined1Parser.FunctionNameContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#functionName}.
	 * @param ctx the parse tree
	 */
	void exitFunctionName(Combined1Parser.FunctionNameContext ctx);
	/**
	 * Enter a parse tree produced by the {@code boolExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterBoolExpression(Combined1Parser.BoolExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code boolExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitBoolExpression(Combined1Parser.BoolExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code varExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterVarExpression(Combined1Parser.VarExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code varExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitVarExpression(Combined1Parser.VarExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code notExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterNotExpression(Combined1Parser.NotExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code notExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitNotExpression(Combined1Parser.NotExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code funcCallExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterFuncCallExpression(Combined1Parser.FuncCallExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code funcCallExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitFuncCallExpression(Combined1Parser.FuncCallExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code parentExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterParentExpression(Combined1Parser.ParentExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code parentExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitParentExpression(Combined1Parser.ParentExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code addExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterAddExpression(Combined1Parser.AddExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code addExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitAddExpression(Combined1Parser.AddExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code compExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterCompExpression(Combined1Parser.CompExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code compExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitCompExpression(Combined1Parser.CompExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code constExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterConstExpression(Combined1Parser.ConstExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code constExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitConstExpression(Combined1Parser.ConstExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code turnStagesExp}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterTurnStagesExp(Combined1Parser.TurnStagesExpContext ctx);
	/**
	 * Exit a parse tree produced by the {@code turnStagesExp}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitTurnStagesExp(Combined1Parser.TurnStagesExpContext ctx);
	/**
	 * Enter a parse tree produced by the {@code pMoveTypeExp}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterPMoveTypeExp(Combined1Parser.PMoveTypeExpContext ctx);
	/**
	 * Exit a parse tree produced by the {@code pMoveTypeExp}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitPMoveTypeExp(Combined1Parser.PMoveTypeExpContext ctx);
	/**
	 * Enter a parse tree produced by the {@code multExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterMultExpression(Combined1Parser.MultExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code multExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitMultExpression(Combined1Parser.MultExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code absExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterAbsExpression(Combined1Parser.AbsExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code absExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitAbsExpression(Combined1Parser.AbsExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code listExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterListExpression(Combined1Parser.ListExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code listExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitListExpression(Combined1Parser.ListExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code negExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterNegExpression(Combined1Parser.NegExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code negExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitNegExpression(Combined1Parser.NegExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code inputExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void enterInputExpression(Combined1Parser.InputExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code inputExpression}
	 * labeled alternative in {@link Combined1Parser#expression}.
	 * @param ctx the parse tree
	 */
	void exitInputExpression(Combined1Parser.InputExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#turnStages}.
	 * @param ctx the parse tree
	 */
	void enterTurnStages(Combined1Parser.TurnStagesContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#turnStages}.
	 * @param ctx the parse tree
	 */
	void exitTurnStages(Combined1Parser.TurnStagesContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#input}.
	 * @param ctx the parse tree
	 */
	void enterInput(Combined1Parser.InputContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#input}.
	 * @param ctx the parse tree
	 */
	void exitInput(Combined1Parser.InputContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#inputTypes}.
	 * @param ctx the parse tree
	 */
	void enterInputTypes(Combined1Parser.InputTypesContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#inputTypes}.
	 * @param ctx the parse tree
	 */
	void exitInputTypes(Combined1Parser.InputTypesContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#pieceMoveTypes}.
	 * @param ctx the parse tree
	 */
	void enterPieceMoveTypes(Combined1Parser.PieceMoveTypesContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#pieceMoveTypes}.
	 * @param ctx the parse tree
	 */
	void exitPieceMoveTypes(Combined1Parser.PieceMoveTypesContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#multOp}.
	 * @param ctx the parse tree
	 */
	void enterMultOp(Combined1Parser.MultOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#multOp}.
	 * @param ctx the parse tree
	 */
	void exitMultOp(Combined1Parser.MultOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#addOp}.
	 * @param ctx the parse tree
	 */
	void enterAddOp(Combined1Parser.AddOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#addOp}.
	 * @param ctx the parse tree
	 */
	void exitAddOp(Combined1Parser.AddOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#compareOp}.
	 * @param ctx the parse tree
	 */
	void enterCompareOp(Combined1Parser.CompareOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#compareOp}.
	 * @param ctx the parse tree
	 */
	void exitCompareOp(Combined1Parser.CompareOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#boolOp}.
	 * @param ctx the parse tree
	 */
	void enterBoolOp(Combined1Parser.BoolOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#boolOp}.
	 * @param ctx the parse tree
	 */
	void exitBoolOp(Combined1Parser.BoolOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#type}.
	 * @param ctx the parse tree
	 */
	void enterType(Combined1Parser.TypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#type}.
	 * @param ctx the parse tree
	 */
	void exitType(Combined1Parser.TypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#property}.
	 * @param ctx the parse tree
	 */
	void enterProperty(Combined1Parser.PropertyContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#property}.
	 * @param ctx the parse tree
	 */
	void exitProperty(Combined1Parser.PropertyContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#attribute}.
	 * @param ctx the parse tree
	 */
	void enterAttribute(Combined1Parser.AttributeContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#attribute}.
	 * @param ctx the parse tree
	 */
	void exitAttribute(Combined1Parser.AttributeContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#constant}.
	 * @param ctx the parse tree
	 */
	void enterConstant(Combined1Parser.ConstantContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#constant}.
	 * @param ctx the parse tree
	 */
	void exitConstant(Combined1Parser.ConstantContext ctx);
	/**
	 * Enter a parse tree produced by {@link Combined1Parser#color}.
	 * @param ctx the parse tree
	 */
	void enterColor(Combined1Parser.ColorContext ctx);
	/**
	 * Exit a parse tree produced by {@link Combined1Parser#color}.
	 * @param ctx the parse tree
	 */
	void exitColor(Combined1Parser.ColorContext ctx);
}