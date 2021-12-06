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
        // Set up the output StreamWriter
        private StreamWriter _output;

        private string var;
        private int j = 0;



        // Create the Code Generator
        public CodeGenerator()
        {
            _output = new StreamWriter("program.il");
        }

        int ifCounter = 0;

        int whileCounter = 0;

        // Create a method to write something to the output stream
        private void Write(String textToWrite)
        {
            Console.Write(textToWrite);
            _output.Write(textToWrite);
        }

        // Create the method to write a line to the output stream
        private void WriteLine(String textToWrite)
        {
            Console.WriteLine(textToWrite);
            _output.WriteLine(textToWrite);
        }

        // Do this at the beginning of EVERY program
        public override void InAProgram(AProgram node)
        {
            WriteLine(".assembly extern mscorlib {}");
            WriteLine(".assembly myprogram");
            WriteLine("{\n\t.ver 1:0:1:0\n}\n");
        }

        // Do this at the END of every program
        public override void OutAProgram(AProgram node)
        {
            _output.Close();
        }

        // Do this at the beginning of main
        public override void InAMainMainFunction(AMainMainFunction node)
        {
            WriteLine(".method static void main() cil managed");
            WriteLine("{");
            WriteLine("\t.maxstack 128");
            WriteLine("\t.entrypoint\n");
        }

        // Do this at the end of main
        public override void OutAMainMainFunction(AMainMainFunction node)
        {
            WriteLine("\n\tret");
            WriteLine("}");
        }

        // Do this for each declare statement
        public override void OutADeclareStatement(ADeclareStatement node)
        {
            WriteLine("\t// Declaring Variable " + node.GetVarname().Text);

            Write("\t.locals init (");

            // Check for int, float, or string!
            if (node.GetType().Text == "int")
            {
                Write("int32 ");
            }
            else if (node.GetType().Text == "float")
            {
                Write("float32 "); // Changed from float to float32
            }
            else
            {
                Write("string "); // We only support int32, float32 and string
            }

            Write(node.GetVarname().Text);

            WriteLine(")\n");
        }

        // Do this for each int32 that we create
        public override void OutAIntexpOperand(AIntexpOperand node)
        {
            WriteLine("\tldc.i4 " + node.GetInt().Text);
        }

        public override void OutAFloatexpOperand(AFloatexpOperand node)
        {
            WriteLine("\tldc.r8 " + node.GetFloat().Text);
        }

        public override void OutAStringexpOperand(AStringexpOperand node)
        {
            WriteLine("\tldstr " + node.GetString().Text);
        }

        public override void OutAVariableOperand(AVariableOperand node)
        {
            WriteLine("\tldloc " + node.GetId().Text);
        }

        public override void OutAGreaterexpExpression4(AGreaterexpExpression4 node)
        {
            var = ">";
            WriteLine("\tcgt");

        }

        public override void OutALessexpExpression4(ALessexpExpression4 node)

        {
            var = "<";
            WriteLine("\tclt");
        }

        public override void OutAEqualexpExpression3(AEqualexpExpression3 node)
        {
            var = "==";
            WriteLine("\tceq");
        }

        public override void OutAGreaterequalexpExpression3(AGreaterequalexpExpression3 node)
        {
            var = ">=";
            
        }

        public override void OutALessequalexpExpression3(ALessequalexpExpression3 node)
        {
            var = "<=";
        }

        public override void OutANotequalexpExpression3(ANotequalexpExpression3 node)
        {
            var = "!=";


        }

        public override void OutAAssignStatement(AAssignStatement node)
        {
            // TO DO < PUT VALUE ON TOP OF STACK >

            // if 

            WriteLine("\n\tstloc " + node.GetId().Text + "\n");
        }

        public override void OutAAddexpExpression5(AAddexpExpression5 node)
        {
            WriteLine("\tadd");
        }

        public override void OutASubtractexpExpression5(ASubtractexpExpression5 node)
        {
            WriteLine("\tsub");
        }

        public override void OutAMultexpExpression6(AMultexpExpression6 node)
        {
            WriteLine("\tmul");
        }

        public override void OutADivexpExpression6(ADivexpExpression6 node)
        {
            WriteLine("\tdiv");
        }

        public override void OutANegateexpExpression7(ANegateexpExpression7 node)
        {
            WriteLine("\tneg");
        }

        public override void OutAAndexpExpression2(AAndexpExpression2 node)
        {
            WriteLine("\tand");
        }

        public override void OutAOrexpExpression(AOrexpExpression node)
        {
            WriteLine("\tor");
        }

        public override void OutANotexpExpression7(ANotexpExpression7 node)
        {
            WriteLine("\tbrzero LABEL_TRUE" + ifCounter);
            //WriteLine("\tnot");
            
        }


        public override void OutAFunctionCallStatement(AFunctionCallStatement node)
        {
            if (node.GetId().Text == "printInt")
            {
                WriteLine("\tcall void [mscorlib]System.Console::Write(int32)");
            }
            else if (node.GetId().Text == "printFloat")
            {
                WriteLine("\tcall void [mscorlib]System.Console::Write(float32)");
            }
            else if (node.GetId().Text == "printString")
            {
                WriteLine("\tcall void [mscorlib]System.Console::Write(string)");
            }
            // elif (node.GetId().Text == "print")   check if param is string if so print it!
            else if (node.GetId().Text == "print")
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


        public override void InAFunctionDeclaration(AFunctionDeclaration node)
        {
            WriteLine(".method static void " + node.GetId().Text + "() cil managed");
            WriteLine("{");
            WriteLine("\t.maxstack 128\n");
        }

        public override void OutAFunctionDeclaration(AFunctionDeclaration node)
        {
            WriteLine("\tret");
            WriteLine("}\n");
        }

        public override void CaseAIfStatement(AIfStatement node)
        {
            InAIfStatement(node);

            ifCounter += 1;

            if (node.GetIf() != null)
            {
                node.GetIf().Apply(this);
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
            
           
            
            if (var == ">")
            {
                //WriteLine("\t LABEL_TRUE" + ifCounter);
                WriteLine("\tldc.i4 1");
                WriteLine("\tbeq LABEL_TRUE" + ifCounter);

            }
            else if(var == "<") {
                //WriteLine("\tblt LABEL_TRUE" + ifCounter);
                WriteLine("\tldc.i4 1");
                WriteLine("\tbeq LABEL_TRUE" + ifCounter);
            }
            else if(var == "==")
            {
                //WriteLine("\tbeq LABEL_TRUE" + ifCounter);
                WriteLine("\tldc.i4 1");
                WriteLine("\tbeq LABEL_TRUE" + ifCounter);
            }
            else if(var == ">=")
            {
                WriteLine("\tbge LABEL_TRUE" + ifCounter);
            }
            else if(var == "<=")
            {
                WriteLine("\tble LABEL_TRUE" + ifCounter);
            }
            else if(var == "!=")
            {
                WriteLine("\tbne.un LABEL_TRUE" + ifCounter);
            }
            else
            {
                WriteLine("\tldc.i4 1");
                WriteLine("\tbeq LABEL_TRUE" + ifCounter);
            }
            WriteLine("\t\tldc.i4 0");
            WriteLine("\tbr LABEL_CONTINUE" + ifCounter);
            WriteLine("\tLABEL_TRUE" + ifCounter + ":");
            WriteLine("\t\tldc.i4 1");
            WriteLine("\tLABEL_CONTINUE" + ifCounter +":");

            if (node.GetRightParenthesis() != null)
            {
                node.GetRightParenthesis().Apply(this);
            }
            if (node.GetLeft1() != null)
            {
                node.GetLeft1().Apply(this);
            }

            // This is where we do the if statment
            // Note:  Toy Language does not support else
            //        and it will not work for more than
            //        a single IF throughout the program
            WriteLine("\n\t// IF TRUE CODE GOES HERE");
            WriteLine("\tbrtrue LABEL_1" + ifCounter);
            WriteLine("\tbr LABEL_2" + ifCounter);
            WriteLine("\tLABEL_1" + ifCounter +":");

            if (node.GetStat1() != null)
            {
                node.GetStat1().Apply(this);
            }
            if (node.GetRight1() != null)
            {
                node.GetRight1().Apply(this);
            }

            WriteLine("\tbr LABEL_3" + ifCounter);

            WriteLine("\tLABEL_2" + ifCounter + ":");

            WriteLine("\tLABEL_3" + ifCounter + ":");
            //WriteLine("\tcall void [mscorlib]System.Console::Write(int32)");
            //WriteLine("\tcall void [mscorlib]System.Console::Write(int32)");
            
        }

        public override void CaseAElseIfStatement(AElseIfStatement node)
        {
            
            InAElseIfStatement(node);

            ifCounter += 1;

            if (node.GetIf() != null)
            {
                node.GetIf().Apply(this);
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
            if (var == ">")
            {
                //WriteLine("\t LABEL_TRUE" + ifCounter);
                WriteLine("\tldc.i4 1");
                WriteLine("\tbeq LABEL_TRUE" + ifCounter);

            }
            else if (var == "<")
            {
                //WriteLine("\tblt LABEL_TRUE" + ifCounter);
                WriteLine("\tldc.i4 1");
                WriteLine("\tbeq LABEL_TRUE" + ifCounter);
            }
            else if (var == "==")
            {
                //WriteLine("\tbeq LABEL_TRUE" + ifCounter);
                WriteLine("\tldc.i4 1");
                WriteLine("\tbeq LABEL_TRUE" + ifCounter);
            }
        
            else if (var == ">=")
            {
                WriteLine("\tbge LABEL_TRUE" + ifCounter);
            }
            else if (var == "<=")
            {
                WriteLine("\tble LABEL_TRUE" + ifCounter);
            }
            else if (var == "!=")
            {
                WriteLine("\tbne.un LABEL_TRUE" + ifCounter);
            }
            else
            {
                WriteLine("\tldc.i4 1");
                WriteLine("\tbeq LABEL_TRUE" + ifCounter);
            }
            WriteLine("\t\tldc.i4 0");
            WriteLine("\tbr LABEL_CONTINUE" + ifCounter);
            WriteLine("\tLABEL_TRUE" + ifCounter + ":");
            WriteLine("\t\tldc.i4 1");
            WriteLine("\tLABEL_CONTINUE" + ifCounter + ":");

            if (node.GetRightParenthesis() != null)
            {
                node.GetRightParenthesis().Apply(this);
            }
            if (node.GetLeft1() != null)
            {
                node.GetLeft1().Apply(this);
            }

            // This is where we do the if statment
            // Note:  Toy Language does not support else
            //        and it will not work for more than
            //        a single IF throughout the program
            WriteLine("\n\t// IF TRUE CODE GOES HERE");
            WriteLine("\tbrtrue LABEL_1" + ifCounter);
            WriteLine("\tbr LABEL_2" + ifCounter);
            WriteLine("\tLABEL_1" + ifCounter + ":");

            if (node.GetStat1() != null)
            {
                node.GetStat1().Apply(this);
            }
            if (node.GetRight1() != null)
            {
                node.GetRight1().Apply(this);
            }

            WriteLine("\tbr LABEL_3" + ifCounter);

            WriteLine("\tLABEL_2" + ifCounter + ":");

            if (node.GetStat1() != null)
            {
                //node.GetStat1().Apply(this);
            }
            if (node.GetRight1() != null)
            {
                node.GetRight1().Apply(this);
            }
            if (node.GetElse() != null)
            {
                node.GetElse().Apply(this);
            }
            if (node.GetLeft2() != null)
            {
                node.GetLeft2().Apply(this);
            }
            if (node.GetStat2() != null)
            {
                node.GetStat2().Apply(this);
            }
            if (node.GetRight2() != null)
            {
                node.GetRight2().Apply(this);
            }

            WriteLine("\tLABEL_3" + ifCounter + ":");
            //WriteLine("\tcall void [mscorlib]System.Console::Write(int32)");
            //WriteLine("\tcall void [mscorlib]System.Console::Write(int32)");

        }

        public override void CaseAWhileStatement(AWhileStatement node)
        {
            
            InAWhileStatement(node);
            whileCounter += 1;
            j += 1;

            WriteLine("\tLABEL_START" + whileCounter + ":");

            if (node.GetWhile() != null)
            {
                node.GetWhile().Apply(this);
            }
            if (node.GetLeftParenthesis() != null)
            {
                node.GetLeftParenthesis().Apply(this);
            }
            if (node.GetExpression() != null)
            {
                node.GetExpression().Apply(this);
            }

            
            if (var == ">")
            {
                //whileCounter += 1;
                //WriteLine("\t LABEL_TRUE" + ifCounter);
                WriteLine("\tldc.i4 1");
                WriteLine("\tbeq LABEL_TRUEw" + whileCounter);
                WriteLine("\tbr LABEL_FALSE" + whileCounter);
            }
            else if (var == "<")
            {
                //whileCounter += 1;
                //WriteLine("\tblt LABEL_TRUE" + ifCounter);
                WriteLine("\tldc.i4 1");
                WriteLine("\tbeq LABEL_TRUEw" + whileCounter);
                WriteLine("\tbr LABEL_FALSE" + whileCounter);
            }
            else if (var == "==")
            {
                //whileCounter += 1;
                //WriteLine("\tbeq LABEL_TRUE" + ifCounter);
                WriteLine("\tldc.i4 1");
                WriteLine("\tbeq LABEL_TRUEw" + whileCounter);
                WriteLine("\tbr LABEL_FALSE" + whileCounter);
            }
            else if (var == ">=")
            {
                WriteLine("\tbge LABEL_TRUEw" + whileCounter);
                WriteLine("\tbr LABEL_FALSE" + whileCounter);
            }
            else if (var == "<=")
            {
                WriteLine("\tble LABEL_TRUEw" + whileCounter);
                WriteLine("\tbr LABEL_FALSE" + whileCounter);
            }
            else if (var == "!=")
            {
                WriteLine("\tbne.un LABEL_TRUEw" + whileCounter);
                WriteLine("\tbr LABEL_FALSE" + whileCounter);
            }

            //WriteLine("\t\tldc.i4 0");
            //WriteLine("\tbr LABEL_CONTINUEw" + whileCounter);
            WriteLine("\tLABEL_TRUEw" + whileCounter + ":");
            //WriteLine("\t\tldc.i4 1");
            //WriteLine("\tLABEL_CONTINUEw" + whileCounter + ":");
            if (node.GetRightParenthesis() != null)
            {
                node.GetRightParenthesis().Apply(this);
            }
            if (node.GetLeftCurly() != null)
            {
                node.GetLeftCurly().Apply(this);
            }
            if (node.GetStatements() != null)
            {
                node.GetStatements().Apply(this);
            }
            if (node.GetRightCurly() != null)
            {
                node.GetRightCurly().Apply(this);
            }

            if (j >= 2)
            {
                WriteLine("\tbr LABEL_START" + (whileCounter));

                WriteLine("\tLABEL_FALSE" + (whileCounter) + ":");
                j -= 1;
            }
            else if (whileCounter == 1)
            {
                WriteLine("\tbr LABEL_START1");
                WriteLine("\tLABEL_FALSE1:");
            }
            else
            {
                
                WriteLine("\tbr LABEL_START" + (whileCounter - 1));
                WriteLine("\tLABEL_FALSE" + (whileCounter - 1 ) + ":");
                
            }

            


        }
    }
}
    

    
    

