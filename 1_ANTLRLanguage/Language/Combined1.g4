grammar Combined1;

program: (line | comment)* EOF;

comment: COMMENT | LINE_COMMENT;

COMMENT : '/*' .*? '*/';
LINE_COMMENT : '//' ~[\r\n]*;

line: statement | phase | ifBlock | repeatUntil | functionBody | functionCall | block | logStatement;


//////////////////////////
/*	SIMPLE STRUCTURES	*/

block: '{' (line | comment)* '}';

logStatement: '#' expression ';';

phase: 'Phase' INTEGER block | 'Phase' INTEGER ';';

ifBlock: 'if' '(' expression ')' block ('else' elseifBlock)?;

elseifBlock: block | ifBlock;

repeatUntil: 'repeat' block 'until' '(' expression ')';


//////////////////
/*	STATEMENTS	*/

statement: (declaration | assignment | stop | cancel) ';';

declaration: type pieceType? ID (parameterList)? ('=' list)?;

assignment: variable '=' expression;

stop: 'stop';

cancel: 'cancel';


//////////////////
/*	VARIABLES	*/

variable: (ID|tile) member* | member+;

pieceType: '('ID')';

parameterList: '(' (expression (',' expression)*)? ')' | '(' ')';

 type
	:	'Player'
	|	'Piece'
	|	'Tile'
	|	'Dice'
	|	'List'
	;

member: '.'? field | '.'? collection | element;

field
    : 'pieces' | 'tiles' | 'players' | 'empty'
    | 'posX' | 'posY' | 'player' | 'color' | 'route' | 'routePosition'
    | 'texture' | 'type' | 'name' | 'value' | 'size' 
	| 'active' | 'text' | 'textColor' | 'fontSize' | 'onClick'
    | '@' parameterList
	;
 
tile: '(' expression ','expression ')';


//////////////
/*	LISTS	*/

collection: 'all' | 'none' | 'any' | 'count';

list: '[' (expression (',' expression)*)? ']';

element: '[' expression ']';


//////////////////
/*	FUNSTIONS	*/

functionBody: variable '.' functionName functionBlock;

functionBlock: '(' declaration? ')' block;

functionCall: (variable '.')? functionName  parameterList (';')?;

functionName: 'Rule' | 'Turn' | 'EndTurn' | 'WinCondition' | 'MoveTo' | 'Remove' | 'TryTurn' | 'Add' | 'Move'| 'Find'  | 'Roll' | ID;


//////////////////
/*	EXPRESSIONS	*/

 expression
	: constant								#constExpression
	| variable								#varExpression
	| list									#listExpression
	| functionCall							#funcCallExpression
	| '(' expression ')'					#parentExpression
	| '!' expression						#notExpression
	| '|' expression '|'					#absExpression
	| expression multOp expression			#multExpression
	| expression addOp expression			#addExpression
	| expression compareOp expression		#compExpression
	| expression boolOp expression			#boolExpression
	| '-' expression						#negExpression
	| input									#inputExpression
	| '<'turnStages'>'						#turnStagesExp
	| pieceMoveTypes						#pMoveTypeExp
	| neighbors								#neighborsExp
	;

turnStages: 'SelectPiece' parameterList | 'SelectTile' parameterList | functionCall;
input: 'INPUT' '.' inputTypes '(' expression ')';
inputTypes: 'Click' | 'Press';
pieceMoveTypes: 'Step' | 'Slide' | 'Jump';
neighbors: 'N' | 'E' | 'S' | 'W';

multOp: '*' | '/' | '%';
addOp: '+' | '-';
compareOp: '==' | '!=' | '>' | '<' | '>=' | '<=';
boolOp: 'AND' | 'OR';

constant: INTEGER | FLOAT | BOOL | STRING | NULL | color;
color: 'Color' '(' STRING ')';

INTEGER: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+;
STRING: '"' ('\\' ["\\] | ~["\\\r\n])* '"' ;
BOOL: 'true' | 'false';
NULL: 'NULL';

ID: [a-zA-Z_][a-zA-Z0-9_]*;

WS: [ \t\r\n]+ -> skip;


