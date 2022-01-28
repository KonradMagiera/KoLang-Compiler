grammar KoLang;

program: statement* EOF ;

statement: PRINT LPARENTHESIS value RPARENTHESIS	                    #print
         | PRINT LPARENTHESIS ID LBRACKET INT RBRACKET RPARENTHESIS     #printArrayItem
         | READ LPARENTHESIS ID RPARENTHESIS                            #read
         | 'zmienna' ID ASSIGN value                                    #assign
         | 'zmienna' ID ASSIGN arrayAssignItem                          #assignArrayItemToID
         | ID LBRACKET INT RBRACKET ASSIGN math                         #changeArrayItemValue
         | 'zmienna' ID LBRACKET INT? RBRACKET ASSIGN LBRACE arrayVal (',' arrayVal)* RBRACE                        #assignArray
         | 'if' LPARENTHESIS comparision RPARENTHESIS LBRACE statement* RBRACE elseifStatement? elseStatement?      #ifStatement
         | 'while' LPARENTHESIS whileComp RPARENTHESIS LBRACE statement* RBRACE                                     #while
         | functionReturnType ID LPARENTHESIS functionArguments? RPARENTHESIS LBRACE statement* ('return' math)? RBRACE  #function
         | callFunction                             #invokeFunction
         | 'zmienna' ID ASSIGN callFunction         #assignFunction
         ;

value: ID
     | math
     | stringConcat ;

arrayAssignItem: ID LBRACKET INT RBRACKET ;

math: LPARENTHESIS math RPARENTHESIS    #parent 
    | math operatorTwo math             #multiply 
    | math operatorOne math             #add 
    | number                            #single 
    ;


number: INT
      | REAL
      | ID ;

stringConcat: concatVal ('+' concatVal)* ;

concatVal: STRING 
         | INT
         | REAL ;

arrayVal: INT
        | REAL ;

whileComp: compValueFirst compareOperator compValueSecond ;

elseifStatement: 'else if' LPARENTHESIS comparision RPARENTHESIS LBRACE statement* RBRACE elseifStatement? ;

elseStatement: 'else' LBRACE statement* RBRACE ;

comparision: compValueFirst compareOperator compValueSecond ;

compValueFirst: math ;
compValueSecond: math ;

callFunction: ID LPARENTHESIS givenFunctionArguments? RPARENTHESIS ;

functionArguments: functionArg (',' functionArg)* ;
functionArg: functionArgType ID ;

givenFunctionArguments: givenFunctionArg (',' givenFunctionArg)* ;
givenFunctionArg: ID ;

functionArgType: 'int' | 'double' ;
functionReturnType: 'void' | 'int' | 'double' ;
operatorOne: '-' | '+' ;
operatorTwo: '*' | '/' ;
compareOperator: '<' | '>' | '<=' | '>=' | '==' | '!=' ;
PRINT:	'pokazMiSwojeTowary' ;
READ: 'DajMiLiczbe' ;
STRING:  '"' ( ~('\\'|'"') )* '"' ;
ID:   ('a'..'z'|'A'..'Z')+ ;
INT:   [+-]?[0-9]+ ;
REAL: [+-]?[0-9]+'.'[0-9]+ ;
ASSIGN: '=' ;
LPARENTHESIS: '(' ;
RPARENTHESIS: ')' ;
LBRACKET: '[' ;
RBRACKET: ']' ;
LBRACE: '{' ;
RBRACE: '}' ;
WS: [ \t\r\n]+ -> skip ;
COMMENT: '//'~('\n')*'\n'* -> skip ;
MULTILINECOMMENT: '/*' .*? '*/' -> skip ;