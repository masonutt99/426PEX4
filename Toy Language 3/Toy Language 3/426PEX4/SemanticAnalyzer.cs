using CS426.node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS426.analysis
{
    class SemanticAnalyzer : DepthFirstAdapter
    {
        // This symbol table keeps track of global "stuff"
        Dictionary<string, Definition> globalSymbolTable = new Dictionary<string, Definition>();

        // This symbol table keeps track of local "stuff"
        Dictionary<string, Definition> localSymbolTable = new Dictionary<string, Definition>();

        // This symbol table keeps track of a parameter's ID and TYPE
        Dictionary<string, Definition> parameterTable = new Dictionary<string, Definition>();

        // This is our decorated parse tree, implemented as a dictionary
        Dictionary<Node, Definition> decoratedParseTree = new Dictionary<Node, Definition>();

        public void PrintWarning(Token t, string message)
        {
            Console.WriteLine(t.Line + "," + t.Pos + ":" + message);
        }

        // PEX 3 code goes here!
        public override void InAProgram(AProgram node)
        {
            // Create Definition for Integers
            Definition intDefinition = new NumberDefinition();
            intDefinition.name = "int";

            // Create Definition for Floats
            Definition floatDefinition = new NumberDefinition();
            intDefinition.name = "float";

            // Create Definition for Strings
            Definition strDefinition = new StringDefinition();
            strDefinition.name = "string";

            // Create Definition for Booleans (To be used for if and while statements)
            Definition booleanDefinition = new BooleanDefinition();
            booleanDefinition.name = "boolean";

            globalSymbolTable.Add("int", intDefinition);
            globalSymbolTable.Add("float", floatDefinition);
            globalSymbolTable.Add("string", strDefinition);
            globalSymbolTable.Add("boolean", booleanDefinition);
        }

        // --------------------------------------------------------------
        // OPERAND
        // --------------------------------------------------------------
        public override void OutAIntexpOperand(AIntexpOperand node)
        {
            // Creates the Definition Object we will add to our parse tree
            Definition intDefinition = new NumberDefinition();
            intDefinition.name = "int";

            // Adds this node to the decorated parse tree
            decoratedParseTree.Add(node, intDefinition);
        }
        public override void OutAFloatexpOperand(AFloatexpOperand node)
        {
            // Creates the Definition Object we will add to our parse tree
            Definition floatDefinition = new NumberDefinition();
            floatDefinition.name = "float";

            // Adds this node to the decorated parse tree
            decoratedParseTree.Add(node, floatDefinition);
        }
        public override void OutAStringexpOperand(AStringexpOperand node)
        {
            // Creates the Definition Object we will add to our parse tree
            Definition stringDefinition = new StringDefinition();
            stringDefinition.name = "string";

            // Adds this node to the decorated parse tree
            decoratedParseTree.Add(node, stringDefinition);
        }
        public override void OutAVariableOperand(AVariableOperand node)
        {
            // Gets the Name of the ID
            String varName = node.GetId().Text;

            // This will contain the definition of the variable from the
            // symbol table, assuming it exists
            Definition varDefinition;

            // Checks the symbol table to see if the variable has been declared
            if (!localSymbolTable.TryGetValue(varName, out varDefinition))
            {
                // Prints out a warning that the variable does not exist
                PrintWarning(node.GetId(), "Variable " + varName + " does not exist");
            }
            // Checks to see if the value obtained from the localSymbolTable is a VariableDefinition
            else if (!(varDefinition is VariableDefinition))
            {
                PrintWarning(node.GetId(), "Identifier" + varName + " is not a variable");
            }
            else
            {
                // This casts the variable definition so that we can access its contents
                VariableDefinition v = (VariableDefinition)varDefinition;

                // Decorates the parse tree with the type of the variable
                decoratedParseTree.Add(node, v.variableType);
            }
        }

        // --------------------------------------------------------------
        // EXPRESSION 8
        // --------------------------------------------------------------
        public override void OutAPassExpression8(APassExpression8 node)
        {
            Definition operandDefinition;

            if (!decoratedParseTree.TryGetValue(node.GetOperand(), out operandDefinition))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else
            {
                decoratedParseTree.Add(node, operandDefinition);
            }
        }
        public override void OutAParenthesesexpExpression8(AParenthesesexpExpression8 node)
        {
            Definition leftParenthesisDefinition;
            Definition expressionDefinition;
            Definition rightParenthesisDefinition;

            if (!decoratedParseTree.TryGetValue(node.GetLeftParenthesis(), out leftParenthesisDefinition))
            {
                PrintWarning(node.GetLeftParenthesis(), "Expected (");

            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDefinition))
            {
                // If the error was here, it would have already been found
            }
            else if (!decoratedParseTree.TryGetValue(node.GetRightParenthesis(), out rightParenthesisDefinition))
            {
                PrintWarning(node.GetRightParenthesis(), "Expected )");
            }
            else
            {
                decoratedParseTree.Add(node, leftParenthesisDefinition);
                decoratedParseTree.Add(node, expressionDefinition);
                decoratedParseTree.Add(node, rightParenthesisDefinition);

            }
        }

        // --------------------------------------------------------------
        // EXPRESSION 7
        // --------------------------------------------------------------
        public override void OutAPassExpression7(APassExpression7 node)
        {
            Definition expression8Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression8(), out expression8Def))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else
            {
                decoratedParseTree.Add(node, expression8Def);
            }
        }
        public override void OutANotexpExpression7(ANotexpExpression7 node)
        {
            Definition notDef;
            Definition expression8Def;

            if (!decoratedParseTree.TryGetValue(node.GetNot(), out notDef))
            {
                PrintWarning(node.GetNot(), "Expected !");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression8(), out expression8Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                // I think we need to add this as a boolean?
                decoratedParseTree.Add(node, notDef);
                decoratedParseTree.Add(node, expression8Def);
            }
        }
        public override void OutANegateexpExpression7(ANegateexpExpression7 node)
        {
            Definition minusDef;
            Definition expression8Def;

            if (!decoratedParseTree.TryGetValue(node.GetMinus(), out minusDef))
            {
                PrintWarning(node.GetMinus(), "Expected -");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression8(), out expression8Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                decoratedParseTree.Add(node, minusDef);
                decoratedParseTree.Add(node, expression8Def);
            }
        }

        // --------------------------------------------------------------
        // EXPRESSION 6
        // --------------------------------------------------------------
        public override void OutAPassExpression6(APassExpression6 node)
        {
            Definition expression7Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression7(), out expression7Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                decoratedParseTree.Add(node, expression7Def);
            }
        }
        public override void OutADivexpExpression6(ADivexpExpression6 node)
        {
            Definition expression6Def;
            Definition divDef;
            Definition expression7Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression6(), out expression6Def))
            {
                // If the error was here, it would have already been found
            }
            else if (!decoratedParseTree.TryGetValue(node.GetDiv(), out divDef))
            {
                PrintWarning(node.GetDiv(), "Expected /");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression7(), out expression7Def))
            {
                // if the error was here, it would have already been found
            }
            else
            {
                decoratedParseTree.Add(node, expression6Def);
                decoratedParseTree.Add(node, divDef);
                decoratedParseTree.Add(node, expression7Def);

            }
        }
        public override void OutAMultexpExpression6(AMultexpExpression6 node)
        {
            Definition expression6Def;
            Definition multDef;
            Definition expression7Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression6(), out expression6Def))
            {
                // If the error was here, it would have already been found
            }
            else if (!decoratedParseTree.TryGetValue(node.GetMult(), out multDef))
            {
                PrintWarning(node.GetMult(), "Expected /");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression7(), out expression7Def))
            {
                // if the error was here, it would have already been found
            }
            else
            {
                decoratedParseTree.Add(node, expression6Def);
                decoratedParseTree.Add(node, multDef);
                decoratedParseTree.Add(node, expression7Def);

            }
        }

        // --------------------------------------------------------------
        // EXPRESSION 5
        // --------------------------------------------------------------
        public override void OutAPassExpression5(APassExpression5 node)
        {
            Definition expression6Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression6(), out expression6Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                decoratedParseTree.Add(node, expression6Def);
            }
        }
        public override void OutASubtractexpExpression5(ASubtractexpExpression5 node)
        {
            Definition expression5Def;
            Definition minusDef;
            Definition expression6Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression5(), out expression5Def))
            {
                // If the error was here, it would have already been found
            }
            else if (!decoratedParseTree.TryGetValue(node.GetMinus(), out minusDef))
            {
                PrintWarning(node.GetMinus(), "Expected -");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression6(), out expression6Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                decoratedParseTree.Add(node, expression5Def);
                decoratedParseTree.Add(node, minusDef);
                decoratedParseTree.Add(node, expression6Def);
            }
        }
        public override void OutAAddexpExpression5(AAddexpExpression5 node)
        {
            Definition expression5Def;
            Definition plusDef;
            Definition expression6Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression5(), out expression5Def))
            {
                // If the error was here, it would have already been found
            }
            else if (!decoratedParseTree.TryGetValue(node.GetPlus(), out plusDef))
            {
                PrintWarning(node.GetPlus(), "Expected -");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression6(), out expression6Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                decoratedParseTree.Add(node, expression5Def);
                decoratedParseTree.Add(node, plusDef);
                decoratedParseTree.Add(node, expression6Def);
            }
        }

        // --------------------------------------------------------------
        // EXPRESSION 4
        // --------------------------------------------------------------
        public override void OutAPassExpression4(APassExpression4 node)
        {
            Definition expression5Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression5(), out expression5Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                decoratedParseTree.Add(node, expression5Def);
            }
        }
        public override void OutAGreaterexpExpression4(AGreaterexpExpression4 node)
        {
            Definition expression4Def;
            Definition greaterThanDef;
            Definition expression5Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression4(), out expression4Def))
            {
                // If the error was here, it would have already been found
            }
            else if (!decoratedParseTree.TryGetValue(node.GetGreaterThan(), out greaterThanDef))
            {
                PrintWarning(node.GetGreaterThan(), "Expected >");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression5(), out expression5Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                // I think we need to add this node as a boolean?
                decoratedParseTree.Add(node, expression4Def);
                decoratedParseTree.Add(node, greaterThanDef);
                decoratedParseTree.Add(node, expression5Def);
            }
        }
        public override void OutALessexpExpression4(ALessexpExpression4 node)
        {
            Definition expression4Def;
            Definition lessThanDef;
            Definition expression5Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression4(), out expression4Def))
            {
                // If the error was here, it would have already been found
            }
            else if (!decoratedParseTree.TryGetValue(node.GetLessThan(), out lessThanDef))
            {
                PrintWarning(node.GetLessThan(), "Expected <");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression5(), out expression5Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                // I think we need to add this node as a boolean?
                decoratedParseTree.Add(node, expression4Def);
                decoratedParseTree.Add(node, lessThanDef);
                decoratedParseTree.Add(node, expression5Def);
            }
        }

        // --------------------------------------------------------------
        // EXPRESSION 3
        // --------------------------------------------------------------
        public override void OutAPassExpression3(APassExpression3 node)
        {
            Definition expression4Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression4(), out expression4Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                decoratedParseTree.Add(node, expression4Def);
            }
        }
        public override void OutANotequalexpExpression3(ANotequalexpExpression3 node)
        {
            Definition expression3Def;
            Definition notEqualDef;
            Definition expression4Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3Def))
            {
                // If the error was here, it would have already been found
            }
            else if (!decoratedParseTree.TryGetValue(node.GetNotEquivalent(), out notEqualDef))
            {
                PrintWarning(node.GetNotEquivalent(), "Expected !=");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression4(), out expression4Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                // I think we need to add this node as a boolean?
                decoratedParseTree.Add(node, expression3Def);
                decoratedParseTree.Add(node, notEqualDef);
                decoratedParseTree.Add(node, expression4Def);
            }
        }
        public override void OutAEqualexpExpression3(AEqualexpExpression3 node)
        {
            Definition expression3Def;
            Definition equalDef;
            Definition expression4Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3Def))
            {
                // If the error was here, it would have already been found
            }
            else if (!decoratedParseTree.TryGetValue(node.GetEquivalent(), out equalDef))
            {
                PrintWarning(node.GetEquivalent(), "Expected ==");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression4(), out expression4Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                // I think we need to add this node as a boolean?
                decoratedParseTree.Add(node, expression3Def);
                decoratedParseTree.Add(node, equalDef);
                decoratedParseTree.Add(node, expression4Def);
            }
        }

        // --------------------------------------------------------------
        // EXPRESSION 2
        // --------------------------------------------------------------
        public override void OutAPassExpression2(APassExpression2 node)
        {
            Definition expression3Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3Def))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else
            {
                decoratedParseTree.Add(node, expression3Def);
            }
        }
        public override void OutAAndexpExpression2(AAndexpExpression2 node)
        {
            Definition expression2Def;
            Definition andDef;
            Definition expression3Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2Def))
            {
                // If the error was here, it would have already been found
            }
            else if (!decoratedParseTree.TryGetValue(node.GetAnd(), out andDef))
            {
                PrintWarning(node.GetAnd(), "Expected &&");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                decoratedParseTree.Add(node, expression2Def);
                decoratedParseTree.Add(node, andDef);
                decoratedParseTree.Add(node, expression3Def);
            }
        }

        // --------------------------------------------------------------
        // EXPRESSION
        // --------------------------------------------------------------
        public override void OutAPassExpression(APassExpression node)
        {
            Definition expression2Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2Def))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else
            {
                decoratedParseTree.Add(node, expression2Def);
            }
        }
        public override void OutAOrexpExpression(AOrexpExpression node)
        {
            Definition expressionDef;
            Definition orDef;
            Definition expression2Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                // If the error was here, it would have already been found
            }
            else if (!decoratedParseTree.TryGetValue(node.GetOr(), out orDef))
            {
                PrintWarning(node.GetOr(), "Expected &&");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2Def))
            {
                // If the error was here, it would have already been found
            }
            else
            {
                decoratedParseTree.Add(node, expressionDef);
                decoratedParseTree.Add(node, orDef);
                decoratedParseTree.Add(node, expression2Def);
            }
        }

        // --------------------------------------------------------------
        // DECLARE STATEMENT
        // --------------------------------------------------------------
        public override void OutADeclareStatement(ADeclareStatement node)
        {
            Definition typeDef;
            Definition idDef;

            if (!globalSymbolTable.TryGetValue(node.GetType().Text, out typeDef))
            {
                // If the type doesn't exist, throw an error
                PrintWarning(node.GetType(), "Type " + node.GetType().Text + " does not exist");
            }
            else if (localSymbolTable.TryGetValue(node.GetVarname().Text, out idDef))
            {
                // If the id exists, then we can't declare something with the same name
                PrintWarning(node.GetVarname(), "ID " + node.GetVarname().Text
                    + " has already been declared");
            }
            else
            {
                // Add the id to the symbol table
                VariableDefinition newVariableDefinition = new VariableDefinition();
                newVariableDefinition.name = node.GetVarname().Text;
                newVariableDefinition.variableType = (TypeDefinition)typeDef;

                localSymbolTable.Add(node.GetVarname().Text, newVariableDefinition);
            }
        }

        // --------------------------------------------------------------
        // ASSIGN STATEMENT
        // --------------------------------------------------------------
        public override void OutAAssignStatement(AAssignStatement node)
        {
            Definition idDef;
            Definition expressionDef;

            if (!localSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "ID " + node.GetId().Text + " does not exist");
            }
            else if (!(idDef is VariableDefinition))
            {
                PrintWarning(node.GetId(), "ID " + node.GetId().Text + " is not a variable");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (((VariableDefinition)idDef).variableType.name != expressionDef.name)
            {
                PrintWarning(node.GetId(), "Cannot assign value of type " + expressionDef.name
                    + " to variable of type " + ((VariableDefinition)idDef).variableType.name);
            }
            else
            {
                // NOTHING IS REQUIRED ONCE ALL THE TESTS HAVE PASSED
            }
        }

        // --------------------------------------------------------------
        // If STATEMENT
        // --------------------------------------------------------------
        public override void OutAIfStatement(AIfStatement node)
        {
            
            Definition expressionDef;
            
            Definition statementDef;
            
            

            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (!(expressionDef is BooleanDefinition))
            {
                PrintWarning(node.GetExpression(), " is not bool");
            }
            else
            {
                // NOTHING IS REQUIRED ONCE ALL THE TESTS HAVE PASSED
            }
        }

        // --------------------------------------------------------------
        // If STATEMENT
        // --------------------------------------------------------------
        public override void OutAWhileStatement(AWhileStatement node)
        {

            Definition expressionDef;

            Definition statementDef;



            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (!(expressionDef is BooleanDefinition))
            {
                PrintWarning(node.GetExpression(), " is not Bool");
            }
            else
            {
                // NOTHING IS REQUIRED ONCE ALL THE TESTS HAVE PASSED
            }
        }

        // --------------------------------------------------------------
        // FUNCTION DECLARATIONS
        // --------------------------------------------------------------
        public override void InAFunctionDeclaration(AFunctionDeclaration node)
        {
            Definition idDef;

            if (globalSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "Identifier " + node.GetId().Text + " is already being used");
            }
            else
            {
                // Wipes out the local symbol table
                localSymbolTable = new Dictionary<string, Definition>();

                // Registers the New Function Definition in the Global Table
                FunctionDefinition newFunctionDefinition = new FunctionDefinition();
                newFunctionDefinition.name = node.GetId().Text;

                // TODO:  You will have to figure out how to populate this with parameters
                // when you work on PEX 3
                newFunctionDefinition.parameters = new List<VariableDefinition>();
                // For each parameter we see, we want to be able to add it to the list of parameters
                // How do we get each individual parameter, though?

                /*for each param_name and param_type that comes from param_decs:
                    add that param_name and param_type to the list as analysis tuple
                    newFunctionDefinition.parameters.Add(param_name, param_type);*/

                // Adds the Function!
                globalSymbolTable.Add(node.GetId().Text, newFunctionDefinition);
            }
        }
        public override void OutAFunctionDeclaration(AFunctionDeclaration node)
        {
            // Wipes out the local symbol table so that the next function doesn't have to deal with it
            localSymbolTable = new Dictionary<string, Definition>();
        }

        // --------------------------------------------------------------
        // FUNCTION CALL
        // --------------------------------------------------------------
        public override void OutAFunctionCallStatement(AFunctionCallStatement node)
        {
            Definition idDef;

            if (!globalSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "ID " + node.GetId().Text + " not found");
            }
            else if (!(idDef is FunctionDefinition))
            {
                PrintWarning(node.GetId(), "ID " + node.GetId().Text + " is not a function");
            }

            // TODO:  Verify parameters are in the correct order, and are of the correct type
            // HINT:  You can use a class variable to "build" a list of the parameters as
            //        you discover them!
        }

        public override void OutAParameter(AParameter node)
        {
            Definition expressionDef;

            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (!(expressionDef is NumberDefinition) || !(expressionDef is StringDefinition))
            {
                Console.WriteLine("Invalid Parameter: " + expressionDef);
            }
        }

        // --------------------------------------------------------------
        // Constant STATEMENT
        // --------------------------------------------------------------
        public override void OutACosntantStatement(AConstantStatement node)
        {
            Definition typeDef;
            Definition idDef;

            if (!globalSymbolTable.TryGetValue(node.GetType().Text, out typeDef))
            {
                // If the type doesn't exist, throw an error
                PrintWarning(node.GetType(), "Type " + node.GetType().Text + " does not exist");
            }
            else if (globalSymbolTable.TryGetValue(node.GetVarname().Text, out idDef))
            {
                // If the id exists, then we can't declare something with the same name
                PrintWarning(node.GetVarname(), "ID " + node.GetVarname().Text
                    + " has already been declared");
            }
            else
            {
                // Add the id to the symbol table
                ConstantDefinition newConstantDefinition = new ConstantDefinition();
                newConstantDefinition.name = node.GetVarname().Text;
                newConstantDefinition.constantType = (TypeDefinition)typeDef;

                globalSymbolTable.Add(node.GetVarname().Text, newConstantDefinition);
            }
        }
    }
}

