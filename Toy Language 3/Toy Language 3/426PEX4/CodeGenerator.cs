using CS426.node;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CS426.analysis
{
    class CodeGenerator : DepthFirstAdapter
    {
        private StreamWriter _output;

        public CodeGenerator()
        {
            _output = new StreamWriter("program.il");
        }

        private void Write(String textToWrite)
        {
            Console.Write(textToWrite);
            _output.Write(textToWrite);
        }

        private void WriteLine(String textToWrite)
        {
            Console.WriteLine(textToWrite);
            _output.WriteLine(textToWrite);
        }

        public override void InAProgram(AProgram node)
        {
            WriteLine(".assembly extern mscorlib {}");
            WriteLine(".assembly toyprogram");
            WriteLine("{\n\t.ver 1:0:1:0\n}\n");
        }

        public override void OutAProgram(AProgram node)
        {
            _output.Close();
        }

        public override void InAMainfunction(AMainfunction node)
        {
            WriteLine(".method static void main() cil managed");
            WriteLine("{");
            WriteLine("\t.maxstack 128");
            WriteLine("\t.entrypoint\n");
        }

        public override void OutAMainfunction(AMainfunction node)
        {
            WriteLine("\n\tret");
            WriteLine("}");
        }

        public override void OutADeclareStatement(ADeclareStatement node)
        {
            WriteLine("\t// Declaring Variable " + node.GetVarname().Text);

            Write("\t.locals init (");

            // TODO Declare the Variable Here
            if (node.GetType().Text == "int")
            {
                Write("int32 ");
            }
            else
            {
                Write(node.GetType().Text + " ");
            }

            Write(node.GetVarname().Text);

            WriteLine(")\n");
        }

        public override void OutAIntOperand(AIntOperand node)
        {
            WriteLine("\tldc.i4 " + node.GetInteger().Text);
        }

        public override void OutAStringOperand(AStringOperand node)
        {
            WriteLine("\tldstr " + node.GetString().Text);
        }

        public override void OutAVariableOperand(AVariableOperand node)
        {
            WriteLine("\tldloc " + node.GetId().Text);
        }

        public override void OutAAssignStatement(AAssignStatement node)
        {
            WriteLine("\tstloc " + node.GetId().Text + "\n");
        }

        public override void OutAAddExpression(AAddExpression node)
        {
            WriteLine("\tadd");
        }

        public override void OutAMultiplyExpression2(AMultiplyExpression2 node)
        {
            WriteLine("\tmul");
        }

        public override void OutANegativeExpression3(ANegativeExpression3 node)
        {
            WriteLine("\tneg");
        }

        public override void OutAFunctionCallStatement(AFunctionCallStatement node)
        {
            if (node.GetId().Text == "printInt")
            {
                WriteLine("\tcall void [mscorlib]System.Console::Write(int32)");
            }
            else if (node.GetId().Text == "printString")
            {
                WriteLine("\tcall void [mscorlib]System.Console::Write(string)");
            }
            else if (node.GetId().Text == "printLine")
            {
                WriteLine("\tldstr \"\\n\"");
                WriteLine("\tcall void [mscorlib]System.Console::Write(string)");
            }
            else
            {
                WriteLine("\tcall void " + node.GetId().Text + "()");
            }

            WriteLine("");
        }


        public override void InASingleSubfunction(ASingleSubfunction node)
        {
            WriteLine(".method static void " + node.GetId().Text + "() cil managed");
            WriteLine("{");
            WriteLine("\t.maxstack 128\n");
        }

        public override void OutASingleSubfunction(ASingleSubfunction node)
        {
            WriteLine("\tret");
            WriteLine("}\n");
        }

        public override void CaseAIfOneStatement(AIfOneStatement node)
        {
            InAIfOneStatement(node);

            if (node.GetKeywordIf() != null)
            {
                node.GetKeywordIf().Apply(this);
            }
            if (node.GetLeftParenthesis() != null)
            {
                node.GetLeftParenthesis().Apply(this);
            }
            if (node.GetExpression() != null)
            {
                node.GetExpression().Apply(this);
            }

            // We are going compare whatever is on the stack to a 1
            // If it is 1, we're going to put a 1 on the stack, else a 0
            WriteLine("\tldc.i4 1");
            WriteLine("\tbeq LABEL_TRUE");
            WriteLine("\t\tldc.i4 0");
            WriteLine("\tbr LABEL_CONTINUE");
            WriteLine("\tLABEL_TRUE:");
            WriteLine("\t\tldc.i4 1");
            WriteLine("\tLABEL_CONTINUE:");

            if (node.GetRightParenthesis() != null)
            {
                node.GetRightParenthesis().Apply(this);
            }
            if (node.GetLeftCurly() != null)
            {
                node.GetLeftCurly().Apply(this);
            }

            // This is where we do the if statment
            // Note:  Toy Language does not support else
            //        and it will not work for more than
            //        a single IF throughout the program
            WriteLine("\n\t// IF TRUE CODE GOES HERE");
            WriteLine("\tbrtrue LABEL_1");
            WriteLine("\tbr LABEL_2");
            WriteLine("\tLABEL_1:");

            if (node.GetStatements() != null)
            {
                node.GetStatements().Apply(this);
            }
            if (node.GetRightCurly() != null)
            {
                node.GetRightCurly().Apply(this);
            }

            WriteLine("\tLABEL_2:");

            OutAIfOneStatement(node);
        }
    }
}
