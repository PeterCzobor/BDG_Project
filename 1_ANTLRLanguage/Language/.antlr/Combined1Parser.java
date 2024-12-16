// Generated from c:/Users/czobo/source/repos/Language/Language/Combined1.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class Combined1Parser extends Parser {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, T__25=26, T__26=27, T__27=28, T__28=29, T__29=30, T__30=31, 
		T__31=32, T__32=33, T__33=34, T__34=35, T__35=36, T__36=37, T__37=38, 
		T__38=39, T__39=40, T__40=41, T__41=42, T__42=43, T__43=44, T__44=45, 
		T__45=46, T__46=47, T__47=48, T__48=49, T__49=50, T__50=51, T__51=52, 
		T__52=53, T__53=54, T__54=55, T__55=56, T__56=57, T__57=58, T__58=59, 
		T__59=60, T__60=61, T__61=62, T__62=63, T__63=64, T__64=65, T__65=66, 
		T__66=67, T__67=68, T__68=69, T__69=70, T__70=71, T__71=72, T__72=73, 
		T__73=74, T__74=75, T__75=76, COMMENT=77, LINE_COMMENT=78, INTEGER=79, 
		FLOAT=80, STRING=81, BOOL=82, NULL=83, ID=84, WS=85;
	public static final int
		RULE_program = 0, RULE_comment = 1, RULE_block = 2, RULE_line = 3, RULE_phase = 4, 
		RULE_statement = 5, RULE_ifBlock = 6, RULE_repeatUntil = 7, RULE_stop = 8, 
		RULE_cancel = 9, RULE_elseifBlock = 10, RULE_collection = 11, RULE_list = 12, 
		RULE_element = 13, RULE_tile = 14, RULE_variable = 15, RULE_declaration = 16, 
		RULE_pieceType = 17, RULE_parameterList = 18, RULE_assignment = 19, RULE_functionBody = 20, 
		RULE_functionBlock = 21, RULE_functionCall = 22, RULE_functionName = 23, 
		RULE_expression = 24, RULE_turnStages = 25, RULE_input = 26, RULE_inputTypes = 27, 
		RULE_pieceMoveTypes = 28, RULE_multOp = 29, RULE_addOp = 30, RULE_compareOp = 31, 
		RULE_boolOp = 32, RULE_type = 33, RULE_property = 34, RULE_attribute = 35, 
		RULE_constant = 36, RULE_color = 37;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "comment", "block", "line", "phase", "statement", "ifBlock", 
			"repeatUntil", "stop", "cancel", "elseifBlock", "collection", "list", 
			"element", "tile", "variable", "declaration", "pieceType", "parameterList", 
			"assignment", "functionBody", "functionBlock", "functionCall", "functionName", 
			"expression", "turnStages", "input", "inputTypes", "pieceMoveTypes", 
			"multOp", "addOp", "compareOp", "boolOp", "type", "property", "attribute", 
			"constant", "color"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'{'", "'}'", "'Phase'", "';'", "'if'", "'('", "')'", "'else'", 
			"'repeat'", "'until'", "'stop'", "'cancel'", "'all'", "'none'", "'any'", 
			"'Count'", "'['", "','", "']'", "'='", "'.'", "'Rule'", "'Turn'", "'EndTurn'", 
			"'WinCondition'", "'MoveTo'", "'Remove'", "'TryTurn'", "'Add'", "'Move'", 
			"'Find'", "'Roll'", "'!'", "'|'", "'-'", "'<'", "'>'", "'SelectPiece'", 
			"'SelectTile'", "'INPUT'", "'Click'", "'Press'", "'Step'", "'Slide'", 
			"'Jump'", "'*'", "'/'", "'%'", "'+'", "'=='", "'!='", "'>='", "'<='", 
			"'AND'", "'OR'", "'Player'", "'Piece'", "'Tile'", "'Dice'", "'List'", 
			"'pieces'", "'tiles'", "'PosX'", "'PosY'", "'player'", "'color'", "'Route'", 
			"'RoutePosition'", "'Texture'", "'Type'", "'name'", "'value'", "'size'", 
			"'active'", "'text'", "'Color'", null, null, null, null, null, null, 
			"'NULL'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, "COMMENT", "LINE_COMMENT", "INTEGER", "FLOAT", 
			"STRING", "BOOL", "NULL", "ID", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "Combined1.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public Combined1Parser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ProgramContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(Combined1Parser.EOF, 0); }
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public List<CommentContext> comment() {
			return getRuleContexts(CommentContext.class);
		}
		public CommentContext comment(int i) {
			return getRuleContext(CommentContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterProgram(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitProgram(this);
		}
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(80);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & -72057585449829782L) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & 1077247L) != 0)) {
				{
				setState(78);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case T__0:
				case T__2:
				case T__4:
				case T__5:
				case T__8:
				case T__10:
				case T__11:
				case T__12:
				case T__13:
				case T__14:
				case T__15:
				case T__16:
				case T__20:
				case T__21:
				case T__22:
				case T__23:
				case T__24:
				case T__25:
				case T__26:
				case T__27:
				case T__28:
				case T__29:
				case T__30:
				case T__31:
				case T__55:
				case T__56:
				case T__57:
				case T__58:
				case T__59:
				case T__60:
				case T__61:
				case T__62:
				case T__63:
				case T__64:
				case T__65:
				case T__66:
				case T__67:
				case T__68:
				case T__69:
				case T__70:
				case T__71:
				case T__72:
				case T__73:
				case T__74:
				case ID:
					{
					setState(76);
					line();
					}
					break;
				case COMMENT:
				case LINE_COMMENT:
					{
					setState(77);
					comment();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(82);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(83);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CommentContext extends ParserRuleContext {
		public TerminalNode COMMENT() { return getToken(Combined1Parser.COMMENT, 0); }
		public TerminalNode LINE_COMMENT() { return getToken(Combined1Parser.LINE_COMMENT, 0); }
		public CommentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_comment; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterComment(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitComment(this);
		}
	}

	public final CommentContext comment() throws RecognitionException {
		CommentContext _localctx = new CommentContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_comment);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(85);
			_la = _input.LA(1);
			if ( !(_la==COMMENT || _la==LINE_COMMENT) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BlockContext extends ParserRuleContext {
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitBlock(this);
		}
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(87);
			match(T__0);
			setState(91);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & -72057585449829782L) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & 1052671L) != 0)) {
				{
				{
				setState(88);
				line();
				}
				}
				setState(93);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(94);
			match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class LineContext extends ParserRuleContext {
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public PhaseContext phase() {
			return getRuleContext(PhaseContext.class,0);
		}
		public IfBlockContext ifBlock() {
			return getRuleContext(IfBlockContext.class,0);
		}
		public RepeatUntilContext repeatUntil() {
			return getRuleContext(RepeatUntilContext.class,0);
		}
		public FunctionBodyContext functionBody() {
			return getRuleContext(FunctionBodyContext.class,0);
		}
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public LineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_line; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterLine(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitLine(this);
		}
	}

	public final LineContext line() throws RecognitionException {
		LineContext _localctx = new LineContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_line);
		try {
			setState(103);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(96);
				statement();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(97);
				phase();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(98);
				ifBlock();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(99);
				repeatUntil();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(100);
				functionBody();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(101);
				functionCall();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(102);
				block();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class PhaseContext extends ParserRuleContext {
		public TerminalNode INTEGER() { return getToken(Combined1Parser.INTEGER, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public PhaseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_phase; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterPhase(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitPhase(this);
		}
	}

	public final PhaseContext phase() throws RecognitionException {
		PhaseContext _localctx = new PhaseContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_phase);
		try {
			setState(111);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(105);
				match(T__2);
				setState(106);
				match(INTEGER);
				setState(107);
				block();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(108);
				match(T__2);
				setState(109);
				match(INTEGER);
				setState(110);
				match(T__3);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StatementContext extends ParserRuleContext {
		public DeclarationContext declaration() {
			return getRuleContext(DeclarationContext.class,0);
		}
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public StopContext stop() {
			return getRuleContext(StopContext.class,0);
		}
		public CancelContext cancel() {
			return getRuleContext(CancelContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitStatement(this);
		}
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(117);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,5,_ctx) ) {
			case 1:
				{
				setState(113);
				declaration();
				}
				break;
			case 2:
				{
				setState(114);
				assignment();
				}
				break;
			case 3:
				{
				setState(115);
				stop();
				}
				break;
			case 4:
				{
				setState(116);
				cancel();
				}
				break;
			}
			setState(119);
			match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IfBlockContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ElseifBlockContext elseifBlock() {
			return getRuleContext(ElseifBlockContext.class,0);
		}
		public IfBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifBlock; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterIfBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitIfBlock(this);
		}
	}

	public final IfBlockContext ifBlock() throws RecognitionException {
		IfBlockContext _localctx = new IfBlockContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_ifBlock);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(121);
			match(T__4);
			setState(122);
			match(T__5);
			setState(123);
			expression(0);
			setState(124);
			match(T__6);
			setState(125);
			block();
			setState(128);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__7) {
				{
				setState(126);
				match(T__7);
				setState(127);
				elseifBlock();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class RepeatUntilContext extends ParserRuleContext {
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public RepeatUntilContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_repeatUntil; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterRepeatUntil(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitRepeatUntil(this);
		}
	}

	public final RepeatUntilContext repeatUntil() throws RecognitionException {
		RepeatUntilContext _localctx = new RepeatUntilContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_repeatUntil);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(130);
			match(T__8);
			setState(131);
			block();
			setState(132);
			match(T__9);
			setState(133);
			match(T__5);
			setState(134);
			expression(0);
			setState(135);
			match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StopContext extends ParserRuleContext {
		public StopContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stop; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterStop(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitStop(this);
		}
	}

	public final StopContext stop() throws RecognitionException {
		StopContext _localctx = new StopContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_stop);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(137);
			match(T__10);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CancelContext extends ParserRuleContext {
		public CancelContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cancel; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterCancel(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitCancel(this);
		}
	}

	public final CancelContext cancel() throws RecognitionException {
		CancelContext _localctx = new CancelContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_cancel);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(139);
			match(T__11);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ElseifBlockContext extends ParserRuleContext {
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public IfBlockContext ifBlock() {
			return getRuleContext(IfBlockContext.class,0);
		}
		public ElseifBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elseifBlock; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterElseifBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitElseifBlock(this);
		}
	}

	public final ElseifBlockContext elseifBlock() throws RecognitionException {
		ElseifBlockContext _localctx = new ElseifBlockContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_elseifBlock);
		try {
			setState(143);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				enterOuterAlt(_localctx, 1);
				{
				setState(141);
				block();
				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 2);
				{
				setState(142);
				ifBlock();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CollectionContext extends ParserRuleContext {
		public CollectionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_collection; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterCollection(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitCollection(this);
		}
	}

	public final CollectionContext collection() throws RecognitionException {
		CollectionContext _localctx = new CollectionContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_collection);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(145);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 122880L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ListContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public ListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_list; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterList(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitList(this);
		}
	}

	public final ListContext list() throws RecognitionException {
		ListContext _localctx = new ListContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(147);
			match(T__16);
			setState(156);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & -2305780199613800384L) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & 2072575L) != 0)) {
				{
				setState(148);
				expression(0);
				setState(153);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__17) {
					{
					{
					setState(149);
					match(T__17);
					setState(150);
					expression(0);
					}
					}
					setState(155);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(158);
			match(T__18);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ElementContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ElementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_element; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterElement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitElement(this);
		}
	}

	public final ElementContext element() throws RecognitionException {
		ElementContext _localctx = new ElementContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_element);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(160);
			match(T__16);
			setState(161);
			expression(0);
			setState(162);
			match(T__18);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TileContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TileContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_tile; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterTile(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitTile(this);
		}
	}

	public final TileContext tile() throws RecognitionException {
		TileContext _localctx = new TileContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_tile);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(164);
			match(T__5);
			setState(165);
			expression(0);
			setState(166);
			match(T__17);
			setState(167);
			expression(0);
			setState(168);
			match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class VariableContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(Combined1Parser.ID, 0); }
		public TileContext tile() {
			return getRuleContext(TileContext.class,0);
		}
		public List<PropertyContext> property() {
			return getRuleContexts(PropertyContext.class);
		}
		public PropertyContext property(int i) {
			return getRuleContext(PropertyContext.class,i);
		}
		public VariableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variable; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterVariable(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitVariable(this);
		}
	}

	public final VariableContext variable() throws RecognitionException {
		VariableContext _localctx = new VariableContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_variable);
		try {
			int _alt;
			setState(185);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__5:
			case ID:
				enterOuterAlt(_localctx, 1);
				{
				setState(172);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case ID:
					{
					setState(170);
					match(ID);
					}
					break;
				case T__5:
					{
					setState(171);
					tile();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(177);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
				while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						setState(174);
						property();
						}
						} 
					}
					setState(179);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
				}
				}
				break;
			case T__12:
			case T__13:
			case T__14:
			case T__15:
			case T__16:
			case T__20:
			case T__60:
			case T__61:
			case T__62:
			case T__63:
			case T__64:
			case T__65:
			case T__66:
			case T__67:
			case T__68:
			case T__69:
			case T__70:
			case T__71:
			case T__72:
			case T__73:
			case T__74:
				enterOuterAlt(_localctx, 2);
				{
				setState(181); 
				_errHandler.sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						setState(180);
						property();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(183); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,12,_ctx);
				} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class DeclarationContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(Combined1Parser.ID, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public PieceTypeContext pieceType() {
			return getRuleContext(PieceTypeContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ParameterListContext parameterList() {
			return getRuleContext(ParameterListContext.class,0);
		}
		public DeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_declaration; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterDeclaration(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitDeclaration(this);
		}
	}

	public final DeclarationContext declaration() throws RecognitionException {
		DeclarationContext _localctx = new DeclarationContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_declaration);
		int _la;
		try {
			setState(206);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,19,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(188);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 2233785415175766016L) != 0)) {
					{
					setState(187);
					type();
					}
				}

				setState(191);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__5) {
					{
					setState(190);
					pieceType();
					}
				}

				setState(193);
				match(ID);
				setState(196);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__19) {
					{
					setState(194);
					match(T__19);
					setState(195);
					expression(0);
					}
				}

				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(198);
				type();
				setState(200);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__5) {
					{
					setState(199);
					pieceType();
					}
				}

				setState(202);
				match(ID);
				setState(204);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__5) {
					{
					setState(203);
					parameterList();
					}
				}

				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class PieceTypeContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(Combined1Parser.ID, 0); }
		public PieceTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pieceType; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterPieceType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitPieceType(this);
		}
	}

	public final PieceTypeContext pieceType() throws RecognitionException {
		PieceTypeContext _localctx = new PieceTypeContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_pieceType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(208);
			match(T__5);
			setState(209);
			match(ID);
			setState(210);
			match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ParameterListContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public ParameterListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterList; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterParameterList(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitParameterList(this);
		}
	}

	public final ParameterListContext parameterList() throws RecognitionException {
		ParameterListContext _localctx = new ParameterListContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_parameterList);
		int _la;
		try {
			setState(226);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,22,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(212);
				match(T__5);
				setState(221);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & -2305780199613800384L) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & 2072575L) != 0)) {
					{
					setState(213);
					expression(0);
					setState(218);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==T__17) {
						{
						{
						setState(214);
						match(T__17);
						setState(215);
						expression(0);
						}
						}
						setState(220);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				setState(223);
				match(T__6);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(224);
				match(T__5);
				setState(225);
				match(T__6);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AssignmentContext extends ParserRuleContext {
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterAssignment(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitAssignment(this);
		}
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(228);
			variable();
			setState(229);
			match(T__19);
			setState(230);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FunctionBodyContext extends ParserRuleContext {
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public FunctionNameContext functionName() {
			return getRuleContext(FunctionNameContext.class,0);
		}
		public FunctionBlockContext functionBlock() {
			return getRuleContext(FunctionBlockContext.class,0);
		}
		public FunctionBodyContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionBody; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterFunctionBody(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitFunctionBody(this);
		}
	}

	public final FunctionBodyContext functionBody() throws RecognitionException {
		FunctionBodyContext _localctx = new FunctionBodyContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_functionBody);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(232);
			variable();
			setState(233);
			match(T__20);
			setState(234);
			functionName();
			setState(235);
			functionBlock();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FunctionBlockContext extends ParserRuleContext {
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public DeclarationContext declaration() {
			return getRuleContext(DeclarationContext.class,0);
		}
		public FunctionBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionBlock; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterFunctionBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitFunctionBlock(this);
		}
	}

	public final FunctionBlockContext functionBlock() throws RecognitionException {
		FunctionBlockContext _localctx = new FunctionBlockContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_functionBlock);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(237);
			match(T__5);
			setState(239);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 2233785415175766080L) != 0) || _la==ID) {
				{
				setState(238);
				declaration();
				}
			}

			setState(241);
			match(T__6);
			setState(242);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FunctionCallContext extends ParserRuleContext {
		public FunctionNameContext functionName() {
			return getRuleContext(FunctionNameContext.class,0);
		}
		public ParameterListContext parameterList() {
			return getRuleContext(ParameterListContext.class,0);
		}
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public FunctionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCall; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterFunctionCall(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitFunctionCall(this);
		}
	}

	public final FunctionCallContext functionCall() throws RecognitionException {
		FunctionCallContext _localctx = new FunctionCallContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_functionCall);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(247);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
			case 1:
				{
				setState(244);
				variable();
				setState(245);
				match(T__20);
				}
				break;
			}
			setState(249);
			functionName();
			setState(250);
			parameterList();
			setState(252);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,25,_ctx) ) {
			case 1:
				{
				setState(251);
				match(T__3);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FunctionNameContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(Combined1Parser.ID, 0); }
		public FunctionNameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionName; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterFunctionName(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitFunctionName(this);
		}
	}

	public final FunctionNameContext functionName() throws RecognitionException {
		FunctionNameContext _localctx = new FunctionNameContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_functionName);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(254);
			_la = _input.LA(1);
			if ( !(((((_la - 22)) & ~0x3f) == 0 && ((1L << (_la - 22)) & 4611686018427389951L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ExpressionContext extends ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	 
		public ExpressionContext() { }
		public void copyFrom(ExpressionContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class BoolExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public BoolOpContext boolOp() {
			return getRuleContext(BoolOpContext.class,0);
		}
		public BoolExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterBoolExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitBoolExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class VarExpressionContext extends ExpressionContext {
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public VarExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterVarExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitVarExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class NotExpressionContext extends ExpressionContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public NotExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterNotExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitNotExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class FuncCallExpressionContext extends ExpressionContext {
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public FuncCallExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterFuncCallExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitFuncCallExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ParentExpressionContext extends ExpressionContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ParentExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterParentExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitParentExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AddExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public AddOpContext addOp() {
			return getRuleContext(AddOpContext.class,0);
		}
		public AddExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterAddExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitAddExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class CompExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public CompareOpContext compareOp() {
			return getRuleContext(CompareOpContext.class,0);
		}
		public CompExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterCompExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitCompExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ConstExpressionContext extends ExpressionContext {
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public ConstExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterConstExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitConstExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class TurnStagesExpContext extends ExpressionContext {
		public TurnStagesContext turnStages() {
			return getRuleContext(TurnStagesContext.class,0);
		}
		public TurnStagesExpContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterTurnStagesExp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitTurnStagesExp(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class PMoveTypeExpContext extends ExpressionContext {
		public PieceMoveTypesContext pieceMoveTypes() {
			return getRuleContext(PieceMoveTypesContext.class,0);
		}
		public PMoveTypeExpContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterPMoveTypeExp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitPMoveTypeExp(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MultExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public MultOpContext multOp() {
			return getRuleContext(MultOpContext.class,0);
		}
		public MultExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterMultExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitMultExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AbsExpressionContext extends ExpressionContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public AbsExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterAbsExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitAbsExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ListExpressionContext extends ExpressionContext {
		public ListContext list() {
			return getRuleContext(ListContext.class,0);
		}
		public ListExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterListExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitListExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class NegExpressionContext extends ExpressionContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public NegExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterNegExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitNegExpression(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class InputExpressionContext extends ExpressionContext {
		public InputContext input() {
			return getRuleContext(InputContext.class,0);
		}
		public InputExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterInputExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitInputExpression(this);
		}
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 48;
		enterRecursionRule(_localctx, 48, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(279);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,26,_ctx) ) {
			case 1:
				{
				_localctx = new ConstExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(257);
				constant();
				}
				break;
			case 2:
				{
				_localctx = new VarExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(258);
				variable();
				}
				break;
			case 3:
				{
				_localctx = new ListExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(259);
				list();
				}
				break;
			case 4:
				{
				_localctx = new FuncCallExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(260);
				functionCall();
				}
				break;
			case 5:
				{
				_localctx = new ParentExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(261);
				match(T__5);
				setState(262);
				expression(0);
				setState(263);
				match(T__6);
				}
				break;
			case 6:
				{
				_localctx = new NotExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(265);
				match(T__32);
				setState(266);
				expression(10);
				}
				break;
			case 7:
				{
				_localctx = new AbsExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(267);
				match(T__33);
				setState(268);
				expression(0);
				setState(269);
				match(T__33);
				}
				break;
			case 8:
				{
				_localctx = new NegExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(271);
				match(T__34);
				setState(272);
				expression(4);
				}
				break;
			case 9:
				{
				_localctx = new InputExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(273);
				input();
				}
				break;
			case 10:
				{
				_localctx = new TurnStagesExpContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(274);
				match(T__35);
				setState(275);
				turnStages();
				setState(276);
				match(T__36);
				}
				break;
			case 11:
				{
				_localctx = new PMoveTypeExpContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(278);
				pieceMoveTypes();
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(299);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,28,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(297);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,27,_ctx) ) {
					case 1:
						{
						_localctx = new MultExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(281);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(282);
						multOp();
						setState(283);
						expression(9);
						}
						break;
					case 2:
						{
						_localctx = new AddExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(285);
						if (!(precpred(_ctx, 7))) throw new FailedPredicateException(this, "precpred(_ctx, 7)");
						setState(286);
						addOp();
						setState(287);
						expression(8);
						}
						break;
					case 3:
						{
						_localctx = new CompExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(289);
						if (!(precpred(_ctx, 6))) throw new FailedPredicateException(this, "precpred(_ctx, 6)");
						setState(290);
						compareOp();
						setState(291);
						expression(7);
						}
						break;
					case 4:
						{
						_localctx = new BoolExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(293);
						if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
						setState(294);
						boolOp();
						setState(295);
						expression(6);
						}
						break;
					}
					} 
				}
				setState(301);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,28,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TurnStagesContext extends ParserRuleContext {
		public ParameterListContext parameterList() {
			return getRuleContext(ParameterListContext.class,0);
		}
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public TurnStagesContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_turnStages; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterTurnStages(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitTurnStages(this);
		}
	}

	public final TurnStagesContext turnStages() throws RecognitionException {
		TurnStagesContext _localctx = new TurnStagesContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_turnStages);
		try {
			setState(307);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__37:
				enterOuterAlt(_localctx, 1);
				{
				setState(302);
				match(T__37);
				setState(303);
				parameterList();
				}
				break;
			case T__38:
				enterOuterAlt(_localctx, 2);
				{
				setState(304);
				match(T__38);
				setState(305);
				parameterList();
				}
				break;
			case T__5:
			case T__12:
			case T__13:
			case T__14:
			case T__15:
			case T__16:
			case T__20:
			case T__21:
			case T__22:
			case T__23:
			case T__24:
			case T__25:
			case T__26:
			case T__27:
			case T__28:
			case T__29:
			case T__30:
			case T__31:
			case T__60:
			case T__61:
			case T__62:
			case T__63:
			case T__64:
			case T__65:
			case T__66:
			case T__67:
			case T__68:
			case T__69:
			case T__70:
			case T__71:
			case T__72:
			case T__73:
			case T__74:
			case ID:
				enterOuterAlt(_localctx, 3);
				{
				setState(306);
				functionCall();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class InputContext extends ParserRuleContext {
		public InputTypesContext inputTypes() {
			return getRuleContext(InputTypesContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public InputContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_input; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterInput(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitInput(this);
		}
	}

	public final InputContext input() throws RecognitionException {
		InputContext _localctx = new InputContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_input);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(309);
			match(T__39);
			setState(310);
			match(T__20);
			setState(311);
			inputTypes();
			setState(312);
			match(T__5);
			setState(313);
			expression(0);
			setState(314);
			match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class InputTypesContext extends ParserRuleContext {
		public InputTypesContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_inputTypes; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterInputTypes(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitInputTypes(this);
		}
	}

	public final InputTypesContext inputTypes() throws RecognitionException {
		InputTypesContext _localctx = new InputTypesContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_inputTypes);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(316);
			_la = _input.LA(1);
			if ( !(_la==T__40 || _la==T__41) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class PieceMoveTypesContext extends ParserRuleContext {
		public PieceMoveTypesContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pieceMoveTypes; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterPieceMoveTypes(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitPieceMoveTypes(this);
		}
	}

	public final PieceMoveTypesContext pieceMoveTypes() throws RecognitionException {
		PieceMoveTypesContext _localctx = new PieceMoveTypesContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_pieceMoveTypes);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(318);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 61572651155456L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class MultOpContext extends ParserRuleContext {
		public MultOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_multOp; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterMultOp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitMultOp(this);
		}
	}

	public final MultOpContext multOp() throws RecognitionException {
		MultOpContext _localctx = new MultOpContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_multOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(320);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 492581209243648L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AddOpContext extends ParserRuleContext {
		public AddOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addOp; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterAddOp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitAddOp(this);
		}
	}

	public final AddOpContext addOp() throws RecognitionException {
		AddOpContext _localctx = new AddOpContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_addOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(322);
			_la = _input.LA(1);
			if ( !(_la==T__34 || _la==T__48) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CompareOpContext extends ParserRuleContext {
		public CompareOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compareOp; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterCompareOp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitCompareOp(this);
		}
	}

	public final CompareOpContext compareOp() throws RecognitionException {
		CompareOpContext _localctx = new CompareOpContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_compareOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(324);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 16888704761069568L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BoolOpContext extends ParserRuleContext {
		public BoolOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolOp; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterBoolOp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitBoolOp(this);
		}
	}

	public final BoolOpContext boolOp() throws RecognitionException {
		BoolOpContext _localctx = new BoolOpContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_boolOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(326);
			_la = _input.LA(1);
			if ( !(_la==T__53 || _la==T__54) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TypeContext extends ParserRuleContext {
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitType(this);
		}
	}

	public final TypeContext type() throws RecognitionException {
		TypeContext _localctx = new TypeContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_type);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(328);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 2233785415175766016L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class PropertyContext extends ParserRuleContext {
		public AttributeContext attribute() {
			return getRuleContext(AttributeContext.class,0);
		}
		public CollectionContext collection() {
			return getRuleContext(CollectionContext.class,0);
		}
		public ElementContext element() {
			return getRuleContext(ElementContext.class,0);
		}
		public PropertyContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_property; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterProperty(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitProperty(this);
		}
	}

	public final PropertyContext property() throws RecognitionException {
		PropertyContext _localctx = new PropertyContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_property);
		int _la;
		try {
			setState(339);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,32,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(331);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__20) {
					{
					setState(330);
					match(T__20);
					}
				}

				setState(333);
				attribute();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(335);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__20) {
					{
					setState(334);
					match(T__20);
					}
				}

				setState(337);
				collection();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(338);
				element();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AttributeContext extends ParserRuleContext {
		public AttributeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attribute; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterAttribute(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitAttribute(this);
		}
	}

	public final AttributeContext attribute() throws RecognitionException {
		AttributeContext _localctx = new AttributeContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_attribute);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(341);
			_la = _input.LA(1);
			if ( !(((((_la - 61)) & ~0x3f) == 0 && ((1L << (_la - 61)) & 32767L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ConstantContext extends ParserRuleContext {
		public TerminalNode INTEGER() { return getToken(Combined1Parser.INTEGER, 0); }
		public TerminalNode FLOAT() { return getToken(Combined1Parser.FLOAT, 0); }
		public TerminalNode BOOL() { return getToken(Combined1Parser.BOOL, 0); }
		public TerminalNode STRING() { return getToken(Combined1Parser.STRING, 0); }
		public TerminalNode NULL() { return getToken(Combined1Parser.NULL, 0); }
		public ColorContext color() {
			return getRuleContext(ColorContext.class,0);
		}
		public ConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitConstant(this);
		}
	}

	public final ConstantContext constant() throws RecognitionException {
		ConstantContext _localctx = new ConstantContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_constant);
		try {
			setState(349);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INTEGER:
				enterOuterAlt(_localctx, 1);
				{
				setState(343);
				match(INTEGER);
				}
				break;
			case FLOAT:
				enterOuterAlt(_localctx, 2);
				{
				setState(344);
				match(FLOAT);
				}
				break;
			case BOOL:
				enterOuterAlt(_localctx, 3);
				{
				setState(345);
				match(BOOL);
				}
				break;
			case STRING:
				enterOuterAlt(_localctx, 4);
				{
				setState(346);
				match(STRING);
				}
				break;
			case NULL:
				enterOuterAlt(_localctx, 5);
				{
				setState(347);
				match(NULL);
				}
				break;
			case T__75:
				enterOuterAlt(_localctx, 6);
				{
				setState(348);
				color();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ColorContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(Combined1Parser.STRING, 0); }
		public ColorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_color; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).enterColor(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof Combined1Listener ) ((Combined1Listener)listener).exitColor(this);
		}
	}

	public final ColorContext color() throws RecognitionException {
		ColorContext _localctx = new ColorContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_color);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(351);
			match(T__75);
			setState(352);
			match(T__5);
			setState(353);
			match(STRING);
			setState(354);
			match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 24:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 8);
		case 1:
			return precpred(_ctx, 7);
		case 2:
			return precpred(_ctx, 6);
		case 3:
			return precpred(_ctx, 5);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u0001U\u0165\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0002"+
		"\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007\u000f"+
		"\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002\u0012\u0007\u0012"+
		"\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002\u0015\u0007\u0015"+
		"\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017\u0002\u0018\u0007\u0018"+
		"\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a\u0002\u001b\u0007\u001b"+
		"\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d\u0002\u001e\u0007\u001e"+
		"\u0002\u001f\u0007\u001f\u0002 \u0007 \u0002!\u0007!\u0002\"\u0007\"\u0002"+
		"#\u0007#\u0002$\u0007$\u0002%\u0007%\u0001\u0000\u0001\u0000\u0005\u0000"+
		"O\b\u0000\n\u0000\f\u0000R\t\u0000\u0001\u0000\u0001\u0000\u0001\u0001"+
		"\u0001\u0001\u0001\u0002\u0001\u0002\u0005\u0002Z\b\u0002\n\u0002\f\u0002"+
		"]\t\u0002\u0001\u0002\u0001\u0002\u0001\u0003\u0001\u0003\u0001\u0003"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0003\u0003h\b\u0003"+
		"\u0001\u0004\u0001\u0004\u0001\u0004\u0001\u0004\u0001\u0004\u0001\u0004"+
		"\u0003\u0004p\b\u0004\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005"+
		"\u0003\u0005v\b\u0005\u0001\u0005\u0001\u0005\u0001\u0006\u0001\u0006"+
		"\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0003\u0006"+
		"\u0081\b\u0006\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007"+
		"\u0001\u0007\u0001\u0007\u0001\b\u0001\b\u0001\t\u0001\t\u0001\n\u0001"+
		"\n\u0003\n\u0090\b\n\u0001\u000b\u0001\u000b\u0001\f\u0001\f\u0001\f\u0001"+
		"\f\u0005\f\u0098\b\f\n\f\f\f\u009b\t\f\u0003\f\u009d\b\f\u0001\f\u0001"+
		"\f\u0001\r\u0001\r\u0001\r\u0001\r\u0001\u000e\u0001\u000e\u0001\u000e"+
		"\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000f\u0001\u000f\u0003\u000f"+
		"\u00ad\b\u000f\u0001\u000f\u0005\u000f\u00b0\b\u000f\n\u000f\f\u000f\u00b3"+
		"\t\u000f\u0001\u000f\u0004\u000f\u00b6\b\u000f\u000b\u000f\f\u000f\u00b7"+
		"\u0003\u000f\u00ba\b\u000f\u0001\u0010\u0003\u0010\u00bd\b\u0010\u0001"+
		"\u0010\u0003\u0010\u00c0\b\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0003"+
		"\u0010\u00c5\b\u0010\u0001\u0010\u0001\u0010\u0003\u0010\u00c9\b\u0010"+
		"\u0001\u0010\u0001\u0010\u0003\u0010\u00cd\b\u0010\u0003\u0010\u00cf\b"+
		"\u0010\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0012\u0001"+
		"\u0012\u0001\u0012\u0001\u0012\u0005\u0012\u00d9\b\u0012\n\u0012\f\u0012"+
		"\u00dc\t\u0012\u0003\u0012\u00de\b\u0012\u0001\u0012\u0001\u0012\u0001"+
		"\u0012\u0003\u0012\u00e3\b\u0012\u0001\u0013\u0001\u0013\u0001\u0013\u0001"+
		"\u0013\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001"+
		"\u0015\u0001\u0015\u0003\u0015\u00f0\b\u0015\u0001\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0016\u0001\u0016\u0001\u0016\u0003\u0016\u00f8\b\u0016\u0001"+
		"\u0016\u0001\u0016\u0001\u0016\u0003\u0016\u00fd\b\u0016\u0001\u0017\u0001"+
		"\u0017\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001"+
		"\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001"+
		"\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001"+
		"\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0003"+
		"\u0018\u0118\b\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001"+
		"\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001"+
		"\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0005"+
		"\u0018\u012a\b\u0018\n\u0018\f\u0018\u012d\t\u0018\u0001\u0019\u0001\u0019"+
		"\u0001\u0019\u0001\u0019\u0001\u0019\u0003\u0019\u0134\b\u0019\u0001\u001a"+
		"\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a"+
		"\u0001\u001b\u0001\u001b\u0001\u001c\u0001\u001c\u0001\u001d\u0001\u001d"+
		"\u0001\u001e\u0001\u001e\u0001\u001f\u0001\u001f\u0001 \u0001 \u0001!"+
		"\u0001!\u0001\"\u0003\"\u014c\b\"\u0001\"\u0001\"\u0003\"\u0150\b\"\u0001"+
		"\"\u0001\"\u0003\"\u0154\b\"\u0001#\u0001#\u0001$\u0001$\u0001$\u0001"+
		"$\u0001$\u0001$\u0003$\u015e\b$\u0001%\u0001%\u0001%\u0001%\u0001%\u0001"+
		"%\u0000\u00010&\u0000\u0002\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014"+
		"\u0016\u0018\u001a\u001c\u001e \"$&(*,.02468:<>@BDFHJ\u0000\u000b\u0001"+
		"\u0000MN\u0001\u0000\r\u0010\u0002\u0000\u0016 TT\u0001\u0000)*\u0001"+
		"\u0000+-\u0001\u0000.0\u0002\u0000##11\u0002\u0000$%25\u0001\u000067\u0001"+
		"\u00008<\u0001\u0000=K\u0178\u0000P\u0001\u0000\u0000\u0000\u0002U\u0001"+
		"\u0000\u0000\u0000\u0004W\u0001\u0000\u0000\u0000\u0006g\u0001\u0000\u0000"+
		"\u0000\bo\u0001\u0000\u0000\u0000\nu\u0001\u0000\u0000\u0000\fy\u0001"+
		"\u0000\u0000\u0000\u000e\u0082\u0001\u0000\u0000\u0000\u0010\u0089\u0001"+
		"\u0000\u0000\u0000\u0012\u008b\u0001\u0000\u0000\u0000\u0014\u008f\u0001"+
		"\u0000\u0000\u0000\u0016\u0091\u0001\u0000\u0000\u0000\u0018\u0093\u0001"+
		"\u0000\u0000\u0000\u001a\u00a0\u0001\u0000\u0000\u0000\u001c\u00a4\u0001"+
		"\u0000\u0000\u0000\u001e\u00b9\u0001\u0000\u0000\u0000 \u00ce\u0001\u0000"+
		"\u0000\u0000\"\u00d0\u0001\u0000\u0000\u0000$\u00e2\u0001\u0000\u0000"+
		"\u0000&\u00e4\u0001\u0000\u0000\u0000(\u00e8\u0001\u0000\u0000\u0000*"+
		"\u00ed\u0001\u0000\u0000\u0000,\u00f7\u0001\u0000\u0000\u0000.\u00fe\u0001"+
		"\u0000\u0000\u00000\u0117\u0001\u0000\u0000\u00002\u0133\u0001\u0000\u0000"+
		"\u00004\u0135\u0001\u0000\u0000\u00006\u013c\u0001\u0000\u0000\u00008"+
		"\u013e\u0001\u0000\u0000\u0000:\u0140\u0001\u0000\u0000\u0000<\u0142\u0001"+
		"\u0000\u0000\u0000>\u0144\u0001\u0000\u0000\u0000@\u0146\u0001\u0000\u0000"+
		"\u0000B\u0148\u0001\u0000\u0000\u0000D\u0153\u0001\u0000\u0000\u0000F"+
		"\u0155\u0001\u0000\u0000\u0000H\u015d\u0001\u0000\u0000\u0000J\u015f\u0001"+
		"\u0000\u0000\u0000LO\u0003\u0006\u0003\u0000MO\u0003\u0002\u0001\u0000"+
		"NL\u0001\u0000\u0000\u0000NM\u0001\u0000\u0000\u0000OR\u0001\u0000\u0000"+
		"\u0000PN\u0001\u0000\u0000\u0000PQ\u0001\u0000\u0000\u0000QS\u0001\u0000"+
		"\u0000\u0000RP\u0001\u0000\u0000\u0000ST\u0005\u0000\u0000\u0001T\u0001"+
		"\u0001\u0000\u0000\u0000UV\u0007\u0000\u0000\u0000V\u0003\u0001\u0000"+
		"\u0000\u0000W[\u0005\u0001\u0000\u0000XZ\u0003\u0006\u0003\u0000YX\u0001"+
		"\u0000\u0000\u0000Z]\u0001\u0000\u0000\u0000[Y\u0001\u0000\u0000\u0000"+
		"[\\\u0001\u0000\u0000\u0000\\^\u0001\u0000\u0000\u0000][\u0001\u0000\u0000"+
		"\u0000^_\u0005\u0002\u0000\u0000_\u0005\u0001\u0000\u0000\u0000`h\u0003"+
		"\n\u0005\u0000ah\u0003\b\u0004\u0000bh\u0003\f\u0006\u0000ch\u0003\u000e"+
		"\u0007\u0000dh\u0003(\u0014\u0000eh\u0003,\u0016\u0000fh\u0003\u0004\u0002"+
		"\u0000g`\u0001\u0000\u0000\u0000ga\u0001\u0000\u0000\u0000gb\u0001\u0000"+
		"\u0000\u0000gc\u0001\u0000\u0000\u0000gd\u0001\u0000\u0000\u0000ge\u0001"+
		"\u0000\u0000\u0000gf\u0001\u0000\u0000\u0000h\u0007\u0001\u0000\u0000"+
		"\u0000ij\u0005\u0003\u0000\u0000jk\u0005O\u0000\u0000kp\u0003\u0004\u0002"+
		"\u0000lm\u0005\u0003\u0000\u0000mn\u0005O\u0000\u0000np\u0005\u0004\u0000"+
		"\u0000oi\u0001\u0000\u0000\u0000ol\u0001\u0000\u0000\u0000p\t\u0001\u0000"+
		"\u0000\u0000qv\u0003 \u0010\u0000rv\u0003&\u0013\u0000sv\u0003\u0010\b"+
		"\u0000tv\u0003\u0012\t\u0000uq\u0001\u0000\u0000\u0000ur\u0001\u0000\u0000"+
		"\u0000us\u0001\u0000\u0000\u0000ut\u0001\u0000\u0000\u0000vw\u0001\u0000"+
		"\u0000\u0000wx\u0005\u0004\u0000\u0000x\u000b\u0001\u0000\u0000\u0000"+
		"yz\u0005\u0005\u0000\u0000z{\u0005\u0006\u0000\u0000{|\u00030\u0018\u0000"+
		"|}\u0005\u0007\u0000\u0000}\u0080\u0003\u0004\u0002\u0000~\u007f\u0005"+
		"\b\u0000\u0000\u007f\u0081\u0003\u0014\n\u0000\u0080~\u0001\u0000\u0000"+
		"\u0000\u0080\u0081\u0001\u0000\u0000\u0000\u0081\r\u0001\u0000\u0000\u0000"+
		"\u0082\u0083\u0005\t\u0000\u0000\u0083\u0084\u0003\u0004\u0002\u0000\u0084"+
		"\u0085\u0005\n\u0000\u0000\u0085\u0086\u0005\u0006\u0000\u0000\u0086\u0087"+
		"\u00030\u0018\u0000\u0087\u0088\u0005\u0007\u0000\u0000\u0088\u000f\u0001"+
		"\u0000\u0000\u0000\u0089\u008a\u0005\u000b\u0000\u0000\u008a\u0011\u0001"+
		"\u0000\u0000\u0000\u008b\u008c\u0005\f\u0000\u0000\u008c\u0013\u0001\u0000"+
		"\u0000\u0000\u008d\u0090\u0003\u0004\u0002\u0000\u008e\u0090\u0003\f\u0006"+
		"\u0000\u008f\u008d\u0001\u0000\u0000\u0000\u008f\u008e\u0001\u0000\u0000"+
		"\u0000\u0090\u0015\u0001\u0000\u0000\u0000\u0091\u0092\u0007\u0001\u0000"+
		"\u0000\u0092\u0017\u0001\u0000\u0000\u0000\u0093\u009c\u0005\u0011\u0000"+
		"\u0000\u0094\u0099\u00030\u0018\u0000\u0095\u0096\u0005\u0012\u0000\u0000"+
		"\u0096\u0098\u00030\u0018\u0000\u0097\u0095\u0001\u0000\u0000\u0000\u0098"+
		"\u009b\u0001\u0000\u0000\u0000\u0099\u0097\u0001\u0000\u0000\u0000\u0099"+
		"\u009a\u0001\u0000\u0000\u0000\u009a\u009d\u0001\u0000\u0000\u0000\u009b"+
		"\u0099\u0001\u0000\u0000\u0000\u009c\u0094\u0001\u0000\u0000\u0000\u009c"+
		"\u009d\u0001\u0000\u0000\u0000\u009d\u009e\u0001\u0000\u0000\u0000\u009e"+
		"\u009f\u0005\u0013\u0000\u0000\u009f\u0019\u0001\u0000\u0000\u0000\u00a0"+
		"\u00a1\u0005\u0011\u0000\u0000\u00a1\u00a2\u00030\u0018\u0000\u00a2\u00a3"+
		"\u0005\u0013\u0000\u0000\u00a3\u001b\u0001\u0000\u0000\u0000\u00a4\u00a5"+
		"\u0005\u0006\u0000\u0000\u00a5\u00a6\u00030\u0018\u0000\u00a6\u00a7\u0005"+
		"\u0012\u0000\u0000\u00a7\u00a8\u00030\u0018\u0000\u00a8\u00a9\u0005\u0007"+
		"\u0000\u0000\u00a9\u001d\u0001\u0000\u0000\u0000\u00aa\u00ad\u0005T\u0000"+
		"\u0000\u00ab\u00ad\u0003\u001c\u000e\u0000\u00ac\u00aa\u0001\u0000\u0000"+
		"\u0000\u00ac\u00ab\u0001\u0000\u0000\u0000\u00ad\u00b1\u0001\u0000\u0000"+
		"\u0000\u00ae\u00b0\u0003D\"\u0000\u00af\u00ae\u0001\u0000\u0000\u0000"+
		"\u00b0\u00b3\u0001\u0000\u0000\u0000\u00b1\u00af\u0001\u0000\u0000\u0000"+
		"\u00b1\u00b2\u0001\u0000\u0000\u0000\u00b2\u00ba\u0001\u0000\u0000\u0000"+
		"\u00b3\u00b1\u0001\u0000\u0000\u0000\u00b4\u00b6\u0003D\"\u0000\u00b5"+
		"\u00b4\u0001\u0000\u0000\u0000\u00b6\u00b7\u0001\u0000\u0000\u0000\u00b7"+
		"\u00b5\u0001\u0000\u0000\u0000\u00b7\u00b8\u0001\u0000\u0000\u0000\u00b8"+
		"\u00ba\u0001\u0000\u0000\u0000\u00b9\u00ac\u0001\u0000\u0000\u0000\u00b9"+
		"\u00b5\u0001\u0000\u0000\u0000\u00ba\u001f\u0001\u0000\u0000\u0000\u00bb"+
		"\u00bd\u0003B!\u0000\u00bc\u00bb\u0001\u0000\u0000\u0000\u00bc\u00bd\u0001"+
		"\u0000\u0000\u0000\u00bd\u00bf\u0001\u0000\u0000\u0000\u00be\u00c0\u0003"+
		"\"\u0011\u0000\u00bf\u00be\u0001\u0000\u0000\u0000\u00bf\u00c0\u0001\u0000"+
		"\u0000\u0000\u00c0\u00c1\u0001\u0000\u0000\u0000\u00c1\u00c4\u0005T\u0000"+
		"\u0000\u00c2\u00c3\u0005\u0014\u0000\u0000\u00c3\u00c5\u00030\u0018\u0000"+
		"\u00c4\u00c2\u0001\u0000\u0000\u0000\u00c4\u00c5\u0001\u0000\u0000\u0000"+
		"\u00c5\u00cf\u0001\u0000\u0000\u0000\u00c6\u00c8\u0003B!\u0000\u00c7\u00c9"+
		"\u0003\"\u0011\u0000\u00c8\u00c7\u0001\u0000\u0000\u0000\u00c8\u00c9\u0001"+
		"\u0000\u0000\u0000\u00c9\u00ca\u0001\u0000\u0000\u0000\u00ca\u00cc\u0005"+
		"T\u0000\u0000\u00cb\u00cd\u0003$\u0012\u0000\u00cc\u00cb\u0001\u0000\u0000"+
		"\u0000\u00cc\u00cd\u0001\u0000\u0000\u0000\u00cd\u00cf\u0001\u0000\u0000"+
		"\u0000\u00ce\u00bc\u0001\u0000\u0000\u0000\u00ce\u00c6\u0001\u0000\u0000"+
		"\u0000\u00cf!\u0001\u0000\u0000\u0000\u00d0\u00d1\u0005\u0006\u0000\u0000"+
		"\u00d1\u00d2\u0005T\u0000\u0000\u00d2\u00d3\u0005\u0007\u0000\u0000\u00d3"+
		"#\u0001\u0000\u0000\u0000\u00d4\u00dd\u0005\u0006\u0000\u0000\u00d5\u00da"+
		"\u00030\u0018\u0000\u00d6\u00d7\u0005\u0012\u0000\u0000\u00d7\u00d9\u0003"+
		"0\u0018\u0000\u00d8\u00d6\u0001\u0000\u0000\u0000\u00d9\u00dc\u0001\u0000"+
		"\u0000\u0000\u00da\u00d8\u0001\u0000\u0000\u0000\u00da\u00db\u0001\u0000"+
		"\u0000\u0000\u00db\u00de\u0001\u0000\u0000\u0000\u00dc\u00da\u0001\u0000"+
		"\u0000\u0000\u00dd\u00d5\u0001\u0000\u0000\u0000\u00dd\u00de\u0001\u0000"+
		"\u0000\u0000\u00de\u00df\u0001\u0000\u0000\u0000\u00df\u00e3\u0005\u0007"+
		"\u0000\u0000\u00e0\u00e1\u0005\u0006\u0000\u0000\u00e1\u00e3\u0005\u0007"+
		"\u0000\u0000\u00e2\u00d4\u0001\u0000\u0000\u0000\u00e2\u00e0\u0001\u0000"+
		"\u0000\u0000\u00e3%\u0001\u0000\u0000\u0000\u00e4\u00e5\u0003\u001e\u000f"+
		"\u0000\u00e5\u00e6\u0005\u0014\u0000\u0000\u00e6\u00e7\u00030\u0018\u0000"+
		"\u00e7\'\u0001\u0000\u0000\u0000\u00e8\u00e9\u0003\u001e\u000f\u0000\u00e9"+
		"\u00ea\u0005\u0015\u0000\u0000\u00ea\u00eb\u0003.\u0017\u0000\u00eb\u00ec"+
		"\u0003*\u0015\u0000\u00ec)\u0001\u0000\u0000\u0000\u00ed\u00ef\u0005\u0006"+
		"\u0000\u0000\u00ee\u00f0\u0003 \u0010\u0000\u00ef\u00ee\u0001\u0000\u0000"+
		"\u0000\u00ef\u00f0\u0001\u0000\u0000\u0000\u00f0\u00f1\u0001\u0000\u0000"+
		"\u0000\u00f1\u00f2\u0005\u0007\u0000\u0000\u00f2\u00f3\u0003\u0004\u0002"+
		"\u0000\u00f3+\u0001\u0000\u0000\u0000\u00f4\u00f5\u0003\u001e\u000f\u0000"+
		"\u00f5\u00f6\u0005\u0015\u0000\u0000\u00f6\u00f8\u0001\u0000\u0000\u0000"+
		"\u00f7\u00f4\u0001\u0000\u0000\u0000\u00f7\u00f8\u0001\u0000\u0000\u0000"+
		"\u00f8\u00f9\u0001\u0000\u0000\u0000\u00f9\u00fa\u0003.\u0017\u0000\u00fa"+
		"\u00fc\u0003$\u0012\u0000\u00fb\u00fd\u0005\u0004\u0000\u0000\u00fc\u00fb"+
		"\u0001\u0000\u0000\u0000\u00fc\u00fd\u0001\u0000\u0000\u0000\u00fd-\u0001"+
		"\u0000\u0000\u0000\u00fe\u00ff\u0007\u0002\u0000\u0000\u00ff/\u0001\u0000"+
		"\u0000\u0000\u0100\u0101\u0006\u0018\uffff\uffff\u0000\u0101\u0118\u0003"+
		"H$\u0000\u0102\u0118\u0003\u001e\u000f\u0000\u0103\u0118\u0003\u0018\f"+
		"\u0000\u0104\u0118\u0003,\u0016\u0000\u0105\u0106\u0005\u0006\u0000\u0000"+
		"\u0106\u0107\u00030\u0018\u0000\u0107\u0108\u0005\u0007\u0000\u0000\u0108"+
		"\u0118\u0001\u0000\u0000\u0000\u0109\u010a\u0005!\u0000\u0000\u010a\u0118"+
		"\u00030\u0018\n\u010b\u010c\u0005\"\u0000\u0000\u010c\u010d\u00030\u0018"+
		"\u0000\u010d\u010e\u0005\"\u0000\u0000\u010e\u0118\u0001\u0000\u0000\u0000"+
		"\u010f\u0110\u0005#\u0000\u0000\u0110\u0118\u00030\u0018\u0004\u0111\u0118"+
		"\u00034\u001a\u0000\u0112\u0113\u0005$\u0000\u0000\u0113\u0114\u00032"+
		"\u0019\u0000\u0114\u0115\u0005%\u0000\u0000\u0115\u0118\u0001\u0000\u0000"+
		"\u0000\u0116\u0118\u00038\u001c\u0000\u0117\u0100\u0001\u0000\u0000\u0000"+
		"\u0117\u0102\u0001\u0000\u0000\u0000\u0117\u0103\u0001\u0000\u0000\u0000"+
		"\u0117\u0104\u0001\u0000\u0000\u0000\u0117\u0105\u0001\u0000\u0000\u0000"+
		"\u0117\u0109\u0001\u0000\u0000\u0000\u0117\u010b\u0001\u0000\u0000\u0000"+
		"\u0117\u010f\u0001\u0000\u0000\u0000\u0117\u0111\u0001\u0000\u0000\u0000"+
		"\u0117\u0112\u0001\u0000\u0000\u0000\u0117\u0116\u0001\u0000\u0000\u0000"+
		"\u0118\u012b\u0001\u0000\u0000\u0000\u0119\u011a\n\b\u0000\u0000\u011a"+
		"\u011b\u0003:\u001d\u0000\u011b\u011c\u00030\u0018\t\u011c\u012a\u0001"+
		"\u0000\u0000\u0000\u011d\u011e\n\u0007\u0000\u0000\u011e\u011f\u0003<"+
		"\u001e\u0000\u011f\u0120\u00030\u0018\b\u0120\u012a\u0001\u0000\u0000"+
		"\u0000\u0121\u0122\n\u0006\u0000\u0000\u0122\u0123\u0003>\u001f\u0000"+
		"\u0123\u0124\u00030\u0018\u0007\u0124\u012a\u0001\u0000\u0000\u0000\u0125"+
		"\u0126\n\u0005\u0000\u0000\u0126\u0127\u0003@ \u0000\u0127\u0128\u0003"+
		"0\u0018\u0006\u0128\u012a\u0001\u0000\u0000\u0000\u0129\u0119\u0001\u0000"+
		"\u0000\u0000\u0129\u011d\u0001\u0000\u0000\u0000\u0129\u0121\u0001\u0000"+
		"\u0000\u0000\u0129\u0125\u0001\u0000\u0000\u0000\u012a\u012d\u0001\u0000"+
		"\u0000\u0000\u012b\u0129\u0001\u0000\u0000\u0000\u012b\u012c\u0001\u0000"+
		"\u0000\u0000\u012c1\u0001\u0000\u0000\u0000\u012d\u012b\u0001\u0000\u0000"+
		"\u0000\u012e\u012f\u0005&\u0000\u0000\u012f\u0134\u0003$\u0012\u0000\u0130"+
		"\u0131\u0005\'\u0000\u0000\u0131\u0134\u0003$\u0012\u0000\u0132\u0134"+
		"\u0003,\u0016\u0000\u0133\u012e\u0001\u0000\u0000\u0000\u0133\u0130\u0001"+
		"\u0000\u0000\u0000\u0133\u0132\u0001\u0000\u0000\u0000\u01343\u0001\u0000"+
		"\u0000\u0000\u0135\u0136\u0005(\u0000\u0000\u0136\u0137\u0005\u0015\u0000"+
		"\u0000\u0137\u0138\u00036\u001b\u0000\u0138\u0139\u0005\u0006\u0000\u0000"+
		"\u0139\u013a\u00030\u0018\u0000\u013a\u013b\u0005\u0007\u0000\u0000\u013b"+
		"5\u0001\u0000\u0000\u0000\u013c\u013d\u0007\u0003\u0000\u0000\u013d7\u0001"+
		"\u0000\u0000\u0000\u013e\u013f\u0007\u0004\u0000\u0000\u013f9\u0001\u0000"+
		"\u0000\u0000\u0140\u0141\u0007\u0005\u0000\u0000\u0141;\u0001\u0000\u0000"+
		"\u0000\u0142\u0143\u0007\u0006\u0000\u0000\u0143=\u0001\u0000\u0000\u0000"+
		"\u0144\u0145\u0007\u0007\u0000\u0000\u0145?\u0001\u0000\u0000\u0000\u0146"+
		"\u0147\u0007\b\u0000\u0000\u0147A\u0001\u0000\u0000\u0000\u0148\u0149"+
		"\u0007\t\u0000\u0000\u0149C\u0001\u0000\u0000\u0000\u014a\u014c\u0005"+
		"\u0015\u0000\u0000\u014b\u014a\u0001\u0000\u0000\u0000\u014b\u014c\u0001"+
		"\u0000\u0000\u0000\u014c\u014d\u0001\u0000\u0000\u0000\u014d\u0154\u0003"+
		"F#\u0000\u014e\u0150\u0005\u0015\u0000\u0000\u014f\u014e\u0001\u0000\u0000"+
		"\u0000\u014f\u0150\u0001\u0000\u0000\u0000\u0150\u0151\u0001\u0000\u0000"+
		"\u0000\u0151\u0154\u0003\u0016\u000b\u0000\u0152\u0154\u0003\u001a\r\u0000"+
		"\u0153\u014b\u0001\u0000\u0000\u0000\u0153\u014f\u0001\u0000\u0000\u0000"+
		"\u0153\u0152\u0001\u0000\u0000\u0000\u0154E\u0001\u0000\u0000\u0000\u0155"+
		"\u0156\u0007\n\u0000\u0000\u0156G\u0001\u0000\u0000\u0000\u0157\u015e"+
		"\u0005O\u0000\u0000\u0158\u015e\u0005P\u0000\u0000\u0159\u015e\u0005R"+
		"\u0000\u0000\u015a\u015e\u0005Q\u0000\u0000\u015b\u015e\u0005S\u0000\u0000"+
		"\u015c\u015e\u0003J%\u0000\u015d\u0157\u0001\u0000\u0000\u0000\u015d\u0158"+
		"\u0001\u0000\u0000\u0000\u015d\u0159\u0001\u0000\u0000\u0000\u015d\u015a"+
		"\u0001\u0000\u0000\u0000\u015d\u015b\u0001\u0000\u0000\u0000\u015d\u015c"+
		"\u0001\u0000\u0000\u0000\u015eI\u0001\u0000\u0000\u0000\u015f\u0160\u0005"+
		"L\u0000\u0000\u0160\u0161\u0005\u0006\u0000\u0000\u0161\u0162\u0005Q\u0000"+
		"\u0000\u0162\u0163\u0005\u0007\u0000\u0000\u0163K\u0001\u0000\u0000\u0000"+
		"\"NP[gou\u0080\u008f\u0099\u009c\u00ac\u00b1\u00b7\u00b9\u00bc\u00bf\u00c4"+
		"\u00c8\u00cc\u00ce\u00da\u00dd\u00e2\u00ef\u00f7\u00fc\u0117\u0129\u012b"+
		"\u0133\u014b\u014f\u0153\u015d";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}